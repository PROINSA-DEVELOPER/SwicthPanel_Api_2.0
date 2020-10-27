using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Collections;
//using InputKey;

using Symbol.RFID3;
using NLog;

namespace EASY_PASS_SWITCH_PANEL
{
    public partial class TESTING_READER : Form
    {

        //////////////////////////////////////////////////////////////////

        DATA_BASE.CONFIGURACION consulta = new DATA_BASE.CONFIGURACION();
        SERVICIOS.BITACORA bitacora = new SERVICIOS.BITACORA();

        //////////////////////////////////////////////////////////////////


        public TESTING_READER()
        {
            InitializeComponent();
        }

        private void Reader_Testing_Load(object sender, EventArgs e)
        {
            //CARGAR PORTALES
            CONFIGURACION_CARGAR_PORTALES();

            //DELETE TEST READS
            bitacora.DELETE_TEST_READS();
            GV_TEST.DataSource = null;


        }


        ///variables
        public RFIDReader RFID_READER;
        private UpdateRead m_UpdateReadHandler = null;
        Symbol.RFID3.AntennaInfo AntenaInfo;
        ArrayList TagsAlmacenados = new ArrayList();
        ArrayList blacklist = new ArrayList();
        Boolean m_IsConnected;
        private delegate void UpdateRead(Events.ReadEventData eventData);
        int TiempoEsperaEscribirLectura = 0;

        Thread READER = null;
        Thread ULTIMA_LECTURA = null;
        Thread CONEXION = null;
        Thread HILO_LIMPIEZA_TAGS = null;









        /// <summary>
        /// PORTALES ACTUALES
        /// </summary>
        public void CONFIGURACION_CARGAR_PORTALES()
        {
            DataTable DT = new DataTable();

            DT = consulta.GET_PORTALES();

            CMB_PORTAL.DisplayMember = "NOMBRE_PORTAL";
            CMB_PORTAL.ValueMember = "ID_PORTAL";
            CMB_PORTAL.DataSource = DT;
        }





        //////////////////////////////////////////////


        #region EVENTOS BUTTONS


        /// <summary>
        /// BTN START
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            /////////////////////////////////////////////////////////
            //                      VARIABLES                      //
            /////////////////////////////////////////////////////////

            //ID PORTAL
            int ID_PORTAL = Convert.ToInt32(CMB_PORTAL.SelectedValue);

            LBL_ID_PORTAL.Text = ID_PORTAL.ToString();


            /////////////////////////////////////////////////////////
            //           DESCONECTAR  PORTAL Y SU LECTURA          //
            /////////////////////////////////////////////////////////
            DETENER_PORTAL(ID_PORTAL);

            /////////////////////////////////////////////////////////
            //               INICIAR  PORTAL Y SU LECTURA          //
            /////////////////////////////////////////////////////////
            //servicio.INICIAR_PORTAL(ID_PORTAL);
            INICIAR_PORTAL(ID_PORTAL);




        }

        /// <summary>
        /// BTN STOP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_STOP_Click(object sender, EventArgs e)
        {
            try
            {
                //DELETE TEST READS
                bitacora.DELETE_TEST_READS();
                GV_TEST.DataSource = null;

                DETENER_PORTAL(Convert.ToInt32(LBL_ID_PORTAL.Text));

                //RADIO BUTTON
                RB_ONLINE.Enabled = false;
                RB_OFFLINE.Enabled = true;
                RB_OFFLINE.ForeColor = Color.Red;
                RB_OFFLINE.Checked = true;
            }
            catch (Exception)
            {

            }

        }

        #endregion


        //////////////////////////////////////////////


        #region INICIAR / DETNER PORTAL

        /// <summary>
        /// METODO QUE INICIA O DETIENE LA CONEXION DEL READER
        /// </summary>
        /// <param name="ID_PORTAL"></param>
        private void INICIAR_PORTAL(int ID_PORTAL)
        {
            //INICIAR EL READER SEGUN SU PORTAL
            READER = new Thread(() => INICIAR_LECTOR(ID_PORTAL));
            READER.Start();

            //DETENEMOS EL PROCESO , MIENTRAS LO SUBPROCESOS TERMINAN Y ASI OBTENEMOS EL ESTADO DEL READER (m_IsConnected)
            Thread.Sleep(4000);
            if (m_IsConnected == true)
            {
                //RADIO BUTTON
                RB_OFFLINE.Enabled = false;
                RB_ONLINE.Enabled = true;
                RB_ONLINE.ForeColor = Color.Green;
                RB_ONLINE.Checked = true;
            }
        }

