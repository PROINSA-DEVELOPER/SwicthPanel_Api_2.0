using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Collections;

namespace EASY_PASS_SWITCH_PANEL.FORMS.CONFIGURACION
{
    public partial class CONFIGURACION_GENERAL : Form
    {
        //INSTANCIAR OBJETO
        FUNCIONES.ARCHIVOS ARCHIVOS = new FUNCIONES.ARCHIVOS();
        DATA_BASE.CONFIGURACION consulta = new DATA_BASE.CONFIGURACION();
        CLASES.SEGURIDAD seguridad = new CLASES.SEGURIDAD();


        public CONFIGURACION_GENERAL()
        {
            InitializeComponent();

            //CARGAR CONFIGURACION
            CARGAR_CONFIGURACION();

            //CARGAR PORTALES
            CONFIGURACION_CARGAR_PORTALES();

            //CARGAR PORTALES BLACKLIST
            CONFIGURACION_CARGAR_PORTALES_BLACKLIST();

            //CARGAR CONFIGURACION SERVIDOR DE CORREO
            CARGAR_CONFIGURACION_SERVIDOR_CORREO();

            //ESTADO POR DEFAULT = TRUE
            RB_INSERTAR.Checked = true;
        }

        ///////////////////////////////

        #region CONFIGURACION GENERAL

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_GUARDAR_Click_1(object sender, EventArgs e)
        {
            string  TM_SINCRONIZAR   = TXT_SINCRONIZACION.Text ;
            bool    ESTADO_SINCRONIZADOR = CHCK_ESTADO_SINCRONIZADOR.Checked ;
            string  TM_COMPROBACION_READER = TXT_COMPROBACION_READER.Text  ;
            string  PATH = Application.StartupPath.ToString() + "\\Settings\\" ;
            string  PATH_BLACKLIST = Application.StartupPath.ToString() + "\\Settings\\BlackList\\";

            
            //CREAR DIRECTORIO Y ARCHIVO DE CONFIGURACION
            bool respuesta = ARCHIVOS.CREAR_DIRECTORIO_CONFIGURACION(PATH, LBL_CONFIG.Text, TM_SINCRONIZAR, ESTADO_SINCRONIZADOR, TM_COMPROBACION_READER, PATH_BLACKLIST);

            if (respuesta == true)
            {
                DATA_BASE.CONSULTAS CN = new DATA_BASE.CONSULTAS();
                //CN.GUARDAR_PARAMETRO(PATH);


                MessageBox.Show("CAMBIOS APLICADOS CORRECTAMENTE", "CONFIGURACION") ;
            }
        }