        /// <summary>
        /// METODO QUE DESCONECTA LA CONEXION DEL READER
        /// </summary>
        /// <returns></returns>
        private int DETENER_PORTAL(int ID_PORTAL)
        {
            try
            {
                //INOCAR CLASE CONSULTAS
                DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();
                //APLICAR PROCESO
                bool Respuesta = PORTAL.UPDATE_ESTADO_PORTAL(ID_PORTAL, false);

                //DESCONECTAR LECTOR
                DESCONECTAR_LECTOR(ID_PORTAL);

                return 1;
            }
            catch (Exception)
            {
                return 0;
            }

        }


        #endregion


        //////////////////////////////////////////////


        #region INICIAR / DETNER LECTOR

        /// <summary>
        /// INICIAR LECTOR
        /// </summary>
        public void INICIAR_LECTOR(int ID_PORTAL)
        {
            //PORTAL
            DATA_BASE.CONSULTAS portal = new DATA_BASE.CONSULTAS();
            //CONSUMIR CONSULTA
            DataTable dt = portal.CONSULTAR_ESTADO_PORTAL(ID_PORTAL);
            //ASIGNAR AL DATAROW Y ASI SELECCIONAR EL CAMPO A CONSULTAR
            DataRow dr = dt.Rows[0];

            //VARIABLES
            string IP_LECTOR = dr["IP_LECTOR"].ToString();

            try
            {
                //////////////////////////////////////////////////////////////////////////////////////////
                //INICIAR LECTOR
                bool ESTADO_CONEXION = CONECTAR_READER(IP_LECTOR, 0, 0, ID_PORTAL);


                if (ESTADO_CONEXION == true)
                {
                    //INICIAR REGISTRO DE LECTURAS
                    INICIAR_EVENTO_LECTURA(ID_PORTAL);
                    //
                    ////INICIAR LECTURA
                    INICIAR_LECTURA(ID_PORTAL);
                    //
                    ////EJECUTAR SUBPROCESO 1
                    HILO_LIMPIEZA_TAGS = new Thread(CLEAR_ARRAY);
                    HILO_LIMPIEZA_TAGS.Start();
                    //
                    ////EJECUTAR SUBPROCESO 2
                    ULTIMA_LECTURA = new Thread(TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO);
                    ULTIMA_LECTURA.Start();
                    //
                    ////EJECUTAR SUBPROCESO 3
                    CONEXION = new Thread(() => COMPROBAR_CONEXION_LECTOR(ID_PORTAL));
                    CONEXION.Start();

                    //INICIAR TIMER
                    TIMER_TEST.Enabled = true;


                }

                if (ESTADO_CONEXION == false)
                {
                    //DESCONECTAR LECTOR
                    m_IsConnected = false;
                }
            }
            catch (Exception ex)
            {
                //DESCONECTAR LECTOR
                m_IsConnected = false;
            }

        }

        /// <summary>
        /// DETENER LECTOR
        /// </summary>
        /// <param name="ID_PORTAL"></param>
        public void DESCONECTAR_LECTOR(int ID_PORTAL)
        {
            try
            {
                //PORTAL
                DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();

                //ACTUALIZAR ESTADO PORTAL A FALSE
                bool Respuesta = PORTAL.UPDATE_ESTADO_PORTAL(ID_PORTAL, false);


                ///////////////////////////////////////////////////////////////
                //DESCONECTAR LECTOR

                //VALIDAR ESTADO DEL READERS
                if (m_IsConnected)
                {

                    //DESCONECTAR READER
                    RFID_READER.Dispose();

                    //ACTUALIZAMOS SU ESTADO
                    m_IsConnected = false;
                    RFID_READER = null;
                    m_UpdateReadHandler = null;

                    //TERMINAR SUBPROCESOS
                    HILO_LIMPIEZA_TAGS.Abort();
                    ULTIMA_LECTURA.Abort();
                    CONEXION.Abort();
                }
                else
                {
                    if (RFID_READER != null)
                    {
                        RFID_READER.Disconnect();
                    }

                    //ACTUALIZAMOS SU ESTADO
                    m_IsConnected = false;
                    RFID_READER = null;
                    m_UpdateReadHandler = null;

                    //TERMINAR SUBPROCESOS
                    //HILO_LIMPIEZA_TAGS.Abort();
                    //ULTIMA_LECTURA.Abort();

                }
            }
            catch (Exception ex)
            {
                string MENSJAE = ex.Message + "  Close";
            }
        }

        #endregion


        //////////////////////////////////////////////

        #region METODOS READER

        /// <summary>
        /// INICIAR EVENTO LECTURA
        /// </summary>
        /// <param name="ID_PORTAL"></param>
        private void INICIAR_EVENTO_LECTURA(int ID_PORTAL)
        {
            m_UpdateReadHandler = new UpdateRead(REGISTRO_LECTURAS_READER);
        }