        /// <summary>
        /// CARGAR CONFIGURACION DEL SWITCH PANEL
        /// </summary>
        private void CARGAR_CONFIGURACION()
        {
            try
            {
                FUNCIONES.ARCHIVOS File = new FUNCIONES.ARCHIVOS();
                string TIMER_SINCRONIZACION = "";
                string TIMER_COMPROBACION_PORTAL = "";
                string PATH_CONFIG = "";
                string PATH_BLACKLIST = "";
                string STATUS_SINCONIZADOR = ""; 

                //LEER FILE CONFIG
                DataTable DT = File.LEER_ARCHIVO();

                if (DT.Rows.Count > 0)
                {
                    DataRow dr = DT.Rows[0];

                    TIMER_SINCRONIZACION = dr["TM_SINCRONIZAR"].ToString();
                    TIMER_COMPROBACION_PORTAL = dr["TM_COMPROBACION_READER"].ToString();
                    STATUS_SINCONIZADOR = dr["STATUS_SINCRNIZADOR"].ToString();
                    PATH_CONFIG = dr["PATH_CONFIG"].ToString();
                    PATH_BLACKLIST = dr["PATH_BLACKLIST"].ToString();


                    TXT_PADRE.Text = PATH_CONFIG;
                    TXT_BLACKLIST.Text = PATH_BLACKLIST;
                    TXT_SINCRONIZACION.Text = TIMER_SINCRONIZACION;
                    TXT_COMPROBACION_READER.Text = TIMER_COMPROBACION_PORTAL;

                    if (STATUS_SINCONIZADOR == "True")
                    {
                        CHCK_ESTADO_SINCRONIZADOR.Checked = true;
                    }
                    else
                    {
                        CHCK_ESTADO_SINCRONIZADOR.Checked = false;
                    }

                }
                else
                {
                    //RUTA APP 
                    TXT_PADRE.Text = Application.StartupPath.ToString() + "\\Settings\\";

                    TXT_BLACKLIST.Text = Application.StartupPath.ToString() + "\\Settings\\BlackList\\";
                }


            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// CARGAR CONFIGURACION DEL SWITCH PANEL
        /// </summary>
        private void CARGAR_CONFIGURACION_SERVIDOR_CORREO()
        {
            try
            {
                FUNCIONES.ARCHIVOS File = new FUNCIONES.ARCHIVOS();
                string SERVIDOR = "";
                string PUERTO = "";
                string SSL = "";
                string EMAIL_EMISOR = "";
                string PASSWORD_EMISOR = "";

                //LEER FILE CONFIG
                DataTable DT = File.LEER_ARCHIVO_CONFIG_SERVIDOR();

                if (DT.Rows.Count > 0)
                {
                    DataRow dr = DT.Rows[0];

                    SERVIDOR = dr["SERVIDOR"].ToString();
                    PUERTO = dr["PUERTO"].ToString();
                    SSL = dr["SSL"].ToString();
                    EMAIL_EMISOR = dr["EMAIL_EMISOR"].ToString();
                    PASSWORD_EMISOR = dr["PASSWORD_EMISOR"].ToString();

                    TXT_SERVIDOR.Text = SERVIDOR;
                    TXT_PUERTO.Text = PUERTO;
                    TXT_EMAIL_SERVIDOR.Text = EMAIL_EMISOR;
                    TXT_EMAIL_PASSWORD.Text = PASSWORD_EMISOR;

                    if(SSL == "True")
                    {
                        CHKBOX_SSL.Checked = true;
                    }
                    else
                    {
                         CHKBOX_SSL.Checked = false;
                    }

                }
            }
            catch (Exception)
            {

            }
        }

        #endregion

        ///////////////////////////////

        #region CONFIGURACION PORTALES

        #region METODOS CATALOGOS

        /// <summary>
        /// CONSULTA DE PORTALES 
        /// </summary>
        public void CONFIGURACION_CARGAR_PORTALES()
        {
            DataTable DT = new DataTable();

            DT = consulta.GET_PORTALES();

            CMB_PORTAL.DisplayMember = "NOMBRE_PORTAL";
            CMB_PORTAL.ValueMember = "ID_PORTAL";
            CMB_PORTAL.DataSource = DT;
        }


        /// <summary>
        /// CONSULTA DE PORTALES 
        /// </summary>
        public void CONFIGURACION_CARGAR_PORTALES_BLACKLIST()
        {
            DataTable DT = new DataTable();

            DT = consulta.GET_PORTALES();

            CMB_PORTAL_BLACKLIST.DisplayMember = "NOMBRE_PORTAL";
            CMB_PORTAL_BLACKLIST.ValueMember = "ID_PORTAL";
            CMB_PORTAL_BLACKLIST.DataSource = DT;
        }


        /// <summary>
        /// CONSULTA DE PORTALES 
        /// </summary>
        public void CONFIGURACION_CARGAR_MODELOS()
        {
            DataTable DT = new DataTable();

            DT = consulta.GET_CATALOGO_MODELO_READERS("");

            CMB_MODELO.DisplayMember = "MODELO";
            CMB_MODELO.ValueMember = "ID_MODELO";
            CMB_MODELO.DataSource = DT;
        }

        #endregion

        #region EVENTOS

        /// <summary>
        /// BTN | APLICAR CAMBIOS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_GUARDAR_PORTAL_Click(object sender, EventArgs e)
        {
            try
            {
                //PARAMETROS
                DATA_BASE.CONFIGURACION portal = new DATA_BASE.CONFIGURACION();
                bool Respuesta;

                //string CODIGO_COMPANIA = ;
                string ID_PORTAL = TXT_ID_PORTAL.Text;
                string IP_PORTAL = TXT_IP_READER.Text;
                string NOMBRE_PORTAL = TXT_NOMBRE_PORTAL.Text;
                string NOMBRE_READER = TXT_NOMBRE_READER.Text;
                int MODELO_READER = Convert.ToInt32(CMB_MODELO.SelectedValue);
                string SERIE_READER = TXT_SERIE_READER.Text;
                string EMAIL_READER = TXT_EMAIL.Text;
                string EMAIL_COPIAS = TXT_COPIAS_EMAIL.Text;
                bool EMAIL_ESTADO;

                if (CHKBX_ON.Checked == true)
                {
                    EMAIL_ESTADO = true;
                }
                else
                {
                    EMAIL_ESTADO = false;
                }

                //PROCESAR GURDADO
                Respuesta = portal.UPDATE_DATOS_PORTAL(ID_PORTAL, IP_PORTAL, NOMBRE_PORTAL, NOMBRE_READER, MODELO_READER, SERIE_READER, EMAIL_READER, EMAIL_COPIAS, EMAIL_ESTADO);


                if (Respuesta == true)
                {
                    MessageBox.Show("PORTAL ACTUALIZADO CORRECTAMENTE.");
                }
                else
                {
                    MessageBox.Show("ERROR: PORTAL NO ACTUALIZADO");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("ERROR: PORTAL NO ACTUALIZADO");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CMB_PORTAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            ///////////////////////////
            //LLENA EL FORMULARIO SEGUN EL PORTAL CONSULTADO

            DataTable dt = new DataTable();

            dt = consulta.GET_DATOS_PORTALES(CMB_PORTAL.SelectedValue.ToString());

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                //////////////////////
                //ID PORTAL
                TXT_ID_PORTAL.Text = dr["ID_PORTAL"].ToString();
                //////////////////////
                //NOMBRE PORTAL
                TXT_NOMBRE_PORTAL.Text = dr["NOMBRE_PORTAL"].ToString();
                LBL_PORTAL_1.Text = TXT_NOMBRE_PORTAL.Text;
                //////////////////////
                //NOMBRE READER
                TXT_NOMBRE_READER.Text = dr["NOMBRE_READER"].ToString();
                //////////////////////
                //IP READER
                TXT_IP_READER.Text = dr["IP_READER_PORTAL"].ToString();
                //////////////////////
                //MODELO READER
                string ID_MODELO = dr["MODELO_READER"].ToString();

                if (ID_MODELO != "")
                {
                    //CMB_MODELO.Items.Clear();
                    CONFIGURACION_CARGAR_MODELOS();
                    CMB_MODELO.SelectedIndex = Convert.ToInt32(ID_MODELO) - 1;
                }

                //////////////////////
                //SERIE READER
                TXT_SERIE_READER.Text = dr["SERIE_READER"].ToString();
                //////////////////////
                //ESTADO ENVIO DE EMAIL
                string ESTADO_EMAIL = dr["ESTADO_EMAIL"].ToString();

                if (ESTADO_EMAIL == "True")
                {
                    CHKBX_ON.Checked = true;
                    LBL_EMAIL_PORTAL.Visible = true;
                    TXT_EMAIL.Visible = true;
                    LBL_COPIAS.Visible = true;
                    TXT_COPIAS_EMAIL.Visible = true;

                    TXT_EMAIL.Text = dr["EMAIL"].ToString();
                    TXT_COPIAS_EMAIL.Text = dr["EMAIL_COPIAS"].ToString();
                }
                else
                {
                    CHKBX_ON.Checked = false;

                    LBL_EMAIL_PORTAL.Visible = false;
                    TXT_EMAIL.Visible = false;
                    TXT_EMAIL.Text = "";
                    LBL_COPIAS.Visible = false;
                    TXT_COPIAS_EMAIL.Visible = false;
                }
            }
        }

        /// <summary>
        /// CARGAR LA IMAGEN DEL READER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CMB_MODELO_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DT = new DataTable();
                string ID_READER = CMB_MODELO.SelectedValue.ToString();

                DT = consulta.GET_CATALOGO_MODELO_READERS(ID_READER);

                if (DT.Rows.Count > 0)
                {
                    DataRow dr = DT.Rows[0];
                    byte[] Imagen = new byte[0];

                    string IMG_VLD = dr["IMAGEN"].ToString();

                    if (IMG_VLD != "")
                    {
                        Imagen = (byte[])dr["IMAGEN"];
                        MemoryStream ms = new MemoryStream(Imagen);
                        IMAGEN_READER.Image = Image.FromStream(ms);
                    }
                    
                }
            }
            catch (Exception)
            {
               
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CHKBX_ON_CheckedChanged(object sender, EventArgs e)
        {
            //HABILITAMOS LOS DEMAS CAMPOS A MODIFICAR

            if (CHKBX_ON.Checked == true)
            {
                LBL_EMAIL_PORTAL.Visible = true;
                TXT_EMAIL.Visible = true;
                LBL_COPIAS.Visible = true;
                TXT_COPIAS_EMAIL.Visible = true;
            }
            else
            {
                LBL_EMAIL_PORTAL.Visible = false;
                TXT_EMAIL.Visible = false;
                LBL_COPIAS.Visible = false;
                TXT_COPIAS_EMAIL.Visible = false;
            }

        }
        #endregion


        #endregion

        ///////////////////////////////


        #region BLACKLIST
        
        /// <summary>
        /// BTN SAVE TAG BLACKLIST 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_BLACKLIST_Click(object sender, EventArgs e)
        {
            try
            {
                /////////////////////////////////////////////////////
                //INSTANCIAS
                FUNCIONES.ARCHIVOS File = new FUNCIONES.ARCHIVOS();
                CLASES.PARAMETROS PM = new CLASES.PARAMETROS();

                /////////////////////////////////////////////////////
                //VARIABLES
                string FILE_NAME = "Blacklist_" + ID_PORTAL_BLACKLIST.Text;
                string PATH_BLACKLIST = "";
                

                //VALIDAR CHECKED
                if(RB_INSERTAR.Checked == true)
                {
                    ////////////////////////////////////////////////////////////////////
                    //VALIDAR CANTIDAD DE CARACTERES DEL TAG INGRESADO
                    string N_Caracteres = TXT_TAG.Text.Trim();
                    string TAG_INGRESADO = "";

                    ////////////////////////////////////////////////////
                    //AGREGAR LOS CEROS
                    if (N_Caracteres.Length == 24)
                    {
                        TAG_INGRESADO = TXT_TAG.Text;
                    }
                    else
                    {
                        int N = 24 - Convert.ToInt32(N_Caracteres.Length);
                        //CICLO QUE COMPLETA LOS 0 RESTANTES AL TAG ACTIVO
                        for (int i = 1; i <= N; i++)
                        {
                            TAG_INGRESADO += "0";
                        }
                        //ADICIONAMOS EL TAG INGRESADO
                        TAG_INGRESADO += TXT_TAG.Text;

                    }
                    
                    ////////////////////////////////////////////////////////////////////
                    //LEER FILE CONFIG
                    DataTable DT = File.LEER_ARCHIVO();

                    if(DT.Rows.Count >= 0 )
                    {
                        DataRow dr = DT.Rows[0];

                        PATH_BLACKLIST = dr["PATH_BLACKLIST"].ToString();

                    }

                    ////////////////////////////////////////////////////////////////////
                    //CREAR ARCHIVO BLACKLIST
                    string respuesta = File.CREAR_ARCHIVO_BLACKLIST(PATH_BLACKLIST, FILE_NAME, TAG_INGRESADO);

                    //CARGAR LISTA DE TAGS
                    PORTAL_BLACKLIST(Convert.ToInt32(ID_PORTAL_BLACKLIST.Text));

                    //MENSAJE
                    MessageBox.Show(respuesta);
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
            }
        }

        /// <summary>
        /// MOSTRAR ACTIVOS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CMB_PORTAL_BLACKLIST_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LIMPIAR GRIDVIEW
            GV_TAGS_BLACKLIST.DataSource = null;

            //SELECCIONAR VALOR DEL PORTAL
            int ID_PORTAL = Convert.ToInt32(CMB_PORTAL_BLACKLIST.SelectedValue);

            //MOSTRAR ID PORTAL
            ID_PORTAL_BLACKLIST.Visible = false;
            ID_PORTAL_BLACKLIST.Text = ID_PORTAL.ToString();

            //CARGAR TAGS DEL BLACKLIST DEL PORTAL
            PORTAL_BLACKLIST(ID_PORTAL);
        }

        /// <summary>
        /// CARGAR BLACKLIST
        /// </summary>
        private void PORTAL_BLACKLIST(int ID_PORTAL)
        {
            try
            {
                //VARIABLES
                string PATH_BLACKLIST = "";
                string line;

                //DATATABLE
                DataTable DT_TAGS = new DataTable();
                DT_TAGS.Columns.Add("TAG", typeof(string));

                FUNCIONES.ARCHIVOS File = new FUNCIONES.ARCHIVOS();
            
                //LEER FILE CONFIG
                DataTable DT = File.LEER_ARCHIVO();

                if (DT.Rows.Count > 0)
                {
                    DataRow dr = DT.Rows[0];

                    PATH_BLACKLIST = dr["PATH_BLACKLIST"].ToString();
                }

                //FILE NAME
                string FILE_NAME = PATH_BLACKLIST + "\\Blacklist_" + ID_PORTAL.ToString() + ".txt";


                try
                {
                    //LIMPIAR DATATABLE
                    //DT_TAGS = null;

                    StreamReader file = new StreamReader(@FILE_NAME);
                    while ((line = file.ReadLine()) != null)
                    {
                        DT_TAGS.Rows.Add(line);
                    }

                    file.Close();


                    //CARGAR GRIDVIEW
                    GV_TAGS_BLACKLIST.DataSource = DT_TAGS;

                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
            catch (Exception)
            {
                
            }
        }


        #endregion



        /// <summary>
        /// GUARDAR CONDIGURACION DATOS SERVIDOR DE CORREO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_SAVE_DATOS_SERVIDOR_CORREO_Click(object sender, EventArgs e)
        {
            try
            {
                //VARIABLES
                string SERVIDOR = TXT_SERVIDOR.Text;
                string PUERTO = TXT_PUERTO.Text;
                bool SSL = false;

                string EMISOR_EMAIL = TXT_EMAIL_SERVIDOR.Text;
                string EMISOR_PASSWORD = TXT_EMAIL_PASSWORD.Text;

                if(CHKBOX_SSL.Checked == true)
                {
                    SSL = true;
                }


                //GURDAR CONFIGURACION 
                bool RESPUESTA = ARCHIVOS.CREAR_DIRECTORIO_CONFIGURACION_SERVIDOR_CORREO(SERVIDOR, PUERTO, SSL.ToString(), EMISOR_EMAIL, EMISOR_PASSWORD);

                if(RESPUESTA == true)
                {
                    MessageBox.Show("CONFIGURACIÓN GUARDADA", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("CONFIGURACIÓN NO GUARDADA", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void CONFIGURACION_GENERAL_Load(object sender, EventArgs e)
        {

        }


    }
}