        /// <summary>
        /// EVENTO LECTURAS DE ANTENAS
        /// </summary>
        /// <param name="eventData"></param>
        private void REGISTRO_LECTURAS_READER(Events.ReadEventData eventData)
        {
            //VARIABLES
            int ID_PORTAL = Convert.ToInt32(LBL_ID_PORTAL.Text);

            try
            {
                if (m_IsConnected == true)
                {
                    Symbol.RFID3.TagData[] tagData = RFID_READER.Actions.GetReadTags(1000);

                    if (tagData != null)
                    {
                        if (eventData != null)
                        {
                            if (tagData[0].TagID.Length <= 24)
                            {
                                //////////////////////
                                //ESCRIBIR ACHIVO [ULTIMA LECTURA]
                                //WRITE_ULTIMA_LECTURA();

                                //////////////////////
                                //VALIDAR SI EL ARCHIVO BLACKLIST.TXT TIENE CONTENIDO
                                //if (!blacklist.Contains(tagData[0].TagID))
                                //{
                                    if (!TagsAlmacenados.Contains(tagData[0].TagID))
                                    {

                                        //////////////////////
                                        //INSERTAR A BITACORA
                                        bitacora.INSERTAR_ENTRADA_SALIDA_TEST(tagData, RFID_READER.HostName);

                                        TagsAlmacenados.Add(tagData[0].TagID);

                                    }
                                //}
                            }
                        }
                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
            }

        }

        /// <summary>
        /// WRITE ULTIMA LECTURA
        /// </summary>
        private void WRITE_ULTIMA_LECTURA()
        {
            if (TiempoEsperaEscribirLectura > 0)
            {
                try
                {
                    //Siempre se va a guardar la ultima lectura y solamente eso
                    StreamWriter sw = new StreamWriter("UltimaLectura_Portal_2.txt");

                    sw.WriteLine(DateTime.Now);

                    sw.Close();

                    TiempoEsperaEscribirLectura = 0;
                }
                catch (Exception ex)
                {
                    //Log.Instance.ErrorException(ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// INICIAR LECTURA
        /// </summary>
        /// <param name="ID_PORTAL"></param>
        private void INICIAR_LECTURA(int ID_PORTAL)
        {
            //INICIALIZAR ANTENAS
            INICIAR_ANTENENAS(ID_PORTAL);

            try
            {
                if (RFID_READER.Actions.TagAccess.OperationSequence.Length > 0)
                {
                    RFID_READER.Actions.TagAccess.OperationSequence.PerformSequence(null, null, AntenaInfo);
                }
                else
                {
                    RFID_READER.Actions.Inventory.Perform(null, null, AntenaInfo);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// INICIAR ANTENNAS
        /// </summary>
        /// <param name="ID_PORTAL"></param>
        private void INICIAR_ANTENENAS(int ID_PORTAL)
        {
            try
            {
                //VARIABLES
                int numAtenna = RFID_READER.Config.Antennas.AvailableAntennas.Length;

                ushort[] antList = new ushort[numAtenna];

                for (int index = 1; index <= numAtenna; index++)
                {
                    antList[index - 1] = ushort.Parse(index.ToString());
                }

                if (null == AntenaInfo)
                {
                    AntenaInfo = new Symbol.RFID3.AntennaInfo(antList);
                }
                else
                {
                    AntenaInfo.AntennaID = antList;
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// LIMPIAR ARREGLO
        /// </summary>
        private void CLEAR_ARRAY()
        {
            while (true)
            {
                Thread.Sleep(2000);
                TagsAlmacenados.Clear();
            }
        }

        /// <summary>
        /// TIMEPO ESPERA | ESCRITURA DE ARCHIVO
        /// </summary>
        public void TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO()
        {
            while (true)
            {
                try
                {
                    Thread.Sleep(Convert.ToInt32(Properties.Settings.Default.UltimaLectura));
                    TiempoEsperaEscribirLectura++;
                }
                catch (Exception ex)
                {
                }
            }
        }

        /// <summary>
        /// COMPROBAR CONEXION DE LECTOR
        /// </summary>
        /// <param name="ID_PORTAL"></param>
        public void COMPROBAR_CONEXION_LECTOR(int ID_PORTAL)
        {
            //INVOCAR CLASES
            DATA_BASE.CONSULTAS portal = new DATA_BASE.CONSULTAS();
            SERVICIOS.ENVIO_CORREO correo = new SERVICIOS.ENVIO_CORREO();

            //CONSUMIR CONSULTA
            DataTable dt = portal.CONSULTAR_ESTADO_PORTAL(ID_PORTAL);
            //ASIGNAR AL DATAROW Y ASI SELECCIONAR EL CAMPO A CONSULTAR
            DataRow dr = dt.Rows[0];

            //VARIABLES
            string IP_LECTOR = dr["IP_LECTOR"].ToString();
            bool FLAG = true;

            while (FLAG == true)
            {
                //VARIABLES
                string IP_HOSTNAME = IP_LECTOR;
                Thread.Sleep(1000);


                if (RFID_READER != null)
                {
                    //SI EL LECTOR ESTA DESCONECTADO
                    if (RFID_READER.IsConnected == false)
                    {
                        try
                        {
                            //DESCONECTAR LECTOR
                            DESCONECTAR_LECTOR(ID_PORTAL);

                            //INVOCAR CLASE CONSULTAS
                            DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();

                            //ESTADO PORTAL FALSE
                            bool Respuesta = PORTAL.UPDATE_ESTADO_PORTAL(ID_PORTAL, false);

                            //FLAG FALSE
                            FLAG = false;
                        }
                        catch (Exception ex)
                        {

                        }

                    }
                }

            }

        }

        /// <summary>
        /// CONECTAR READER
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="tagCB"></param>
        /// <param name="eventCB"></param>
        /// <param name="ID_PORTAL"></param>
        /// <returns></returns>
        private bool CONECTAR_READER(string hostname, int tagCB, int eventCB, int ID_PORTAL)
        {
            bool Conexion = false;


            ///////////////////////
            //VALIDAR SI EL RFID READER ESTA CONECTADO
            if (m_IsConnected != true)
            {
                /////////////////////
                //PARAMETROS
                string IP_READER = hostname;
                uint PUERTO = uint.Parse("5084");

                //---------------------------------------------------------------------------------------
                RFID_READER = new RFIDReader(IP_READER, PUERTO, 0);

                try
                {
                    RFID_READER.Connect();
                    m_IsConnected = true;

                    //REGISTRO DE EVENTOS
                    RFID_READER.Actions.PreFilters.DeleteAll();
                    RFID_READER.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify_Reader);
                    RFID_READER.Events.AttachTagDataWithReadEvent = false;
                    RFID_READER.Events.NotifyGPIEvent = true;
                    RFID_READER.Events.NotifyAntennaEvent = true;
                    RFID_READER.Events.NotifyReaderDisconnectEvent = true;
                    RFID_READER.Events.NotifyBufferFullEvent = true;
                    RFID_READER.Events.NotifyBufferFullWarningEvent = true;
                    RFID_READER.Events.NotifyAccessStartEvent = true;
                    RFID_READER.Events.NotifyAccessStopEvent = true;
                    RFID_READER.Events.NotifyInventoryStartEvent = true;
                    RFID_READER.Events.NotifyInventoryStopEvent = true;
                    RFID_READER.Events.NotifyReaderExceptionEvent = true;

                    Conexion = true;

                }
                catch (Exception ex)
                {
                    m_IsConnected = false;
                    return Conexion;
                }

                return Conexion;
            }
            else
            {
                Conexion = true;

                return Conexion;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="readEventArgs"></param>
        private void Events_ReadNotify_Reader(object sender, Events.ReadEventArgs readEventArgs)
        {
            try
            {
                m_UpdateReadHandler(readEventArgs.ReadEventData);
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CMB_PORTAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID_PORTAL = Convert.ToInt32(CMB_PORTAL.SelectedValue);

            LBL_ID_PORTAL.Text = ID_PORTAL.ToString();
        }


        #endregion

        /// <summary>
        /// TIMER TEST
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TIMER_TEST_Tick(object sender, EventArgs e)
        {
            try
            {
                DataTable DT = bitacora.CARGAR_TEST_READS();


                if (DT.Rows.Count != 0)
                {
                    //CARGAR DATOS EN EL GRIDVIEW
                    GV_TEST.DataSource = DT;

                    //PERSONALIZAR COLUMNAS
                    GV_TEST.Columns[0].Width = 300;
                    GV_TEST.Columns[1].Width = 80;
                    GV_TEST.Columns[2].Visible = false;
                    GV_TEST.Columns[4].Width = 50;

                    //ELLIMINAR SELECCION
                    GV_TEST.SelectedRows[0].Selected = false;

                    //DESHABILITAR ORDENACION 
                    foreach (DataGridViewColumn Col in GV_TEST.Columns)
                    {
                        Col.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }


                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// FORM CLOSED EVENT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Reader_Testing_FormClosed(object sender, FormClosedEventArgs e)
        {
            //DETENER TIMER
            TIMER_TEST.Enabled = false;
        }

    }
}
