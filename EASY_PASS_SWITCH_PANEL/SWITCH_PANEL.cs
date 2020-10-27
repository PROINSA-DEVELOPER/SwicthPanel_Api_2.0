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
using Newtonsoft.Json;

namespace EASY_PASS_SWITCH_PANEL
{
    //////////////////////////////////////////////////////////////////////


    public delegate void TagArrivedCallBack_5(TagData tagData);
    public delegate void EventSignalledCallBack_5(Events.StatusEventArgs e);


    //////////////////////////////////////////////////////////////////////



    public partial class SWITCH_PANEL : Form
    {
        DATA_BASE.CONSULTAS consulta_DB = new DATA_BASE.CONSULTAS();
        CLASES.LOG log = new CLASES.LOG();


        ////////////////////////////////////////////////////////////////////////
        //                          METODO PRICIPAL                           //
        ////////////////////////////////////////////////////////////////////////
        public SWITCH_PANEL()
        {
            InitializeComponent();

            //CARGAR CONFIGURAION DADA POR EL USUARIO
            //CARGAR_CONFIGURACION();

            //CARGAR NOMBRE PORTALES
            //CONSULTA_PORTALES();

            //CARGAR ITEMS CMBX
            CARGAR_COMBOX_ITEMS_ESTADO();
        }




        ////////////////////////////////////////////////////////////////////////
        //                               VARIABLES                            //
        ////////////////////////////////////////////////////////////////////////

        #region VARIABLES READER


        //VARIABLES READER RFID
        public RFIDReader RFID_READER_1;
        public RFIDReader RFID_READER_2;
        public RFIDReader RFID_READER_3;
        public RFIDReader RFID_READER_4;
        public RFIDReader RFID_READER_5;
        public RFIDReader RFID_READER_6;
        public RFIDReader RFID_READER_7;
        public RFIDReader RFID_READER_8;
        public RFIDReader RFID_READER_9;
        public RFIDReader RFID_READER_10;
        public RFIDReader RFID_READER_11;
        public RFIDReader RFID_READER_12;
        public RFIDReader RFID_READER_13;
        public RFIDReader RFID_READER_14;
        public RFIDReader RFID_READER_15;
        public RFIDReader RFID_READER_16;
        public RFIDReader RFID_READER_17;
        public RFIDReader RFID_READER_18;
        public RFIDReader RFID_READER_19;
        public RFIDReader RFID_READER_20;

        //VARIABLES EVENTOS READER
        private UpdateRead m_UpdateReadHandler_1 = null;
        private UpdateRead m_UpdateReadHandler_2 = null;
        private UpdateRead m_UpdateReadHandler_3 = null;
        private UpdateRead m_UpdateReadHandler_4 = null;
        private UpdateRead m_UpdateReadHandler_5 = null;
        private UpdateRead m_UpdateReadHandler_6 = null;
        private UpdateRead m_UpdateReadHandler_7 = null;
        private UpdateRead m_UpdateReadHandler_8 = null;
        private UpdateRead m_UpdateReadHandler_9 = null;
        private UpdateRead m_UpdateReadHandler_10 = null;
        private UpdateRead m_UpdateReadHandler_11 = null;
        private UpdateRead m_UpdateReadHandler_12 = null;
        private UpdateRead m_UpdateReadHandler_13 = null;
        private UpdateRead m_UpdateReadHandler_14 = null;
        private UpdateRead m_UpdateReadHandler_15 = null;
        private UpdateRead m_UpdateReadHandler_16 = null;
        private UpdateRead m_UpdateReadHandler_17 = null;
        private UpdateRead m_UpdateReadHandler_18 = null;
        private UpdateRead m_UpdateReadHandler_19 = null;
        private UpdateRead m_UpdateReadHandler_20 = null;

        //VARABLES ANTENNA READER
        Symbol.RFID3.AntennaInfo AntenaInfo_1;
        Symbol.RFID3.AntennaInfo AntenaInfo_2;
        Symbol.RFID3.AntennaInfo AntenaInfo_3;
        Symbol.RFID3.AntennaInfo AntenaInfo_4;
        Symbol.RFID3.AntennaInfo AntenaInfo_5;
        Symbol.RFID3.AntennaInfo AntenaInfo_6;
        Symbol.RFID3.AntennaInfo AntenaInfo_7;
        Symbol.RFID3.AntennaInfo AntenaInfo_8;
        Symbol.RFID3.AntennaInfo AntenaInfo_9;
        Symbol.RFID3.AntennaInfo AntenaInfo_10;
        Symbol.RFID3.AntennaInfo AntenaInfo_11;
        Symbol.RFID3.AntennaInfo AntenaInfo_12;
        Symbol.RFID3.AntennaInfo AntenaInfo_13;
        Symbol.RFID3.AntennaInfo AntenaInfo_14;
        Symbol.RFID3.AntennaInfo AntenaInfo_15;
        Symbol.RFID3.AntennaInfo AntenaInfo_16;
        Symbol.RFID3.AntennaInfo AntenaInfo_17;
        Symbol.RFID3.AntennaInfo AntenaInfo_18;
        Symbol.RFID3.AntennaInfo AntenaInfo_19;
        Symbol.RFID3.AntennaInfo AntenaInfo_20;

        //ARRAYLIST TAGS 
        ArrayList TagsAlmacenados_1 = new ArrayList();
        ArrayList TagsAlmacenados_2 = new ArrayList();
        ArrayList TagsAlmacenados_3 = new ArrayList();
        ArrayList TagsAlmacenados_4 = new ArrayList();
        ArrayList TagsAlmacenados_5 = new ArrayList();
        ArrayList TagsAlmacenados_6 = new ArrayList();
        ArrayList TagsAlmacenados_7 = new ArrayList();
        ArrayList TagsAlmacenados_8 = new ArrayList();
        ArrayList TagsAlmacenados_9 = new ArrayList();
        ArrayList TagsAlmacenados_10 = new ArrayList();
        ArrayList TagsAlmacenados_11 = new ArrayList();
        ArrayList TagsAlmacenados_12 = new ArrayList();
        ArrayList TagsAlmacenados_13 = new ArrayList();
        ArrayList TagsAlmacenados_14 = new ArrayList();
        ArrayList TagsAlmacenados_15 = new ArrayList();
        ArrayList TagsAlmacenados_16 = new ArrayList();
        ArrayList TagsAlmacenados_17 = new ArrayList();
        ArrayList TagsAlmacenados_18 = new ArrayList();
        ArrayList TagsAlmacenados_19 = new ArrayList();
        ArrayList TagsAlmacenados_20 = new ArrayList();



        //ARRAYLIST BLACKLIST 
        ArrayList blacklist_1 = new ArrayList();
        ArrayList blacklist_2 = new ArrayList();
        ArrayList blacklist_3 = new ArrayList();
        ArrayList blacklist_4 = new ArrayList();
        ArrayList blacklist_5 = new ArrayList();
        ArrayList blacklist_6 = new ArrayList();
        ArrayList blacklist_7 = new ArrayList();
        ArrayList blacklist_8 = new ArrayList();
        ArrayList blacklist_9 = new ArrayList();
        ArrayList blacklist_10 = new ArrayList();
        ArrayList blacklist_11 = new ArrayList();
        ArrayList blacklist_12 = new ArrayList();
        ArrayList blacklist_13 = new ArrayList();
        ArrayList blacklist_14 = new ArrayList();
        ArrayList blacklist_15 = new ArrayList();
        ArrayList blacklist_16 = new ArrayList();
        ArrayList blacklist_17 = new ArrayList();
        ArrayList blacklist_18 = new ArrayList();
        ArrayList blacklist_19 = new ArrayList();
        ArrayList blacklist_20 = new ArrayList();



        //VARIABLES ESTADO READER
        Boolean m_IsConnected_1,
                    m_IsConnected_2,
                    m_IsConnected_3,
                    m_IsConnected_4,
                    m_IsConnected_5,
                    m_IsConnected_6,
                    m_IsConnected_7,
                    m_IsConnected_8,
                    m_IsConnected_9,
                    m_IsConnected_10,
                    m_IsConnected_11,
                    m_IsConnected_12,
                    m_IsConnected_13,
                    m_IsConnected_14,
                    m_IsConnected_15,
                    m_IsConnected_16,
                    m_IsConnected_17,
                    m_IsConnected_18,
                    m_IsConnected_19,
                    m_IsConnected_20;

        Boolean Estado_Test_1 = false;
        Boolean Estado_Test_2 = false;
        Boolean Estado_Test_3 = false;
        Boolean Estado_Test_4 = false;
        Boolean Estado_Test_5 = false;
        Boolean Estado_Test_6 = false;
        Boolean Estado_Test_7 = false;
        Boolean Estado_Test_8 = false;
        Boolean Estado_Test_9 = false;
        Boolean Estado_Test_10 = false;
        Boolean Estado_Test_11 = false;
        Boolean Estado_Test_12 = false;
        Boolean Estado_Test_13 = false;
        Boolean Estado_Test_14 = false;
        Boolean Estado_Test_15 = false;
        Boolean Estado_Test_16 = false;
        Boolean Estado_Test_17 = false;
        Boolean Estado_Test_18 = false;
        Boolean Estado_Test_19 = false;
        Boolean Estado_Test_20 = false;



        Boolean ESTADO_COMPROBACION_READER_1 = false;
        Boolean ESTADO_COMPROBACION_READER_2 = false;
        Boolean ESTADO_COMPROBACION_READER_3 = false;
        Boolean ESTADO_COMPROBACION_READER_4 = false;
        Boolean ESTADO_COMPROBACION_READER_5 = false;
        Boolean ESTADO_COMPROBACION_READER_6 = false;
        Boolean ESTADO_COMPROBACION_READER_7 = false;
        Boolean ESTADO_COMPROBACION_READER_8 = false;
        Boolean ESTADO_COMPROBACION_READER_9 = false;
        Boolean ESTADO_COMPROBACION_READER_10 = false;
        Boolean ESTADO_COMPROBACION_READER_11 = false;
        Boolean ESTADO_COMPROBACION_READER_12 = false;
        Boolean ESTADO_COMPROBACION_READER_13 = false;
        Boolean ESTADO_COMPROBACION_READER_14 = false;
        Boolean ESTADO_COMPROBACION_READER_15 = false;
        Boolean ESTADO_COMPROBACION_READER_16 = false;
        Boolean ESTADO_COMPROBACION_READER_17 = false;
        Boolean ESTADO_COMPROBACION_READER_18 = false;
        Boolean ESTADO_COMPROBACION_READER_19 = false;
        Boolean ESTADO_COMPROBACION_READER_20 = false;


        Boolean FLAG_LECTURA_1 = false;
        Boolean FLAG_LECTURA_2 = false;
        Boolean FLAG_LECTURA_3 = false;
        Boolean FLAG_LECTURA_4 = false;
        Boolean FLAG_LECTURA_5 = false;
        Boolean FLAG_LECTURA_6 = false;
        Boolean FLAG_LECTURA_7 = false;
        Boolean FLAG_LECTURA_8 = false;
        Boolean FLAG_LECTURA_9 = false;
        Boolean FLAG_LECTURA_10 = false;
        Boolean FLAG_LECTURA_11 = false;
        Boolean FLAG_LECTURA_12 = false;
        Boolean FLAG_LECTURA_13 = false;
        Boolean FLAG_LECTURA_14 = false;
        Boolean FLAG_LECTURA_15 = false;
        Boolean FLAG_LECTURA_16 = false;
        Boolean FLAG_LECTURA_17 = false;
        Boolean FLAG_LECTURA_18 = false;
        Boolean FLAG_LECTURA_19 = false;
        Boolean FLAG_LECTURA_20 = false;


        //CLASES
        SERVICIOS.BITACORA bitacora = new SERVICIOS.BITACORA();


        //OTROS
        private delegate void UpdateRead(Events.ReadEventData eventData);
        int TiempoEsperaEscribirLectura = 0;

        #endregion


        #region SUBPROCESOS

        //SUBPROCESOS (HILOS)
        Thread READER_1 = null;
        Thread READER_2 = null;
        Thread READER_3 = null;
        Thread READER_4 = null;
        Thread READER_5 = null;
        Thread READER_6 = null;
        Thread READER_7 = null;
        Thread READER_8 = null;
        Thread READER_9 = null;
        Thread READER_10 = null;
        Thread READER_11 = null;
        Thread READER_12 = null;
        Thread READER_13 = null;
        Thread READER_14 = null;
        Thread READER_15 = null;
        Thread READER_16 = null;
        Thread READER_17 = null;
        Thread READER_18 = null;
        Thread READER_19 = null;
        Thread READER_20 = null;


        Thread ULTIMA_LECTURA_1 = null;
        Thread ULTIMA_LECTURA_2 = null;
        Thread ULTIMA_LECTURA_3 = null;
        Thread ULTIMA_LECTURA_4 = null;
        Thread ULTIMA_LECTURA_5 = null;
        Thread ULTIMA_LECTURA_6 = null;
        Thread ULTIMA_LECTURA_7 = null;
        Thread ULTIMA_LECTURA_8 = null;
        Thread ULTIMA_LECTURA_9 = null;
        Thread ULTIMA_LECTURA_10 = null;
        Thread ULTIMA_LECTURA_11 = null;
        Thread ULTIMA_LECTURA_12 = null;
        Thread ULTIMA_LECTURA_13 = null;
        Thread ULTIMA_LECTURA_14 = null;
        Thread ULTIMA_LECTURA_15 = null;
        Thread ULTIMA_LECTURA_16 = null;
        Thread ULTIMA_LECTURA_17 = null;
        Thread ULTIMA_LECTURA_18 = null;
        Thread ULTIMA_LECTURA_19 = null;
        Thread ULTIMA_LECTURA_20 = null;


        Thread CONEXION_1 = null;
        Thread CONEXION_2 = null;
        Thread CONEXION_3 = null;
        Thread CONEXION_4 = null;
        Thread CONEXION_5 = null;
        Thread CONEXION_6 = null;
        Thread CONEXION_7 = null;
        Thread CONEXION_8 = null;
        Thread CONEXION_9 = null;
        Thread CONEXION_10 = null;
        Thread CONEXION_11 = null;
        Thread CONEXION_12 = null;
        Thread CONEXION_13 = null;
        Thread CONEXION_14 = null;
        Thread CONEXION_15 = null;
        Thread CONEXION_16 = null;
        Thread CONEXION_17 = null;
        Thread CONEXION_18 = null;
        Thread CONEXION_19 = null;
        Thread CONEXION_20 = null;


        Thread HILO_LIMPIEZA_TAGS_1 = null;
        Thread HILO_LIMPIEZA_TAGS_2 = null;
        Thread HILO_LIMPIEZA_TAGS_3 = null;
        Thread HILO_LIMPIEZA_TAGS_4 = null;
        Thread HILO_LIMPIEZA_TAGS_5 = null;
        Thread HILO_LIMPIEZA_TAGS_6 = null;
        Thread HILO_LIMPIEZA_TAGS_7 = null;
        Thread HILO_LIMPIEZA_TAGS_8 = null;
        Thread HILO_LIMPIEZA_TAGS_9 = null;
        Thread HILO_LIMPIEZA_TAGS_10 = null;
        Thread HILO_LIMPIEZA_TAGS_11 = null;
        Thread HILO_LIMPIEZA_TAGS_12 = null;
        Thread HILO_LIMPIEZA_TAGS_13 = null;
        Thread HILO_LIMPIEZA_TAGS_14 = null;
        Thread HILO_LIMPIEZA_TAGS_15 = null;
        Thread HILO_LIMPIEZA_TAGS_16 = null;
        Thread HILO_LIMPIEZA_TAGS_17 = null;
        Thread HILO_LIMPIEZA_TAGS_18 = null;
        Thread HILO_LIMPIEZA_TAGS_19 = null;
        Thread HILO_LIMPIEZA_TAGS_20 = null;

        Thread THR_BITACORA = null;

        #endregion


        #region VARIABLES DATOS EMAIL

        //PARAMETROS
        string TITULO = "EASY PASS PORTALES";
        string MENSAJE = "[ERROR] LECTOR DESCONECTADO";

        #endregion


        ////////////////////////////////////////////////////////////////////////
        //                        INICIAR/DETENER READER                      //
        ////////////////////////////////////////////////////////////////////////

        #region INICIAR/DETENER READER

        /// <summary>
        /// METODO QUE INICIA O DETIENE LA CONEXION DEL READER
        /// </summary>
        /// <param name="ID_PORTAL"></param>
        private void INICIAR_PORTAL(int ID_PORTAL)
        {
            try
            {
                //PORTAL
                DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();

                //UPDATE ESTADO PORTAL A TRUE
                bool Respuesta = PORTAL.UPDATE_ESTADO_PORTAL(ID_PORTAL, true);

                //SI SE EJECUTO BIEN EL PROC. EJECUTA LA INSTRUCCION, E INICIA EL PROCESO DE LECTURA DEL LECTOR
                if (Respuesta == true)
                {
                    switch (ID_PORTAL)
                    {
                        case 1:

                            #region PORTAL 1


                            ////////////////////////////////////////////////////////////////
                            //INICIAR EL READER 1
                            READER_1 = new Thread(() => INICIAR_LECTOR_1(ID_PORTAL));
                            READER_1.Start();

                            ////////////////////////////////////////////////////////////////
                            //DETENEMOS EL PROCESO , MIENTRAS LO SUBPROCESOS TERMINAN Y ASI OBTENEMOS EL ESTADO DEL READER (m_IsConnected)
                            Thread.Sleep(4000);
                            if (m_IsConnected_1 == true)
                            {
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_1.Text + " (Conectado  " + DateTime.Now + ")");

                                //REGISTRO DE BITACORA
                                log.LogBitacoraProcesos(LBL_PORTAL_1.Text, "CONECTADO");

                                bool FLAG_INICIAR = true;

                                CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                            }
                            else
                            {
                                ////////////////////////////////////////////////////////////////
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_1.Text + " (Conexion Rechazada" + DateTime.Now + ")");

                                /////////////////////////////////////////////////////////
                                //               DETENER  PORTAL Y SU LECTURA          //
                                /////////////////////////////////////////////////////////
                                int respuesta = DETENER_LECTOR(ID_PORTAL);

                                if (respuesta == 1)
                                {
                                    bool FLAG_INICIAR = false;

                                    CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                                }
                            }

                            #endregion

                            break;

                        case 2:

                            #region PORTAL 2

                            ////////////////////////////////////////////////////////////////
                            //INICIAR EL READER 1
                            READER_2 = new Thread(() => INICIAR_LECTOR_2(ID_PORTAL));
                            READER_2.Start();

                            ////////////////////////////////////////////////////////////////
                            //DETENEMOS EL PROCESO , MIENTRAS LO SUBPROCESOS TERMINAN Y ASI OBTENEMOS EL ESTADO DEL READER (m_IsConnected)
                            Thread.Sleep(4000);
                            if (m_IsConnected_2 == true)
                            {
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_2.Text + " (Conectado  " + DateTime.Now + ")");

                                //REGISTRO DE BITACORA
                                log.LogBitacoraProcesos(LBL_PORTAL_2.Text, "CONECTADO");

                                bool FLAG_INICIAR = true;

                                CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                            }
                            else
                            {
                                ////////////////////////////////////////////////////////////////
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_2.Text + " (Conexion Rechazada" + DateTime.Now + ")");

                                /////////////////////////////////////////////////////////
                                //               DETENER  PORTAL Y SU LECTURA          //
                                /////////////////////////////////////////////////////////
                                int respuesta = DETENER_LECTOR(ID_PORTAL);

                                if (respuesta == 1)
                                {
                                    bool FLAG_INICIAR = false;

                                    CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                                }
                            }

                            #endregion

                            break;

                        case 3:

                            #region PORTAL 3

                            ////////////////////////////////////////////////////////////////
                            //INICIAR EL READER 1
                            READER_3 = new Thread(() => INICIAR_LECTOR_3(ID_PORTAL));
                            READER_3.Start();

                            ////////////////////////////////////////////////////////////////
                            //DETENEMOS EL PROCESO , MIENTRAS LO SUBPROCESOS TERMINAN Y ASI OBTENEMOS EL ESTADO DEL READER (m_IsConnected)
                            Thread.Sleep(4000);
                            if (m_IsConnected_3 == true)
                            {
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_3.Text + " (Conectado  " + DateTime.Now + ")");

                                //REGISTRO DE BITACORA
                                log.LogBitacoraProcesos(LBL_PORTAL_3.Text, "CONECTADO");

                                bool FLAG_INICIAR = true;

                                CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                            }
                            else
                            {
                                ////////////////////////////////////////////////////////////////
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_3.Text + " (Conexion Rechazada" + DateTime.Now + ")");

                                /////////////////////////////////////////////////////////
                                //               DETENER  PORTAL Y SU LECTURA          //
                                /////////////////////////////////////////////////////////
                                int respuesta = DETENER_LECTOR(ID_PORTAL);

                                if (respuesta == 1)
                                {
                                    bool FLAG_INICIAR = false;

                                    CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                                }
                            }

                            #endregion

                            break;

                        case 4:

                            #region PORTAL 4

                            ////////////////////////////////////////////////////////////////
                            //INICIAR EL READER 1
                            READER_4 = new Thread(() => INICIAR_LECTOR_4(ID_PORTAL));
                            READER_4.Start();

                            ////////////////////////////////////////////////////////////////
                            //DETENEMOS EL PROCESO , MIENTRAS LO SUBPROCESOS TERMINAN Y ASI OBTENEMOS EL ESTADO DEL READER (m_IsConnected)
                            Thread.Sleep(4000);
                            if (m_IsConnected_4 == true)
                            {
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_4.Text + " (Conectado  " + DateTime.Now + ")");

                                //REGISTRO DE BITACORA
                                log.LogBitacoraProcesos(LBL_PORTAL_4.Text, "CONECTADO");

                                bool FLAG_INICIAR = true;

                                CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                            }
                            else
                            {
                                ////////////////////////////////////////////////////////////////
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_4.Text + " (Conexion Rechazada" + DateTime.Now + ")");

                                /////////////////////////////////////////////////////////
                                //               DETENER  PORTAL Y SU LECTURA          //
                                /////////////////////////////////////////////////////////
                                int respuesta = DETENER_LECTOR(ID_PORTAL);

                                if (respuesta == 1)
                                {
                                    bool FLAG_INICIAR = false;

                                    CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                                }
                            }

                            #endregion

                            break;

                        case 5:

                            #region PORTAL 5

                            ////////////////////////////////////////////////////////////////
                            //INICIAR EL READER 1
                            READER_5 = new Thread(() => INICIAR_LECTOR_5(ID_PORTAL));
                            READER_5.Start();

                            ////////////////////////////////////////////////////////////////
                            //DETENEMOS EL PROCESO , MIENTRAS LO SUBPROCESOS TERMINAN Y ASI OBTENEMOS EL ESTADO DEL READER (m_IsConnected)
                            Thread.Sleep(4000);
                            if (m_IsConnected_5 == true)
                            {
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_5.Text + " (Conectado  " + DateTime.Now + ")");

                                //REGISTRO DE BITACORA
                                log.LogBitacoraProcesos(LBL_PORTAL_5.Text, "CONECTADO");

                                bool FLAG_INICIAR = true;

                                CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                            }
                            else
                            {
                                ////////////////////////////////////////////////////////////////
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_5.Text + " (Conexion Rechazada" + DateTime.Now + ")");

                                /////////////////////////////////////////////////////////
                                //               DETENER  PORTAL Y SU LECTURA          //
                                /////////////////////////////////////////////////////////
                                int respuesta = DETENER_LECTOR(ID_PORTAL);

                                if (respuesta == 1)
                                {
                                    bool FLAG_INICIAR = false;

                                    CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                                }
                            }

                            #endregion

                            break;

                        case 6:

                            #region PORTAL 6

                            ////////////////////////////////////////////////////////////////
                            //INICIAR EL READER 1
                            READER_6 = new Thread(() => INICIAR_LECTOR_6(ID_PORTAL));
                            READER_6.Start();

                            ////////////////////////////////////////////////////////////////
                            //DETENEMOS EL PROCESO , MIENTRAS LO SUBPROCESOS TERMINAN Y ASI OBTENEMOS EL ESTADO DEL READER (m_IsConnected)
                            Thread.Sleep(4000);
                            if (m_IsConnected_6 == true)
                            {
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_6.Text + " (Conectado  " + DateTime.Now + ")");

                                //REGISTRO DE BITACORA
                                log.LogBitacoraProcesos(LBL_PORTAL_6.Text, "CONECTADO");

                                bool FLAG_INICIAR = true;

                                CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                            }
                            else
                            {
                                ////////////////////////////////////////////////////////////////
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_6.Text + " (Conexion Rechazada" + DateTime.Now + ")");

                                /////////////////////////////////////////////////////////
                                //               DETENER  PORTAL Y SU LECTURA          //
                                /////////////////////////////////////////////////////////
                                int respuesta = DETENER_LECTOR(ID_PORTAL);

                                if (respuesta == 1)
                                {
                                    bool FLAG_INICIAR = false;

                                    CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                                }
                            }

                            #endregion

                            break;

                        case 7:

                            #region PORTAL 7

                            ////////////////////////////////////////////////////////////////
                            //INICIAR EL READER 1
                            READER_7 = new Thread(() => INICIAR_LECTOR_7(ID_PORTAL));
                            READER_7.Start();

                            ////////////////////////////////////////////////////////////////
                            //DETENEMOS EL PROCESO , MIENTRAS LO SUBPROCESOS TERMINAN Y ASI OBTENEMOS EL ESTADO DEL READER (m_IsConnected)
                            Thread.Sleep(4000);
                            if (m_IsConnected_7 == true)
                            {
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_7.Text + " (Conectado  " + DateTime.Now + ")");

                                //REGISTRO DE BITACORA
                                log.LogBitacoraProcesos(LBL_PORTAL_7.Text, "CONECTADO");

                                bool FLAG_INICIAR = true;

                                CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                            }
                            else
                            {
                                ////////////////////////////////////////////////////////////////
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_7.Text + " (Conexion Rechazada" + DateTime.Now + ")");

                                /////////////////////////////////////////////////////////
                                //               DETENER  PORTAL Y SU LECTURA          //
                                /////////////////////////////////////////////////////////
                                int respuesta = DETENER_LECTOR(ID_PORTAL);

                                if (respuesta == 1)
                                {
                                    bool FLAG_INICIAR = false;

                                    CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                                }
                            }

                            #endregion

                            break;

                        case 8:

                            #region PORTAL 8

                            ////////////////////////////////////////////////////////////////
                            //INICIAR EL READER 1
                            READER_8 = new Thread(() => INICIAR_LECTOR_8(ID_PORTAL));
                            READER_8.Start();

                            ////////////////////////////////////////////////////////////////
                            //DETENEMOS EL PROCESO , MIENTRAS LO SUBPROCESOS TERMINAN Y ASI OBTENEMOS EL ESTADO DEL READER (m_IsConnected)
                            Thread.Sleep(4000);
                            if (m_IsConnected_8 == true)
                            {
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_8.Text + " (Conectado  " + DateTime.Now + ")");

                                //REGISTRO DE BITACORA
                                log.LogBitacoraProcesos(LBL_PORTAL_8.Text, "CONECTADO");

                                bool FLAG_INICIAR = true;

                                CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                            }
                            else
                            {
                                ////////////////////////////////////////////////////////////////
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_8.Text + " (Conexion Rechazada" + DateTime.Now.ToShortTimeString() + ")");

                                /////////////////////////////////////////////////////////
                                //               DETENER  PORTAL Y SU LECTURA          //
                                /////////////////////////////////////////////////////////
                                int respuesta = DETENER_LECTOR(ID_PORTAL);

                                if (respuesta == 1)
                                {
                                    bool FLAG_INICIAR = false;

                                    CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                                }
                            }

                            #endregion

                            break;

                        case 9:

                            #region PORTAL 9

                            ////////////////////////////////////////////////////////////////
                            //INICIAR EL READER 1
                            READER_9 = new Thread(() => INICIAR_LECTOR_9(ID_PORTAL));
                            READER_9.Start();

                            ////////////////////////////////////////////////////////////////
                            //DETENEMOS EL PROCESO , MIENTRAS LO SUBPROCESOS TERMINAN Y ASI OBTENEMOS EL ESTADO DEL READER (m_IsConnected)
                            Thread.Sleep(4000);
                            if (m_IsConnected_9 == true)
                            {
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_9.Text + " (Conectado  " + DateTime.Now + ")");

                                //REGISTRO DE BITACORA
                                log.LogBitacoraProcesos(LBL_PORTAL_9.Text, "CONECTADO");

                                bool FLAG_INICIAR = true;

                                CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                            }
                            else
                            {
                                ////////////////////////////////////////////////////////////////
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_9.Text + " (Conexion Rechazada" + DateTime.Now + ")");

                                /////////////////////////////////////////////////////////
                                //               DETENER  PORTAL Y SU LECTURA          //
                                /////////////////////////////////////////////////////////
                                int respuesta = DETENER_LECTOR(ID_PORTAL);

                                if (respuesta == 1)
                                {
                                    bool FLAG_INICIAR = false;

                                    CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                                }
                            }

                            #endregion

                            break;

                        case 10:

                            #region PORTAL 10

                            ////////////////////////////////////////////////////////////////
                            //INICIAR EL READER 1
                            READER_10 = new Thread(() => INICIAR_LECTOR_10(ID_PORTAL));
                            READER_10.Start();

                            ////////////////////////////////////////////////////////////////
                            //DETENEMOS EL PROCESO , MIENTRAS LO SUBPROCESOS TERMINAN Y ASI OBTENEMOS EL ESTADO DEL READER (m_IsConnected)
                            Thread.Sleep(4000);
                            if (m_IsConnected_10 == true)
                            {
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_10.Text + " (Conectado  " + DateTime.Now + ")");

                                //REGISTRO DE BITACORA
                                log.LogBitacoraProcesos(LBL_PORTAL_10.Text, "CONECTADO");

                                bool FLAG_INICIAR = true;

                                CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                            }
                            else
                            {
                                ////////////////////////////////////////////////////////////////
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_10.Text + " (Conexion Rechazada" + DateTime.Now + ")");

                                /////////////////////////////////////////////////////////
                                //               DETENER  PORTAL Y SU LECTURA          //
                                /////////////////////////////////////////////////////////
                                int respuesta = DETENER_LECTOR(ID_PORTAL);

                                if (respuesta == 1)
                                {
                                    bool FLAG_INICIAR = false;

                                    CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                                }
                            }

                            #endregion

                            break;

                        case 11:

                            #region PORTAL 11

                            ////////////////////////////////////////////////////////////////
                            //INICIAR EL READER 1
                            READER_11 = new Thread(() => INICIAR_LECTOR_11(ID_PORTAL));
                            READER_11.Start();

                            ////////////////////////////////////////////////////////////////
                            //DETENEMOS EL PROCESO , MIENTRAS LO SUBPROCESOS TERMINAN Y ASI OBTENEMOS EL ESTADO DEL READER (m_IsConnected)
                            Thread.Sleep(4000);
                            if (m_IsConnected_11 == true)
                            {
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_11.Text + " (Conectado  " + DateTime.Now + ")");

                                //REGISTRO DE BITACORA
                                log.LogBitacoraProcesos(LBL_PORTAL_11.Text, "CONECTADO");

                                bool FLAG_INICIAR = true;

                                CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                            }
                            else
                            {
                                ////////////////////////////////////////////////////////////////
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_11.Text + " (Conexion Rechazada" + DateTime.Now + ")");

                                /////////////////////////////////////////////////////////
                                //               DETENER  PORTAL Y SU LECTURA          //
                                /////////////////////////////////////////////////////////
                                int respuesta = DETENER_LECTOR(ID_PORTAL);

                                if (respuesta == 1)
                                {
                                    bool FLAG_INICIAR = false;

                                    CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                                }
                            }

                            #endregion

                            break;

                        case 12:

                            #region PORTAL 12

                            ////////////////////////////////////////////////////////////////
                            //INICIAR EL READER 1
                            READER_12 = new Thread(() => INICIAR_LECTOR_12(ID_PORTAL));
                            READER_12.Start();

                            ////////////////////////////////////////////////////////////////
                            //DETENEMOS EL PROCESO , MIENTRAS LO SUBPROCESOS TERMINAN Y ASI OBTENEMOS EL ESTADO DEL READER (m_IsConnected)
                            Thread.Sleep(4000);
                            if (m_IsConnected_12 == true)
                            {
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_12.Text + " (Conectado  " + DateTime.Now + ")");

                                //REGISTRO DE BITACORA
                                log.LogBitacoraProcesos(LBL_PORTAL_12.Text, "CONECTADO");

                                bool FLAG_INICIAR = true;

                                CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                            }
                            else
                            {
                                ////////////////////////////////////////////////////////////////
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_12.Text + " (Conexion Rechazada" + DateTime.Now + ")");

                                /////////////////////////////////////////////////////////
                                //               DETENER  PORTAL Y SU LECTURA          //
                                /////////////////////////////////////////////////////////
                                int respuesta = DETENER_LECTOR(ID_PORTAL);

                                if (respuesta == 1)
                                {
                                    bool FLAG_INICIAR = false;

                                    CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                                }
                            }

                            #endregion

                            break;

                        case 13:

                            #region PORTAL 13

                            ////////////////////////////////////////////////////////////////
                            //INICIAR EL READER 1
                            READER_13 = new Thread(() => INICIAR_LECTOR_13(ID_PORTAL));
                            READER_13.Start();

                            ////////////////////////////////////////////////////////////////
                            //DETENEMOS EL PROCESO , MIENTRAS LO SUBPROCESOS TERMINAN Y ASI OBTENEMOS EL ESTADO DEL READER (m_IsConnected)
                            Thread.Sleep(4000);
                            if (m_IsConnected_13 == true)
                            {
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_13.Text + " (Conectado  " + DateTime.Now + ")");

                                //REGISTRO DE BITACORA
                                log.LogBitacoraProcesos(LBL_PORTAL_13.Text, "CONECTADO");

                                bool FLAG_INICIAR = true;

                                CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                            }
                            else
                            {
                                ////////////////////////////////////////////////////////////////
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_13.Text + " (Conexion Rechazada" + DateTime.Now + ")");

                                /////////////////////////////////////////////////////////
                                //               DETENER  PORTAL Y SU LECTURA          //
                                /////////////////////////////////////////////////////////
                                int respuesta = DETENER_LECTOR(ID_PORTAL);

                                if (respuesta == 1)
                                {
                                    bool FLAG_INICIAR = false;

                                    CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                                }
                            }

                            #endregion

                            break;

                        case 14:

                            #region PORTAL 14

                            ////////////////////////////////////////////////////////////////
                            //INICIAR EL READER 1
                            READER_14 = new Thread(() => INICIAR_LECTOR_14(ID_PORTAL));
                            READER_14.Start();

                            ////////////////////////////////////////////////////////////////
                            //DETENEMOS EL PROCESO , MIENTRAS LO SUBPROCESOS TERMINAN Y ASI OBTENEMOS EL ESTADO DEL READER (m_IsConnected)
                            Thread.Sleep(4000);
                            if (m_IsConnected_14 == true)
                            {
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_14.Text + " (Conectado  " + DateTime.Now + ")");

                                //REGISTRO DE BITACORA
                                log.LogBitacoraProcesos(LBL_PORTAL_14.Text, "CONECTADO");

                                bool FLAG_INICIAR = true;

                                CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                            }
                            else
                            {
                                ////////////////////////////////////////////////////////////////
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_14.Text + " (Conexion Rechazada" + DateTime.Now + ")");

                                /////////////////////////////////////////////////////////
                                //               DETENER  PORTAL Y SU LECTURA          //
                                /////////////////////////////////////////////////////////
                                int respuesta = DETENER_LECTOR(ID_PORTAL);

                                if (respuesta == 1)
                                {
                                    bool FLAG_INICIAR = false;

                                    CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                                }
                            }

                            #endregion

                            break;

                        case 15:

                            #region PORTAL 15

                            ////////////////////////////////////////////////////////////////
                            //INICIAR EL READER 1
                            READER_15 = new Thread(() => INICIAR_LECTOR_15(ID_PORTAL));
                            READER_15.Start();

                            ////////////////////////////////////////////////////////////////
                            //DETENEMOS EL PROCESO , MIENTRAS LO SUBPROCESOS TERMINAN Y ASI OBTENEMOS EL ESTADO DEL READER (m_IsConnected)
                            Thread.Sleep(4000);
                            if (m_IsConnected_15 == true)
                            {
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_15.Text + " (Conectado  " + DateTime.Now + ")");

                                //REGISTRO DE BITACORA
                                log.LogBitacoraProcesos(LBL_PORTAL_15.Text, "CONECTADO");

                                bool FLAG_INICIAR = true;

                                CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                            }
                            else
                            {
                                ////////////////////////////////////////////////////////////////
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_15.Text + " (Conexion Rechazada" + DateTime.Now + ")");

                                /////////////////////////////////////////////////////////
                                //               DETENER  PORTAL Y SU LECTURA          //
                                /////////////////////////////////////////////////////////
                                int respuesta = DETENER_LECTOR(ID_PORTAL);

                                if (respuesta == 1)
                                {
                                    bool FLAG_INICIAR = false;

                                    CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                                }
                            }

                            #endregion

                            break;

                        case 16:

                            #region PORTAL 16

                            ////////////////////////////////////////////////////////////////
                            //INICIAR EL READER 1
                            READER_16 = new Thread(() => INICIAR_LECTOR_16(ID_PORTAL));
                            READER_16.Start();

                            ////////////////////////////////////////////////////////////////
                            //DETENEMOS EL PROCESO , MIENTRAS LO SUBPROCESOS TERMINAN Y ASI OBTENEMOS EL ESTADO DEL READER (m_IsConnected)
                            Thread.Sleep(4000);
                            if (m_IsConnected_16 == true)
                            {
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_16.Text + " (Conectado  " + DateTime.Now + ")");

                                //REGISTRO DE BITACORA
                                log.LogBitacoraProcesos(LBL_PORTAL_16.Text, "CONECTADO");

                                bool FLAG_INICIAR = true;

                                CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                            }
                            else
                            {
                                ////////////////////////////////////////////////////////////////
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_16.Text + " (Conexion Rechazada" + DateTime.Now + ")");

                                /////////////////////////////////////////////////////////
                                //               DETENER  PORTAL Y SU LECTURA          //
                                /////////////////////////////////////////////////////////
                                int respuesta = DETENER_LECTOR(ID_PORTAL);

                                if (respuesta == 1)
                                {
                                    bool FLAG_INICIAR = false;

                                    CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                                }
                            }

                            #endregion

                            break;

                        case 17:

                            #region PORTAL 17

                            ////////////////////////////////////////////////////////////////
                            //INICIAR EL READER 1
                            READER_17 = new Thread(() => INICIAR_LECTOR_17(ID_PORTAL));
                            READER_17.Start();

                            ////////////////////////////////////////////////////////////////
                            //DETENEMOS EL PROCESO , MIENTRAS LO SUBPROCESOS TERMINAN Y ASI OBTENEMOS EL ESTADO DEL READER (m_IsConnected)
                            Thread.Sleep(4000);
                            if (m_IsConnected_17 == true)
                            {
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_17.Text + " (Conectado  " + DateTime.Now + ")");

                                //REGISTRO DE BITACORA
                                log.LogBitacoraProcesos(LBL_PORTAL_17.Text, "CONECTADO");

                                bool FLAG_INICIAR = true;

                                CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                            }
                            else
                            {
                                ////////////////////////////////////////////////////////////////
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_17.Text + " (Conexion Rechazada" + DateTime.Now + ")");

                                /////////////////////////////////////////////////////////
                                //               DETENER  PORTAL Y SU LECTURA          //
                                /////////////////////////////////////////////////////////
                                int respuesta = DETENER_LECTOR(ID_PORTAL);

                                if (respuesta == 1)
                                {
                                    bool FLAG_INICIAR = false;

                                    CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                                }
                            }

                            #endregion

                            break;

                        case 18:

                            #region PORTAL 18

                            ////////////////////////////////////////////////////////////////
                            //INICIAR EL READER 1
                            READER_18 = new Thread(() => INICIAR_LECTOR_18(ID_PORTAL));
                            READER_18.Start();

                            ////////////////////////////////////////////////////////////////
                            //DETENEMOS EL PROCESO , MIENTRAS LO SUBPROCESOS TERMINAN Y ASI OBTENEMOS EL ESTADO DEL READER (m_IsConnected)
                            Thread.Sleep(4000);
                            if (m_IsConnected_18 == true)
                            {
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_18.Text + " (Conectado  " + DateTime.Now + ")");

                                //REGISTRO DE BITACORA
                                log.LogBitacoraProcesos(LBL_PORTAL_18.Text, "CONECTADO");

                                bool FLAG_INICIAR = true;

                                CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                            }
                            else
                            {
                                ////////////////////////////////////////////////////////////////
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_18.Text + " (Conexion Rechazada" + DateTime.Now + ")");

                                /////////////////////////////////////////////////////////
                                //               DETENER  PORTAL Y SU LECTURA          //
                                /////////////////////////////////////////////////////////
                                int respuesta = DETENER_LECTOR(ID_PORTAL);

                                if (respuesta == 1)
                                {
                                    bool FLAG_INICIAR = false;

                                    CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                                }
                            }

                            #endregion

                            break;

                        case 19:

                            #region PORTAL 19

                            ////////////////////////////////////////////////////////////////
                            //INICIAR EL READER 1
                            READER_19 = new Thread(() => INICIAR_LECTOR_19(ID_PORTAL));
                            READER_19.Start();

                            ////////////////////////////////////////////////////////////////
                            //DETENEMOS EL PROCESO , MIENTRAS LO SUBPROCESOS TERMINAN Y ASI OBTENEMOS EL ESTADO DEL READER (m_IsConnected)
                            Thread.Sleep(4000);
                            if (m_IsConnected_19 == true)
                            {
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_19.Text + " (Conectado  " + DateTime.Now + ")");

                                //REGISTRO DE BITACORA
                                log.LogBitacoraProcesos(LBL_PORTAL_19.Text, "CONECTADO");

                                bool FLAG_INICIAR = true;

                                CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                            }
                            else
                            {
                                ////////////////////////////////////////////////////////////////
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_19.Text + " (Conexion Rechazada" + DateTime.Now + ")");

                                /////////////////////////////////////////////////////////
                                //               DETENER  PORTAL Y SU LECTURA          //
                                /////////////////////////////////////////////////////////
                                int respuesta = DETENER_LECTOR(ID_PORTAL);

                                if (respuesta == 1)
                                {
                                    bool FLAG_INICIAR = false;

                                    CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                                }
                            }

                            #endregion

                            break;

                        case 20:

                            #region PORTAL 20

                            ////////////////////////////////////////////////////////////////
                            //INICIAR EL READER 1
                            READER_20 = new Thread(() => INICIAR_LECTOR_20(ID_PORTAL));
                            READER_20.Start();

                            ////////////////////////////////////////////////////////////////
                            //DETENEMOS EL PROCESO , MIENTRAS LO SUBPROCESOS TERMINAN Y ASI OBTENEMOS EL ESTADO DEL READER (m_IsConnected)
                            Thread.Sleep(4000);
                            if (m_IsConnected_20 == true)
                            {
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_20.Text + " (Conectado  " + DateTime.Now + ")");

                                //REGISTRO DE BITACORA
                                log.LogBitacoraProcesos(LBL_PORTAL_20.Text, "CONECTADO");

                                bool FLAG_INICIAR = true;

                                CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                            }
                            else
                            {
                                ////////////////////////////////////////////////////////////////
                                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                                LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_20.Text + " (Conexion Rechazada" + DateTime.Now + ")");

                                /////////////////////////////////////////////////////////
                                //               DETENER  PORTAL Y SU LECTURA          //
                                /////////////////////////////////////////////////////////
                                int respuesta = DETENER_LECTOR(ID_PORTAL);

                                if (respuesta == 1)
                                {
                                    bool FLAG_INICIAR = false;

                                    CAMBIAR_ESTADO_PORTAL(ID_PORTAL, FLAG_INICIAR);
                                }
                            }

                            #endregion

                            break;

                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// DETENER PORTAL
        /// </summary>
        /// <returns></returns>
        private int DETENER_LECTOR(int ID_PORTAL)
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


        ////////////////////////////////////////////////////////////////////////
        //                          METODOS READER                            //
        ////////////////////////////////////////////////////////////////////////

        #region READER RFID

        #region INICIAR LECTURA READER

        /// <summary>
        /// INICIALIZA EL READER DEL PORTAL 1
        /// </summary>
        public void INICIAR_LECTOR_1(int ID_PORTAL)
        {
            //PORTAL
            DATA_BASE.CONSULTAS portal = new DATA_BASE.CONSULTAS();
            //CONSUMIR CONSULTA
            DataTable dt = portal.CONSULTAR_ESTADO_PORTAL(ID_PORTAL);
            //ASIGNAR AL DATAROW Y ASI SELECCIONAR EL CAMPO A CONSULTAR
            DataRow dr = dt.Rows[0];

            //VARIABLES
            string ESTADO = dr["ESTADO"].ToString();
            string IP_LECTOR = dr["IP_LECTOR"].ToString();

            //////////////////////////////////////////////////////////////////////////////////////////
            //INICIAR LECTOR
            bool ESTADO_CONEXION = CONECTAR_LECTOR(IP_LECTOR, 0, 0, ID_PORTAL);

            try
            {
                if (ESTADO == "True" && ESTADO_CONEXION == true)
                {

                    //LECTURA BLACKLIST
                    LECTURA_BLACKLIST(ID_PORTAL);

                    //INICIAR REGISTRO DE LECTURAS
                    //STATUS LECTURA
                    FLAG_LECTURA_1 = true;
                    INICIAR_EVENTO_LECTURA(ID_PORTAL);

                    //INICIAR LECTURA
                    INICIAR_LECTURA(ID_PORTAL);

                    //EJECUTAR SUBPROCESO 1
                    HILO_LIMPIEZA_TAGS_1 = new Thread(CLEAR_ARRAY_1);
                    HILO_LIMPIEZA_TAGS_1.Start();

                    //EJECUTAR SUBPROCESO 2
                    ULTIMA_LECTURA_1 = new Thread(TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_1);
                    ULTIMA_LECTURA_1.Start();

                    //EJECUTAR SUBPROCESO 3
                    CONEXION_1 = new Thread(() => COMPROBAR_CONEXION_LECTOR_1(ID_PORTAL));
                    CONEXION_1.Start();

                    //ESTADO HILO
                    ESTADO_COMPROBACION_READER_1 = true;

                }

                if (ESTADO_CONEXION == false)
                {
                    //DESCONECTAR LECTOR
                    m_IsConnected_1 = false;
                }
            }
            catch (Exception ex)
            {
                //REGISTRO DE LOG
                log.LogConectionEventos(ex.ToString(), IP_LECTOR, Convert.ToString(ID_PORTAL));

                //DESCONECTAR LECTOR
                m_IsConnected_1 = false;
            }

        }

        /// <summary>
        /// INICIALIZA EL READER DEL PORTAL 2
        /// </summary>
        public void INICIAR_LECTOR_2(int ID_PORTAL)
        {
            //PORTAL
            DATA_BASE.CONSULTAS portal = new DATA_BASE.CONSULTAS();
            //CONSUMIR CONSULTA
            DataTable dt = portal.CONSULTAR_ESTADO_PORTAL(ID_PORTAL);
            //ASIGNAR AL DATAROW Y ASI SELECCIONAR EL CAMPO A CONSULTAR
            DataRow dr = dt.Rows[0];

            //VARIABLES
            string ESTADO = dr["ESTADO"].ToString();
            string IP_LECTOR = dr["IP_LECTOR"].ToString();


            try
            {

                //////////////////////////////////////////////////////////////////////////////////////////
                //INICIAR LECTOR
                bool ESTADO_CONEXION = CONECTAR_LECTOR(IP_LECTOR, 0, 0, ID_PORTAL);


                if (ESTADO == "True" && ESTADO_CONEXION == true)
                {
                    //LECTURA BLACKLIST
                    LECTURA_BLACKLIST(ID_PORTAL);

                    //INICIAR REGISTRO DE LECTURAS
                    INICIAR_EVENTO_LECTURA(ID_PORTAL);

                    //INICIAR LECTURA
                    INICIAR_LECTURA(ID_PORTAL);

                    //EJECUTAR SUBPROCESO 1
                    HILO_LIMPIEZA_TAGS_2 = new Thread(CLEAR_ARRAY_2);
                    HILO_LIMPIEZA_TAGS_2.Start();

                    //EJECUTAR SUBPROCESO 2
                    ULTIMA_LECTURA_2 = new Thread(TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_2);
                    ULTIMA_LECTURA_2.Start();

                    //EJECUTAR SUBPROCESO 3
                    CONEXION_2 = new Thread(() => COMPROBAR_CONEXION_LECTOR_2(ID_PORTAL));
                    CONEXION_2.Start();

                    //ESTADO HILO
                    ESTADO_COMPROBACION_READER_2 = true;
                }

                if (ESTADO_CONEXION == false)
                {
                    //DESCONECTAR LECTOR
                    m_IsConnected_2 = false;
                }
            }
            catch (Exception ex)
            {
                //REGISTRO DE LOG
                log.LogConectionEventos(ex.ToString(), IP_LECTOR, Convert.ToString(ID_PORTAL));

                //DESCONECTAR LECTOR
                m_IsConnected_2 = false;
            }

        }

        /// <summary>
        /// INICIALIZA EL READER DEL PORTAL 3
        /// </summary>
        public void INICIAR_LECTOR_3(int ID_PORTAL)
        {
            //PORTAL
            DATA_BASE.CONSULTAS portal = new DATA_BASE.CONSULTAS();
            //CONSUMIR CONSULTA
            DataTable dt = portal.CONSULTAR_ESTADO_PORTAL(ID_PORTAL);
            //ASIGNAR AL DATAROW Y ASI SELECCIONAR EL CAMPO A CONSULTAR
            DataRow dr = dt.Rows[0];

            //VARIABLES
            string ESTADO = dr["ESTADO"].ToString();
            string IP_LECTOR = dr["IP_LECTOR"].ToString();


            try
            {

                //////////////////////////////////////////////////////////////////////////////////////////
                //INICIAR LECTOR
                bool ESTADO_CONEXION = CONECTAR_LECTOR(IP_LECTOR, 0, 0, ID_PORTAL);


                if (ESTADO == "True" && ESTADO_CONEXION == true)
                {
                    //LECTURA BLACKLIST
                    LECTURA_BLACKLIST(ID_PORTAL);

                    //INICIAR REGISTRO DE LECTURAS
                    INICIAR_EVENTO_LECTURA(ID_PORTAL);

                    //INICIAR LECTURA
                    INICIAR_LECTURA(ID_PORTAL);

                    //EJECUTAR SUBPROCESO 1
                    HILO_LIMPIEZA_TAGS_3 = new Thread(CLEAR_ARRAY_3);
                    HILO_LIMPIEZA_TAGS_3.Start();

                    //EJECUTAR SUBPROCESO 2
                    ULTIMA_LECTURA_3 = new Thread(TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_3);
                    ULTIMA_LECTURA_3.Start();

                    //EJECUTAR SUBPROCESO 3
                    CONEXION_3 = new Thread(() => COMPROBAR_CONEXION_LECTOR_3(ID_PORTAL));
                    CONEXION_3.Start();

                    //ESTADO HILO
                    ESTADO_COMPROBACION_READER_3 = true;
                }

                if (ESTADO_CONEXION == false)
                {
                    //DESCONECTAR LECTOR
                    m_IsConnected_3 = false;
                }
            }
            catch (Exception ex)
            {
                //REGISTRO DE LOG
                log.LogConectionEventos(ex.ToString(), IP_LECTOR, Convert.ToString(ID_PORTAL));

                //DESCONECTAR LECTOR
                m_IsConnected_3 = false;
            }

        }

        /// <summary>
        /// INICIALIZA EL READER DEL PORTAL 4
        /// </summary>
        public void INICIAR_LECTOR_4(int ID_PORTAL)
        {
            //PORTAL
            DATA_BASE.CONSULTAS portal = new DATA_BASE.CONSULTAS();
            //CONSUMIR CONSULTA
            DataTable dt = portal.CONSULTAR_ESTADO_PORTAL(ID_PORTAL);
            //ASIGNAR AL DATAROW Y ASI SELECCIONAR EL CAMPO A CONSULTAR
            DataRow dr = dt.Rows[0];

            //VARIABLES
            string ESTADO = dr["ESTADO"].ToString();
            string IP_LECTOR = dr["IP_LECTOR"].ToString();


            try
            {

                //////////////////////////////////////////////////////////////////////////////////////////
                //INICIAR LECTOR
                bool ESTADO_CONEXION = CONECTAR_LECTOR(IP_LECTOR, 0, 0, ID_PORTAL);


                if (ESTADO == "True" && ESTADO_CONEXION == true)
                {
                    //LECTURA BLACKLIST
                    LECTURA_BLACKLIST(ID_PORTAL);

                    //INICIAR REGISTRO DE LECTURAS
                    INICIAR_EVENTO_LECTURA(ID_PORTAL);

                    //INICIAR LECTURA
                    INICIAR_LECTURA(ID_PORTAL);

                    //EJECUTAR SUBPROCESO 1
                    HILO_LIMPIEZA_TAGS_4 = new Thread(CLEAR_ARRAY_4);
                    HILO_LIMPIEZA_TAGS_4.Start();

                    //EJECUTAR SUBPROCESO 2
                    ULTIMA_LECTURA_4 = new Thread(TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_4);
                    ULTIMA_LECTURA_4.Start();

                    //EJECUTAR SUBPROCESO 3
                    CONEXION_4 = new Thread(() => COMPROBAR_CONEXION_LECTOR_4(ID_PORTAL));
                    CONEXION_4.Start();

                    //ESTADO HILO
                    ESTADO_COMPROBACION_READER_4 = true;

                }

                if (ESTADO_CONEXION == false)
                {
                    //DESCONECTAR LECTOR
                    m_IsConnected_4 = false;
                }
            }
            catch (Exception ex)
            {
                //REGISTRO DE LOG
                log.LogConectionEventos(ex.ToString(), IP_LECTOR, Convert.ToString(ID_PORTAL));

                //DESCONECTAR LECTOR
                m_IsConnected_4 = false;
            }

        }

        /// <summary>
        /// INICIALIZA EL READER DEL PORTAL 5
        /// </summary>
        public void INICIAR_LECTOR_5(int ID_PORTAL)
        {
            //PORTAL
            DATA_BASE.CONSULTAS portal = new DATA_BASE.CONSULTAS();
            //CONSUMIR CONSULTA
            DataTable dt = portal.CONSULTAR_ESTADO_PORTAL(ID_PORTAL);
            //ASIGNAR AL DATAROW Y ASI SELECCIONAR EL CAMPO A CONSULTAR
            DataRow dr = dt.Rows[0];

            //VARIABLES
            string ESTADO = dr["ESTADO"].ToString();
            string IP_LECTOR = dr["IP_LECTOR"].ToString();

            try
            {

                //////////////////////////////////////////////////////////////////////////////////////////
                //INICIAR LECTOR
                bool ESTADO_CONEXION = CONECTAR_LECTOR(IP_LECTOR, 0, 0, ID_PORTAL);


                if (ESTADO == "True" && ESTADO_CONEXION == true)
                {
                    //LECTURA BLACKLIST
                    LECTURA_BLACKLIST(ID_PORTAL);

                    //INICIAR REGISTRO DE LECTURAS
                    INICIAR_EVENTO_LECTURA(ID_PORTAL);

                    //INICIAR LECTURA
                    INICIAR_LECTURA(ID_PORTAL);

                    //EJECUTAR SUBPROCESO 1
                    HILO_LIMPIEZA_TAGS_5 = new Thread(CLEAR_ARRAY_5);
                    HILO_LIMPIEZA_TAGS_5.Start();

                    //EJECUTAR SUBPROCESO 2
                    ULTIMA_LECTURA_5 = new Thread(TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_5);
                    ULTIMA_LECTURA_5.Start();

                    //EJECUTAR SUBPROCESO 3
                    CONEXION_5 = new Thread(() => COMPROBAR_CONEXION_LECTOR_5(ID_PORTAL));
                    CONEXION_5.Start();

                    //ESTADO HILO
                    ESTADO_COMPROBACION_READER_5 = true;
                }

                if (ESTADO_CONEXION == false)
                {
                    //DESCONECTAR LECTOR
                    m_IsConnected_5 = false;
                }
            }
            catch (Exception ex)
            {
                //REGISTRO DE LOG
                log.LogConectionEventos(ex.ToString(), IP_LECTOR, Convert.ToString(ID_PORTAL));

                //DESCONECTAR LECTOR
                m_IsConnected_5 = false;
            }

        }

        /// <summary>
        /// INICIALIZA EL READER DEL PORTAL 6
        /// </summary>
        public void INICIAR_LECTOR_6(int ID_PORTAL)
        {
            //PORTAL
            DATA_BASE.CONSULTAS portal = new DATA_BASE.CONSULTAS();
            //CONSUMIR CONSULTA
            DataTable dt = portal.CONSULTAR_ESTADO_PORTAL(ID_PORTAL);
            //ASIGNAR AL DATAROW Y ASI SELECCIONAR EL CAMPO A CONSULTAR
            DataRow dr = dt.Rows[0];

            //VARIABLES
            string ESTADO = dr["ESTADO"].ToString();
            string IP_LECTOR = dr["IP_LECTOR"].ToString();


            try
            {
                //////////////////////////////////////////////////////////////////////////////////////////
                //INICIAR LECTOR
                bool ESTADO_CONEXION = CONECTAR_LECTOR(IP_LECTOR, 0, 0, ID_PORTAL);


                if (ESTADO == "True" && ESTADO_CONEXION == true)
                {
                    //LECTURA BLACKLIST
                    LECTURA_BLACKLIST(ID_PORTAL);

                    //INICIAR REGISTRO DE LECTURAS
                    INICIAR_EVENTO_LECTURA(ID_PORTAL);

                    //INICIAR LECTURA
                    INICIAR_LECTURA(ID_PORTAL);

                    //EJECUTAR SUBPROCESO 1
                    HILO_LIMPIEZA_TAGS_6 = new Thread(CLEAR_ARRAY_6);
                    HILO_LIMPIEZA_TAGS_6.Start();

                    //EJECUTAR SUBPROCESO 2
                    ULTIMA_LECTURA_6 = new Thread(TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_6);
                    ULTIMA_LECTURA_6.Start();

                    //EJECUTAR SUBPROCESO 3
                    CONEXION_6 = new Thread(() => COMPROBAR_CONEXION_LECTOR_6(ID_PORTAL));
                    CONEXION_6.Start();

                    //ESTADO HILO
                    ESTADO_COMPROBACION_READER_6 = true;
                }

                if (ESTADO_CONEXION == false)
                {
                    //DESCONECTAR LECTOR
                    m_IsConnected_6 = false;
                }
            }
            catch (Exception ex)
            {
                //REGISTRO DE LOG
                log.LogConectionEventos(ex.ToString(), IP_LECTOR, Convert.ToString(ID_PORTAL));

                //DESCONECTAR LECTOR
                m_IsConnected_6 = false;
            }

        }

        /// <summary>
        /// INICIALIZA EL READER DEL PORTAL 7
        /// </summary>
        public void INICIAR_LECTOR_7(int ID_PORTAL)
        {
            //PORTAL
            DATA_BASE.CONSULTAS portal = new DATA_BASE.CONSULTAS();
            //CONSUMIR CONSULTA
            DataTable dt = portal.CONSULTAR_ESTADO_PORTAL(ID_PORTAL);
            //ASIGNAR AL DATAROW Y ASI SELECCIONAR EL CAMPO A CONSULTAR
            DataRow dr = dt.Rows[0];

            //VARIABLES
            string ESTADO = dr["ESTADO"].ToString();
            string IP_LECTOR = dr["IP_LECTOR"].ToString();


            try
            {

                //////////////////////////////////////////////////////////////////////////////////////////
                //INICIAR LECTOR
                bool ESTADO_CONEXION = CONECTAR_LECTOR(IP_LECTOR, 0, 0, ID_PORTAL);


                if (ESTADO == "True" && ESTADO_CONEXION == true)
                {
                    //LECTURA BLACKLIST
                    LECTURA_BLACKLIST(ID_PORTAL);

                    //INICIAR REGISTRO DE LECTURAS
                    INICIAR_EVENTO_LECTURA(ID_PORTAL);

                    //INICIAR LECTURA
                    INICIAR_LECTURA(ID_PORTAL);

                    //EJECUTAR SUBPROCESO 1
                    HILO_LIMPIEZA_TAGS_7 = new Thread(CLEAR_ARRAY_7);
                    HILO_LIMPIEZA_TAGS_7.Start();

                    //EJECUTAR SUBPROCESO 2
                    ULTIMA_LECTURA_7 = new Thread(TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_7);
                    ULTIMA_LECTURA_7.Start();

                    //EJECUTAR SUBPROCESO 3
                    CONEXION_7 = new Thread(() => COMPROBAR_CONEXION_LECTOR_7(ID_PORTAL));
                    CONEXION_7.Start();

                    //ESTADO HILO
                    ESTADO_COMPROBACION_READER_7 = true;
                }

                if (ESTADO_CONEXION == false)
                {
                    //DESCONECTAR LECTOR
                    m_IsConnected_7 = false;
                }
            }
            catch (Exception ex)
            {
                //REGISTRO DE LOG
                log.LogConectionEventos(ex.ToString(), IP_LECTOR, Convert.ToString(ID_PORTAL));

                //DESCONECTAR LECTOR
                m_IsConnected_7 = false;
            }

        }

        /// <summary>
        /// INICIALIZA EL READER DEL PORTAL 8
        /// </summary>
        public void INICIAR_LECTOR_8(int ID_PORTAL)
        {
            //PORTAL
            DATA_BASE.CONSULTAS portal = new DATA_BASE.CONSULTAS();
            //CONSUMIR CONSULTA
            DataTable dt = portal.CONSULTAR_ESTADO_PORTAL(ID_PORTAL);
            //ASIGNAR AL DATAROW Y ASI SELECCIONAR EL CAMPO A CONSULTAR
            DataRow dr = dt.Rows[0];

            //VARIABLES
            string ESTADO = dr["ESTADO"].ToString();
            string IP_LECTOR = dr["IP_LECTOR"].ToString();


            try
            {

                //////////////////////////////////////////////////////////////////////////////////////////
                //INICIAR LECTOR
                bool ESTADO_CONEXION = CONECTAR_LECTOR(IP_LECTOR, 0, 0, ID_PORTAL);


                if (ESTADO == "True" && ESTADO_CONEXION == true)
                {
                    //LECTURA BLACKLIST
                    LECTURA_BLACKLIST(ID_PORTAL);

                    //INICIAR REGISTRO DE LECTURAS
                    INICIAR_EVENTO_LECTURA(ID_PORTAL);

                    //INICIAR LECTURA
                    INICIAR_LECTURA(ID_PORTAL);

                    //EJECUTAR SUBPROCESO 1
                    HILO_LIMPIEZA_TAGS_8 = new Thread(CLEAR_ARRAY_8);
                    HILO_LIMPIEZA_TAGS_8.Start();

                    //EJECUTAR SUBPROCESO 2
                    ULTIMA_LECTURA_8 = new Thread(TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_8);
                    ULTIMA_LECTURA_8.Start();

                    //EJECUTAR SUBPROCESO 3
                    CONEXION_8 = new Thread(() => COMPROBAR_CONEXION_LECTOR_8(ID_PORTAL));
                    CONEXION_8.Start();

                    //ESTADO HILO
                    ESTADO_COMPROBACION_READER_8 = true;
                }

                if (ESTADO_CONEXION == false)
                {
                    //DESCONECTAR LECTOR
                    m_IsConnected_8 = false;
                }
            }
            catch (Exception ex)
            {
                //REGISTRO DE LOG
                log.LogConectionEventos(ex.ToString(), IP_LECTOR, Convert.ToString(ID_PORTAL));

                //DESCONECTAR LECTOR
                m_IsConnected_8 = false;
            }

        }

        /// <summary>
        /// INICIALIZA EL READER DEL PORTAL 9
        /// </summary>
        public void INICIAR_LECTOR_9(int ID_PORTAL)
        {
            //PORTAL
            DATA_BASE.CONSULTAS portal = new DATA_BASE.CONSULTAS();
            //CONSUMIR CONSULTA
            DataTable dt = portal.CONSULTAR_ESTADO_PORTAL(ID_PORTAL);
            //ASIGNAR AL DATAROW Y ASI SELECCIONAR EL CAMPO A CONSULTAR
            DataRow dr = dt.Rows[0];

            //VARIABLES
            string ESTADO = dr["ESTADO"].ToString();
            string IP_LECTOR = dr["IP_LECTOR"].ToString();

            try
            {
                //////////////////////////////////////////////////////////////////////////////////////////
                //INICIAR LECTOR
                bool ESTADO_CONEXION = CONECTAR_LECTOR(IP_LECTOR, 0, 0, ID_PORTAL);


                if (ESTADO == "True" && ESTADO_CONEXION == true)
                {
                    //LECTURA BLACKLIST
                    LECTURA_BLACKLIST(ID_PORTAL);

                    //INICIAR REGISTRO DE LECTURAS
                    INICIAR_EVENTO_LECTURA(ID_PORTAL);

                    //INICIAR LECTURA
                    INICIAR_LECTURA(ID_PORTAL);

                    //EJECUTAR SUBPROCESO 1
                    HILO_LIMPIEZA_TAGS_9 = new Thread(CLEAR_ARRAY_9);
                    HILO_LIMPIEZA_TAGS_9.Start();

                    //EJECUTAR SUBPROCESO 2
                    ULTIMA_LECTURA_9 = new Thread(TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_9);
                    ULTIMA_LECTURA_9.Start();

                    //EJECUTAR SUBPROCESO 3
                    CONEXION_9 = new Thread(() => COMPROBAR_CONEXION_LECTOR_9(ID_PORTAL));
                    CONEXION_9.Start();

                    //ESTADO HILO
                    ESTADO_COMPROBACION_READER_9 = true;
                }

                if (ESTADO_CONEXION == false)
                {
                    //DESCONECTAR LECTOR
                    m_IsConnected_9 = false;
                }
            }
            catch (Exception ex)
            {
                //REGISTRO DE LOG
                log.LogConectionEventos(ex.ToString(), IP_LECTOR, Convert.ToString(ID_PORTAL));

                //DESCONECTAR LECTOR
                m_IsConnected_9 = false;
            }

        }

        /// <summary>
        /// INICIALIZA EL READER DEL PORTAL 10
        /// </summary>
        public void INICIAR_LECTOR_10(int ID_PORTAL)
        {
            //PORTAL
            DATA_BASE.CONSULTAS portal = new DATA_BASE.CONSULTAS();
            //CONSUMIR CONSULTA
            DataTable dt = portal.CONSULTAR_ESTADO_PORTAL(ID_PORTAL);
            //ASIGNAR AL DATAROW Y ASI SELECCIONAR EL CAMPO A CONSULTAR
            DataRow dr = dt.Rows[0];

            //VARIABLES
            string ESTADO = dr["ESTADO"].ToString();
            string IP_LECTOR = dr["IP_LECTOR"].ToString();


            try
            {
                //////////////////////////////////////////////////////////////////////////////////////////
                //INICIAR LECTOR
                bool ESTADO_CONEXION = CONECTAR_LECTOR(IP_LECTOR, 0, 0, ID_PORTAL);


                if (ESTADO == "True" && ESTADO_CONEXION == true)
                {
                    //LECTURA BLACKLIST
                    LECTURA_BLACKLIST(ID_PORTAL);

                    //INICIAR REGISTRO DE LECTURAS
                    INICIAR_EVENTO_LECTURA(ID_PORTAL);

                    //INICIAR LECTURA
                    INICIAR_LECTURA(ID_PORTAL);

                    //EJECUTAR SUBPROCESO 1
                    HILO_LIMPIEZA_TAGS_10 = new Thread(CLEAR_ARRAY_10);
                    HILO_LIMPIEZA_TAGS_10.Start();

                    //EJECUTAR SUBPROCESO 2
                    ULTIMA_LECTURA_10 = new Thread(TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_10);
                    ULTIMA_LECTURA_10.Start();

                    //EJECUTAR SUBPROCESO 3
                    CONEXION_10 = new Thread(() => COMPROBAR_CONEXION_LECTOR_10(ID_PORTAL));
                    CONEXION_10.Start();

                    //ESTADO HILO
                    ESTADO_COMPROBACION_READER_10 = true;
                }

                if (ESTADO_CONEXION == false)
                {
                    //DESCONECTAR LECTOR
                    m_IsConnected_10 = false;
                }
            }
            catch (Exception ex)
            {
                //REGISTRO DE LOG
                log.LogConectionEventos(ex.ToString(), IP_LECTOR, Convert.ToString(ID_PORTAL));

                //DESCONECTAR LECTOR
                m_IsConnected_10 = false;
            }

        }

        /// <summary>
        /// INICIALIZA EL READER DEL PORTAL 11
        /// </summary>
        public void INICIAR_LECTOR_11(int ID_PORTAL)
        {
            //PORTAL
            DATA_BASE.CONSULTAS portal = new DATA_BASE.CONSULTAS();
            //CONSUMIR CONSULTA
            DataTable dt = portal.CONSULTAR_ESTADO_PORTAL(ID_PORTAL);
            //ASIGNAR AL DATAROW Y ASI SELECCIONAR EL CAMPO A CONSULTAR
            DataRow dr = dt.Rows[0];

            //VARIABLES
            string ESTADO = dr["ESTADO"].ToString();
            string IP_LECTOR = dr["IP_LECTOR"].ToString();


            try
            {

                //////////////////////////////////////////////////////////////////////////////////////////
                //INICIAR LECTOR
                bool ESTADO_CONEXION = CONECTAR_LECTOR(IP_LECTOR, 0, 0, ID_PORTAL);


                if (ESTADO == "True" && ESTADO_CONEXION == true)
                {
                    //LECTURA BLACKLIST
                    LECTURA_BLACKLIST(ID_PORTAL);

                    //INICIAR REGISTRO DE LECTURAS
                    INICIAR_EVENTO_LECTURA(ID_PORTAL);

                    //INICIAR LECTURA
                    INICIAR_LECTURA(ID_PORTAL);

                    //EJECUTAR SUBPROCESO 1
                    HILO_LIMPIEZA_TAGS_11 = new Thread(CLEAR_ARRAY_11);
                    HILO_LIMPIEZA_TAGS_11.Start();

                    //EJECUTAR SUBPROCESO 2
                    ULTIMA_LECTURA_11 = new Thread(TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_11);
                    ULTIMA_LECTURA_11.Start();

                    //EJECUTAR SUBPROCESO 3
                    CONEXION_11 = new Thread(() => COMPROBAR_CONEXION_LECTOR_11(ID_PORTAL));
                    CONEXION_11.Start();
                    //ESTADO HILO
                    ESTADO_COMPROBACION_READER_11 = true;
                }

                if (ESTADO_CONEXION == false)
                {
                    //DESCONECTAR LECTOR
                    m_IsConnected_11 = false;
                }
            }
            catch (Exception ex)
            {
                //REGISTRO DE LOG
                log.LogConectionEventos(ex.ToString(), IP_LECTOR, Convert.ToString(ID_PORTAL));

                //DESCONECTAR LECTOR
                m_IsConnected_11 = false;
            }

        }

        /// <summary>
        /// INICIALIZA EL READER DEL PORTAL 12
        /// </summary>
        public void INICIAR_LECTOR_12(int ID_PORTAL)
        {
            //PORTAL
            DATA_BASE.CONSULTAS portal = new DATA_BASE.CONSULTAS();
            //CONSUMIR CONSULTA
            DataTable dt = portal.CONSULTAR_ESTADO_PORTAL(ID_PORTAL);
            //ASIGNAR AL DATAROW Y ASI SELECCIONAR EL CAMPO A CONSULTAR
            DataRow dr = dt.Rows[0];

            //VARIABLES
            string ESTADO = dr["ESTADO"].ToString();
            string IP_LECTOR = dr["IP_LECTOR"].ToString();


            try
            {

                //////////////////////////////////////////////////////////////////////////////////////////
                //INICIAR LECTOR
                bool ESTADO_CONEXION = CONECTAR_LECTOR(IP_LECTOR, 0, 0, ID_PORTAL);


                if (ESTADO == "True" && ESTADO_CONEXION == true)
                {

                    //LECTURA BLACKLIST
                    LECTURA_BLACKLIST(ID_PORTAL);

                    //INICIAR REGISTRO DE LECTURAS
                    INICIAR_EVENTO_LECTURA(ID_PORTAL);

                    //INICIAR LECTURA
                    INICIAR_LECTURA(ID_PORTAL);

                    //EJECUTAR SUBPROCESO 1
                    HILO_LIMPIEZA_TAGS_12 = new Thread(CLEAR_ARRAY_12);
                    HILO_LIMPIEZA_TAGS_12.Start();

                    //EJECUTAR SUBPROCESO 2
                    ULTIMA_LECTURA_12 = new Thread(TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_12);
                    ULTIMA_LECTURA_12.Start();

                    //EJECUTAR SUBPROCESO 3
                    CONEXION_12 = new Thread(() => COMPROBAR_CONEXION_LECTOR_12(ID_PORTAL));
                    CONEXION_12.Start();

                    //ESTADO HILO
                    ESTADO_COMPROBACION_READER_12 = true;
                }

                if (ESTADO_CONEXION == false)
                {
                    //DESCONECTAR LECTOR
                    m_IsConnected_12 = false;
                }
            }
            catch (Exception ex)
            {
                //REGISTRO DE LOG
                log.LogConectionEventos(ex.ToString(), IP_LECTOR, Convert.ToString(ID_PORTAL));

                //DESCONECTAR LECTOR
                m_IsConnected_12 = false;
            }

        }

        /// <summary>
        /// INICIALIZA EL READER DEL PORTAL 13
        /// </summary>
        public void INICIAR_LECTOR_13(int ID_PORTAL)
        {
            //PORTAL
            DATA_BASE.CONSULTAS portal = new DATA_BASE.CONSULTAS();
            //CONSUMIR CONSULTA
            DataTable dt = portal.CONSULTAR_ESTADO_PORTAL(ID_PORTAL);
            //ASIGNAR AL DATAROW Y ASI SELECCIONAR EL CAMPO A CONSULTAR
            DataRow dr = dt.Rows[0];

            //VARIABLES
            string ESTADO = dr["ESTADO"].ToString();
            string IP_LECTOR = dr["IP_LECTOR"].ToString();

            try
            {

                //////////////////////////////////////////////////////////////////////////////////////////
                //INICIAR LECTOR
                bool ESTADO_CONEXION = CONECTAR_LECTOR(IP_LECTOR, 0, 0, ID_PORTAL);


                if (ESTADO == "True" && ESTADO_CONEXION == true)
                {
                    //LECTURA BLACKLIST
                    LECTURA_BLACKLIST(ID_PORTAL);

                    //INICIAR REGISTRO DE LECTURAS
                    INICIAR_EVENTO_LECTURA(ID_PORTAL);

                    //INICIAR LECTURA
                    INICIAR_LECTURA(ID_PORTAL);

                    //EJECUTAR SUBPROCESO 1
                    HILO_LIMPIEZA_TAGS_13 = new Thread(CLEAR_ARRAY_13);
                    HILO_LIMPIEZA_TAGS_13.Start();

                    //EJECUTAR SUBPROCESO 2
                    ULTIMA_LECTURA_13 = new Thread(TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_13);
                    ULTIMA_LECTURA_13.Start();

                    //EJECUTAR SUBPROCESO 3
                    CONEXION_13 = new Thread(() => COMPROBAR_CONEXION_LECTOR_13(ID_PORTAL));
                    CONEXION_13.Start();

                    //ESTADO HILO
                    ESTADO_COMPROBACION_READER_13 = true;
                }

                if (ESTADO_CONEXION == false)
                {
                    //DESCONECTAR LECTOR
                    m_IsConnected_13 = false;
                }
            }
            catch (Exception ex)
            {
                //REGISTRO DE LOG
                log.LogConectionEventos(ex.ToString(), IP_LECTOR, Convert.ToString(ID_PORTAL));

                //DESCONECTAR LECTOR
                m_IsConnected_13 = false;
            }

        }

        /// <summary>
        /// INICIALIZA EL READER DEL PORTAL 14
        /// </summary>
        public void INICIAR_LECTOR_14(int ID_PORTAL)
        {
            //PORTAL
            DATA_BASE.CONSULTAS portal = new DATA_BASE.CONSULTAS();
            //CONSUMIR CONSULTA
            DataTable dt = portal.CONSULTAR_ESTADO_PORTAL(ID_PORTAL);
            //ASIGNAR AL DATAROW Y ASI SELECCIONAR EL CAMPO A CONSULTAR
            DataRow dr = dt.Rows[0];

            //VARIABLES
            string ESTADO = dr["ESTADO"].ToString();
            string IP_LECTOR = dr["IP_LECTOR"].ToString();


            try
            {

                //////////////////////////////////////////////////////////////////////////////////////////
                //INICIAR LECTOR
                bool ESTADO_CONEXION = CONECTAR_LECTOR(IP_LECTOR, 0, 0, ID_PORTAL);


                if (ESTADO == "True" && ESTADO_CONEXION == true)
                {
                    //LECTURA BLACKLIST
                    LECTURA_BLACKLIST(ID_PORTAL);

                    //INICIAR REGISTRO DE LECTURAS
                    INICIAR_EVENTO_LECTURA(ID_PORTAL);

                    //INICIAR LECTURA
                    INICIAR_LECTURA(ID_PORTAL);

                    //EJECUTAR SUBPROCESO 1
                    HILO_LIMPIEZA_TAGS_14 = new Thread(CLEAR_ARRAY_14);
                    HILO_LIMPIEZA_TAGS_14.Start();

                    //EJECUTAR SUBPROCESO 2
                    ULTIMA_LECTURA_14 = new Thread(TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_14);
                    ULTIMA_LECTURA_14.Start();

                    //EJECUTAR SUBPROCESO 3
                    CONEXION_14 = new Thread(() => COMPROBAR_CONEXION_LECTOR_14(ID_PORTAL));
                    CONEXION_14.Start();

                    //ESTADO HILO
                    ESTADO_COMPROBACION_READER_14 = true;
                }

                if (ESTADO_CONEXION == false)
                {
                    //DESCONECTAR LECTOR
                    m_IsConnected_14 = false;
                }
            }
            catch (Exception ex)
            {
                //REGISTRO DE LOG
                log.LogConectionEventos(ex.ToString(), IP_LECTOR, Convert.ToString(ID_PORTAL));

                //DESCONECTAR LECTOR
                m_IsConnected_14 = false;
            }

        }

        /// <summary>
        /// INICIALIZA EL READER DEL PORTAL 15
        /// </summary>
        public void INICIAR_LECTOR_15(int ID_PORTAL)
        {
            //PORTAL
            DATA_BASE.CONSULTAS portal = new DATA_BASE.CONSULTAS();
            //CONSUMIR CONSULTA
            DataTable dt = portal.CONSULTAR_ESTADO_PORTAL(ID_PORTAL);
            //ASIGNAR AL DATAROW Y ASI SELECCIONAR EL CAMPO A CONSULTAR
            DataRow dr = dt.Rows[0];

            //VARIABLES
            string ESTADO = dr["ESTADO"].ToString();
            string IP_LECTOR = dr["IP_LECTOR"].ToString();

            try
            {

                //////////////////////////////////////////////////////////////////////////////////////////
                //INICIAR LECTOR
                bool ESTADO_CONEXION = CONECTAR_LECTOR(IP_LECTOR, 0, 0, ID_PORTAL);


                if (ESTADO == "True" && ESTADO_CONEXION == true)
                {
                    //LECTURA BLACKLIST
                    LECTURA_BLACKLIST(ID_PORTAL);

                    //INICIAR REGISTRO DE LECTURAS
                    INICIAR_EVENTO_LECTURA(ID_PORTAL);

                    //INICIAR LECTURA
                    INICIAR_LECTURA(ID_PORTAL);

                    //EJECUTAR SUBPROCESO 1
                    HILO_LIMPIEZA_TAGS_15 = new Thread(CLEAR_ARRAY_15);
                    HILO_LIMPIEZA_TAGS_15.Start();

                    //EJECUTAR SUBPROCESO 2
                    ULTIMA_LECTURA_15 = new Thread(TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_15);
                    ULTIMA_LECTURA_15.Start();

                    //EJECUTAR SUBPROCESO 3
                    CONEXION_15 = new Thread(() => COMPROBAR_CONEXION_LECTOR_15(ID_PORTAL));
                    CONEXION_15.Start();

                    //ESTADO HILO
                    ESTADO_COMPROBACION_READER_15 = true;
                }

                if (ESTADO_CONEXION == false)
                {
                    //DESCONECTAR LECTOR
                    m_IsConnected_15 = false;
                }
            }
            catch (Exception ex)
            {
                //REGISTRO DE LOG
                log.LogConectionEventos(ex.ToString(), IP_LECTOR, Convert.ToString(ID_PORTAL));

                //DESCONECTAR LECTOR
                m_IsConnected_15 = false;
            }

        }

        /// <summary>
        /// INICIALIZA EL READER DEL PORTAL 16
        /// </summary>
        public void INICIAR_LECTOR_16(int ID_PORTAL)
        {
            //PORTAL
            DATA_BASE.CONSULTAS portal = new DATA_BASE.CONSULTAS();
            //CONSUMIR CONSULTA
            DataTable dt = portal.CONSULTAR_ESTADO_PORTAL(ID_PORTAL);
            //ASIGNAR AL DATAROW Y ASI SELECCIONAR EL CAMPO A CONSULTAR
            DataRow dr = dt.Rows[0];

            //VARIABLES
            string ESTADO = dr["ESTADO"].ToString();
            string IP_LECTOR = dr["IP_LECTOR"].ToString();

            try
            {

                //////////////////////////////////////////////////////////////////////////////////////////
                //INICIAR LECTOR
                bool ESTADO_CONEXION = CONECTAR_LECTOR(IP_LECTOR, 0, 0, ID_PORTAL);


                if (ESTADO == "True" && ESTADO_CONEXION == true)
                {
                    //LECTURA BLACKLIST
                    LECTURA_BLACKLIST(ID_PORTAL);

                    //INICIAR REGISTRO DE LECTURAS
                    INICIAR_EVENTO_LECTURA(ID_PORTAL);

                    //INICIAR LECTURA
                    INICIAR_LECTURA(ID_PORTAL);

                    //EJECUTAR SUBPROCESO 1
                    HILO_LIMPIEZA_TAGS_16 = new Thread(CLEAR_ARRAY_16);
                    HILO_LIMPIEZA_TAGS_16.Start();

                    //EJECUTAR SUBPROCESO 2
                    ULTIMA_LECTURA_16 = new Thread(TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_16);
                    ULTIMA_LECTURA_16.Start();

                    //EJECUTAR SUBPROCESO 3
                    CONEXION_16 = new Thread(() => COMPROBAR_CONEXION_LECTOR_16(ID_PORTAL));
                    CONEXION_16.Start();

                    //ESTADO HILO
                    ESTADO_COMPROBACION_READER_16 = true;
                }

                if (ESTADO_CONEXION == false)
                {
                    //DESCONECTAR LECTOR
                    m_IsConnected_16 = false;
                }
            }
            catch (Exception ex)
            {
                //REGISTRO DE LOG
                log.LogConectionEventos(ex.ToString(), IP_LECTOR, Convert.ToString(ID_PORTAL));

                //DESCONECTAR LECTOR
                m_IsConnected_16 = false;
            }

        }

        /// <summary>
        /// INICIALIZA EL READER DEL PORTAL 17
        /// </summary>
        public void INICIAR_LECTOR_17(int ID_PORTAL)
        {
            //PORTAL
            DATA_BASE.CONSULTAS portal = new DATA_BASE.CONSULTAS();
            //CONSUMIR CONSULTA
            DataTable dt = portal.CONSULTAR_ESTADO_PORTAL(ID_PORTAL);
            //ASIGNAR AL DATAROW Y ASI SELECCIONAR EL CAMPO A CONSULTAR
            DataRow dr = dt.Rows[0];

            //VARIABLES
            string ESTADO = dr["ESTADO"].ToString();
            string IP_LECTOR = dr["IP_LECTOR"].ToString();


            try
            {

                //////////////////////////////////////////////////////////////////////////////////////////
                //INICIAR LECTOR
                bool ESTADO_CONEXION = CONECTAR_LECTOR(IP_LECTOR, 0, 0, ID_PORTAL);


                if (ESTADO == "True" && ESTADO_CONEXION == true)
                {
                    //LECTURA BLACKLIST
                    LECTURA_BLACKLIST(ID_PORTAL);

                    //INICIAR REGISTRO DE LECTURAS
                    INICIAR_EVENTO_LECTURA(ID_PORTAL);

                    //INICIAR LECTURA
                    INICIAR_LECTURA(ID_PORTAL);

                    //EJECUTAR SUBPROCESO 1
                    HILO_LIMPIEZA_TAGS_17 = new Thread(CLEAR_ARRAY_17);
                    HILO_LIMPIEZA_TAGS_17.Start();

                    //EJECUTAR SUBPROCESO 2
                    ULTIMA_LECTURA_17 = new Thread(TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_17);
                    ULTIMA_LECTURA_17.Start();

                    //EJECUTAR SUBPROCESO 3
                    CONEXION_17 = new Thread(() => COMPROBAR_CONEXION_LECTOR_17(ID_PORTAL));
                    CONEXION_17.Start();

                    //ESTADO HILO
                    ESTADO_COMPROBACION_READER_17 = true;
                }

                if (ESTADO_CONEXION == false)
                {
                    //DESCONECTAR LECTOR
                    m_IsConnected_17 = false;
                }
            }
            catch (Exception ex)
            {
                //REGISTRO DE LOG
                log.LogConectionEventos(ex.ToString(), IP_LECTOR, Convert.ToString(ID_PORTAL));

                //DESCONECTAR LECTOR
                m_IsConnected_17 = false;
            }

        }

        /// <summary>
        /// INICIALIZA EL READER DEL PORTAL 18
        /// </summary>
        public void INICIAR_LECTOR_18(int ID_PORTAL)
        {
            //PORTAL
            DATA_BASE.CONSULTAS portal = new DATA_BASE.CONSULTAS();
            //CONSUMIR CONSULTA
            DataTable dt = portal.CONSULTAR_ESTADO_PORTAL(ID_PORTAL);
            //ASIGNAR AL DATAROW Y ASI SELECCIONAR EL CAMPO A CONSULTAR
            DataRow dr = dt.Rows[0];

            //VARIABLES
            string ESTADO = dr["ESTADO"].ToString();
            string IP_LECTOR = dr["IP_LECTOR"].ToString();

            try
            {

                //////////////////////////////////////////////////////////////////////////////////////////
                //INICIAR LECTOR
                bool ESTADO_CONEXION = CONECTAR_LECTOR(IP_LECTOR, 0, 0, ID_PORTAL);


                if (ESTADO == "True" && ESTADO_CONEXION == true)
                {
                    //LECTURA BLACKLIST
                    LECTURA_BLACKLIST(ID_PORTAL);

                    //INICIAR REGISTRO DE LECTURAS
                    INICIAR_EVENTO_LECTURA(ID_PORTAL);

                    //INICIAR LECTURA
                    INICIAR_LECTURA(ID_PORTAL);

                    //EJECUTAR SUBPROCESO 1
                    HILO_LIMPIEZA_TAGS_18 = new Thread(CLEAR_ARRAY_18);
                    HILO_LIMPIEZA_TAGS_18.Start();

                    //EJECUTAR SUBPROCESO 2
                    ULTIMA_LECTURA_18 = new Thread(TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_18);
                    ULTIMA_LECTURA_18.Start();

                    //EJECUTAR SUBPROCESO 3
                    CONEXION_18 = new Thread(() => COMPROBAR_CONEXION_LECTOR_18(ID_PORTAL));
                    CONEXION_18.Start();

                    //ESTADO HILO
                    ESTADO_COMPROBACION_READER_18 = true;
                }

                if (ESTADO_CONEXION == false)
                {
                    //DESCONECTAR LECTOR
                    m_IsConnected_18 = false;
                }
            }
            catch (Exception ex)
            {
                //REGISTRO DE LOG
                log.LogConectionEventos(ex.ToString(), IP_LECTOR, Convert.ToString(ID_PORTAL));

                //DESCONECTAR LECTOR
                m_IsConnected_18 = false;
            }

        }

        /// <summary>
        /// INICIALIZA EL READER DEL PORTAL 19
        /// </summary>
        public void INICIAR_LECTOR_19(int ID_PORTAL)
        {
            //PORTAL
            DATA_BASE.CONSULTAS portal = new DATA_BASE.CONSULTAS();
            //CONSUMIR CONSULTA
            DataTable dt = portal.CONSULTAR_ESTADO_PORTAL(ID_PORTAL);
            //ASIGNAR AL DATAROW Y ASI SELECCIONAR EL CAMPO A CONSULTAR
            DataRow dr = dt.Rows[0];

            //VARIABLES
            string ESTADO = dr["ESTADO"].ToString();
            string IP_LECTOR = dr["IP_LECTOR"].ToString();


            try
            {

                //////////////////////////////////////////////////////////////////////////////////////////
                //INICIAR LECTOR
                bool ESTADO_CONEXION = CONECTAR_LECTOR(IP_LECTOR, 0, 0, ID_PORTAL);


                if (ESTADO == "True" && ESTADO_CONEXION == true)
                {
                    //LECTURA BLACKLIST
                    LECTURA_BLACKLIST(ID_PORTAL);

                    //INICIAR REGISTRO DE LECTURAS
                    INICIAR_EVENTO_LECTURA(ID_PORTAL);

                    //INICIAR LECTURA
                    INICIAR_LECTURA(ID_PORTAL);

                    //EJECUTAR SUBPROCESO 1
                    HILO_LIMPIEZA_TAGS_19 = new Thread(CLEAR_ARRAY_19);
                    HILO_LIMPIEZA_TAGS_19.Start();

                    //EJECUTAR SUBPROCESO 2
                    ULTIMA_LECTURA_19 = new Thread(TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_19);
                    ULTIMA_LECTURA_19.Start();

                    //EJECUTAR SUBPROCESO 3
                    CONEXION_19 = new Thread(() => COMPROBAR_CONEXION_LECTOR_19(ID_PORTAL));
                    CONEXION_19.Start();

                    //ESTADO HILO
                    ESTADO_COMPROBACION_READER_19 = true;
                }

                if (ESTADO_CONEXION == false)
                {
                    //DESCONECTAR LECTOR
                    m_IsConnected_19 = false;
                }
            }
            catch (Exception ex)
            {
                //REGISTRO DE LOG
                log.LogConectionEventos(ex.ToString(), IP_LECTOR, Convert.ToString(ID_PORTAL));

                //DESCONECTAR LECTOR
                m_IsConnected_19 = false;
            }

        }

        /// <summary>
        /// INICIALIZA EL READER DEL PORTAL 20
        /// </summary>
        public void INICIAR_LECTOR_20(int ID_PORTAL)
        {
            //PORTAL
            DATA_BASE.CONSULTAS portal = new DATA_BASE.CONSULTAS();
            //CONSUMIR CONSULTA
            DataTable dt = portal.CONSULTAR_ESTADO_PORTAL(ID_PORTAL);
            //ASIGNAR AL DATAROW Y ASI SELECCIONAR EL CAMPO A CONSULTAR
            DataRow dr = dt.Rows[0];

            //VARIABLES
            string ESTADO = dr["ESTADO"].ToString();
            string IP_LECTOR = dr["IP_LECTOR"].ToString();

            try
            {
                //////////////////////////////////////////////////////////////////////////////////////////
                //INICIAR LECTOR
                bool ESTADO_CONEXION = CONECTAR_LECTOR(IP_LECTOR, 0, 0, ID_PORTAL);


                if (ESTADO == "True" && ESTADO_CONEXION == true)
                {
                    //LECTURA BLACKLIST
                    LECTURA_BLACKLIST(ID_PORTAL);

                    //INICIAR REGISTRO DE LECTURAS
                    INICIAR_EVENTO_LECTURA(ID_PORTAL);

                    //INICIAR LECTURA
                    INICIAR_LECTURA(ID_PORTAL);

                    //EJECUTAR SUBPROCESO 1
                    HILO_LIMPIEZA_TAGS_20 = new Thread(CLEAR_ARRAY_20);
                    HILO_LIMPIEZA_TAGS_20.Start();

                    //EJECUTAR SUBPROCESO 2
                    ULTIMA_LECTURA_20 = new Thread(TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_20);
                    ULTIMA_LECTURA_20.Start();

                    //EJECUTAR SUBPROCESO 3
                    CONEXION_20 = new Thread(() => COMPROBAR_CONEXION_LECTOR_20(ID_PORTAL));
                    CONEXION_20.Start();

                    //ESTADO HILO
                    ESTADO_COMPROBACION_READER_20 = true;
                }

                if (ESTADO_CONEXION == false)
                {
                    //DESCONECTAR LECTOR
                    m_IsConnected_20 = false;
                }
            }
            catch (Exception ex)
            {
                //REGISTRO DE LOG
                log.LogConectionEventos(ex.ToString(), IP_LECTOR, Convert.ToString(ID_PORTAL));

                //DESCONECTAR LECTOR
                m_IsConnected_20 = false;
            }

        }


        #endregion

        //----------------------

        #region CONECTAR/DESCONECTAR READER



        /// <summary>
        /// CONECTAR EL LECTOR
        /// </summary>
        private bool CONECTAR_LECTOR(string hostname, int tagCB, int eventCB, int ID_PORTAL)
        {
            bool Conexion = false;

            try
            {

                if (ID_PORTAL == 1)
                {
                    #region CONEXION

                    ///////////////////////
                    //VALIDAR SI EL RFID READER ESTA CONECTADO
                    if (m_IsConnected_1 != true)
                    {
                        /////////////////////
                        //PARAMETROS
                        string IP_READER = hostname;
                        uint PUERTO = uint.Parse("5084");

                        //---------------------------------------------------------------------------------------
                        RFID_READER_1 = new RFIDReader(IP_READER, PUERTO, 0);

                        try
                        {
                            RFID_READER_1.Connect();
                            m_IsConnected_1 = true;

                            //REGISTRO DE EVENTOS
                            RFID_READER_1.Actions.PreFilters.DeleteAll();
                            RFID_READER_1.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify_Reader_1);
                            RFID_READER_1.Events.AttachTagDataWithReadEvent = false;
                            RFID_READER_1.Events.NotifyGPIEvent = true;
                            RFID_READER_1.Events.NotifyAntennaEvent = true;
                            RFID_READER_1.Events.NotifyReaderDisconnectEvent = true;
                            RFID_READER_1.Events.NotifyBufferFullEvent = true;
                            RFID_READER_1.Events.NotifyBufferFullWarningEvent = true;
                            RFID_READER_1.Events.NotifyAccessStartEvent = true;
                            RFID_READER_1.Events.NotifyAccessStopEvent = true;
                            RFID_READER_1.Events.NotifyInventoryStartEvent = true;
                            RFID_READER_1.Events.NotifyInventoryStopEvent = true;
                            RFID_READER_1.Events.NotifyReaderExceptionEvent = true;

                            Conexion = true;

                            return true;
                        }
                        catch (OperationFailureException ex)
                        {
                            //REGISTRO DE LOG
                            log.LogConectionReader(ex.ToString(), IP_READER, Convert.ToString(ID_PORTAL));

                            m_IsConnected_1 = false;
                            return false;
                        }
                    }
                    else
                    {
                        Conexion = true;
                    }



                    #endregion
                }
                else if (ID_PORTAL == 2)
                {
                    #region CONEXION

                    ///////////////////////
                    //VALIDAR SI EL RFID READER ESTA CONECTADO
                    if (m_IsConnected_2 != true)
                    {
                        /////////////////////
                        //PARAMETROS
                        string IP_READER = hostname;
                        uint PUERTO = uint.Parse("5084");

                        //---------------------------------------------------------------------------------------
                        RFID_READER_2 = new RFIDReader(IP_READER, PUERTO, 0);

                        try
                        {
                            RFID_READER_2.Connect();
                            m_IsConnected_2 = true;

                            //REGISTRO DE EVENTOS
                            RFID_READER_2.Actions.PreFilters.DeleteAll();
                            RFID_READER_2.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify_Reader_2);
                            RFID_READER_2.Events.AttachTagDataWithReadEvent = false;
                            RFID_READER_2.Events.NotifyGPIEvent = true;
                            RFID_READER_2.Events.NotifyAntennaEvent = true;
                            RFID_READER_2.Events.NotifyReaderDisconnectEvent = true;
                            RFID_READER_2.Events.NotifyBufferFullEvent = true;
                            RFID_READER_2.Events.NotifyBufferFullWarningEvent = true;
                            RFID_READER_2.Events.NotifyAccessStartEvent = true;
                            RFID_READER_2.Events.NotifyAccessStopEvent = true;
                            RFID_READER_2.Events.NotifyInventoryStartEvent = true;
                            RFID_READER_2.Events.NotifyInventoryStopEvent = true;
                            RFID_READER_2.Events.NotifyReaderExceptionEvent = true;

                            Conexion = true;
                            return true;
                        }
                        catch (OperationFailureException ex)
                        {
                            //REGISTRO DE LOG
                            log.LogConectionReader(ex.ToString(), IP_READER, Convert.ToString(ID_PORTAL));

                            m_IsConnected_2 = false;
                            return false;
                        }
                    }
                    else
                    {
                        Conexion = true;
                    }



                    #endregion
                }
                else if (ID_PORTAL == 3)
                {
                    #region CONEXION

                    ///////////////////////
                    //VALIDAR SI EL RFID READER ESTA CONECTADO
                    if (m_IsConnected_3 != true)
                    {
                        /////////////////////
                        //PARAMETROS
                        string IP_READER = hostname;
                        uint PUERTO = uint.Parse("5084");

                        //---------------------------------------------------------------------------------------
                        RFID_READER_3 = new RFIDReader(IP_READER, PUERTO, 0);

                        try
                        {
                            RFID_READER_3.Connect();
                            m_IsConnected_3 = true;

                            //REGISTRO DE EVENTOS
                            RFID_READER_3.Actions.PreFilters.DeleteAll();
                            RFID_READER_3.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify_Reader_3);
                            RFID_READER_3.Events.AttachTagDataWithReadEvent = false;
                            RFID_READER_3.Events.NotifyGPIEvent = true;
                            RFID_READER_3.Events.NotifyAntennaEvent = true;
                            RFID_READER_3.Events.NotifyReaderDisconnectEvent = true;
                            RFID_READER_3.Events.NotifyBufferFullEvent = true;
                            RFID_READER_3.Events.NotifyBufferFullWarningEvent = true;
                            RFID_READER_3.Events.NotifyAccessStartEvent = true;
                            RFID_READER_3.Events.NotifyAccessStopEvent = true;
                            RFID_READER_3.Events.NotifyInventoryStartEvent = true;
                            RFID_READER_3.Events.NotifyInventoryStopEvent = true;
                            RFID_READER_3.Events.NotifyReaderExceptionEvent = true;

                            Conexion = true;

                            return true;
                        }
                        catch (Exception ex)
                        {
                            //REGISTRO DE LOG
                            log.LogConectionReader(ex.ToString(), IP_READER, Convert.ToString(ID_PORTAL));

                            m_IsConnected_3 = false;
                            return false;
                        }
                    }
                    else
                    {
                        Conexion = true;
                    }

                    #endregion
                }
                else if (ID_PORTAL == 4)
                {
                    #region CONEXION

                    ///////////////////////
                    //VALIDAR SI EL RFID READER ESTA CONECTADO
                    if (m_IsConnected_4 != true)
                    {
                        /////////////////////
                        //PARAMETROS
                        string IP_READER = hostname;
                        uint PUERTO = uint.Parse("5084");
                        RFID_READER_4 = null;

                        //---------------------------------------------------------------------------------------
                        RFID_READER_4 = new RFIDReader(IP_READER, 0, 0);

                        try
                        {
                            RFID_READER_4.Connect();
                            m_IsConnected_4 = true;

                            //REGISTRO DE EVENTOS
                            RFID_READER_4.Actions.PreFilters.DeleteAll();
                            RFID_READER_4.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify_Reader_4);
                            RFID_READER_4.Events.AttachTagDataWithReadEvent = false;
                            RFID_READER_4.Events.NotifyGPIEvent = true;
                            RFID_READER_4.Events.NotifyAntennaEvent = true;
                            RFID_READER_4.Events.NotifyReaderDisconnectEvent = true;
                            RFID_READER_4.Events.NotifyBufferFullEvent = true;
                            RFID_READER_4.Events.NotifyBufferFullWarningEvent = true;
                            RFID_READER_4.Events.NotifyAccessStartEvent = true;
                            RFID_READER_4.Events.NotifyAccessStopEvent = true;
                            RFID_READER_4.Events.NotifyInventoryStartEvent = true;
                            RFID_READER_4.Events.NotifyInventoryStopEvent = true;
                            RFID_READER_4.Events.NotifyReaderExceptionEvent = true;

                            Conexion = true;

                            return true;
                        }
                        catch (Exception ex)
                        {
                            //REGISTRO DE LOG
                            log.LogConectionReader(ex.ToString(), IP_READER, Convert.ToString(ID_PORTAL));

                            m_IsConnected_4 = false;
                            return false;
                        }
                    }
                    else
                    {
                        Conexion = true;
                    }

                    #endregion
                }
                else if (ID_PORTAL == 5)
                {
                    #region CONEXION

                    ///////////////////////
                    //VALIDAR SI EL RFID READER ESTA CONECTADO
                    if (m_IsConnected_5 != true)
                    {
                        /////////////////////
                        //PARAMETROS
                        string IP_READER = hostname;
                        uint PUERTO = uint.Parse("5084");

                        //---------------------------------------------------------------------------------------
                        RFID_READER_5 = new RFIDReader(IP_READER, PUERTO, 0);

                        try
                        {
                            RFID_READER_5.Connect();
                            m_IsConnected_5 = true;

                            //REGISTRO DE EVENTOS
                            RFID_READER_5.Actions.PreFilters.DeleteAll();
                            RFID_READER_5.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify_Reader_5);
                            RFID_READER_5.Events.AttachTagDataWithReadEvent = false;
                            RFID_READER_5.Events.NotifyGPIEvent = true;
                            RFID_READER_5.Events.NotifyAntennaEvent = true;
                            RFID_READER_5.Events.NotifyReaderDisconnectEvent = true;
                            RFID_READER_5.Events.NotifyBufferFullEvent = true;
                            RFID_READER_5.Events.NotifyBufferFullWarningEvent = true;
                            RFID_READER_5.Events.NotifyAccessStartEvent = true;
                            RFID_READER_5.Events.NotifyAccessStopEvent = true;
                            RFID_READER_5.Events.NotifyInventoryStartEvent = true;
                            RFID_READER_5.Events.NotifyInventoryStopEvent = true;
                            RFID_READER_5.Events.NotifyReaderExceptionEvent = true;

                            Conexion = true;

                            return true;
                        }
                        catch (Exception ex)
                        {
                            //REGISTRO DE LOG
                            log.LogConectionReader(ex.ToString(), IP_READER, Convert.ToString(ID_PORTAL));

                            m_IsConnected_5 = false;
                            return false;
                        }
                    }
                    else
                    {
                        Conexion = true;
                    }


                    #endregion
                }
                else if (ID_PORTAL == 6)
                {
                    #region CONEXION
                    ///////////////////////
                    //VALIDAR SI EL RFID READER ESTA CONECTADO

                    if (m_IsConnected_6 != true)
                    {
                        /////////////////////
                        //PARAMETROS
                        string IP_READER = hostname;
                        uint PUERTO = uint.Parse("5084");

                        //---------------------------------------------------------------------------------------
                        RFID_READER_6 = new RFIDReader(IP_READER, PUERTO, 0);

                        try
                        {
                            RFID_READER_6.Connect();
                            m_IsConnected_6 = true;

                            //REGISTRO DE EVENTOS
                            RFID_READER_6.Actions.PreFilters.DeleteAll();
                            RFID_READER_6.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify_Reader_6);
                            RFID_READER_6.Events.AttachTagDataWithReadEvent = false;
                            RFID_READER_6.Events.NotifyGPIEvent = true;
                            RFID_READER_6.Events.NotifyAntennaEvent = true;
                            RFID_READER_6.Events.NotifyReaderDisconnectEvent = true;
                            RFID_READER_6.Events.NotifyBufferFullEvent = true;
                            RFID_READER_6.Events.NotifyBufferFullWarningEvent = true;
                            RFID_READER_6.Events.NotifyAccessStartEvent = true;
                            RFID_READER_6.Events.NotifyAccessStopEvent = true;
                            RFID_READER_6.Events.NotifyInventoryStartEvent = true;
                            RFID_READER_6.Events.NotifyInventoryStopEvent = true;
                            RFID_READER_6.Events.NotifyReaderExceptionEvent = true;

                            Conexion = true;

                            return true;
                        }
                        catch (Exception ex)
                        {
                            //REGISTRO DE LOG
                            log.LogConectionReader(ex.ToString(), IP_READER, Convert.ToString(ID_PORTAL));

                            m_IsConnected_6 = false;
                            return false;
                        }
                    }
                    else
                    {
                        Conexion = true;
                    }



                    #endregion
                }
                else if (ID_PORTAL == 7)
                {
                    #region CONEXION

                    ///////////////////////
                    //VALIDAR SI EL RFID READER ESTA CONECTADO
                    if (m_IsConnected_7 != true)
                    {
                        /////////////////////
                        //PARAMETROS
                        string IP_READER = hostname;
                        uint PUERTO = uint.Parse("5084");

                        //---------------------------------------------------------------------------------------
                        RFID_READER_7 = new RFIDReader(IP_READER, PUERTO, 0);

                        try
                        {
                            RFID_READER_7.Connect();
                            m_IsConnected_7 = true;

                            //REGISTRO DE EVENTOS
                            RFID_READER_7.Actions.PreFilters.DeleteAll();
                            RFID_READER_7.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify_Reader_7);
                            RFID_READER_7.Events.AttachTagDataWithReadEvent = false;
                            RFID_READER_7.Events.NotifyGPIEvent = true;
                            RFID_READER_7.Events.NotifyAntennaEvent = true;
                            RFID_READER_7.Events.NotifyReaderDisconnectEvent = true;
                            RFID_READER_7.Events.NotifyBufferFullEvent = true;
                            RFID_READER_7.Events.NotifyBufferFullWarningEvent = true;
                            RFID_READER_7.Events.NotifyAccessStartEvent = true;
                            RFID_READER_7.Events.NotifyAccessStopEvent = true;
                            RFID_READER_7.Events.NotifyInventoryStartEvent = true;
                            RFID_READER_7.Events.NotifyInventoryStopEvent = true;
                            RFID_READER_7.Events.NotifyReaderExceptionEvent = true;

                            Conexion = true;

                            return true;
                        }
                        catch (Exception ex)
                        {
                            //REGISTRO DE LOG
                            log.LogConectionReader(ex.ToString(), IP_READER, Convert.ToString(ID_PORTAL));

                            m_IsConnected_7 = false;
                            return false;
                        }
                    }
                    else
                    {
                        Conexion = true;
                    }

                    #endregion
                }
                else if (ID_PORTAL == 8)
                {
                    #region CONEXION

                    ///////////////////////
                    //VALIDAR SI EL RFID READER ESTA CONECTADO
                    if (m_IsConnected_8 != true)
                    {
                        /////////////////////
                        //PARAMETROS
                        string IP_READER = hostname;
                        uint PUERTO = uint.Parse("5084");

                        //---------------------------------------------------------------------------------------
                        RFID_READER_8 = new RFIDReader(IP_READER, PUERTO, 0);

                        try
                        {
                            RFID_READER_8.Connect();
                            m_IsConnected_8 = true;

                            //REGISTRO DE EVENTOS
                            RFID_READER_8.Actions.PreFilters.DeleteAll();
                            RFID_READER_8.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify_Reader_8);
                            RFID_READER_8.Events.AttachTagDataWithReadEvent = false;
                            RFID_READER_8.Events.NotifyGPIEvent = true;
                            RFID_READER_8.Events.NotifyAntennaEvent = true;
                            RFID_READER_8.Events.NotifyReaderDisconnectEvent = true;
                            RFID_READER_8.Events.NotifyBufferFullEvent = true;
                            RFID_READER_8.Events.NotifyBufferFullWarningEvent = true;
                            RFID_READER_8.Events.NotifyAccessStartEvent = true;
                            RFID_READER_8.Events.NotifyAccessStopEvent = true;
                            RFID_READER_8.Events.NotifyInventoryStartEvent = true;
                            RFID_READER_8.Events.NotifyInventoryStopEvent = true;
                            RFID_READER_8.Events.NotifyReaderExceptionEvent = true;

                            Conexion = true;

                            return true;
                        }
                        catch (Exception ex)
                        {
                            //REGISTRO DE LOG
                            log.LogConectionReader(ex.ToString(), IP_READER, Convert.ToString(ID_PORTAL));

                            m_IsConnected_8 = false;
                            return false;
                        }
                    }
                    else
                    {
                        Conexion = true;
                    }


                    #endregion
                }
                else if (ID_PORTAL == 9)
                {
                    #region CONEXION

                    ///////////////////////
                    //VALIDAR SI EL RFID READER ESTA CONECTADO
                    if (m_IsConnected_9 != true)
                    {
                        /////////////////////
                        //PARAMETROS
                        string IP_READER = hostname;
                        uint PUERTO = uint.Parse("5084");

                        //---------------------------------------------------------------------------------------
                        RFID_READER_9 = new RFIDReader(IP_READER, PUERTO, 0);

                        try
                        {
                            RFID_READER_9.Connect();
                            m_IsConnected_9 = true;

                            //REGISTRO DE EVENTOS
                            RFID_READER_9.Actions.PreFilters.DeleteAll();
                            RFID_READER_9.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify_Reader_9);
                            RFID_READER_9.Events.AttachTagDataWithReadEvent = false;
                            RFID_READER_9.Events.NotifyGPIEvent = true;
                            RFID_READER_9.Events.NotifyAntennaEvent = true;
                            RFID_READER_9.Events.NotifyReaderDisconnectEvent = true;
                            RFID_READER_9.Events.NotifyBufferFullEvent = true;
                            RFID_READER_9.Events.NotifyBufferFullWarningEvent = true;
                            RFID_READER_9.Events.NotifyAccessStartEvent = true;
                            RFID_READER_9.Events.NotifyAccessStopEvent = true;
                            RFID_READER_9.Events.NotifyInventoryStartEvent = true;
                            RFID_READER_9.Events.NotifyInventoryStopEvent = true;
                            RFID_READER_9.Events.NotifyReaderExceptionEvent = true;

                            Conexion = true;

                            return true;
                        }
                        catch (Exception ex)
                        {
                            //REGISTRO DE LOG
                            log.LogConectionReader(ex.ToString(), IP_READER, Convert.ToString(ID_PORTAL));

                            m_IsConnected_9 = false;
                            return false;
                        }
                    }
                    else
                    {
                        Conexion = true;
                    }


                    #endregion
                }
                else if (ID_PORTAL == 10)
                {
                    #region CONEXION

                    ///////////////////////
                    //VALIDAR SI EL RFID READER ESTA CONECTADO
                    if (m_IsConnected_10 != true)
                    {
                        /////////////////////
                        //PARAMETROS
                        string IP_READER = hostname;
                        uint PUERTO = uint.Parse("5084");

                        //---------------------------------------------------------------------------------------
                        RFID_READER_10 = new RFIDReader(IP_READER, PUERTO, 0);

                        try
                        {
                            RFID_READER_10.Connect();
                            m_IsConnected_10 = true;

                            //REGISTRO DE EVENTOS
                            RFID_READER_10.Actions.PreFilters.DeleteAll();
                            RFID_READER_10.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify_Reader_10);
                            RFID_READER_10.Events.AttachTagDataWithReadEvent = false;
                            RFID_READER_10.Events.NotifyGPIEvent = true;
                            RFID_READER_10.Events.NotifyAntennaEvent = true;
                            RFID_READER_10.Events.NotifyReaderDisconnectEvent = true;
                            RFID_READER_10.Events.NotifyBufferFullEvent = true;
                            RFID_READER_10.Events.NotifyBufferFullWarningEvent = true;
                            RFID_READER_10.Events.NotifyAccessStartEvent = true;
                            RFID_READER_10.Events.NotifyAccessStopEvent = true;
                            RFID_READER_10.Events.NotifyInventoryStartEvent = true;
                            RFID_READER_10.Events.NotifyInventoryStopEvent = true;
                            RFID_READER_10.Events.NotifyReaderExceptionEvent = true;

                            Conexion = true;

                            return true;
                        }
                        catch (Exception ex)
                        {
                            //REGISTRO DE LOG
                            log.LogConectionReader(ex.ToString(), IP_READER, Convert.ToString(ID_PORTAL));

                            m_IsConnected_10 = false;
                            return false;
                        }
                    }
                    else
                    {
                        Conexion = true;
                    }



                    #endregion
                }
                else if (ID_PORTAL == 11)
                {
                    #region CONEXION

                    ///////////////////////
                    //VALIDAR SI EL RFID READER ESTA CONECTADO
                    if (m_IsConnected_11 != true)
                    {
                        /////////////////////
                        //PARAMETROS
                        string IP_READER = hostname;
                        uint PUERTO = uint.Parse("5084");

                        //---------------------------------------------------------------------------------------
                        RFID_READER_11 = new RFIDReader(IP_READER, PUERTO, 0);

                        try
                        {
                            RFID_READER_11.Connect();
                            m_IsConnected_11 = true;

                            //REGISTRO DE EVENTOS
                            RFID_READER_11.Actions.PreFilters.DeleteAll();
                            RFID_READER_11.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify_Reader_11);
                            RFID_READER_11.Events.AttachTagDataWithReadEvent = false;
                            RFID_READER_11.Events.NotifyGPIEvent = true;
                            RFID_READER_11.Events.NotifyAntennaEvent = true;
                            RFID_READER_11.Events.NotifyReaderDisconnectEvent = true;
                            RFID_READER_11.Events.NotifyBufferFullEvent = true;
                            RFID_READER_11.Events.NotifyBufferFullWarningEvent = true;
                            RFID_READER_11.Events.NotifyAccessStartEvent = true;
                            RFID_READER_11.Events.NotifyAccessStopEvent = true;
                            RFID_READER_11.Events.NotifyInventoryStartEvent = true;
                            RFID_READER_11.Events.NotifyInventoryStopEvent = true;
                            RFID_READER_11.Events.NotifyReaderExceptionEvent = true;

                            Conexion = true;

                            return true;
                        }
                        catch (Exception ex)
                        {
                            //REGISTRO DE LOG
                            log.LogConectionReader(ex.ToString(), IP_READER, Convert.ToString(ID_PORTAL));

                            m_IsConnected_11 = false;
                            return false;
                        }
                    }
                    else
                    {
                        Conexion = true;
                    }



                    #endregion
                }
                else if (ID_PORTAL == 12)
                {
                    #region CONEXION

                    ///////////////////////
                    //VALIDAR SI EL RFID READER ESTA CONECTADO
                    if (m_IsConnected_12 != true)
                    {
                        /////////////////////
                        //PARAMETROS
                        string IP_READER = hostname;
                        uint PUERTO = uint.Parse("5084");

                        //---------------------------------------------------------------------------------------
                        RFID_READER_12 = new RFIDReader(IP_READER, PUERTO, 0);

                        try
                        {
                            RFID_READER_12.Connect();
                            m_IsConnected_12 = true;

                            //REGISTRO DE EVENTOS
                            RFID_READER_12.Actions.PreFilters.DeleteAll();
                            RFID_READER_12.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify_Reader_12);
                            RFID_READER_12.Events.AttachTagDataWithReadEvent = false;
                            RFID_READER_12.Events.NotifyGPIEvent = true;
                            RFID_READER_12.Events.NotifyAntennaEvent = true;
                            RFID_READER_12.Events.NotifyReaderDisconnectEvent = true;
                            RFID_READER_12.Events.NotifyBufferFullEvent = true;
                            RFID_READER_12.Events.NotifyBufferFullWarningEvent = true;
                            RFID_READER_12.Events.NotifyAccessStartEvent = true;
                            RFID_READER_12.Events.NotifyAccessStopEvent = true;
                            RFID_READER_12.Events.NotifyInventoryStartEvent = true;
                            RFID_READER_12.Events.NotifyInventoryStopEvent = true;
                            RFID_READER_12.Events.NotifyReaderExceptionEvent = true;

                            Conexion = true;

                            return true;
                        }
                        catch (Exception ex)
                        {
                            //REGISTRO DE LOG
                            log.LogConectionReader(ex.ToString(), IP_READER, Convert.ToString(ID_PORTAL));

                            m_IsConnected_12 = false;
                            return false;
                        }
                    }
                    else
                    {
                        Conexion = true;
                    }


                    #endregion
                }
                else if (ID_PORTAL == 13)
                {
                    #region CONEXION

                    ///////////////////////
                    //VALIDAR SI EL RFID READER ESTA CONECTADO
                    if (m_IsConnected_13 != true)
                    {
                        /////////////////////
                        //PARAMETROS
                        string IP_READER = hostname;
                        uint PUERTO = uint.Parse("5084");

                        //---------------------------------------------------------------------------------------
                        RFID_READER_13 = new RFIDReader(IP_READER, PUERTO, 0);

                        try
                        {
                            RFID_READER_13.Connect();
                            m_IsConnected_13 = true;

                            //REGISTRO DE EVENTOS
                            RFID_READER_13.Actions.PreFilters.DeleteAll();
                            RFID_READER_13.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify_Reader_13);
                            RFID_READER_13.Events.AttachTagDataWithReadEvent = false;
                            RFID_READER_13.Events.NotifyGPIEvent = true;
                            RFID_READER_13.Events.NotifyAntennaEvent = true;
                            RFID_READER_13.Events.NotifyReaderDisconnectEvent = true;
                            RFID_READER_13.Events.NotifyBufferFullEvent = true;
                            RFID_READER_13.Events.NotifyBufferFullWarningEvent = true;
                            RFID_READER_13.Events.NotifyAccessStartEvent = true;
                            RFID_READER_13.Events.NotifyAccessStopEvent = true;
                            RFID_READER_13.Events.NotifyInventoryStartEvent = true;
                            RFID_READER_13.Events.NotifyInventoryStopEvent = true;
                            RFID_READER_13.Events.NotifyReaderExceptionEvent = true;


                            Conexion = true;

                            return true;
                        }
                        catch (Exception ex)
                        {
                            //REGISTRO DE LOG
                            log.LogConectionReader(ex.ToString(), IP_READER, Convert.ToString(ID_PORTAL));

                            m_IsConnected_13 = false;
                            return false;
                        }
                    }
                    else
                    {
                        Conexion = true;
                    }



                    #endregion
                }
                else if (ID_PORTAL == 14)
                {
                    #region CONEXION

                    ///////////////////////
                    //VALIDAR SI EL RFID READER ESTA CONECTADO
                    if (m_IsConnected_14 != true)
                    {
                        /////////////////////
                        //PARAMETROS
                        string IP_READER = hostname;
                        uint PUERTO = uint.Parse("5084");

                        //---------------------------------------------------------------------------------------
                        RFID_READER_14 = new RFIDReader(IP_READER, PUERTO, 0);

                        try
                        {
                            RFID_READER_14.Connect();
                            m_IsConnected_14 = true;

                            //REGISTRO DE EVENTOS
                            RFID_READER_14.Actions.PreFilters.DeleteAll();
                            RFID_READER_14.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify_Reader_14);
                            RFID_READER_14.Events.AttachTagDataWithReadEvent = false;
                            RFID_READER_14.Events.NotifyGPIEvent = true;
                            RFID_READER_14.Events.NotifyAntennaEvent = true;
                            RFID_READER_14.Events.NotifyReaderDisconnectEvent = true;
                            RFID_READER_14.Events.NotifyBufferFullEvent = true;
                            RFID_READER_14.Events.NotifyBufferFullWarningEvent = true;
                            RFID_READER_14.Events.NotifyAccessStartEvent = true;
                            RFID_READER_14.Events.NotifyAccessStopEvent = true;
                            RFID_READER_14.Events.NotifyInventoryStartEvent = true;
                            RFID_READER_14.Events.NotifyInventoryStopEvent = true;
                            RFID_READER_14.Events.NotifyReaderExceptionEvent = true;


                            Conexion = true;

                            return true;
                        }
                        catch (Exception ex)
                        {
                            //REGISTRO DE LOG
                            log.LogConectionReader(ex.ToString(), IP_READER, Convert.ToString(ID_PORTAL));

                            m_IsConnected_14 = false;
                            return false;
                        }
                    }
                    else
                    {
                        Conexion = true;
                    }



                    #endregion
                }
                else if (ID_PORTAL == 15)
                {
                    #region CONEXION

                    ///////////////////////
                    //VALIDAR SI EL RFID READER ESTA CONECTADO
                    if (m_IsConnected_15 != true)
                    {
                        /////////////////////
                        //PARAMETROS
                        string IP_READER = hostname;
                        uint PUERTO = uint.Parse("5084");

                        //---------------------------------------------------------------------------------------
                        RFID_READER_15 = new RFIDReader(IP_READER, PUERTO, 0);

                        try
                        {
                            RFID_READER_15.Connect();
                            m_IsConnected_15 = true;

                            //REGISTRO DE EVENTOS
                            RFID_READER_15.Actions.PreFilters.DeleteAll();
                            RFID_READER_15.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify_Reader_15);
                            RFID_READER_15.Events.AttachTagDataWithReadEvent = false;
                            RFID_READER_15.Events.NotifyGPIEvent = true;
                            RFID_READER_15.Events.NotifyAntennaEvent = true;
                            RFID_READER_15.Events.NotifyReaderDisconnectEvent = true;
                            RFID_READER_15.Events.NotifyBufferFullEvent = true;
                            RFID_READER_15.Events.NotifyBufferFullWarningEvent = true;
                            RFID_READER_15.Events.NotifyAccessStartEvent = true;
                            RFID_READER_15.Events.NotifyAccessStopEvent = true;
                            RFID_READER_15.Events.NotifyInventoryStartEvent = true;
                            RFID_READER_15.Events.NotifyInventoryStopEvent = true;
                            RFID_READER_15.Events.NotifyReaderExceptionEvent = true;

                            Conexion = true;

                            return true;
                        }
                        catch (Exception ex)
                        {
                            //REGISTRO DE LOG
                            log.LogConectionReader(ex.ToString(), IP_READER, Convert.ToString(ID_PORTAL));

                            m_IsConnected_15 = false;
                            return false;
                        }
                    }
                    else
                    {
                        Conexion = true;
                    }


                    #endregion
                }
                else if (ID_PORTAL == 16)
                {
                    #region CONEXION

                    ///////////////////////
                    //VALIDAR SI EL RFID READER ESTA CONECTADO
                    if (m_IsConnected_16 != true)
                    {
                        /////////////////////
                        //PARAMETROS
                        string IP_READER = hostname;
                        uint PUERTO = uint.Parse("5084");

                        //---------------------------------------------------------------------------------------
                        RFID_READER_16 = new RFIDReader(IP_READER, PUERTO, 0);

                        try
                        {
                            RFID_READER_16.Connect();
                            m_IsConnected_16 = true;

                            //REGISTRO DE EVENTOS
                            RFID_READER_16.Actions.PreFilters.DeleteAll();
                            RFID_READER_16.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify_Reader_16);
                            RFID_READER_16.Events.AttachTagDataWithReadEvent = false;
                            RFID_READER_16.Events.NotifyGPIEvent = true;
                            RFID_READER_16.Events.NotifyAntennaEvent = true;
                            RFID_READER_16.Events.NotifyReaderDisconnectEvent = true;
                            RFID_READER_16.Events.NotifyBufferFullEvent = true;
                            RFID_READER_16.Events.NotifyBufferFullWarningEvent = true;
                            RFID_READER_16.Events.NotifyAccessStartEvent = true;
                            RFID_READER_16.Events.NotifyAccessStopEvent = true;
                            RFID_READER_16.Events.NotifyInventoryStartEvent = true;
                            RFID_READER_16.Events.NotifyInventoryStopEvent = true;
                            RFID_READER_16.Events.NotifyReaderExceptionEvent = true;

                            Conexion = true;

                            return true;
                        }
                        catch (Exception ex)
                        {
                            //REGISTRO DE LOG
                            log.LogConectionReader(ex.ToString(), IP_READER, Convert.ToString(ID_PORTAL));

                            m_IsConnected_16 = false;
                            return false;
                        }
                    }
                    else
                    {
                        Conexion = true;
                    }


                    #endregion
                }
                else if (ID_PORTAL == 17)
                {
                    #region CONEXION

                    ///////////////////////
                    //VALIDAR SI EL RFID READER ESTA CONECTADO
                    if (m_IsConnected_17 != true)
                    {
                        /////////////////////
                        //PARAMETROS
                        string IP_READER = hostname;
                        uint PUERTO = uint.Parse("5084");

                        //---------------------------------------------------------------------------------------
                        RFID_READER_17 = new RFIDReader(IP_READER, PUERTO, 0);

                        try
                        {
                            RFID_READER_17.Connect();
                            m_IsConnected_17 = true;

                            //REGISTRO DE EVENTOS
                            RFID_READER_17.Actions.PreFilters.DeleteAll();
                            RFID_READER_17.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify_Reader_17);
                            RFID_READER_17.Events.AttachTagDataWithReadEvent = false;
                            RFID_READER_17.Events.NotifyGPIEvent = true;
                            RFID_READER_17.Events.NotifyAntennaEvent = true;
                            RFID_READER_17.Events.NotifyReaderDisconnectEvent = true;
                            RFID_READER_17.Events.NotifyBufferFullEvent = true;
                            RFID_READER_17.Events.NotifyBufferFullWarningEvent = true;
                            RFID_READER_17.Events.NotifyAccessStartEvent = true;
                            RFID_READER_17.Events.NotifyAccessStopEvent = true;
                            RFID_READER_17.Events.NotifyInventoryStartEvent = true;
                            RFID_READER_17.Events.NotifyInventoryStopEvent = true;
                            RFID_READER_17.Events.NotifyReaderExceptionEvent = true;

                            Conexion = true;

                            return true;
                        }
                        catch (Exception ex)
                        {
                            //REGISTRO DE LOG
                            log.LogConectionReader(ex.ToString(), IP_READER, Convert.ToString(ID_PORTAL));

                            m_IsConnected_17 = false;
                            return false;
                        }
                    }
                    else
                    {
                        Conexion = true;
                    }


                    #endregion
                }
                else if (ID_PORTAL == 18)
                {
                    #region CONEXION

                    ///////////////////////
                    //VALIDAR SI EL RFID READER ESTA CONECTADO
                    if (m_IsConnected_18 != true)
                    {
                        /////////////////////
                        //PARAMETROS
                        string IP_READER = hostname;
                        uint PUERTO = uint.Parse("5084");

                        //---------------------------------------------------------------------------------------
                        RFID_READER_18 = new RFIDReader(IP_READER, PUERTO, 0);

                        try
                        {
                            RFID_READER_18.Connect();
                            m_IsConnected_18 = true;

                            //REGISTRO DE EVENTOS
                            RFID_READER_18.Actions.PreFilters.DeleteAll();
                            RFID_READER_18.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify_Reader_18);
                            RFID_READER_18.Events.AttachTagDataWithReadEvent = false;
                            RFID_READER_18.Events.NotifyGPIEvent = true;
                            RFID_READER_18.Events.NotifyAntennaEvent = true;
                            RFID_READER_18.Events.NotifyReaderDisconnectEvent = true;
                            RFID_READER_18.Events.NotifyBufferFullEvent = true;
                            RFID_READER_18.Events.NotifyBufferFullWarningEvent = true;
                            RFID_READER_18.Events.NotifyAccessStartEvent = true;
                            RFID_READER_18.Events.NotifyAccessStopEvent = true;
                            RFID_READER_18.Events.NotifyInventoryStartEvent = true;
                            RFID_READER_18.Events.NotifyInventoryStopEvent = true;
                            RFID_READER_18.Events.NotifyReaderExceptionEvent = true;

                            Conexion = true;

                            return true;
                        }
                        catch (Exception ex)
                        {
                            //REGISTRO DE LOG
                            log.LogConectionReader(ex.ToString(), IP_READER, Convert.ToString(ID_PORTAL));

                            m_IsConnected_18 = false;
                            return false;
                        }
                    }
                    else
                    {
                        Conexion = true;
                    }

                    #endregion
                }
                else if (ID_PORTAL == 19)
                {
                    #region CONEXION

                    ///////////////////////
                    //VALIDAR SI EL RFID READER ESTA CONECTADO
                    if (m_IsConnected_19 != true)
                    {
                        /////////////////////
                        //PARAMETROS
                        string IP_READER = hostname;
                        uint PUERTO = uint.Parse("5084");

                        //---------------------------------------------------------------------------------------
                        RFID_READER_19 = new RFIDReader(IP_READER, PUERTO, 0);

                        try
                        {
                            RFID_READER_19.Connect();
                            m_IsConnected_19 = true;

                            //REGISTRO DE EVENTOS
                            RFID_READER_19.Actions.PreFilters.DeleteAll();
                            RFID_READER_19.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify_Reader_19);
                            RFID_READER_19.Events.AttachTagDataWithReadEvent = false;
                            RFID_READER_19.Events.NotifyGPIEvent = true;
                            RFID_READER_19.Events.NotifyAntennaEvent = true;
                            RFID_READER_19.Events.NotifyReaderDisconnectEvent = true;
                            RFID_READER_19.Events.NotifyBufferFullEvent = true;
                            RFID_READER_19.Events.NotifyBufferFullWarningEvent = true;
                            RFID_READER_19.Events.NotifyAccessStartEvent = true;
                            RFID_READER_19.Events.NotifyAccessStopEvent = true;
                            RFID_READER_19.Events.NotifyInventoryStartEvent = true;
                            RFID_READER_19.Events.NotifyInventoryStopEvent = true;
                            RFID_READER_19.Events.NotifyReaderExceptionEvent = true;

                            Conexion = true;

                            return true;
                        }
                        catch (Exception ex)
                        {
                            //REGISTRO DE LOG
                            log.LogConectionReader(ex.ToString(), IP_READER, Convert.ToString(ID_PORTAL));

                            m_IsConnected_19 = false;
                            return false;
                        }
                    }
                    else
                    {
                        Conexion = true;
                    }



                    #endregion
                }
                else if (ID_PORTAL == 20)
                {
                    #region CONEXION

                    ///////////////////////
                    //VALIDAR SI EL RFID READER ESTA CONECTADO
                    if (m_IsConnected_20 != true)
                    {
                        /////////////////////
                        //PARAMETROS
                        string IP_READER = hostname;
                        uint PUERTO = uint.Parse("5084");

                        //---------------------------------------------------------------------------------------
                        RFID_READER_20 = new RFIDReader(IP_READER, PUERTO, 0);

                        try
                        {
                            RFID_READER_20.Connect();
                            m_IsConnected_20 = true;

                            //REGISTRO DE EVENTOS
                            RFID_READER_20.Actions.PreFilters.DeleteAll();
                            RFID_READER_20.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify_Reader_20);
                            RFID_READER_20.Events.AttachTagDataWithReadEvent = false;
                            RFID_READER_20.Events.NotifyGPIEvent = true;
                            RFID_READER_20.Events.NotifyAntennaEvent = true;
                            RFID_READER_20.Events.NotifyReaderDisconnectEvent = true;
                            RFID_READER_20.Events.NotifyBufferFullEvent = true;
                            RFID_READER_20.Events.NotifyBufferFullWarningEvent = true;
                            RFID_READER_20.Events.NotifyAccessStartEvent = true;
                            RFID_READER_20.Events.NotifyAccessStopEvent = true;
                            RFID_READER_20.Events.NotifyInventoryStartEvent = true;
                            RFID_READER_20.Events.NotifyInventoryStopEvent = true;
                            RFID_READER_20.Events.NotifyReaderExceptionEvent = true;

                            Conexion = true;

                            return true;
                        }
                        catch (Exception ex)
                        {
                            //REGISTRO DE LOG
                            log.LogConectionReader(ex.ToString(), IP_READER, Convert.ToString(ID_PORTAL));

                            m_IsConnected_20 = false;
                            return false;
                        }
                    }
                    else
                    {
                        Conexion = true;
                    }

                    #endregion
                }

                return Conexion;
            }
            catch (Exception ex)
            {
                //REGISTRO DE LOG
                log.LogConectionEventos(ex.ToString(), ID_PORTAL.ToString(), Convert.ToString(ID_PORTAL));

                return Conexion;
            }
        }

        /// <summary>
        /// DESCONECTAR EL LECTOR
        /// </summary>
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
                switch (ID_PORTAL)
                {
                    case 1:

                        #region PORTAL 1



                        //VALIDAR ESTADO DEL READERS
                        if (m_IsConnected_1)
                        {
                            try
                            {
                                //DESCONECTAR READER
                                RFID_READER_1.Disconnect();

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_1 = false;
                                RFID_READER_1 = null;
                                m_UpdateReadHandler_1 = null;
                                FLAG_LECTURA_1 = false;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_1.Abort();
                                ULTIMA_LECTURA_1.Abort();
                                CONEXION_1.Abort();

                            }
                            catch (Exception)
                            { }
                        }
                        else
                        {
                            try
                            {
                                if (RFID_READER_1 != null)
                                {
                                    if (m_IsConnected_1 != false)
                                    {
                                        RFID_READER_1.Disconnect();
                                    }
                                }
                                else
                                {
                                    //ACTUALIZAMOS SU ESTADO
                                    m_IsConnected_1 = false;
                                    RFID_READER_1 = null;
                                    m_UpdateReadHandler_1 = null;
                                    FLAG_LECTURA_1 = false;

                                    //TERMINAR SUBPROCESOS
                                    HILO_LIMPIEZA_TAGS_1.Abort();
                                    ULTIMA_LECTURA_1.Abort();
                                }


                            }
                            catch (Exception)
                            {
                            }


                        }

                        //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                        LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_1.Text + " (Desconectado " + DateTime.Now + ")");

                        //REGISTRO DE BITACORA
                        log.LogBitacoraProcesos(LBL_PORTAL_1.Text, "DESCONECTADO");

                        CAMBIAR_ESTADO_PORTAL(ID_PORTAL, false);


                        break;

                    #endregion

                    case 2:

                        #region PORTAL 2


                        //VALIDAR ESTADO DEL READERS
                        if (m_IsConnected_2)
                        {
                            try
                            {
                                //DESCONECTAR READER
                                RFID_READER_2.Disconnect();

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_2 = false;
                                RFID_READER_2 = null;
                                m_UpdateReadHandler_2 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_2.Abort();
                                ULTIMA_LECTURA_2.Abort();
                                CONEXION_2.Abort();
                            }
                            catch (Exception)
                            { }
                        }
                        else
                        {
                            try
                            {
                                if (RFID_READER_2 != null)
                                {
                                    if (m_IsConnected_2 != false)
                                    {
                                        RFID_READER_2.Disconnect();
                                    }
                                }

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_2 = false;
                                RFID_READER_2 = null;
                                m_UpdateReadHandler_2 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_2.Abort();
                                ULTIMA_LECTURA_2.Abort();
                            }
                            catch (Exception)
                            { }

                        }

                        //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                        LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_2.Text + " (Desconectado " + DateTime.Now + ")");

                        //REGISTRO DE BITACORA
                        log.LogBitacoraProcesos(LBL_PORTAL_2.Text, "DESCONECTADO");

                        CAMBIAR_ESTADO_PORTAL(ID_PORTAL, false);

                        break;

                    #endregion

                    case 3:

                        #region PORTAL 3


                        //VALIDAR ESTADO DEL READERS
                        if (m_IsConnected_3)
                        {
                            try
                            {
                                //DESCONECTAR READER
                                RFID_READER_3.Disconnect();

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_3 = false;
                                RFID_READER_3 = null;
                                m_UpdateReadHandler_3 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_3.Abort();
                                ULTIMA_LECTURA_3.Abort();
                                CONEXION_3.Abort();
                            }
                            catch (Exception)
                            {

                            }
                        }
                        else
                        {
                            try
                            {
                                if (RFID_READER_3 != null)
                                {
                                    if (m_IsConnected_3 != false)
                                    {
                                        RFID_READER_3.Disconnect();
                                    }
                                }

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_3 = false;
                                RFID_READER_3 = null;
                                m_UpdateReadHandler_3 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_3.Abort();
                                ULTIMA_LECTURA_3.Abort();
                            }
                            catch (Exception)
                            {


                            }

                        }

                        //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                        LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_3.Text + " (Desconectado " + DateTime.Now + ")");

                        //REGISTRO DE BITACORA
                        log.LogBitacoraProcesos(LBL_PORTAL_3.Text, "DESCONECTADO");

                        CAMBIAR_ESTADO_PORTAL(ID_PORTAL, false);

                        break;

                    #endregion

                    case 4:

                        #region PORTAL 4


                        //VALIDAR ESTADO DEL READERS
                        if (m_IsConnected_4)
                        {
                            try
                            {
                                //DESCONECTAR READER
                                RFID_READER_4.Disconnect();

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_4 = false;
                                RFID_READER_4 = null;
                                m_UpdateReadHandler_4 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_4.Abort();
                                ULTIMA_LECTURA_4.Abort();
                                CONEXION_4.Abort();
                            }
                            catch (Exception)
                            {

                            }
                        }
                        else
                        {
                            try
                            {
                                if (RFID_READER_4 != null)
                                {
                                    if (m_IsConnected_4 != false)
                                    {
                                        RFID_READER_4.Disconnect();
                                    }
                                }

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_4 = false;
                                RFID_READER_4 = null;
                                m_UpdateReadHandler_4 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_4.Abort();
                                ULTIMA_LECTURA_4.Abort();
                            }
                            catch (Exception)
                            {

                            }

                        }

                        //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                        LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_4.Text + " (Desconectado " + DateTime.Now + ")");

                        //REGISTRO DE BITACORA
                        log.LogBitacoraProcesos(LBL_PORTAL_4.Text, "DESCONECTADO");

                        CAMBIAR_ESTADO_PORTAL(ID_PORTAL, false);


                        break;
                    #endregion

                    case 5:
                        #region PORTAL 5


                        //VALIDAR ESTADO DEL READERS
                        if (m_IsConnected_5)
                        {
                            try
                            {
                                //DESCONECTAR READER
                                RFID_READER_5.Disconnect();

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_5 = false;
                                RFID_READER_5 = null;
                                m_UpdateReadHandler_5 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_5.Abort();
                                ULTIMA_LECTURA_5.Abort();
                                CONEXION_5.Abort();
                            }
                            catch (Exception)
                            {


                            }
                        }
                        else
                        {
                            try
                            {
                                if (RFID_READER_5 != null)
                                {
                                    if (m_IsConnected_5 != false)
                                    {
                                        RFID_READER_5.Disconnect();
                                    }
                                }

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_5 = false;
                                RFID_READER_5 = null;
                                m_UpdateReadHandler_5 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_5.Abort();
                                ULTIMA_LECTURA_5.Abort();

                            }
                            catch (Exception)
                            {


                            }

                        }

                        //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                        LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_5.Text + " (Desconectado " + DateTime.Now + ")");

                        //REGISTRO DE BITACORA
                        log.LogBitacoraProcesos(LBL_PORTAL_5.Text, "DESCONECTADO");

                        CAMBIAR_ESTADO_PORTAL(ID_PORTAL, false);

                        break;

                    #endregion

                    case 6:

                        #region PORTAL 6


                        //VALIDAR ESTADO DEL READERS
                        if (m_IsConnected_6)
                        {
                            try
                            {
                                //DESCONECTAR READER
                                RFID_READER_6.Disconnect();

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_6 = false;
                                RFID_READER_6 = null;
                                m_UpdateReadHandler_6 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_6.Abort();
                                ULTIMA_LECTURA_6.Abort();
                                CONEXION_6.Abort();
                            }
                            catch (Exception)
                            {

                            }
                        }
                        else
                        {
                            try
                            {
                                if (RFID_READER_6 != null)
                                {
                                    if (m_IsConnected_6 != false)
                                    {
                                        RFID_READER_6.Disconnect();
                                    }
                                }

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_6 = false;
                                RFID_READER_6 = null;
                                m_UpdateReadHandler_6 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_6.Abort();
                                ULTIMA_LECTURA_6.Abort();
                            }
                            catch (Exception)
                            {
                            }

                        }

                        //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                        LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_6.Text + " (Desconectado " + DateTime.Now + ")");

                        //REGISTRO DE BITACORA
                        log.LogBitacoraProcesos(LBL_PORTAL_6.Text, "DESCONECTADO");

                        CAMBIAR_ESTADO_PORTAL(ID_PORTAL, false);

                        break;

                    #endregion

                    case 7:

                        #region PORTAL 7


                        //VALIDAR ESTADO DEL READERS
                        if (m_IsConnected_7)
                        {
                            try
                            {
                                //DESCONECTAR READER
                                RFID_READER_7.Disconnect();

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_7 = false;
                                RFID_READER_7 = null;
                                m_UpdateReadHandler_7 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_7.Abort();
                                ULTIMA_LECTURA_7.Abort();
                                CONEXION_7.Abort();
                            }
                            catch (Exception)
                            {
                            }
                        }
                        else
                        {
                            try
                            {
                                if (RFID_READER_7 != null)
                                {
                                    if (m_IsConnected_7 != false)
                                    {
                                        RFID_READER_7.Disconnect();
                                    }
                                }

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_7 = false;
                                RFID_READER_7 = null;
                                m_UpdateReadHandler_7 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_7.Abort();
                                ULTIMA_LECTURA_7.Abort();
                            }
                            catch (Exception)
                            {
                            }

                        }

                        //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                        LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_7.Text + " (Desconectado " + DateTime.Now + ")");

                        //REGISTRO DE BITACORA
                        log.LogBitacoraProcesos(LBL_PORTAL_7.Text, "DESCONECTADO");

                        CAMBIAR_ESTADO_PORTAL(ID_PORTAL, false);

                        break;

                    #endregion

                    case 8:

                        #region PORTAL 8



                        //VALIDAR ESTADO DEL READERS
                        if (m_IsConnected_8)
                        {
                            try
                            {
                                //DESCONECTAR READER
                                RFID_READER_8.Disconnect();

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_8 = false;
                                RFID_READER_8 = null;
                                m_UpdateReadHandler_8 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_8.Abort();
                                ULTIMA_LECTURA_8.Abort();
                                CONEXION_8.Abort();
                            }
                            catch (Exception)
                            {


                            }
                        }
                        else
                        {
                            try
                            {
                                if (RFID_READER_8 != null)
                                {
                                    if (m_IsConnected_8 != false)
                                    {
                                        RFID_READER_8.Disconnect();
                                    }
                                }

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_8 = false;
                                RFID_READER_8 = null;
                                m_UpdateReadHandler_8 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_8.Abort();
                                ULTIMA_LECTURA_8.Abort();
                            }
                            catch (Exception)
                            {
                            }

                        }

                        //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                        LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_8.Text + " (Desconectado " + DateTime.Now + ")");

                        //REGISTRO DE BITACORA
                        log.LogBitacoraProcesos(LBL_PORTAL_8.Text, "DESCONECTADO");

                        CAMBIAR_ESTADO_PORTAL(ID_PORTAL, false);

                        break;

                    #endregion

                    case 9:
                        #region PORTAL 9



                        //VALIDAR ESTADO DEL READERS
                        if (m_IsConnected_9)
                        {
                            try
                            {
                                //DESCONECTAR READER
                                RFID_READER_9.Disconnect();

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_9 = false;
                                RFID_READER_9 = null;
                                m_UpdateReadHandler_9 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_9.Abort();
                                ULTIMA_LECTURA_9.Abort();
                                CONEXION_9.Abort();
                            }
                            catch (Exception)
                            {
                            }
                        }
                        else
                        {
                            try
                            {
                                if (RFID_READER_9 != null)
                                {
                                    if (m_IsConnected_9 != false)
                                    {
                                        RFID_READER_9.Disconnect();
                                    }
                                }

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_9 = false;
                                RFID_READER_9 = null;
                                m_UpdateReadHandler_9 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_9.Abort();
                                ULTIMA_LECTURA_9.Abort();
                            }
                            catch (Exception)
                            {
                            }

                        }

                        //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                        LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_9.Text + " (Desconectado " + DateTime.Now + ")");

                        //REGISTRO DE BITACORA
                        log.LogBitacoraProcesos(LBL_PORTAL_9.Text, "DESCONECTADO");

                        CAMBIAR_ESTADO_PORTAL(ID_PORTAL, false);

                        break;

                    #endregion

                    case 10:

                        #region PORTAL 10



                        //VALIDAR ESTADO DEL READERS
                        if (m_IsConnected_10)
                        {
                            try
                            {
                                //DESCONECTAR READER
                                RFID_READER_10.Disconnect();

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_10 = false;
                                RFID_READER_10 = null;
                                m_UpdateReadHandler_10 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_10.Abort();
                                ULTIMA_LECTURA_10.Abort();
                                CONEXION_10.Abort();
                            }
                            catch (Exception)
                            {
                            }
                        }
                        else
                        {
                            try
                            {
                                if (RFID_READER_10 != null)
                                {
                                    if (m_IsConnected_10 != false)
                                    {
                                        RFID_READER_10.Disconnect();
                                    }
                                }

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_10 = false;
                                RFID_READER_10 = null;
                                m_UpdateReadHandler_10 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_10.Abort();
                                ULTIMA_LECTURA_10.Abort();
                            }
                            catch (Exception)
                            {
                            }

                        }

                        //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                        LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_10.Text + " (Desconectado " + DateTime.Now + ")");

                        //REGISTRO DE BITACORA
                        log.LogBitacoraProcesos(LBL_PORTAL_10.Text, "DESCONECTADO");

                        CAMBIAR_ESTADO_PORTAL(ID_PORTAL, false);

                        break;

                    #endregion

                    case 11:

                        #region PORTAL 11



                        //VALIDAR ESTADO DEL READERS
                        if (m_IsConnected_11)
                        {
                            try
                            {
                                //DESCONECTAR READER
                                RFID_READER_11.Disconnect();

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_11 = false;
                                RFID_READER_11 = null;
                                m_UpdateReadHandler_11 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_11.Abort();
                                ULTIMA_LECTURA_11.Abort();
                                CONEXION_11.Abort();
                            }
                            catch (Exception)
                            {


                            }
                        }
                        else
                        {
                            try
                            {
                                if (RFID_READER_11 != null)
                                {
                                    if (m_IsConnected_11 != false)
                                    {
                                        RFID_READER_11.Disconnect();
                                    }
                                }

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_11 = false;
                                RFID_READER_11 = null;
                                m_UpdateReadHandler_11 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_11.Abort();
                                ULTIMA_LECTURA_11.Abort();
                            }
                            catch (Exception)
                            {

                                throw;
                            }

                        }

                        //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                        LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_11.Text + " (Desconectado " + DateTime.Now + ")");

                        //REGISTRO DE BITACORA
                        log.LogBitacoraProcesos(LBL_PORTAL_11.Text, "DESCONECTADO");

                        CAMBIAR_ESTADO_PORTAL(ID_PORTAL, false);

                        break;

                    #endregion

                    case 12:

                        #region PORTAL 12



                        //VALIDAR ESTADO DEL READERS
                        if (m_IsConnected_12)
                        {
                            try
                            {
                                //DESCONECTAR READER
                                RFID_READER_12.Disconnect();

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_12 = false;
                                RFID_READER_12 = null;
                                m_UpdateReadHandler_12 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_12.Abort();
                                ULTIMA_LECTURA_12.Abort();
                                CONEXION_12.Abort();
                            }
                            catch (Exception)
                            {
                            }
                        }
                        else
                        {
                            try
                            {
                                if (RFID_READER_12 != null)
                                {
                                    if (m_IsConnected_12 != false)
                                    {
                                        RFID_READER_12.Disconnect();
                                    }
                                }

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_12 = false;
                                RFID_READER_12 = null;
                                m_UpdateReadHandler_12 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_12.Abort();
                                ULTIMA_LECTURA_12.Abort();

                            }
                            catch (Exception)
                            {
                            }

                        }

                        //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                        LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_12.Text + " (Desconectado " + DateTime.Now + ")");

                        //REGISTRO DE BITACORA
                        log.LogBitacoraProcesos(LBL_PORTAL_12.Text, "DESCONECTADO");

                        CAMBIAR_ESTADO_PORTAL(ID_PORTAL, false);

                        break;

                    #endregion

                    case 13:

                        #region PORTAL 13


                        //VALIDAR ESTADO DEL READERS
                        if (m_IsConnected_13)
                        {
                            try
                            {
                                //DESCONECTAR READER
                                RFID_READER_13.Disconnect();

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_13 = false;
                                RFID_READER_13 = null;
                                m_UpdateReadHandler_13 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_13.Abort();
                                ULTIMA_LECTURA_13.Abort();
                                CONEXION_13.Abort();
                            }
                            catch (Exception)
                            {
                            }
                        }
                        else
                        {
                            try
                            {
                                if (RFID_READER_13 != null)
                                {
                                    if (m_IsConnected_13 != false)
                                    {
                                        RFID_READER_13.Disconnect();
                                    }
                                }

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_13 = false;
                                RFID_READER_13 = null;
                                m_UpdateReadHandler_13 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_13.Abort();
                                ULTIMA_LECTURA_13.Abort();
                            }
                            catch (Exception)
                            {

                            }

                        }

                        //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                        LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_13.Text + " (Desconectado " + DateTime.Now + ")");

                        //REGISTRO DE BITACORA
                        log.LogBitacoraProcesos(LBL_PORTAL_13.Text, "DESCONECTADO");

                        CAMBIAR_ESTADO_PORTAL(ID_PORTAL, false);

                        break;

                    #endregion

                    case 14:

                        #region PORTAL 14


                        //VALIDAR ESTADO DEL READERS
                        if (m_IsConnected_14)
                        {
                            try
                            {
                                //DESCONECTAR READER
                                RFID_READER_14.Disconnect();

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_14 = false;
                                RFID_READER_14 = null;
                                m_UpdateReadHandler_14 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_14.Abort();
                                ULTIMA_LECTURA_14.Abort();
                                CONEXION_14.Abort();
                            }
                            catch (Exception)
                            {
                            }
                        }
                        else
                        {
                            try
                            {
                                if (RFID_READER_14 != null)
                                {
                                    if (m_IsConnected_14 != false)
                                    {
                                        RFID_READER_14.Disconnect();
                                    }
                                }

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_14 = false;
                                RFID_READER_14 = null;
                                m_UpdateReadHandler_14 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_14.Abort();
                                ULTIMA_LECTURA_14.Abort();
                            }
                            catch (Exception)
                            {
                            }

                        }

                        //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                        LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_14.Text + " (Desconectado " + DateTime.Now + ")");

                        //REGISTRO DE BITACORA
                        log.LogBitacoraProcesos(LBL_PORTAL_14.Text, "DESCONECTADO");

                        CAMBIAR_ESTADO_PORTAL(ID_PORTAL, false);

                        break;

                    #endregion

                    case 15:

                        #region PORTAL 15



                        //VALIDAR ESTADO DEL READERS
                        if (m_IsConnected_15)
                        {
                            try
                            {
                                //DESCONECTAR READER
                                RFID_READER_15.Disconnect();

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_15 = false;
                                RFID_READER_15 = null;
                                m_UpdateReadHandler_15 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_15.Abort();
                                ULTIMA_LECTURA_15.Abort();
                                CONEXION_15.Abort();
                            }
                            catch (Exception)
                            {

                            }
                        }
                        else
                        {
                            try
                            {
                                if (RFID_READER_15 != null)
                                {
                                    if (m_IsConnected_15 != false)
                                    {
                                        RFID_READER_15.Disconnect();
                                    }
                                }

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_15 = false;
                                RFID_READER_15 = null;
                                m_UpdateReadHandler_15 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_15.Abort();
                                ULTIMA_LECTURA_15.Abort();
                            }
                            catch (Exception)
                            {

                            }

                        }

                        //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                        LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_15.Text + " (Desconectado " + DateTime.Now + ")");

                        //REGISTRO DE BITACORA
                        log.LogBitacoraProcesos(LBL_PORTAL_15.Text, "DESCONECTADO");

                        CAMBIAR_ESTADO_PORTAL(ID_PORTAL, false);

                        break;

                    #endregion

                    case 16:

                        #region PORTAL 16



                        //VALIDAR ESTADO DEL READERS
                        if (m_IsConnected_16)
                        {
                            try
                            {
                                //DESCONECTAR READER
                                RFID_READER_16.Disconnect();

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_16 = false;
                                RFID_READER_16 = null;
                                m_UpdateReadHandler_16 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_16.Abort();
                                ULTIMA_LECTURA_16.Abort();
                                CONEXION_16.Abort();
                            }
                            catch (Exception)
                            {


                            }
                        }
                        else
                        {
                            try
                            {
                                if (RFID_READER_16 != null)
                                {
                                    if (m_IsConnected_16 != false)
                                    {
                                        RFID_READER_16.Disconnect();
                                    }
                                }

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_16 = false;
                                RFID_READER_16 = null;
                                m_UpdateReadHandler_16 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_16.Abort();
                                ULTIMA_LECTURA_16.Abort();
                            }
                            catch (Exception)
                            {

                            }

                        }

                        //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                        LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_16.Text + " (Desconectado " + DateTime.Now + ")");

                        //REGISTRO DE BITACORA
                        log.LogBitacoraProcesos(LBL_PORTAL_16.Text, "DESCONECTADO");

                        CAMBIAR_ESTADO_PORTAL(ID_PORTAL, false);

                        break;

                    #endregion

                    case 17:

                        #region PORTAL 17



                        //VALIDAR ESTADO DEL READERS
                        if (m_IsConnected_17)
                        {
                            try
                            {
                                //DESCONECTAR READER
                                RFID_READER_17.Disconnect();

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_17 = false;
                                RFID_READER_17 = null;
                                m_UpdateReadHandler_17 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_17.Abort();
                                ULTIMA_LECTURA_17.Abort();
                                CONEXION_17.Abort();
                            }
                            catch (Exception)
                            {

                            }
                        }
                        else
                        {
                            try
                            {
                                if (RFID_READER_17 != null)
                                {
                                    if (m_IsConnected_17 != false)
                                    {
                                        RFID_READER_17.Disconnect();
                                    }
                                }

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_17 = false;
                                RFID_READER_17 = null;
                                m_UpdateReadHandler_17 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_17.Abort();
                                ULTIMA_LECTURA_17.Abort();
                            }
                            catch (Exception)
                            {


                            }

                        }

                        //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                        LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_17.Text + " (Desconectado " + DateTime.Now + ")");

                        //REGISTRO DE BITACORA
                        log.LogBitacoraProcesos(LBL_PORTAL_17.Text, "DESCONECTADO");

                        CAMBIAR_ESTADO_PORTAL(ID_PORTAL, false);

                        break;

                    #endregion

                    case 18:

                        #region PORTAL 18


                        //VALIDAR ESTADO DEL READERS
                        if (m_IsConnected_18)
                        {
                            try
                            {
                                //DESCONECTAR READER
                                RFID_READER_18.Disconnect();

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_18 = false;
                                RFID_READER_18 = null;
                                m_UpdateReadHandler_18 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_18.Abort();
                                ULTIMA_LECTURA_18.Abort();
                                CONEXION_18.Abort();
                            }
                            catch (Exception)
                            {

                            }
                        }
                        else
                        {
                            try
                            {
                                if (RFID_READER_18 != null)
                                {
                                    if (m_IsConnected_18 != false)
                                    {
                                        RFID_READER_18.Disconnect();
                                    }
                                }

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_18 = false;
                                RFID_READER_18 = null;
                                m_UpdateReadHandler_18 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_18.Abort();
                                ULTIMA_LECTURA_18.Abort();
                            }
                            catch (Exception)
                            {

                            }

                        }

                        //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                        LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_18.Text + " (Desconectado " + DateTime.Now + ")");

                        //REGISTRO DE BITACORA
                        log.LogBitacoraProcesos(LBL_PORTAL_18.Text, "DESCONECTADO");

                        CAMBIAR_ESTADO_PORTAL(ID_PORTAL, false);

                        break;

                    #endregion

                    case 19:

                        #region PORTAL 19


                        //VALIDAR ESTADO DEL READERS
                        if (m_IsConnected_19)
                        {
                            try
                            {
                                //DESCONECTAR READER
                                RFID_READER_19.Disconnect();

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_19 = false;
                                RFID_READER_19 = null;
                                m_UpdateReadHandler_19 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_19.Abort();
                                ULTIMA_LECTURA_19.Abort();
                                CONEXION_19.Abort();
                            }
                            catch (Exception)
                            {

                            }
                        }
                        else
                        {
                            try
                            {
                                if (RFID_READER_19 != null)
                                {
                                    if (m_IsConnected_19 != false)
                                    {
                                        RFID_READER_19.Disconnect();
                                    }
                                }

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_19 = false;
                                RFID_READER_19 = null;
                                m_UpdateReadHandler_19 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_19.Abort();
                                ULTIMA_LECTURA_19.Abort();
                            }
                            catch (Exception)
                            {

                            }

                        }

                        //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                        LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_19.Text + " (Desconectado " + DateTime.Now + ")");

                        //REGISTRO DE BITACORA
                        log.LogBitacoraProcesos(LBL_PORTAL_19.Text, "DESCONECTADO");

                        CAMBIAR_ESTADO_PORTAL(ID_PORTAL, false);

                        break;

                    #endregion

                    case 20:

                        #region PORTAL 20


                        //VALIDAR ESTADO DEL READERS
                        if (m_IsConnected_2)
                        {
                            try
                            {
                                //DESCONECTAR READ0ER
                                RFID_READER_20.Disconnect();

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_20 = false;
                                RFID_READER_20 = null;
                                m_UpdateReadHandler_20 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_20.Abort();
                                ULTIMA_LECTURA_20.Abort();
                                CONEXION_20.Abort();
                            }
                            catch (Exception)
                            {

                            }
                        }
                        else
                        {
                            try
                            {
                                if (RFID_READER_20 != null)
                                {
                                    if (m_IsConnected_20 != false)
                                    {
                                        RFID_READER_20.Disconnect();
                                    }
                                }

                                //ACTUALIZAMOS SU ESTADO
                                m_IsConnected_20 = false;
                                RFID_READER_20 = null;
                                m_UpdateReadHandler_20 = null;

                                //TERMINAR SUBPROCESOS
                                HILO_LIMPIEZA_TAGS_20.Abort();
                                ULTIMA_LECTURA_20.Abort();
                            }
                            catch (Exception)
                            {

                            }
                        }

                        //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                        LBL_MENSAJE_PROCESO.AppendText(System.Environment.NewLine + "PORTAL: " + LBL_PORTAL_20.Text + " (Desconectado " + DateTime.Now + ")");

                        //REGISTRO DE BITACORA
                        log.LogBitacoraProcesos(LBL_PORTAL_20.Text, "DESCONECTADO");

                        CAMBIAR_ESTADO_PORTAL(ID_PORTAL, false);

                        break;

                        #endregion
                }
            }
            catch (Exception ex)
            {
                string MENSJAE = ex.Message + "  Close";
            }
        }

        #endregion

        //--------------------

        #region START READ


        /// <summary>
        /// INICIAR LECTURAS
        /// </summary>
        private void INICIAR_LECTURA(int ID_PORTAL)
        {
            //INICIALIZAR ANTENAS
            INICIAR_ANTENENAS(ID_PORTAL);

            try
            {
                switch (ID_PORTAL)
                {
                    case 1:

                        if (RFID_READER_1.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            RFID_READER_1.Actions.TagAccess.OperationSequence.PerformSequence(null, null, AntenaInfo_1);
                        }
                        else
                        {
                            RFID_READER_1.Actions.Inventory.Perform(null, null, AntenaInfo_1);
                        }

                        Log.Instance.Info("Lectura de tags iniciado");
                        break;

                    case 2:

                        if (RFID_READER_2.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            RFID_READER_2.Actions.TagAccess.OperationSequence.PerformSequence(null, null, AntenaInfo_2);
                        }
                        else
                        {
                            RFID_READER_2.Actions.Inventory.Perform(null, null, AntenaInfo_2);
                        }

                        Log.Instance.Info("Lectura de tags iniciado");
                        break;

                    case 3:

                        if (RFID_READER_3.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            RFID_READER_3.Actions.TagAccess.OperationSequence.PerformSequence(null, null, AntenaInfo_3);
                        }
                        else
                        {
                            RFID_READER_3.Actions.Inventory.Perform(null, null, AntenaInfo_3);
                        }

                        Log.Instance.Info("Lectura de tags iniciado");
                        break;

                    case 4:

                        if (RFID_READER_4.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            RFID_READER_4.Actions.TagAccess.OperationSequence.PerformSequence(null, null, AntenaInfo_4);
                        }
                        else
                        {
                            RFID_READER_4.Actions.Inventory.Perform(null, null, AntenaInfo_4);
                        }

                        Log.Instance.Info("Lectura de tags iniciado");
                        break;

                    case 5:

                        if (RFID_READER_5.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            RFID_READER_5.Actions.TagAccess.OperationSequence.PerformSequence(null, null, AntenaInfo_5);
                        }
                        else
                        {
                            RFID_READER_5.Actions.Inventory.Perform(null, null, AntenaInfo_5);
                        }

                        Log.Instance.Info("Lectura de tags iniciado");
                        break;
                    case 6:

                        if (RFID_READER_6.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            RFID_READER_6.Actions.TagAccess.OperationSequence.PerformSequence(null, null, AntenaInfo_6);
                        }
                        else
                        {
                            RFID_READER_6.Actions.Inventory.Perform(null, null, AntenaInfo_6);
                        }

                        Log.Instance.Info("Lectura de tags iniciado");
                        break;
                    case 7:

                        if (RFID_READER_7.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            RFID_READER_7.Actions.TagAccess.OperationSequence.PerformSequence(null, null, AntenaInfo_7);
                        }
                        else
                        {
                            RFID_READER_7.Actions.Inventory.Perform(null, null, AntenaInfo_8);
                        }

                        Log.Instance.Info("Lectura de tags iniciado");
                        break;
                    case 8:

                        if (RFID_READER_8.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            RFID_READER_8.Actions.TagAccess.OperationSequence.PerformSequence(null, null, AntenaInfo_8);
                        }
                        else
                        {
                            RFID_READER_8.Actions.Inventory.Perform(null, null, AntenaInfo_9);
                        }

                        Log.Instance.Info("Lectura de tags iniciado");
                        break;
                    case 9:

                        if (RFID_READER_9.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            RFID_READER_9.Actions.TagAccess.OperationSequence.PerformSequence(null, null, AntenaInfo_9);
                        }
                        else
                        {
                            RFID_READER_9.Actions.Inventory.Perform(null, null, AntenaInfo_9);
                        }

                        Log.Instance.Info("Lectura de tags iniciado");
                        break;
                    case 10:

                        if (RFID_READER_10.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            RFID_READER_10.Actions.TagAccess.OperationSequence.PerformSequence(null, null, AntenaInfo_10);
                        }
                        else
                        {
                            RFID_READER_10.Actions.Inventory.Perform(null, null, AntenaInfo_10);
                        }

                        Log.Instance.Info("Lectura de tags iniciado");
                        break;
                    case 11:

                        if (RFID_READER_11.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            RFID_READER_11.Actions.TagAccess.OperationSequence.PerformSequence(null, null, AntenaInfo_11);
                        }
                        else
                        {
                            RFID_READER_11.Actions.Inventory.Perform(null, null, AntenaInfo_11);
                        }

                        Log.Instance.Info("Lectura de tags iniciado");
                        break;
                    case 12:

                        if (RFID_READER_12.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            RFID_READER_12.Actions.TagAccess.OperationSequence.PerformSequence(null, null, AntenaInfo_12);
                        }
                        else
                        {
                            RFID_READER_12.Actions.Inventory.Perform(null, null, AntenaInfo_12);
                        }

                        Log.Instance.Info("Lectura de tags iniciado");
                        break;
                    case 13:

                        if (RFID_READER_13.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            RFID_READER_13.Actions.TagAccess.OperationSequence.PerformSequence(null, null, AntenaInfo_13);
                        }
                        else
                        {
                            RFID_READER_13.Actions.Inventory.Perform(null, null, AntenaInfo_13);
                        }

                        Log.Instance.Info("Lectura de tags iniciado");
                        break;
                    case 14:

                        if (RFID_READER_14.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            RFID_READER_14.Actions.TagAccess.OperationSequence.PerformSequence(null, null, AntenaInfo_14);
                        }
                        else
                        {
                            RFID_READER_14.Actions.Inventory.Perform(null, null, AntenaInfo_14);
                        }

                        Log.Instance.Info("Lectura de tags iniciado");
                        break;
                    case 15:

                        if (RFID_READER_15.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            RFID_READER_15.Actions.TagAccess.OperationSequence.PerformSequence(null, null, AntenaInfo_15);
                        }
                        else
                        {
                            RFID_READER_15.Actions.Inventory.Perform(null, null, AntenaInfo_15);
                        }

                        Log.Instance.Info("Lectura de tags iniciado");
                        break;
                    case 16:

                        if (RFID_READER_16.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            RFID_READER_16.Actions.TagAccess.OperationSequence.PerformSequence(null, null, AntenaInfo_16);
                        }
                        else
                        {
                            RFID_READER_16.Actions.Inventory.Perform(null, null, AntenaInfo_16);
                        }

                        Log.Instance.Info("Lectura de tags iniciado");
                        break;
                    case 17:

                        if (RFID_READER_17.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            RFID_READER_17.Actions.TagAccess.OperationSequence.PerformSequence(null, null, AntenaInfo_17);
                        }
                        else
                        {
                            RFID_READER_17.Actions.Inventory.Perform(null, null, AntenaInfo_17);
                        }

                        Log.Instance.Info("Lectura de tags iniciado");
                        break;
                    case 18:

                        if (RFID_READER_18.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            RFID_READER_18.Actions.TagAccess.OperationSequence.PerformSequence(null, null, AntenaInfo_18);
                        }
                        else
                        {
                            RFID_READER_18.Actions.Inventory.Perform(null, null, AntenaInfo_18);
                        }

                        Log.Instance.Info("Lectura de tags iniciado");
                        break;
                    case 19:

                        if (RFID_READER_19.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            RFID_READER_19.Actions.TagAccess.OperationSequence.PerformSequence(null, null, AntenaInfo_19);
                        }
                        else
                        {
                            RFID_READER_19.Actions.Inventory.Perform(null, null, AntenaInfo_19);
                        }

                        Log.Instance.Info("Lectura de tags iniciado");
                        break;
                    case 20:

                        if (RFID_READER_20.Actions.TagAccess.OperationSequence.Length > 0)
                        {
                            RFID_READER_20.Actions.TagAccess.OperationSequence.PerformSequence(null, null, AntenaInfo_20);
                        }
                        else
                        {
                            RFID_READER_20.Actions.Inventory.Perform(null, null, AntenaInfo_20);
                        }

                        Log.Instance.Info("Lectura de tags iniciado");
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error iniciando la lectura de tags", ex);
            }

        }

        #endregion

        //--------------------

        #region INICIAR ANTENNAS

        /// <summary>
        /// DEFINE CANTIDAD DE ANTENAS CONECTAS AL EQUIPO
        /// Y LAS ACTIVAS PARA SU LECTURA
        /// </summary>
        private void INICIAR_ANTENENAS(int ID_PORTAL)
        {
            if (ID_PORTAL == 1)
            {
                #region ANTENNA

                try
                {
                    //VARIABLES
                    int numAtenna = RFID_READER_1.Config.Antennas.AvailableAntennas.Length;

                    ushort[] antList = new ushort[numAtenna];

                    for (int index = 1; index <= numAtenna; index++)
                    {
                        antList[index - 1] = ushort.Parse(index.ToString());
                    }

                    if (null == AntenaInfo_1)
                    {
                        AntenaInfo_1 = new Symbol.RFID3.AntennaInfo(antList);
                    }
                    else
                    {
                        AntenaInfo_1.AntennaID = antList;
                    }
                    Log.Instance.Info("Inicializacion de antenas iniciada");
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException("Error iniciando las antenas", ex);
                }

                #endregion
            }
            else if (ID_PORTAL == 2)
            {
                #region ANTENNA

                try
                {
                    //VARIABLES
                    int numAtenna = RFID_READER_2.Config.Antennas.AvailableAntennas.Length;

                    ushort[] antList = new ushort[numAtenna];

                    for (int index = 1; index <= numAtenna; index++)
                    {
                        antList[index - 1] = ushort.Parse(index.ToString());
                    }

                    if (null == AntenaInfo_2)
                    {
                        AntenaInfo_2 = new Symbol.RFID3.AntennaInfo(antList);
                    }
                    else
                    {
                        AntenaInfo_2.AntennaID = antList;
                    }
                    Log.Instance.Info("Inicializacion de antenas iniciada");
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException("Error iniciando las antenas", ex);
                }

                #endregion
            }
            else if (ID_PORTAL == 3)
            {
                #region ANTENNA

                try
                {
                    //VARIABLES
                    int numAtenna = RFID_READER_3.Config.Antennas.AvailableAntennas.Length;

                    ushort[] antList = new ushort[numAtenna];

                    for (int index = 1; index <= numAtenna; index++)
                    {
                        antList[index - 1] = ushort.Parse(index.ToString());
                    }

                    if (null == AntenaInfo_3)
                    {
                        AntenaInfo_3 = new Symbol.RFID3.AntennaInfo(antList);
                    }
                    else
                    {
                        AntenaInfo_3.AntennaID = antList;
                    }
                    Log.Instance.Info("Inicializacion de antenas iniciada");
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException("Error iniciando las antenas", ex);
                }

                #endregion
            }
            else if (ID_PORTAL == 4)
            {
                #region ANTENNA

                try
                {
                    //VARIABLES
                    int numAtenna = RFID_READER_4.Config.Antennas.AvailableAntennas.Length;

                    ushort[] antList = new ushort[numAtenna];

                    for (int index = 1; index <= numAtenna; index++)
                    {
                        antList[index - 1] = ushort.Parse(index.ToString());
                    }

                    if (null == AntenaInfo_4)
                    {
                        AntenaInfo_4 = new Symbol.RFID3.AntennaInfo(antList);
                    }
                    else
                    {
                        AntenaInfo_4.AntennaID = antList;
                    }
                    Log.Instance.Info("Inicializacion de antenas iniciada");
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException("Error iniciando las antenas", ex);
                }

                #endregion
            }
            else if (ID_PORTAL == 5)
            {
                #region ANTENNA

                try
                {
                    //VARIABLES
                    int numAtenna = RFID_READER_5.Config.Antennas.AvailableAntennas.Length;

                    ushort[] antList = new ushort[numAtenna];

                    for (int index = 1; index <= numAtenna; index++)
                    {
                        antList[index - 1] = ushort.Parse(index.ToString());
                    }

                    if (null == AntenaInfo_5)
                    {
                        AntenaInfo_5 = new Symbol.RFID3.AntennaInfo(antList);
                    }
                    else
                    {
                        AntenaInfo_5.AntennaID = antList;
                    }
                    Log.Instance.Info("Inicializacion de antenas iniciada");
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException("Error iniciando las antenas", ex);
                }

                #endregion
            }
            else if (ID_PORTAL == 6)
            {
                #region ANTENNA

                try
                {
                    //VARIABLES
                    int numAtenna = RFID_READER_6.Config.Antennas.AvailableAntennas.Length;

                    ushort[] antList = new ushort[numAtenna];

                    for (int index = 1; index <= numAtenna; index++)
                    {
                        antList[index - 1] = ushort.Parse(index.ToString());
                    }

                    if (null == AntenaInfo_6)
                    {
                        AntenaInfo_6 = new Symbol.RFID3.AntennaInfo(antList);
                    }
                    else
                    {
                        AntenaInfo_6.AntennaID = antList;
                    }
                    Log.Instance.Info("Inicializacion de antenas iniciada");
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException("Error iniciando las antenas", ex);
                }

                #endregion
            }
            else if (ID_PORTAL == 7)
            {
                #region ANTENNA

                try
                {
                    //VARIABLES
                    int numAtenna = RFID_READER_7.Config.Antennas.AvailableAntennas.Length;

                    ushort[] antList = new ushort[numAtenna];

                    for (int index = 1; index <= numAtenna; index++)
                    {
                        antList[index - 1] = ushort.Parse(index.ToString());
                    }

                    if (null == AntenaInfo_7)
                    {
                        AntenaInfo_7 = new Symbol.RFID3.AntennaInfo(antList);
                    }
                    else
                    {
                        AntenaInfo_7.AntennaID = antList;
                    }
                    Log.Instance.Info("Inicializacion de antenas iniciada");
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException("Error iniciando las antenas", ex);
                }

                #endregion
            }
            else if (ID_PORTAL == 8)
            {
                #region ANTENNA

                try
                {
                    //VARIABLES
                    int numAtenna = RFID_READER_8.Config.Antennas.AvailableAntennas.Length;

                    ushort[] antList = new ushort[numAtenna];

                    for (int index = 1; index <= numAtenna; index++)
                    {
                        antList[index - 1] = ushort.Parse(index.ToString());
                    }

                    if (null == AntenaInfo_8)
                    {
                        AntenaInfo_8 = new Symbol.RFID3.AntennaInfo(antList);
                    }
                    else
                    {
                        AntenaInfo_8.AntennaID = antList;
                    }
                    Log.Instance.Info("Inicializacion de antenas iniciada");
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException("Error iniciando las antenas", ex);
                }

                #endregion
            }
            else if (ID_PORTAL == 9)
            {
                #region ANTENNA

                try
                {
                    //VARIABLES
                    int numAtenna = RFID_READER_9.Config.Antennas.AvailableAntennas.Length;

                    ushort[] antList = new ushort[numAtenna];

                    for (int index = 1; index <= numAtenna; index++)
                    {
                        antList[index - 1] = ushort.Parse(index.ToString());
                    }

                    if (null == AntenaInfo_9)
                    {
                        AntenaInfo_9 = new Symbol.RFID3.AntennaInfo(antList);
                    }
                    else
                    {
                        AntenaInfo_9.AntennaID = antList;
                    }
                    Log.Instance.Info("Inicializacion de antenas iniciada");
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException("Error iniciando las antenas", ex);
                }

                #endregion
            }
            else if (ID_PORTAL == 10)
            {
                #region ANTENNA

                try
                {
                    //VARIABLES
                    int numAtenna = RFID_READER_10.Config.Antennas.AvailableAntennas.Length;

                    ushort[] antList = new ushort[numAtenna];

                    for (int index = 1; index <= numAtenna; index++)
                    {
                        antList[index - 1] = ushort.Parse(index.ToString());
                    }

                    if (null == AntenaInfo_10)
                    {
                        AntenaInfo_10 = new Symbol.RFID3.AntennaInfo(antList);
                    }
                    else
                    {
                        AntenaInfo_10.AntennaID = antList;
                    }
                    Log.Instance.Info("Inicializacion de antenas iniciada");
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException("Error iniciando las antenas", ex);
                }

                #endregion
            }
            else if (ID_PORTAL == 11)
            {
                #region ANTENNA

                try
                {
                    //VARIABLES
                    int numAtenna = RFID_READER_11.Config.Antennas.AvailableAntennas.Length;

                    ushort[] antList = new ushort[numAtenna];

                    for (int index = 1; index <= numAtenna; index++)
                    {
                        antList[index - 1] = ushort.Parse(index.ToString());
                    }

                    if (null == AntenaInfo_11)
                    {
                        AntenaInfo_11 = new Symbol.RFID3.AntennaInfo(antList);
                    }
                    else
                    {
                        AntenaInfo_11.AntennaID = antList;
                    }
                    Log.Instance.Info("Inicializacion de antenas iniciada");
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException("Error iniciando las antenas", ex);
                }

                #endregion
            }
            else if (ID_PORTAL == 12)
            {
                #region ANTENNA

                try
                {
                    //VARIABLES
                    int numAtenna = RFID_READER_12.Config.Antennas.AvailableAntennas.Length;

                    ushort[] antList = new ushort[numAtenna];

                    for (int index = 1; index <= numAtenna; index++)
                    {
                        antList[index - 1] = ushort.Parse(index.ToString());
                    }

                    if (null == AntenaInfo_12)
                    {
                        AntenaInfo_12 = new Symbol.RFID3.AntennaInfo(antList);
                    }
                    else
                    {
                        AntenaInfo_12.AntennaID = antList;
                    }
                    Log.Instance.Info("Inicializacion de antenas iniciada");
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException("Error iniciando las antenas", ex);
                }

                #endregion
            }
            else if (ID_PORTAL == 13)
            {
                #region ANTENNA

                try
                {
                    //VARIABLES
                    int numAtenna = RFID_READER_13.Config.Antennas.AvailableAntennas.Length;

                    ushort[] antList = new ushort[numAtenna];

                    for (int index = 1; index <= numAtenna; index++)
                    {
                        antList[index - 1] = ushort.Parse(index.ToString());
                    }

                    if (null == AntenaInfo_13)
                    {
                        AntenaInfo_13 = new Symbol.RFID3.AntennaInfo(antList);
                    }
                    else
                    {
                        AntenaInfo_13.AntennaID = antList;
                    }
                    Log.Instance.Info("Inicializacion de antenas iniciada");
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException("Error iniciando las antenas", ex);
                }

                #endregion
            }
            else if (ID_PORTAL == 14)
            {
                #region ANTENNA

                try
                {
                    //VARIABLES
                    int numAtenna = RFID_READER_14.Config.Antennas.AvailableAntennas.Length;

                    ushort[] antList = new ushort[numAtenna];

                    for (int index = 1; index <= numAtenna; index++)
                    {
                        antList[index - 1] = ushort.Parse(index.ToString());
                    }

                    if (null == AntenaInfo_14)
                    {
                        AntenaInfo_14 = new Symbol.RFID3.AntennaInfo(antList);
                    }
                    else
                    {
                        AntenaInfo_14.AntennaID = antList;
                    }
                    Log.Instance.Info("Inicializacion de antenas iniciada");
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException("Error iniciando las antenas", ex);
                }

                #endregion
            }
            else if (ID_PORTAL == 15)
            {
                #region ANTENNA

                try
                {
                    //VARIABLES
                    int numAtenna = RFID_READER_15.Config.Antennas.AvailableAntennas.Length;

                    ushort[] antList = new ushort[numAtenna];

                    for (int index = 1; index <= numAtenna; index++)
                    {
                        antList[index - 1] = ushort.Parse(index.ToString());
                    }

                    if (null == AntenaInfo_15)
                    {
                        AntenaInfo_15 = new Symbol.RFID3.AntennaInfo(antList);
                    }
                    else
                    {
                        AntenaInfo_15.AntennaID = antList;
                    }
                    Log.Instance.Info("Inicializacion de antenas iniciada");
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException("Error iniciando las antenas", ex);
                }

                #endregion
            }
            else if (ID_PORTAL == 16)
            {
                #region ANTENNA

                try
                {
                    //VARIABLES
                    int numAtenna = RFID_READER_16.Config.Antennas.AvailableAntennas.Length;

                    ushort[] antList = new ushort[numAtenna];

                    for (int index = 1; index <= numAtenna; index++)
                    {
                        antList[index - 1] = ushort.Parse(index.ToString());
                    }

                    if (null == AntenaInfo_16)
                    {
                        AntenaInfo_16 = new Symbol.RFID3.AntennaInfo(antList);
                    }
                    else
                    {
                        AntenaInfo_16.AntennaID = antList;
                    }
                    Log.Instance.Info("Inicializacion de antenas iniciada");
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException("Error iniciando las antenas", ex);
                }

                #endregion
            }
            else if (ID_PORTAL == 17)
            {
                #region ANTENNA

                try
                {
                    //VARIABLES
                    int numAtenna = RFID_READER_17.Config.Antennas.AvailableAntennas.Length;

                    ushort[] antList = new ushort[numAtenna];

                    for (int index = 1; index <= numAtenna; index++)
                    {
                        antList[index - 1] = ushort.Parse(index.ToString());
                    }

                    if (null == AntenaInfo_17)
                    {
                        AntenaInfo_17 = new Symbol.RFID3.AntennaInfo(antList);
                    }
                    else
                    {
                        AntenaInfo_17.AntennaID = antList;
                    }
                    Log.Instance.Info("Inicializacion de antenas iniciada");
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException("Error iniciando las antenas", ex);
                }

                #endregion
            }
            else if (ID_PORTAL == 18)
            {
                #region ANTENNA

                try
                {
                    //VARIABLES
                    int numAtenna = RFID_READER_18.Config.Antennas.AvailableAntennas.Length;

                    ushort[] antList = new ushort[numAtenna];

                    for (int index = 1; index <= numAtenna; index++)
                    {
                        antList[index - 1] = ushort.Parse(index.ToString());
                    }

                    if (null == AntenaInfo_18)
                    {
                        AntenaInfo_18 = new Symbol.RFID3.AntennaInfo(antList);
                    }
                    else
                    {
                        AntenaInfo_18.AntennaID = antList;
                    }
                    Log.Instance.Info("Inicializacion de antenas iniciada");
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException("Error iniciando las antenas", ex);
                }

                #endregion
            }
            else if (ID_PORTAL == 19)
            {
                #region ANTENNA

                try
                {
                    //VARIABLES
                    int numAtenna = RFID_READER_19.Config.Antennas.AvailableAntennas.Length;

                    ushort[] antList = new ushort[numAtenna];

                    for (int index = 1; index <= numAtenna; index++)
                    {
                        antList[index - 1] = ushort.Parse(index.ToString());
                    }

                    if (null == AntenaInfo_19)
                    {
                        AntenaInfo_19 = new Symbol.RFID3.AntennaInfo(antList);
                    }
                    else
                    {
                        AntenaInfo_19.AntennaID = antList;
                    }
                    Log.Instance.Info("Inicializacion de antenas iniciada");
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException("Error iniciando las antenas", ex);
                }

                #endregion
            }
            else if (ID_PORTAL == 20)
            {
                #region ANTENNA

                try
                {
                    //VARIABLES
                    int numAtenna = RFID_READER_20.Config.Antennas.AvailableAntennas.Length;

                    ushort[] antList = new ushort[numAtenna];

                    for (int index = 1; index <= numAtenna; index++)
                    {
                        antList[index - 1] = ushort.Parse(index.ToString());
                    }

                    if (null == AntenaInfo_20)
                    {
                        AntenaInfo_20 = new Symbol.RFID3.AntennaInfo(antList);
                    }
                    else
                    {
                        AntenaInfo_20.AntennaID = antList;
                    }
                    Log.Instance.Info("Inicializacion de antenas iniciada");
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException("Error iniciando las antenas", ex);
                }

                #endregion
            }
        }

        #endregion

        //--------------------

        #region EVENTO INICIAR LECTURA

        /// <summary>
        /// EVENTO | INICIAR LECTURA
        /// </summary>
        /// <param name="ID_PORTAL"></param>
        private void INICIAR_EVENTO_LECTURA(int ID_PORTAL)
        {
            if (ID_PORTAL == 1)
            {
                m_UpdateReadHandler_1 = new UpdateRead(REGISTRO_LECTURAS_READER_1);
            }
            else if (ID_PORTAL == 2)
            {
                m_UpdateReadHandler_2 = new UpdateRead(REGISTRO_LECTURAS_READER_2);
            }
            else if (ID_PORTAL == 3)
            {
                m_UpdateReadHandler_3 = new UpdateRead(REGISTRO_LECTURAS_READER_3);
            }
            else if (ID_PORTAL == 4)
            {
                m_UpdateReadHandler_4 = new UpdateRead(REGISTRO_LECTURAS_READER_4);
            }
            else if (ID_PORTAL == 5)
            {
                m_UpdateReadHandler_5 = new UpdateRead(REGISTRO_LECTURAS_READER_5);
            }
            else if (ID_PORTAL == 6)
            {
                m_UpdateReadHandler_6 = new UpdateRead(REGISTRO_LECTURAS_READER_6);
            }
            else if (ID_PORTAL == 7)
            {
                m_UpdateReadHandler_7 = new UpdateRead(REGISTRO_LECTURAS_READER_7);
            }
            else if (ID_PORTAL == 8)
            {
                m_UpdateReadHandler_8 = new UpdateRead(REGISTRO_LECTURAS_READER_8);
            }
            else if (ID_PORTAL == 9)
            {
                m_UpdateReadHandler_9 = new UpdateRead(REGISTRO_LECTURAS_READER_9);
            }
            else if (ID_PORTAL == 10)
            {
                m_UpdateReadHandler_10 = new UpdateRead(REGISTRO_LECTURAS_READER_10);
            }
            else if (ID_PORTAL == 11)
            {
                m_UpdateReadHandler_11 = new UpdateRead(REGISTRO_LECTURAS_READER_11);
            }
            else if (ID_PORTAL == 12)
            {
                m_UpdateReadHandler_12 = new UpdateRead(REGISTRO_LECTURAS_READER_12);
            }
            else if (ID_PORTAL == 13)
            {
                m_UpdateReadHandler_13 = new UpdateRead(REGISTRO_LECTURAS_READER_13);
            }
            else if (ID_PORTAL == 14)
            {
                m_UpdateReadHandler_14 = new UpdateRead(REGISTRO_LECTURAS_READER_14);
            }
            else if (ID_PORTAL == 15)
            {
                m_UpdateReadHandler_15 = new UpdateRead(REGISTRO_LECTURAS_READER_15);
            }
            else if (ID_PORTAL == 16)
            {
                m_UpdateReadHandler_16 = new UpdateRead(REGISTRO_LECTURAS_READER_16);
            }
            else if (ID_PORTAL == 17)
            {
                m_UpdateReadHandler_17 = new UpdateRead(REGISTRO_LECTURAS_READER_17);
            }
            else if (ID_PORTAL == 18)
            {
                m_UpdateReadHandler_18 = new UpdateRead(REGISTRO_LECTURAS_READER_18);
            }
            else if (ID_PORTAL == 19)
            {
                m_UpdateReadHandler_19 = new UpdateRead(REGISTRO_LECTURAS_READER_19);
            }
            else if (ID_PORTAL == 20)
            {
                m_UpdateReadHandler_20 = new UpdateRead(REGISTRO_LECTURAS_READER_20);
            }
        }

        #endregion

        //--------------------

        #region LIMPIAR ARRAYS

        /// <summary>
        /// LIMPIAR ARREGLO
        /// </summary>
        private void CLEAR_ARRAY_1()
        {
            while (true)
            {
                Thread.Sleep(2000);
                TagsAlmacenados_1.Clear();
            }
        }

        /// <summary>
        /// LIMPIAR ARREGLO
        /// </summary>
        private void CLEAR_ARRAY_2()
        {
            while (true)
            {
                Thread.Sleep(2000);
                TagsAlmacenados_2.Clear();
            }
        }

        /// <summary>
        /// LIMPIAR ARREGLO
        /// </summary>
        private void CLEAR_ARRAY_3()
        {
            while (true)
            {
                Thread.Sleep(2000);
                TagsAlmacenados_3.Clear();
            }
        }

        /// <summary>
        /// LIMPIAR ARREGLO
        /// </summary>
        private void CLEAR_ARRAY_4()
        {
            while (true)
            {
                Thread.Sleep(2000);
                TagsAlmacenados_4.Clear();
            }
        }

        /// <summary>
        /// LIMPIAR ARREGLO
        /// </summary>
        private void CLEAR_ARRAY_5()
        {
            while (true)
            {
                Thread.Sleep(2000);
                TagsAlmacenados_5.Clear();
            }
        }

        /// <summary>
        /// LIMPIAR ARREGLO
        /// </summary>
        private void CLEAR_ARRAY_6()
        {
            while (true)
            {
                Thread.Sleep(2000);
                TagsAlmacenados_6.Clear();
            }
        }

        /// <summary>
        /// LIMPIAR ARREGLO
        /// </summary>
        private void CLEAR_ARRAY_7()
        {
            while (true)
            {
                Thread.Sleep(2000);
                TagsAlmacenados_7.Clear();
            }
        }

        /// <summary>
        /// LIMPIAR ARREGLO
        /// </summary>
        private void CLEAR_ARRAY_8()
        {
            while (true)
            {
                Thread.Sleep(2000);
                TagsAlmacenados_8.Clear();
            }
        }

        /// <summary>
        /// LIMPIAR ARREGLO
        /// </summary>
        private void CLEAR_ARRAY_9()
        {
            while (true)
            {
                Thread.Sleep(2000);
                TagsAlmacenados_9.Clear();
            }
        }

        /// <summary>
        /// LIMPIAR ARREGLO
        /// </summary>
        private void CLEAR_ARRAY_10()
        {
            while (true)
            {
                Thread.Sleep(2000);
                TagsAlmacenados_10.Clear();
            }
        }

        /// <summary>
        /// LIMPIAR ARREGLO
        /// </summary>
        private void CLEAR_ARRAY_11()
        {
            while (true)
            {
                Thread.Sleep(2000);
                TagsAlmacenados_11.Clear();
            }
        }

        /// <summary>
        /// LIMPIAR ARREGLO
        /// </summary>
        private void CLEAR_ARRAY_12()
        {
            while (true)
            {
                Thread.Sleep(2000);
                TagsAlmacenados_12.Clear();
            }
        }

        /// <summary>
        /// LIMPIAR ARREGLO
        /// </summary>
        private void CLEAR_ARRAY_13()
        {
            while (true)
            {
                Thread.Sleep(2000);
                TagsAlmacenados_13.Clear();
            }
        }

        /// <summary>
        /// LIMPIAR ARREGLO
        /// </summary>
        private void CLEAR_ARRAY_14()
        {
            while (true)
            {
                Thread.Sleep(2000);
                TagsAlmacenados_14.Clear();
            }
        }

        /// <summary>
        /// LIMPIAR ARREGLO
        /// </summary>
        private void CLEAR_ARRAY_15()
        {
            while (true)
            {
                Thread.Sleep(2000);
                TagsAlmacenados_15.Clear();
            }
        }

        /// <summary>
        /// LIMPIAR ARREGLO
        /// </summary>
        private void CLEAR_ARRAY_16()
        {
            while (true)
            {
                Thread.Sleep(2000);
                TagsAlmacenados_16.Clear();
            }
        }

        /// <summary>
        /// LIMPIAR ARREGLO
        /// </summary>
        private void CLEAR_ARRAY_17()
        {
            while (true)
            {
                Thread.Sleep(2000);
                TagsAlmacenados_17.Clear();
            }
        }

        /// <summary>
        /// LIMPIAR ARREGLO
        /// </summary>
        private void CLEAR_ARRAY_18()
        {
            while (true)
            {
                Thread.Sleep(2000);
                TagsAlmacenados_18.Clear();
            }
        }

        /// <summary>
        /// LIMPIAR ARREGLO
        /// </summary>
        private void CLEAR_ARRAY_19()
        {
            while (true)
            {
                Thread.Sleep(2000);
                TagsAlmacenados_19.Clear();
            }
        }

        /// <summary>
        /// LIMPIAR ARREGLO
        /// </summary>
        private void CLEAR_ARRAY_20()
        {
            while (true)
            {
                Thread.Sleep(2000);
                TagsAlmacenados_20.Clear();
            }
        }

        #endregion

        //--------------------

        #region REGISTRAR LECTURAS

        //Este metodo recibe un evento de lectura que es Events.ReadEventData, 
        //apenas detecta la lectura que es de un tag ingresa a este metodo

        private void REGISTRO_LECTURAS_READER_1(Events.ReadEventData eventData)
        {

            if (FLAG_LECTURA_1 == true)
            {
                //VARIABLE
                int ID_PORTAL = 1;

                try
                {
                    if (m_IsConnected_1 == true)
                    {
                        Symbol.RFID3.TagData[] tagData = RFID_READER_1.Actions.GetReadTags(1000);

                        if (tagData != null)
                        {
                            if (eventData != null)
                            {
                                if (tagData[0].TagID.Length <= 24)
                                {
                                    //////////////////////
                                    //ESCRIBIR ACHIVO [ULTIMA LECTURA]
                                    WRITE_ULTIMA_LECTURA_1();

                                    //LOG RESGISTRO DE LECTURA DEL TAG
                                    log.LogLecturasPortales(RFID_READER_1.HostName, Convert.ToString(ID_PORTAL), tagData[0].TagID);

                                    //////////////////////
                                    //VALIDAR SI EL ARCHIVO BLACKLIST.TXT TIENE CONTENIDO
                                    if (!blacklist_1.Contains(tagData[0].TagID))
                                    {
                                        if (!TagsAlmacenados_1.Contains(tagData[0].TagID))
                                        {
                                            //////////////////////
                                            //INSERTAR A BITACORA
                                            bitacora.INSERTAR_ENTRADA_SALIDA_1(tagData, RFID_READER_1.HostName);

                                            TagsAlmacenados_1.Add(tagData[0].TagID);


                                            //INOCAR CLASE CONSULTAS
                                            DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();
                                            //APLICAR PROCESO
                                            bool Respuesta = PORTAL.UPDATE_ESTADO_PORTAL(ID_PORTAL, true);
                                        }
                                    }
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

                    Log.Instance.ErrorException("Error en el manejo de evento e insercion en bitacora", ex);
                }
            }
            else
            {
                return;
            }



        }

        private void REGISTRO_LECTURAS_READER_2(Events.ReadEventData eventData)
        {
            //VARIABLE
            int ID_PORTAL = 2;

            try
            {
                if (m_IsConnected_2 == true)
                {
                    Symbol.RFID3.TagData[] tagData = RFID_READER_2.Actions.GetReadTags(1000);

                    if (tagData != null)
                    {
                        if (eventData != null)
                        {
                            if (tagData[0].TagID.Length <= 24)
                            {
                                //////////////////////
                                //ESCRIBIR ACHIVO [ULTIMA LECTURA]
                                WRITE_ULTIMA_LECTURA_2();

                                //LOG RESGISTRO DE LECTURA DEL TAG
                                log.LogLecturasPortales(RFID_READER_2.HostName, Convert.ToString(ID_PORTAL), tagData[0].TagID);

                                //////////////////////
                                //VALIDAR SI EL ARCHIVO BLACKLIST.TXT TIENE CONTENIDO
                                if (!blacklist_2.Contains(tagData[0].TagID))
                                {
                                    if (!TagsAlmacenados_2.Contains(tagData[0].TagID))
                                    {
                                        //////////////////////
                                        //INSERTAR A BITACORA
                                        bitacora.INSERTAR_ENTRADA_SALIDA_2(tagData, RFID_READER_2.HostName);

                                        TagsAlmacenados_2.Add(tagData[0].TagID);


                                        //INOCAR CLASE CONSULTAS
                                        DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();
                                        //APLICAR PROCESO
                                        bool Respuesta = PORTAL.UPDATE_ESTADO_PORTAL(ID_PORTAL, true);
                                    }
                                }
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

                Log.Instance.ErrorException("Error en el manejo de evento e insercion en bitacora", ex);
            }

        }

        private void REGISTRO_LECTURAS_READER_3(Events.ReadEventData eventData)
        {
            //VARIABLE
            int ID_PORTAL = 3;

            try
            {
                if (m_IsConnected_3 == true)
                {
                    Symbol.RFID3.TagData[] tagData = RFID_READER_3.Actions.GetReadTags(1000);

                    if (tagData != null)
                    {
                        if (eventData != null)
                        {
                            if (tagData[0].TagID.Length <= 24)
                            {
                                //////////////////////
                                //ESCRIBIR ACHIVO [ULTIMA LECTURA]
                                WRITE_ULTIMA_LECTURA_3();

                                //LOG RESGISTRO DE LECTURA DEL TAG
                                log.LogLecturasPortales(RFID_READER_3.HostName, Convert.ToString(ID_PORTAL), tagData[0].TagID);

                                //////////////////////
                                //VALIDAR SI EL ARCHIVO BLACKLIST.TXT TIENE CONTENIDO
                                if (!blacklist_3.Contains(tagData[0].TagID))
                                {
                                    if (!TagsAlmacenados_3.Contains(tagData[0].TagID))
                                    {
                                        //////////////////////
                                        //INSERTAR A BITACORA
                                        bitacora.INSERTAR_ENTRADA_SALIDA_3(tagData, RFID_READER_3.HostName);

                                        TagsAlmacenados_3.Add(tagData[0].TagID);


                                        //INOCAR CLASE CONSULTAS
                                        DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();
                                        //APLICAR PROCESO
                                        bool Respuesta = PORTAL.UPDATE_ESTADO_PORTAL(ID_PORTAL, true);
                                    }
                                }
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

                Log.Instance.ErrorException("Error en el manejo de evento e insercion en bitacora", ex);
            }

        }

        private void REGISTRO_LECTURAS_READER_4(Events.ReadEventData eventData)
        {
            //VARIABLE
            int ID_PORTAL = 4;

            try
            {
                if (m_IsConnected_4 == true)
                {
                    Symbol.RFID3.TagData[] tagData = RFID_READER_4.Actions.GetReadTags(1000);

                    if (tagData != null)
                    {
                        if (eventData != null)
                        {
                            if (tagData[0].TagID.Length <= 24)
                            {
                                //////////////////////
                                //ESCRIBIR ACHIVO [ULTIMA LECTURA]
                                WRITE_ULTIMA_LECTURA_4();

                                //LOG RESGISTRO DE LECTURA DEL TAG
                                log.LogLecturasPortales(RFID_READER_4.HostName, Convert.ToString(ID_PORTAL), tagData[0].TagID);

                                //////////////////////
                                //VALIDAR SI EL ARCHIVO BLACKLIST.TXT TIENE CONTENIDO
                                if (!blacklist_4.Contains(tagData[0].TagID))
                                {
                                    if (!TagsAlmacenados_4.Contains(tagData[0].TagID))
                                    {
                                        //////////////////////
                                        //INSERTAR A BITACORA
                                        bitacora.INSERTAR_ENTRADA_SALIDA_4(tagData, RFID_READER_4.HostName);

                                        TagsAlmacenados_4.Add(tagData[0].TagID);


                                        //INOCAR CLASE CONSULTAS
                                        DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();
                                        //APLICAR PROCESO
                                        bool Respuesta = PORTAL.UPDATE_ESTADO_PORTAL(ID_PORTAL, true);
                                    }
                                }
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

                Log.Instance.ErrorException("Error en el manejo de evento e insercion en bitacora", ex);
            }

        }

        private void REGISTRO_LECTURAS_READER_5(Events.ReadEventData eventData)
        {
            //VARIABLE
            int ID_PORTAL = 5;

            try
            {
                if (m_IsConnected_5 == true)
                {
                    Symbol.RFID3.TagData[] tagData = RFID_READER_5.Actions.GetReadTags(1000);
                    //Symbol.RFID3.TagData[] tagData = RFID_READER.Actions.GetReadTags(100);

                    if (tagData != null)
                    {
                        if (eventData != null)
                        {
                            if (tagData[0].TagID.Length <= 24)
                            {
                                //////////////////////
                                //ESCRIBIR ACHIVO [ULTIMA LECTURA]
                                WRITE_ULTIMA_LECTURA_5();

                                //LOG RESGISTRO DE LECTURA DEL TAG
                                log.LogLecturasPortales(RFID_READER_5.HostName, Convert.ToString(ID_PORTAL), tagData[0].TagID);

                                //////////////////////
                                //VALIDAR SI EL ARCHIVO BLACKLIST.TXT TIENE CONTENIDO
                                if (!blacklist_5.Contains(tagData[0].TagID))
                                {
                                    if (!TagsAlmacenados_5.Contains(tagData[0].TagID))
                                    {
                                        //////////////////////
                                        //INSERTAR A BITACORA
                                        bitacora.INSERTAR_ENTRADA_SALIDA_5(tagData, RFID_READER_5.HostName);

                                        TagsAlmacenados_5.Add(tagData[0].TagID);


                                        //INOCAR CLASE CONSULTAS
                                        DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();
                                        //APLICAR PROCESO
                                        bool Respuesta = PORTAL.UPDATE_ESTADO_PORTAL(ID_PORTAL, true);
                                    }
                                }
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

                Log.Instance.ErrorException("Error en el manejo de evento e insercion en bitacora", ex);
            }

        }

        private void REGISTRO_LECTURAS_READER_6(Events.ReadEventData eventData)
        {
            //VARIABLE
            int ID_PORTAL = 6;

            try
            {
                if (m_IsConnected_6 == true)
                {
                    Symbol.RFID3.TagData[] tagData = RFID_READER_6.Actions.GetReadTags(1000);

                    if (tagData != null)
                    {
                        if (eventData != null)
                        {
                            if (tagData[0].TagID.Length <= 24)
                            {
                                //////////////////////
                                //ESCRIBIR ACHIVO [ULTIMA LECTURA]
                                WRITE_ULTIMA_LECTURA_6();

                                //LOG RESGISTRO DE LECTURA DEL TAG
                                log.LogLecturasPortales(RFID_READER_6.HostName, Convert.ToString(ID_PORTAL), tagData[0].TagID);

                                //////////////////////
                                //VALIDAR SI EL ARCHIVO BLACKLIST.TXT TIENE CONTENIDO
                                if (!blacklist_6.Contains(tagData[0].TagID))
                                {
                                    if (!TagsAlmacenados_6.Contains(tagData[0].TagID))
                                    {
                                        //////////////////////
                                        //INSERTAR A BITACORA
                                        bitacora.INSERTAR_ENTRADA_SALIDA_6(tagData, RFID_READER_6.HostName);

                                        TagsAlmacenados_6.Add(tagData[0].TagID);


                                        //INOCAR CLASE CONSULTAS
                                        DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();
                                        //APLICAR PROCESO
                                        bool Respuesta = PORTAL.UPDATE_ESTADO_PORTAL(ID_PORTAL, true);
                                    }
                                }
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

                Log.Instance.ErrorException("Error en el manejo de evento e insercion en bitacora", ex);
            }

        }

        private void REGISTRO_LECTURAS_READER_7(Events.ReadEventData eventData)
        {
            //VARIABLE
            int ID_PORTAL = 7;

            try
            {
                if (m_IsConnected_7 == true)
                {
                    Symbol.RFID3.TagData[] tagData = RFID_READER_7.Actions.GetReadTags(1000);

                    if (tagData != null)
                    {
                        if (eventData != null)
                        {
                            if (tagData[0].TagID.Length <= 24)
                            {
                                //////////////////////
                                //ESCRIBIR ACHIVO [ULTIMA LECTURA]
                                WRITE_ULTIMA_LECTURA_7();

                                //LOG RESGISTRO DE LECTURA DEL TAG
                                log.LogLecturasPortales(RFID_READER_7.HostName, Convert.ToString(ID_PORTAL), tagData[0].TagID);

                                //////////////////////
                                //VALIDAR SI EL ARCHIVO BLACKLIST.TXT TIENE CONTENIDO
                                if (!blacklist_7.Contains(tagData[0].TagID))
                                {
                                    if (!TagsAlmacenados_7.Contains(tagData[0].TagID))
                                    {
                                        //////////////////////
                                        //INSERTAR A BITACORA
                                        bitacora.INSERTAR_ENTRADA_SALIDA_7(tagData, RFID_READER_7.HostName);

                                        TagsAlmacenados_7.Add(tagData[0].TagID);


                                        //INOCAR CLASE CONSULTAS
                                        DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();
                                        //APLICAR PROCESO
                                        bool Respuesta = PORTAL.UPDATE_ESTADO_PORTAL(ID_PORTAL, true);
                                    }
                                }
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

                Log.Instance.ErrorException("Error en el manejo de evento e insercion en bitacora", ex);
            }

        }

        private void REGISTRO_LECTURAS_READER_8(Events.ReadEventData eventData)
        {
            //VARIABLE
            int ID_PORTAL = 8;

            try
            {
                if (m_IsConnected_8 == true)
                {
                    Symbol.RFID3.TagData[] tagData = RFID_READER_8.Actions.GetReadTags(1000);

                    if (tagData != null)
                    {
                        if (eventData != null)
                        {
                            if (tagData[0].TagID.Length <= 24)
                            {
                                //////////////////////
                                //ESCRIBIR ACHIVO [ULTIMA LECTURA]
                                WRITE_ULTIMA_LECTURA_8();

                                //LOG RESGISTRO DE LECTURA DEL TAG
                                log.LogLecturasPortales(RFID_READER_8.HostName, Convert.ToString(ID_PORTAL), tagData[0].TagID);

                                //////////////////////
                                //VALIDAR SI EL ARCHIVO BLACKLIST.TXT TIENE CONTENIDO
                                if (!blacklist_8.Contains(tagData[0].TagID))
                                {
                                    if (!TagsAlmacenados_8.Contains(tagData[0].TagID))
                                    {
                                        //////////////////////
                                        //INSERTAR A BITACORA
                                        bitacora.INSERTAR_ENTRADA_SALIDA_8(tagData, RFID_READER_8.HostName);

                                        TagsAlmacenados_8.Add(tagData[0].TagID);


                                        //INOCAR CLASE CONSULTAS
                                        DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();
                                        //APLICAR PROCESO
                                        bool Respuesta = PORTAL.UPDATE_ESTADO_PORTAL(ID_PORTAL, true);
                                    }
                                }
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

                Log.Instance.ErrorException("Error en el manejo de evento e insercion en bitacora", ex);
            }

        }

        private void REGISTRO_LECTURAS_READER_9(Events.ReadEventData eventData)
        {
            //VARIABLE
            int ID_PORTAL = 9;

            try
            {
                if (m_IsConnected_9 == true)
                {
                    Symbol.RFID3.TagData[] tagData = RFID_READER_9.Actions.GetReadTags(1000);

                    if (tagData != null)
                    {
                        if (eventData != null)
                        {
                            if (tagData[0].TagID.Length <= 24)
                            {
                                //////////////////////
                                //ESCRIBIR ACHIVO [ULTIMA LECTURA]
                                WRITE_ULTIMA_LECTURA_9();

                                //LOG RESGISTRO DE LECTURA DEL TAG
                                log.LogLecturasPortales(RFID_READER_9.HostName, Convert.ToString(ID_PORTAL), tagData[0].TagID);

                                //////////////////////
                                //VALIDAR SI EL ARCHIVO BLACKLIST.TXT TIENE CONTENIDO
                                if (!blacklist_9.Contains(tagData[0].TagID))
                                {
                                    if (!TagsAlmacenados_9.Contains(tagData[0].TagID))
                                    {
                                        //////////////////////
                                        //INSERTAR A BITACORA
                                        bitacora.INSERTAR_ENTRADA_SALIDA_9(tagData, RFID_READER_9.HostName);

                                        TagsAlmacenados_9.Add(tagData[0].TagID);


                                        //INOCAR CLASE CONSULTAS
                                        DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();
                                        //APLICAR PROCESO
                                        bool Respuesta = PORTAL.UPDATE_ESTADO_PORTAL(ID_PORTAL, true);
                                    }
                                }
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

                Log.Instance.ErrorException("Error en el manejo de evento e insercion en bitacora", ex);
            }

        }

        private void REGISTRO_LECTURAS_READER_10(Events.ReadEventData eventData)
        {
            //VARIABLE
            int ID_PORTAL = 10;

            try
            {
                if (m_IsConnected_10 == true)
                {
                    Symbol.RFID3.TagData[] tagData = RFID_READER_10.Actions.GetReadTags(1000);

                    if (tagData != null)
                    {
                        if (eventData != null)
                        {
                            if (tagData[0].TagID.Length <= 24)
                            {
                                //////////////////////
                                //ESCRIBIR ACHIVO [ULTIMA LECTURA]
                                WRITE_ULTIMA_LECTURA_10();

                                //LOG RESGISTRO DE LECTURA DEL TAG
                                log.LogLecturasPortales(RFID_READER_10.HostName, Convert.ToString(ID_PORTAL), tagData[0].TagID);

                                //////////////////////
                                //VALIDAR SI EL ARCHIVO BLACKLIST.TXT TIENE CONTENIDO
                                if (!blacklist_10.Contains(tagData[0].TagID))
                                {
                                    if (!TagsAlmacenados_10.Contains(tagData[0].TagID))
                                    {
                                        //////////////////////
                                        //INSERTAR A BITACORA
                                        bitacora.INSERTAR_ENTRADA_SALIDA_10(tagData, RFID_READER_10.HostName);

                                        TagsAlmacenados_10.Add(tagData[0].TagID);


                                        //INOCAR CLASE CONSULTAS
                                        DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();
                                        //APLICAR PROCESO
                                        bool Respuesta = PORTAL.UPDATE_ESTADO_PORTAL(ID_PORTAL, true);
                                    }
                                }
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

                Log.Instance.ErrorException("Error en el manejo de evento e insercion en bitacora", ex);
            }

        }

        private void REGISTRO_LECTURAS_READER_11(Events.ReadEventData eventData)
        {
            //VARIABLE
            int ID_PORTAL = 11;

            try
            {
                if (m_IsConnected_11 == true)
                {
                    Symbol.RFID3.TagData[] tagData = RFID_READER_11.Actions.GetReadTags(1000);

                    if (tagData != null)
                    {
                        if (eventData != null)
                        {
                            if (tagData[0].TagID.Length <= 24)
                            {
                                //////////////////////
                                //ESCRIBIR ACHIVO [ULTIMA LECTURA]
                                WRITE_ULTIMA_LECTURA_11();

                                //LOG RESGISTRO DE LECTURA DEL TAG
                                log.LogLecturasPortales(RFID_READER_11.HostName, Convert.ToString(ID_PORTAL), tagData[0].TagID);

                                //////////////////////
                                //VALIDAR SI EL ARCHIVO BLACKLIST.TXT TIENE CONTENIDO
                                if (!blacklist_11.Contains(tagData[0].TagID))
                                {
                                    if (!TagsAlmacenados_11.Contains(tagData[0].TagID))
                                    {
                                        //////////////////////
                                        //INSERTAR A BITACORA
                                        bitacora.INSERTAR_ENTRADA_SALIDA_11(tagData, RFID_READER_11.HostName);

                                        TagsAlmacenados_11.Add(tagData[0].TagID);


                                        //INOCAR CLASE CONSULTAS
                                        DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();
                                        //APLICAR PROCESO
                                        bool Respuesta = PORTAL.UPDATE_ESTADO_PORTAL(ID_PORTAL, true);
                                    }
                                }
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

                Log.Instance.ErrorException("Error en el manejo de evento e insercion en bitacora", ex);
            }

        }

        private void REGISTRO_LECTURAS_READER_12(Events.ReadEventData eventData)
        {
            //VARIABLE
            int ID_PORTAL = 12;

            try
            {
                if (m_IsConnected_12 == true)
                {
                    Symbol.RFID3.TagData[] tagData = RFID_READER_12.Actions.GetReadTags(1000);

                    if (tagData != null)
                    {
                        if (eventData != null)
                        {
                            if (tagData[0].TagID.Length <= 24)
                            {
                                //////////////////////
                                //ESCRIBIR ACHIVO [ULTIMA LECTURA]
                                WRITE_ULTIMA_LECTURA_12();

                                //LOG RESGISTRO DE LECTURA DEL TAG
                                log.LogLecturasPortales(RFID_READER_12.HostName, Convert.ToString(ID_PORTAL), tagData[0].TagID);

                                //////////////////////
                                //VALIDAR SI EL ARCHIVO BLACKLIST.TXT TIENE CONTENIDO
                                if (!blacklist_12.Contains(tagData[0].TagID))
                                {
                                    if (!TagsAlmacenados_12.Contains(tagData[0].TagID))
                                    {
                                        //////////////////////
                                        //INSERTAR A BITACORA
                                        bitacora.INSERTAR_ENTRADA_SALIDA_12(tagData, RFID_READER_12.HostName);

                                        TagsAlmacenados_12.Add(tagData[0].TagID);


                                        //INOCAR CLASE CONSULTAS
                                        DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();
                                        //APLICAR PROCESO
                                        bool Respuesta = PORTAL.UPDATE_ESTADO_PORTAL(ID_PORTAL, true);
                                    }
                                }
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

                Log.Instance.ErrorException("Error en el manejo de evento e insercion en bitacora", ex);
            }

        }

        private void REGISTRO_LECTURAS_READER_13(Events.ReadEventData eventData)
        {
            //VARIABLE
            int ID_PORTAL = 13;

            try
            {
                if (m_IsConnected_13 == true)
                {
                    Symbol.RFID3.TagData[] tagData = RFID_READER_13.Actions.GetReadTags(1000);

                    if (tagData != null)
                    {
                        if (eventData != null)
                        {
                            if (tagData[0].TagID.Length <= 24)
                            {
                                //////////////////////
                                //ESCRIBIR ACHIVO [ULTIMA LECTURA]
                                WRITE_ULTIMA_LECTURA_13();

                                //LOG RESGISTRO DE LECTURA DEL TAG
                                log.LogLecturasPortales(RFID_READER_13.HostName, Convert.ToString(ID_PORTAL), tagData[0].TagID);

                                //////////////////////
                                //VALIDAR SI EL ARCHIVO BLACKLIST.TXT TIENE CONTENIDO
                                if (!blacklist_13.Contains(tagData[0].TagID))
                                {
                                    if (!TagsAlmacenados_13.Contains(tagData[0].TagID))
                                    {
                                        //////////////////////
                                        //INSERTAR A BITACORA
                                        bitacora.INSERTAR_ENTRADA_SALIDA_13(tagData, RFID_READER_13.HostName);

                                        TagsAlmacenados_13.Add(tagData[0].TagID);


                                        //INOCAR CLASE CONSULTAS
                                        DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();
                                        //APLICAR PROCESO
                                        bool Respuesta = PORTAL.UPDATE_ESTADO_PORTAL(ID_PORTAL, true);
                                    }
                                }
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

                Log.Instance.ErrorException("Error en el manejo de evento e insercion en bitacora", ex);
            }

        }

        private void REGISTRO_LECTURAS_READER_14(Events.ReadEventData eventData)
        {
            //VARIABLE
            int ID_PORTAL = 14;

            try
            {
                if (m_IsConnected_14 == true)
                {
                    Symbol.RFID3.TagData[] tagData = RFID_READER_14.Actions.GetReadTags(1000);

                    if (tagData != null)
                    {
                        if (eventData != null)
                        {
                            if (tagData[0].TagID.Length <= 24)
                            {
                                //////////////////////
                                //ESCRIBIR ACHIVO [ULTIMA LECTURA]
                                WRITE_ULTIMA_LECTURA_14();

                                //LOG RESGISTRO DE LECTURA DEL TAG
                                log.LogLecturasPortales(RFID_READER_14.HostName, Convert.ToString(ID_PORTAL), tagData[0].TagID);

                                //////////////////////
                                //VALIDAR SI EL ARCHIVO BLACKLIST.TXT TIENE CONTENIDO
                                if (!blacklist_14.Contains(tagData[0].TagID))
                                {
                                    if (!TagsAlmacenados_14.Contains(tagData[0].TagID))
                                    {
                                        //////////////////////
                                        //INSERTAR A BITACORA
                                        bitacora.INSERTAR_ENTRADA_SALIDA_14(tagData, RFID_READER_14.HostName);

                                        TagsAlmacenados_14.Add(tagData[0].TagID);


                                        //INOCAR CLASE CONSULTAS
                                        DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();
                                        //APLICAR PROCESO
                                        bool Respuesta = PORTAL.UPDATE_ESTADO_PORTAL(ID_PORTAL, true);
                                    }
                                }
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

                Log.Instance.ErrorException("Error en el manejo de evento e insercion en bitacora", ex);
            }

        }

        private void REGISTRO_LECTURAS_READER_15(Events.ReadEventData eventData)
        {
            //VARIABLE
            int ID_PORTAL = 15;

            try
            {
                if (m_IsConnected_15 == true)
                {
                    Symbol.RFID3.TagData[] tagData = RFID_READER_15.Actions.GetReadTags(1000);

                    if (tagData != null)
                    {
                        if (eventData != null)
                        {
                            if (tagData[0].TagID.Length <= 24)
                            {
                                //////////////////////
                                //ESCRIBIR ACHIVO [ULTIMA LECTURA]
                                WRITE_ULTIMA_LECTURA_15();

                                //LOG RESGISTRO DE LECTURA DEL TAG
                                log.LogLecturasPortales(RFID_READER_15.HostName, Convert.ToString(ID_PORTAL), tagData[0].TagID);

                                //////////////////////
                                //VALIDAR SI EL ARCHIVO BLACKLIST.TXT TIENE CONTENIDO
                                if (!blacklist_15.Contains(tagData[0].TagID))
                                {
                                    if (!TagsAlmacenados_15.Contains(tagData[0].TagID))
                                    {
                                        //////////////////////
                                        //INSERTAR A BITACORA
                                        bitacora.INSERTAR_ENTRADA_SALIDA_15(tagData, RFID_READER_15.HostName);

                                        TagsAlmacenados_15.Add(tagData[0].TagID);


                                        //INOCAR CLASE CONSULTAS
                                        DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();
                                        //APLICAR PROCESO
                                        bool Respuesta = PORTAL.UPDATE_ESTADO_PORTAL(ID_PORTAL, true);
                                    }
                                }
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

                Log.Instance.ErrorException("Error en el manejo de evento e insercion en bitacora", ex);
            }

        }

        private void REGISTRO_LECTURAS_READER_16(Events.ReadEventData eventData)
        {
            //VARIABLE
            int ID_PORTAL = 2;

            try
            {
                if (m_IsConnected_16 == true)
                {
                    Symbol.RFID3.TagData[] tagData = RFID_READER_16.Actions.GetReadTags(1000);

                    if (tagData != null)
                    {
                        if (eventData != null)
                        {
                            if (tagData[0].TagID.Length <= 24)
                            {
                                //////////////////////
                                //ESCRIBIR ACHIVO [ULTIMA LECTURA]
                                WRITE_ULTIMA_LECTURA_16();

                                //LOG RESGISTRO DE LECTURA DEL TAG
                                log.LogLecturasPortales(RFID_READER_16.HostName, Convert.ToString(ID_PORTAL), tagData[0].TagID);

                                //////////////////////
                                //VALIDAR SI EL ARCHIVO BLACKLIST.TXT TIENE CONTENIDO
                                if (!blacklist_16.Contains(tagData[0].TagID))
                                {
                                    if (!TagsAlmacenados_16.Contains(tagData[0].TagID))
                                    {
                                        //////////////////////
                                        //INSERTAR A BITACORA
                                        bitacora.INSERTAR_ENTRADA_SALIDA_16(tagData, RFID_READER_16.HostName);

                                        TagsAlmacenados_16.Add(tagData[0].TagID);


                                        //INOCAR CLASE CONSULTAS
                                        DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();
                                        //APLICAR PROCESO
                                        bool Respuesta = PORTAL.UPDATE_ESTADO_PORTAL(ID_PORTAL, true);
                                    }
                                }
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

                Log.Instance.ErrorException("Error en el manejo de evento e insercion en bitacora", ex);
            }

        }

        private void REGISTRO_LECTURAS_READER_17(Events.ReadEventData eventData)
        {
            //VARIABLE
            int ID_PORTAL = 17;

            try
            {
                if (m_IsConnected_17 == true)
                {
                    Symbol.RFID3.TagData[] tagData = RFID_READER_17.Actions.GetReadTags(1000);

                    if (tagData != null)
                    {
                        if (eventData != null)
                        {
                            if (tagData[0].TagID.Length <= 24)
                            {
                                //////////////////////
                                //ESCRIBIR ACHIVO [ULTIMA LECTURA]
                                WRITE_ULTIMA_LECTURA_17();

                                //LOG RESGISTRO DE LECTURA DEL TAG
                                log.LogLecturasPortales(RFID_READER_17.HostName, Convert.ToString(ID_PORTAL), tagData[0].TagID);

                                //////////////////////
                                //VALIDAR SI EL ARCHIVO BLACKLIST.TXT TIENE CONTENIDO
                                if (!blacklist_17.Contains(tagData[0].TagID))
                                {
                                    if (!TagsAlmacenados_17.Contains(tagData[0].TagID))
                                    {
                                        //////////////////////
                                        //INSERTAR A BITACORA
                                        bitacora.INSERTAR_ENTRADA_SALIDA_17(tagData, RFID_READER_17.HostName);

                                        TagsAlmacenados_17.Add(tagData[0].TagID);


                                        //INOCAR CLASE CONSULTAS
                                        DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();
                                        //APLICAR PROCESO
                                        bool Respuesta = PORTAL.UPDATE_ESTADO_PORTAL(ID_PORTAL, true);
                                    }
                                }
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

                Log.Instance.ErrorException("Error en el manejo de evento e insercion en bitacora", ex);
            }

        }

        private void REGISTRO_LECTURAS_READER_18(Events.ReadEventData eventData)
        {
            //VARIABLE
            int ID_PORTAL = 18;

            try
            {
                if (m_IsConnected_18 == true)
                {
                    Symbol.RFID3.TagData[] tagData = RFID_READER_18.Actions.GetReadTags(1000);

                    if (tagData != null)
                    {
                        if (eventData != null)
                        {
                            if (tagData[0].TagID.Length <= 24)
                            {
                                //////////////////////
                                //ESCRIBIR ACHIVO [ULTIMA LECTURA]
                                WRITE_ULTIMA_LECTURA_18();

                                //LOG RESGISTRO DE LECTURA DEL TAG
                                log.LogLecturasPortales(RFID_READER_18.HostName, Convert.ToString(ID_PORTAL), tagData[0].TagID);

                                //////////////////////
                                //VALIDAR SI EL ARCHIVO BLACKLIST.TXT TIENE CONTENIDO
                                if (!blacklist_18.Contains(tagData[0].TagID))
                                {
                                    if (!TagsAlmacenados_18.Contains(tagData[0].TagID))
                                    {
                                        //////////////////////
                                        //INSERTAR A BITACORA
                                        bitacora.INSERTAR_ENTRADA_SALIDA_18(tagData, RFID_READER_18.HostName);

                                        TagsAlmacenados_18.Add(tagData[0].TagID);


                                        //INOCAR CLASE CONSULTAS
                                        DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();
                                        //APLICAR PROCESO
                                        bool Respuesta = PORTAL.UPDATE_ESTADO_PORTAL(ID_PORTAL, true);
                                    }
                                }
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

                Log.Instance.ErrorException("Error en el manejo de evento e insercion en bitacora", ex);
            }

        }

        private void REGISTRO_LECTURAS_READER_19(Events.ReadEventData eventData)
        {
            //VARIABLE
            int ID_PORTAL = 19;

            try
            {
                if (m_IsConnected_19 == true)
                {
                    Symbol.RFID3.TagData[] tagData = RFID_READER_19.Actions.GetReadTags(1000);

                    if (tagData != null)
                    {
                        if (eventData != null)
                        {
                            if (tagData[0].TagID.Length <= 24)
                            {
                                //////////////////////
                                //ESCRIBIR ACHIVO [ULTIMA LECTURA]
                                WRITE_ULTIMA_LECTURA_19();

                                //LOG RESGISTRO DE LECTURA DEL TAG
                                log.LogLecturasPortales(RFID_READER_19.HostName, Convert.ToString(ID_PORTAL), tagData[0].TagID);

                                //////////////////////
                                //VALIDAR SI EL ARCHIVO BLACKLIST.TXT TIENE CONTENIDO
                                if (!blacklist_19.Contains(tagData[0].TagID))
                                {
                                    if (!TagsAlmacenados_19.Contains(tagData[0].TagID))
                                    {
                                        //////////////////////
                                        //INSERTAR A BITACORA
                                        bitacora.INSERTAR_ENTRADA_SALIDA_19(tagData, RFID_READER_19.HostName);

                                        TagsAlmacenados_19.Add(tagData[0].TagID);


                                        //INOCAR CLASE CONSULTAS
                                        DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();
                                        //APLICAR PROCESO
                                        bool Respuesta = PORTAL.UPDATE_ESTADO_PORTAL(ID_PORTAL, true);
                                    }
                                }
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

                Log.Instance.ErrorException("Error en el manejo de evento e insercion en bitacora", ex);
            }

        }

        private void REGISTRO_LECTURAS_READER_20(Events.ReadEventData eventData)
        {
            //VARIABLE
            int ID_PORTAL = 20;

            try
            {
                if (m_IsConnected_20 == true)
                {
                    Symbol.RFID3.TagData[] tagData = RFID_READER_20.Actions.GetReadTags(1000);

                    if (tagData != null)
                    {
                        if (eventData != null)
                        {
                            if (tagData[0].TagID.Length <= 24)
                            {
                                //////////////////////
                                //ESCRIBIR ACHIVO [ULTIMA LECTURA]
                                WRITE_ULTIMA_LECTURA_20();

                                //LOG RESGISTRO DE LECTURA DEL TAG
                                log.LogLecturasPortales(RFID_READER_20.HostName, Convert.ToString(ID_PORTAL), tagData[0].TagID);

                                //////////////////////
                                //VALIDAR SI EL ARCHIVO BLACKLIST.TXT TIENE CONTENIDO
                                if (!blacklist_20.Contains(tagData[0].TagID))
                                {
                                    if (!TagsAlmacenados_20.Contains(tagData[0].TagID))
                                    {
                                        //////////////////////
                                        //INSERTAR A BITACORA
                                        bitacora.INSERTAR_ENTRADA_SALIDA_20(tagData, RFID_READER_20.HostName);

                                        TagsAlmacenados_20.Add(tagData[0].TagID);


                                        //INOCAR CLASE CONSULTAS
                                        DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();
                                        //APLICAR PROCESO
                                        bool Respuesta = PORTAL.UPDATE_ESTADO_PORTAL(ID_PORTAL, true);
                                    }
                                }
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

                Log.Instance.ErrorException("Error en el manejo de evento e insercion en bitacora", ex);
            }

        }


        #endregion

        //--------------------

        #region TIEMPO PARA ESCRITURA DE ARCHIVO

        /// <summary>
        /// TIMEPO ESPERA | ESCRITURA DE ARCHIVO
        /// </summary>
        public void TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_1()
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
                    Log.Instance.ErrorException("Error al escribir archivo " + ex.ToString(), ex);
                }
            }
        }

        /// <summary>
        /// TIMEPO ESPERA | ESCRITURA DE ARCHIVO
        /// </summary>
        public void TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_2()
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
                    Log.Instance.ErrorException("Error al escribir archivo " + ex.ToString(), ex);
                }
            }
        }

        /// <summary>
        /// TIMEPO ESPERA | ESCRITURA DE ARCHIVO
        /// </summary>
        public void TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_3()
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
                    Log.Instance.ErrorException("Error al escribir archivo " + ex.ToString(), ex);
                }
            }
        }

        /// <summary>
        /// TIMEPO ESPERA | ESCRITURA DE ARCHIVO
        /// </summary>
        public void TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_4()
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
                    Log.Instance.ErrorException("Error al escribir archivo " + ex.ToString(), ex);
                }
            }
        }

        /// <summary>
        /// TIMEPO ESPERA | ESCRITURA DE ARCHIVO
        /// </summary>
        public void TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_5()
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
                    Log.Instance.ErrorException("Error al escribir archivo " + ex.ToString(), ex);
                }
            }
        }

        /// <summary>
        /// TIMEPO ESPERA | ESCRITURA DE ARCHIVO
        /// </summary>
        public void TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_6()
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
                    Log.Instance.ErrorException("Error al escribir archivo " + ex.ToString(), ex);
                }
            }
        }

        /// <summary>
        /// TIMEPO ESPERA | ESCRITURA DE ARCHIVO
        /// </summary>
        public void TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_7()
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
                    Log.Instance.ErrorException("Error al escribir archivo " + ex.ToString(), ex);
                }
            }
        }

        /// <summary>
        /// TIMEPO ESPERA | ESCRITURA DE ARCHIVO
        /// </summary>
        public void TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_8()
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
                    Log.Instance.ErrorException("Error al escribir archivo " + ex.ToString(), ex);
                }
            }
        }

        /// <summary>
        /// TIMEPO ESPERA | ESCRITURA DE ARCHIVO
        /// </summary>
        public void TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_9()
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
                    Log.Instance.ErrorException("Error al escribir archivo " + ex.ToString(), ex);
                }
            }
        }

        /// <summary>
        /// TIMEPO ESPERA | ESCRITURA DE ARCHIVO
        /// </summary>
        public void TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_10()
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
                    Log.Instance.ErrorException("Error al escribir archivo " + ex.ToString(), ex);
                }
            }
        }

        /// <summary>
        /// TIMEPO ESPERA | ESCRITURA DE ARCHIVO
        /// </summary>
        public void TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_11()
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
                    Log.Instance.ErrorException("Error al escribir archivo " + ex.ToString(), ex);
                }
            }
        }

        /// <summary>
        /// TIMEPO ESPERA | ESCRITURA DE ARCHIVO
        /// </summary>
        public void TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_12()
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
                    Log.Instance.ErrorException("Error al escribir archivo " + ex.ToString(), ex);
                }
            }
        }

        /// <summary>
        /// TIMEPO ESPERA | ESCRITURA DE ARCHIVO
        /// </summary>
        public void TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_13()
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
                    Log.Instance.ErrorException("Error al escribir archivo " + ex.ToString(), ex);
                }
            }
        }

        /// <summary>
        /// TIMEPO ESPERA | ESCRITURA DE ARCHIVO
        /// </summary>
        public void TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_14()
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
                    Log.Instance.ErrorException("Error al escribir archivo " + ex.ToString(), ex);
                }
            }
        }

        /// <summary>
        /// TIMEPO ESPERA | ESCRITURA DE ARCHIVO
        /// </summary>
        public void TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_15()
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
                    Log.Instance.ErrorException("Error al escribir archivo " + ex.ToString(), ex);
                }
            }
        }

        /// <summary>
        /// TIMEPO ESPERA | ESCRITURA DE ARCHIVO
        /// </summary>
        public void TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_16()
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
                    Log.Instance.ErrorException("Error al escribir archivo " + ex.ToString(), ex);
                }
            }
        }

        /// <summary>
        /// TIMEPO ESPERA | ESCRITURA DE ARCHIVO
        /// </summary>
        public void TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_17()
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
                    Log.Instance.ErrorException("Error al escribir archivo " + ex.ToString(), ex);
                }
            }
        }

        /// <summary>
        /// TIMEPO ESPERA | ESCRITURA DE ARCHIVO
        /// </summary>
        public void TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_18()
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
                    Log.Instance.ErrorException("Error al escribir archivo " + ex.ToString(), ex);
                }
            }
        }

        /// <summary>
        /// TIMEPO ESPERA | ESCRITURA DE ARCHIVO
        /// </summary>
        public void TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_19()
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
                    Log.Instance.ErrorException("Error al escribir archivo " + ex.ToString(), ex);
                }
            }
        }

        /// <summary>
        /// TIMEPO ESPERA | ESCRITURA DE ARCHIVO
        /// </summary>
        public void TIEMPO_ESPERA_ESCRITURA_DE_ARCHIVO_20()
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
                    Log.Instance.ErrorException("Error al escribir archivo " + ex.ToString(), ex);
                }
            }
        }

        #endregion

        //--------------------

        #region COMPROBAR CONEXION DEL READER

        /// <summary>
        /// COMPROBAR CONEXION DEL LECTOR
        /// </summary>
        /// <param name="IP_LECTOR"></param>
        public void COMPROBAR_CONEXION_LECTOR_1(int ID_PORTAL)
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

                if (RFID_READER_1 != null)
                {
                    //SI EL LECTOR ESTA DESCONECTADO
                    if (RFID_READER_1.IsConnected == false || RFID_READER_1.IsConnected == null)
                    {
                        try
                        {
                            //INVOCAR CLASE CONSULTAS
                            DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();


                            //ENVIO DE CORREO
                            string IP_PORTAL = IP_HOSTNAME;
                            bool procesado = correo.ENVIAR(IP_PORTAL, ID_PORTAL, TITULO, MENSAJE);

                            //DESCONECTAR LECTOR
                            DESCONECTAR_LECTOR(ID_PORTAL);



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

        public void COMPROBAR_CONEXION_LECTOR_2(int ID_PORTAL)
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

                if (RFID_READER_2 != null)
                {

                    //SI EL LECTOR ESTA DESCONECTADO
                    if (RFID_READER_2.IsConnected == false || RFID_READER_2.IsConnected == null)
                    {
                        try
                        {
                            //INVOCAR CLASE CONSULTAS
                            DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();


                            //ENVIO DE CORREO
                            string IP_PORTAL = IP_HOSTNAME;
                            bool procesado = correo.ENVIAR(IP_PORTAL, ID_PORTAL, TITULO, MENSAJE);

                            //DESCONECTAR LECTOR
                            DESCONECTAR_LECTOR(ID_PORTAL);



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

        public void COMPROBAR_CONEXION_LECTOR_3(int ID_PORTAL)
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

                if (RFID_READER_3 != null)
                {
                    //SI EL LECTOR ESTA DESCONECTADO
                    if (RFID_READER_3.IsConnected == false || RFID_READER_3.IsConnected == null)
                    {
                        try
                        {
                            //INVOCAR CLASE CONSULTAS
                            DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();


                            //ENVIO DE CORREO
                            string IP_PORTAL = IP_HOSTNAME;
                            bool procesado = correo.ENVIAR(IP_PORTAL, ID_PORTAL, TITULO, MENSAJE);

                            //DESCONECTAR LECTOR
                            DESCONECTAR_LECTOR(ID_PORTAL);



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

        public void COMPROBAR_CONEXION_LECTOR_4(int ID_PORTAL)
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

                if (RFID_READER_4 != null)
                {
                    //SI EL LECTOR ESTA DESCONECTADO
                    if (RFID_READER_4.IsConnected == false || RFID_READER_4.IsConnected == null)
                    {
                        try
                        {
                            //INVOCAR CLASE CONSULTAS
                            DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();


                            //ENVIO DE CORREO
                            string IP_PORTAL = IP_HOSTNAME;
                            bool procesado = correo.ENVIAR(IP_PORTAL, ID_PORTAL, TITULO, MENSAJE);

                            //DESCONECTAR LECTOR
                            DESCONECTAR_LECTOR(ID_PORTAL);



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

        public void COMPROBAR_CONEXION_LECTOR_5(int ID_PORTAL)
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

                if (RFID_READER_5 != null)
                {
                    //SI EL LECTOR ESTA DESCONECTADO
                    if (RFID_READER_5.IsConnected == false || RFID_READER_5.IsConnected == null)
                    {
                        try
                        {
                            //INVOCAR CLASE CONSULTAS
                            DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();


                            //ENVIO DE CORREO
                            string IP_PORTAL = IP_HOSTNAME;
                            bool procesado = correo.ENVIAR(IP_PORTAL, ID_PORTAL, TITULO, MENSAJE);

                            //DESCONECTAR LECTOR
                            DESCONECTAR_LECTOR(ID_PORTAL);



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

        public void COMPROBAR_CONEXION_LECTOR_6(int ID_PORTAL)
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

                if (RFID_READER_6 != null)
                {
                    //SI EL LECTOR ESTA DESCONECTADO
                    if (RFID_READER_6.IsConnected == false || RFID_READER_6.IsConnected == null)
                    {
                        try
                        {
                            //INVOCAR CLASE CONSULTAS
                            DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();


                            //ENVIO DE CORREO
                            string IP_PORTAL = IP_HOSTNAME;
                            bool procesado = correo.ENVIAR(IP_PORTAL, ID_PORTAL, TITULO, MENSAJE);

                            //DESCONECTAR LECTOR
                            DESCONECTAR_LECTOR(ID_PORTAL);



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

        public void COMPROBAR_CONEXION_LECTOR_7(int ID_PORTAL)
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

                if (RFID_READER_7 != null)
                {
                    //SI EL LECTOR ESTA DESCONECTADO
                    if (RFID_READER_7.IsConnected == false || RFID_READER_7.IsConnected == null)
                    {
                        try
                        {
                            //INVOCAR CLASE CONSULTAS
                            DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();


                            //ENVIO DE CORREO
                            string IP_PORTAL = IP_HOSTNAME;
                            bool procesado = correo.ENVIAR(IP_PORTAL, ID_PORTAL, TITULO, MENSAJE);

                            //DESCONECTAR LECTOR
                            DESCONECTAR_LECTOR(ID_PORTAL);



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

        public void COMPROBAR_CONEXION_LECTOR_8(int ID_PORTAL)
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

                if (RFID_READER_8 != null)
                {
                    //SI EL LECTOR ESTA DESCONECTADO
                    if (RFID_READER_8.IsConnected == false || RFID_READER_8.IsConnected == null)
                    {
                        try
                        {
                            //INVOCAR CLASE CONSULTAS
                            DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();


                            //ENVIO DE CORREO
                            string IP_PORTAL = IP_HOSTNAME;
                            bool procesado = correo.ENVIAR(IP_PORTAL, ID_PORTAL, TITULO, MENSAJE);

                            //DESCONECTAR LECTOR
                            DESCONECTAR_LECTOR(ID_PORTAL);



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

        public void COMPROBAR_CONEXION_LECTOR_9(int ID_PORTAL)
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

                if (RFID_READER_9 != null)
                {
                    //SI EL LECTOR ESTA DESCONECTADO
                    if (RFID_READER_9.IsConnected == false || RFID_READER_9.IsConnected == null)
                    {
                        try
                        {
                            //INVOCAR CLASE CONSULTAS
                            DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();


                            //ENVIO DE CORREO
                            string IP_PORTAL = IP_HOSTNAME;
                            bool procesado = correo.ENVIAR(IP_PORTAL, ID_PORTAL, TITULO, MENSAJE);

                            //DESCONECTAR LECTOR
                            DESCONECTAR_LECTOR(ID_PORTAL);



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

        public void COMPROBAR_CONEXION_LECTOR_10(int ID_PORTAL)
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

                if (RFID_READER_10 != null)
                {
                    //SI EL LECTOR ESTA DESCONECTADO
                    if (RFID_READER_10.IsConnected == false || RFID_READER_10.IsConnected == null)
                    {
                        try
                        {
                            //INVOCAR CLASE CONSULTAS
                            DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();


                            //ENVIO DE CORREO
                            string IP_PORTAL = IP_HOSTNAME;
                            bool procesado = correo.ENVIAR(IP_PORTAL, ID_PORTAL, TITULO, MENSAJE);

                            //DESCONECTAR LECTOR
                            DESCONECTAR_LECTOR(ID_PORTAL);



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

        public void COMPROBAR_CONEXION_LECTOR_11(int ID_PORTAL)
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

                if (RFID_READER_11 != null)
                {
                    //SI EL LECTOR ESTA DESCONECTADO
                    if (RFID_READER_11.IsConnected == false || RFID_READER_11.IsConnected == null)
                    {
                        try
                        {
                            //INVOCAR CLASE CONSULTAS
                            DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();


                            //ENVIO DE CORREO
                            string IP_PORTAL = IP_HOSTNAME;
                            bool procesado = correo.ENVIAR(IP_PORTAL, ID_PORTAL, TITULO, MENSAJE);

                            //DESCONECTAR LECTOR
                            DESCONECTAR_LECTOR(ID_PORTAL);



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

        public void COMPROBAR_CONEXION_LECTOR_12(int ID_PORTAL)
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

                if (RFID_READER_12 != null)
                {
                    //SI EL LECTOR ESTA DESCONECTADO
                    if (RFID_READER_12.IsConnected == false || RFID_READER_12.IsConnected == null)
                    {
                        try
                        {
                            //INVOCAR CLASE CONSULTAS
                            DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();


                            //ENVIO DE CORREO
                            string IP_PORTAL = IP_HOSTNAME;
                            bool procesado = correo.ENVIAR(IP_PORTAL, ID_PORTAL, TITULO, MENSAJE);

                            //DESCONECTAR LECTOR
                            DESCONECTAR_LECTOR(ID_PORTAL);



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

        public void COMPROBAR_CONEXION_LECTOR_13(int ID_PORTAL)
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

                if (RFID_READER_13 != null)
                {
                    //SI EL LECTOR ESTA DESCONECTADO
                    if (RFID_READER_13.IsConnected == false || RFID_READER_13.IsConnected == null)
                    {
                        try
                        {
                            //INVOCAR CLASE CONSULTAS
                            DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();


                            //ENVIO DE CORREO
                            string IP_PORTAL = IP_HOSTNAME;
                            bool procesado = correo.ENVIAR(IP_PORTAL, ID_PORTAL, TITULO, MENSAJE);

                            //DESCONECTAR LECTOR
                            DESCONECTAR_LECTOR(ID_PORTAL);



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

        public void COMPROBAR_CONEXION_LECTOR_14(int ID_PORTAL)
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

                if (RFID_READER_14 != null)
                {
                    //SI EL LECTOR ESTA DESCONECTADO
                    if (RFID_READER_14.IsConnected == false || RFID_READER_14.IsConnected == null)
                    {
                        try
                        {
                            //INVOCAR CLASE CONSULTAS
                            DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();


                            //ENVIO DE CORREO
                            string IP_PORTAL = IP_HOSTNAME;
                            bool procesado = correo.ENVIAR(IP_PORTAL, ID_PORTAL, TITULO, MENSAJE);

                            //DESCONECTAR LECTOR
                            DESCONECTAR_LECTOR(ID_PORTAL);



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

        public void COMPROBAR_CONEXION_LECTOR_15(int ID_PORTAL)
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

                if (RFID_READER_15 != null)
                {
                    //SI EL LECTOR ESTA DESCONECTADO
                    if (RFID_READER_15.IsConnected == false || RFID_READER_15.IsConnected == null)
                    {
                        try
                        {
                            //INVOCAR CLASE CONSULTAS
                            DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();


                            //ENVIO DE CORREO
                            string IP_PORTAL = IP_HOSTNAME;
                            bool procesado = correo.ENVIAR(IP_PORTAL, ID_PORTAL, TITULO, MENSAJE);

                            //DESCONECTAR LECTOR
                            DESCONECTAR_LECTOR(ID_PORTAL);



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

        public void COMPROBAR_CONEXION_LECTOR_16(int ID_PORTAL)
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


                if (RFID_READER_16 != null)
                {
                    //SI EL LECTOR ESTA DESCONECTADO
                    if (RFID_READER_16.IsConnected == false || RFID_READER_16.IsConnected == null)
                    {
                        try
                        {
                            //INVOCAR CLASE CONSULTAS
                            DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();


                            //ENVIO DE CORREO
                            string IP_PORTAL = IP_HOSTNAME;
                            bool procesado = correo.ENVIAR(IP_PORTAL, ID_PORTAL, TITULO, MENSAJE);

                            //DESCONECTAR LECTOR
                            DESCONECTAR_LECTOR(ID_PORTAL);



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

        public void COMPROBAR_CONEXION_LECTOR_17(int ID_PORTAL)
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

                if (RFID_READER_17 != null)
                {
                    //SI EL LECTOR ESTA DESCONECTADO
                    if (RFID_READER_17.IsConnected == false || RFID_READER_17.IsConnected == null)
                    {
                        try
                        {
                            //INVOCAR CLASE CONSULTAS
                            DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();


                            //ENVIO DE CORREO
                            string IP_PORTAL = IP_HOSTNAME;
                            bool procesado = correo.ENVIAR(IP_PORTAL, ID_PORTAL, TITULO, MENSAJE);

                            //DESCONECTAR LECTOR
                            DESCONECTAR_LECTOR(ID_PORTAL);



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

        public void COMPROBAR_CONEXION_LECTOR_18(int ID_PORTAL)
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

                if (RFID_READER_18 != null)
                {
                    //SI EL LECTOR ESTA DESCONECTADO
                    if (RFID_READER_18.IsConnected == false || RFID_READER_18.IsConnected == null)
                    {
                        try
                        {
                            //INVOCAR CLASE CONSULTAS
                            DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();


                            //ENVIO DE CORREO
                            string IP_PORTAL = IP_HOSTNAME;
                            bool procesado = correo.ENVIAR(IP_PORTAL, ID_PORTAL, TITULO, MENSAJE);

                            //DESCONECTAR LECTOR
                            DESCONECTAR_LECTOR(ID_PORTAL);



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

        public void COMPROBAR_CONEXION_LECTOR_19(int ID_PORTAL)
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


                if (RFID_READER_19 != null)
                {
                    //SI EL LECTOR ESTA DESCONECTADO
                    if (RFID_READER_19.IsConnected == false || RFID_READER_19.IsConnected == null)
                    {
                        try
                        {
                            //INVOCAR CLASE CONSULTAS
                            DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();


                            //ENVIO DE CORREO
                            string IP_PORTAL = IP_HOSTNAME;
                            bool procesado = correo.ENVIAR(IP_PORTAL, ID_PORTAL, TITULO, MENSAJE);

                            //DESCONECTAR LECTOR
                            DESCONECTAR_LECTOR(ID_PORTAL);



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

        public void COMPROBAR_CONEXION_LECTOR_20(int ID_PORTAL)
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


                if (RFID_READER_20 != null)
                {
                    //SI EL LECTOR ESTA DESCONECTADO
                    if (RFID_READER_20.IsConnected == false || RFID_READER_20.IsConnected == null)
                    {
                        try
                        {
                            //INVOCAR CLASE CONSULTAS
                            DATA_BASE.CONSULTAS PORTAL = new DATA_BASE.CONSULTAS();


                            //ENVIO DE CORREO
                            string IP_PORTAL = IP_HOSTNAME;
                            bool procesado = correo.ENVIAR(IP_PORTAL, ID_PORTAL, TITULO, MENSAJE);

                            //DESCONECTAR LECTOR
                            DESCONECTAR_LECTOR(ID_PORTAL);



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
        #endregion

        //--------------------

        #region WRITE LAST READ



        /// <summary>
        /// ESCRIBIR ULTIMA LECTURA
        /// </summary>
        private void WRITE_ULTIMA_LECTURA_1()
        {
            if (TiempoEsperaEscribirLectura > 0)
            {
                try
                {
                    //Siempre se va a guardar la ultima lectura y solamente eso
                    StreamWriter sw = new StreamWriter("UltimaLectura_Portal_1.txt");

                    sw.WriteLine(DateTime.Now);

                    sw.Close();

                    TiempoEsperaEscribirLectura = 0;
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException(ex.Message, ex);
                }
            }
        }

        private void WRITE_ULTIMA_LECTURA_2()
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
                    Log.Instance.ErrorException(ex.Message, ex);
                }
            }
        }

        private void WRITE_ULTIMA_LECTURA_3()
        {
            if (TiempoEsperaEscribirLectura > 0)
            {
                try
                {
                    //Siempre se va a guardar la ultima lectura y solamente eso
                    StreamWriter sw = new StreamWriter("UltimaLectura_Portal_3.txt");

                    sw.WriteLine(DateTime.Now);

                    sw.Close();

                    TiempoEsperaEscribirLectura = 0;
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException(ex.Message, ex);
                }
            }
        }

        private void WRITE_ULTIMA_LECTURA_4()
        {
            if (TiempoEsperaEscribirLectura > 0)
            {
                try
                {
                    //Siempre se va a guardar la ultima lectura y solamente eso
                    StreamWriter sw = new StreamWriter("UltimaLectura_Portal_4.txt");

                    sw.WriteLine(DateTime.Now);

                    sw.Close();

                    TiempoEsperaEscribirLectura = 0;
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException(ex.Message, ex);
                }
            }
        }

        private void WRITE_ULTIMA_LECTURA_5()
        {
            if (TiempoEsperaEscribirLectura > 0)
            {
                try
                {
                    //Siempre se va a guardar la ultima lectura y solamente eso
                    StreamWriter sw = new StreamWriter("UltimaLectura_Portal_5.txt");

                    sw.WriteLine(DateTime.Now);

                    sw.Close();

                    TiempoEsperaEscribirLectura = 0;
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException(ex.Message, ex);
                }
            }
        }

        private void WRITE_ULTIMA_LECTURA_6()
        {
            if (TiempoEsperaEscribirLectura > 0)
            {
                try
                {
                    //Siempre se va a guardar la ultima lectura y solamente eso
                    StreamWriter sw = new StreamWriter("UltimaLectura_Portal_6.txt");

                    sw.WriteLine(DateTime.Now);

                    sw.Close();

                    TiempoEsperaEscribirLectura = 0;
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException(ex.Message, ex);
                }
            }
        }

        private void WRITE_ULTIMA_LECTURA_7()
        {
            if (TiempoEsperaEscribirLectura > 0)
            {
                try
                {
                    //Siempre se va a guardar la ultima lectura y solamente eso
                    StreamWriter sw = new StreamWriter("UltimaLectura_Portal_7.txt");

                    sw.WriteLine(DateTime.Now);

                    sw.Close();

                    TiempoEsperaEscribirLectura = 0;
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException(ex.Message, ex);
                }
            }
        }

        private void WRITE_ULTIMA_LECTURA_8()
        {
            if (TiempoEsperaEscribirLectura > 0)
            {
                try
                {
                    //Siempre se va a guardar la ultima lectura y solamente eso
                    StreamWriter sw = new StreamWriter("UltimaLectura_Portal_8.txt");

                    sw.WriteLine(DateTime.Now);

                    sw.Close();

                    TiempoEsperaEscribirLectura = 0;
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException(ex.Message, ex);
                }
            }
        }

        private void WRITE_ULTIMA_LECTURA_9()
        {
            if (TiempoEsperaEscribirLectura > 0)
            {
                try
                {
                    //Siempre se va a guardar la ultima lectura y solamente eso
                    StreamWriter sw = new StreamWriter("UltimaLectura_Portal_9.txt");

                    sw.WriteLine(DateTime.Now);

                    sw.Close();

                    TiempoEsperaEscribirLectura = 0;
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException(ex.Message, ex);
                }
            }
        }

        private void WRITE_ULTIMA_LECTURA_10()
        {
            if (TiempoEsperaEscribirLectura > 0)
            {
                try
                {
                    //Siempre se va a guardar la ultima lectura y solamente eso
                    StreamWriter sw = new StreamWriter("UltimaLectura_Portal_10.txt");

                    sw.WriteLine(DateTime.Now);

                    sw.Close();

                    TiempoEsperaEscribirLectura = 0;
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException(ex.Message, ex);
                }
            }
        }

        private void WRITE_ULTIMA_LECTURA_11()
        {
            if (TiempoEsperaEscribirLectura > 0)
            {
                try
                {
                    //Siempre se va a guardar la ultima lectura y solamente eso
                    StreamWriter sw = new StreamWriter("UltimaLectura_Portal_11.txt");

                    sw.WriteLine(DateTime.Now);

                    sw.Close();

                    TiempoEsperaEscribirLectura = 0;
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException(ex.Message, ex);
                }
            }
        }

        private void WRITE_ULTIMA_LECTURA_12()
        {
            if (TiempoEsperaEscribirLectura > 0)
            {
                try
                {
                    //Siempre se va a guardar la ultima lectura y solamente eso
                    StreamWriter sw = new StreamWriter("UltimaLectura_Portal_12.txt");

                    sw.WriteLine(DateTime.Now);

                    sw.Close();

                    TiempoEsperaEscribirLectura = 0;
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException(ex.Message, ex);
                }
            }
        }

        private void WRITE_ULTIMA_LECTURA_13()
        {
            if (TiempoEsperaEscribirLectura > 0)
            {
                try
                {
                    //Siempre se va a guardar la ultima lectura y solamente eso
                    StreamWriter sw = new StreamWriter("UltimaLectura_Portal_13.txt");

                    sw.WriteLine(DateTime.Now);

                    sw.Close();

                    TiempoEsperaEscribirLectura = 0;
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException(ex.Message, ex);
                }
            }
        }

        private void WRITE_ULTIMA_LECTURA_14()
        {
            if (TiempoEsperaEscribirLectura > 0)
            {
                try
                {
                    //Siempre se va a guardar la ultima lectura y solamente eso
                    StreamWriter sw = new StreamWriter("UltimaLectura_Portal_14.txt");

                    sw.WriteLine(DateTime.Now);

                    sw.Close();

                    TiempoEsperaEscribirLectura = 0;
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException(ex.Message, ex);
                }
            }
        }

        private void WRITE_ULTIMA_LECTURA_15()
        {
            if (TiempoEsperaEscribirLectura > 0)
            {
                try
                {
                    //Siempre se va a guardar la ultima lectura y solamente eso
                    StreamWriter sw = new StreamWriter("UltimaLectura_Portal_15.txt");

                    sw.WriteLine(DateTime.Now);

                    sw.Close();

                    TiempoEsperaEscribirLectura = 0;
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException(ex.Message, ex);
                }
            }
        }

        private void WRITE_ULTIMA_LECTURA_16()
        {
            if (TiempoEsperaEscribirLectura > 0)
            {
                try
                {
                    //Siempre se va a guardar la ultima lectura y solamente eso
                    StreamWriter sw = new StreamWriter("UltimaLectura_Portal_16.txt");

                    sw.WriteLine(DateTime.Now);

                    sw.Close();

                    TiempoEsperaEscribirLectura = 0;
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException(ex.Message, ex);
                }
            }
        }

        private void WRITE_ULTIMA_LECTURA_17()
        {
            if (TiempoEsperaEscribirLectura > 0)
            {
                try
                {
                    //Siempre se va a guardar la ultima lectura y solamente eso
                    StreamWriter sw = new StreamWriter("UltimaLectura_Portal_17.txt");

                    sw.WriteLine(DateTime.Now);

                    sw.Close();

                    TiempoEsperaEscribirLectura = 0;
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException(ex.Message, ex);
                }
            }
        }

        private void WRITE_ULTIMA_LECTURA_18()
        {
            if (TiempoEsperaEscribirLectura > 0)
            {
                try
                {
                    //Siempre se va a guardar la ultima lectura y solamente eso
                    StreamWriter sw = new StreamWriter("UltimaLectura_Portal_18.txt");

                    sw.WriteLine(DateTime.Now);

                    sw.Close();

                    TiempoEsperaEscribirLectura = 0;
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException(ex.Message, ex);
                }
            }
        }

        private void WRITE_ULTIMA_LECTURA_19()
        {
            if (TiempoEsperaEscribirLectura > 0)
            {
                try
                {
                    //Siempre se va a guardar la ultima lectura y solamente eso
                    StreamWriter sw = new StreamWriter("UltimaLectura_Portal_19.txt");

                    sw.WriteLine(DateTime.Now);

                    sw.Close();

                    TiempoEsperaEscribirLectura = 0;
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException(ex.Message, ex);
                }
            }
        }

        private void WRITE_ULTIMA_LECTURA_20()
        {
            if (TiempoEsperaEscribirLectura > 0)
            {
                try
                {
                    //Siempre se va a guardar la ultima lectura y solamente eso
                    StreamWriter sw = new StreamWriter("UltimaLectura_Portal_20.txt");

                    sw.WriteLine(DateTime.Now);

                    sw.Close();

                    TiempoEsperaEscribirLectura = 0;
                }
                catch (Exception ex)
                {
                    Log.Instance.ErrorException(ex.Message, ex);
                }
            }
        }


        #endregion

        //--------------------

        #region LECTURA BLACKLIST

        private void LECTURA_BLACKLIST(int ID_PORTAL)
        {

            FUNCIONES.ARCHIVOS File = new FUNCIONES.ARCHIVOS();
            string PATH_BLACKLIST = "";


            //LEER FILE CONFIG
            DataTable DT = File.LEER_ARCHIVO();

            if (DT.Rows.Count >= 0)
            {
                DataRow dr = DT.Rows[0];

                PATH_BLACKLIST = dr["PATH_BLACKLIST"].ToString();

            }

            //FILE NAME
            string FILE_NAME = PATH_BLACKLIST + "Blacklist_" + ID_PORTAL.ToString() + ".txt";


            switch (ID_PORTAL)
            {


                case 1:

                    #region PORTAL 1
                    try
                    {
                        blacklist_1.Clear();

                        string line;

                        StreamReader file = new StreamReader(@FILE_NAME);
                        while ((line = file.ReadLine()) != null)
                        {
                            blacklist_1.Add(line);
                        }

                        file.Close();
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }

                    break;
                #endregion

                case 2:

                    #region PORTAL 2
                    try
                    {
                        blacklist_2.Clear();
                        string line;

                        StreamReader file = new StreamReader(@FILE_NAME);
                        while ((line = file.ReadLine()) != null)
                        {
                            blacklist_2.Add(line);
                        }

                        file.Close();
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }

                    break;
                #endregion

                case 3:

                    #region PORTAL 3
                    try
                    {
                        blacklist_3.Clear();
                        string line;

                        StreamReader file = new StreamReader(@FILE_NAME);
                        while ((line = file.ReadLine()) != null)
                        {
                            blacklist_3.Add(line);
                        }

                        file.Close();
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }

                    break;
                #endregion

                case 4:

                    #region PORTAL 4
                    try
                    {
                        blacklist_4.Clear();
                        string line;

                        StreamReader file = new StreamReader(@FILE_NAME);
                        while ((line = file.ReadLine()) != null)
                        {
                            blacklist_4.Add(line);
                        }

                        file.Close();
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }

                    break;
                #endregion

                case 5:

                    #region PORTAL 5
                    try
                    {
                        blacklist_5.Clear();
                        string line;

                        StreamReader file = new StreamReader(@FILE_NAME);
                        while ((line = file.ReadLine()) != null)
                        {
                            blacklist_5.Add(line);
                        }

                        file.Close();
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }

                    break;
                #endregion

                case 6:

                    #region PORTAL 6
                    try
                    {
                        blacklist_6.Clear();
                        string line;

                        StreamReader file = new StreamReader(@FILE_NAME);
                        while ((line = file.ReadLine()) != null)
                        {
                            blacklist_6.Add(line);
                        }

                        file.Close();
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }

                    break;
                #endregion

                case 7:

                    #region PORTAL 7
                    try
                    {
                        blacklist_7.Clear();
                        string line;

                        StreamReader file = new StreamReader(@FILE_NAME);
                        while ((line = file.ReadLine()) != null)
                        {
                            blacklist_7.Add(line);
                        }

                        file.Close();
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }

                    break;
                #endregion

                case 8:

                    #region PORTAL 8
                    try
                    {
                        blacklist_8.Clear();
                        string line;

                        StreamReader file = new StreamReader(@FILE_NAME);
                        while ((line = file.ReadLine()) != null)
                        {
                            blacklist_8.Add(line);
                        }

                        file.Close();
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }

                    break;
                #endregion

                case 9:

                    #region PORTAL 9
                    try
                    {
                        blacklist_9.Clear();
                        string line;

                        StreamReader file = new StreamReader(@FILE_NAME);
                        while ((line = file.ReadLine()) != null)
                        {
                            blacklist_9.Add(line);
                        }

                        file.Close();
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }

                    break;
                #endregion

                case 10:

                    #region PORTAL 10
                    try
                    {
                        blacklist_10.Clear();
                        string line;

                        StreamReader file = new StreamReader(@FILE_NAME);
                        while ((line = file.ReadLine()) != null)
                        {
                            blacklist_10.Add(line);
                        }

                        file.Close();
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }

                    break;
                #endregion

                case 11:

                    #region PORTAL 11
                    try
                    {
                        blacklist_11.Clear();
                        string line;

                        StreamReader file = new StreamReader(@FILE_NAME);
                        while ((line = file.ReadLine()) != null)
                        {
                            blacklist_11.Add(line);
                        }

                        file.Close();
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }

                    break;
                #endregion

                case 12:

                    #region PORTAL 12
                    try
                    {
                        blacklist_12.Clear();
                        string line;

                        StreamReader file = new StreamReader(@FILE_NAME);
                        while ((line = file.ReadLine()) != null)
                        {
                            blacklist_12.Add(line);
                        }

                        file.Close();
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }

                    break;
                #endregion

                case 13:

                    #region PORTAL 13
                    try
                    {
                        blacklist_13.Clear();
                        string line;

                        StreamReader file = new StreamReader(@FILE_NAME);
                        while ((line = file.ReadLine()) != null)
                        {
                            blacklist_13.Add(line);
                        }

                        file.Close();
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }

                    break;
                #endregion

                case 14:

                    #region PORTAL 14
                    try
                    {
                        blacklist_1.Clear();
                        string line;

                        StreamReader file = new StreamReader(@FILE_NAME);
                        while ((line = file.ReadLine()) != null)
                        {
                            blacklist_14.Add(line);
                        }

                        file.Close();
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }

                    break;
                #endregion

                case 15:

                    #region PORTAL 15
                    try
                    {
                        blacklist_15.Clear();
                        string line;

                        StreamReader file = new StreamReader(@FILE_NAME);
                        while ((line = file.ReadLine()) != null)
                        {
                            blacklist_15.Add(line);
                        }

                        file.Close();
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }

                    break;
                #endregion

                case 16:

                    #region PORTAL 16
                    try
                    {
                        blacklist_16.Clear();
                        string line;

                        StreamReader file = new StreamReader(@FILE_NAME);
                        while ((line = file.ReadLine()) != null)
                        {
                            blacklist_16.Add(line);
                        }

                        file.Close();
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }

                    break;
                #endregion

                case 17:

                    #region PORTAL 17
                    try
                    {
                        blacklist_17.Clear();
                        string line;

                        StreamReader file = new StreamReader(@FILE_NAME);
                        while ((line = file.ReadLine()) != null)
                        {
                            blacklist_17.Add(line);
                        }

                        file.Close();
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }

                    break;
                #endregion

                case 18:

                    #region PORTAL 18
                    try
                    {
                        blacklist_18.Clear();
                        string line;

                        StreamReader file = new StreamReader(@FILE_NAME);
                        while ((line = file.ReadLine()) != null)
                        {
                            blacklist_18.Add(line);
                        }

                        file.Close();
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }

                    break;
                #endregion

                case 19:

                    #region PORTAL 19
                    try
                    {
                        blacklist_19.Clear();
                        string line;

                        StreamReader file = new StreamReader(@FILE_NAME);
                        while ((line = file.ReadLine()) != null)
                        {
                            blacklist_19.Add(line);
                        }

                        file.Close();
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }

                    break;
                #endregion

                case 20:

                    #region PORTAL 20
                    try
                    {
                        blacklist_20.Clear();
                        string line;

                        StreamReader file = new StreamReader(@FILE_NAME);
                        while ((line = file.ReadLine()) != null)
                        {
                            blacklist_20.Add(line);
                        }

                        file.Close();
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }

                    break;
                    #endregion
            }

        }

        #endregion

        #endregion


        #region EVENTOS READ NOTIFY READER

        private void Events_ReadNotify_Reader_1(object sender, Events.ReadEventArgs readEventArgs)
        {
            try
            {
                if (FLAG_LECTURA_1 == true)
                {
                    m_UpdateReadHandler_1(readEventArgs.ReadEventData);
                }
                else
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void Events_ReadNotify_Reader_2(object sender, Events.ReadEventArgs readEventArgs)
        {
            try
            {
                m_UpdateReadHandler_2(readEventArgs.ReadEventData);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error en el evento de lectura de tags", ex);
            }
        }

        private void Events_ReadNotify_Reader_3(object sender, Events.ReadEventArgs readEventArgs)
        {
            try
            {
                m_UpdateReadHandler_3(readEventArgs.ReadEventData);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error en el evento de lectura de tags", ex);
            }
        }

        private void Events_ReadNotify_Reader_4(object sender, Events.ReadEventArgs readEventArgs)
        {
            try
            {
                m_UpdateReadHandler_4(readEventArgs.ReadEventData);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error en el evento de lectura de tags", ex);
            }
        }

        private void Events_ReadNotify_Reader_5(object sender, Events.ReadEventArgs readEventArgs)
        {
            try
            {
                m_UpdateReadHandler_5(readEventArgs.ReadEventData);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error en el evento de lectura de tags", ex);
            }
        }

        private void Events_ReadNotify_Reader_6(object sender, Events.ReadEventArgs readEventArgs)
        {
            try
            {
                m_UpdateReadHandler_6(readEventArgs.ReadEventData);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error en el evento de lectura de tags", ex);
            }
        }

        private void Events_ReadNotify_Reader_7(object sender, Events.ReadEventArgs readEventArgs)
        {
            try
            {
                m_UpdateReadHandler_7(readEventArgs.ReadEventData);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error en el evento de lectura de tags", ex);
            }
        }

        private void Events_ReadNotify_Reader_8(object sender, Events.ReadEventArgs readEventArgs)
        {
            try
            {
                m_UpdateReadHandler_8(readEventArgs.ReadEventData);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error en el evento de lectura de tags", ex);
            }
        }

        private void Events_ReadNotify_Reader_9(object sender, Events.ReadEventArgs readEventArgs)
        {
            try
            {
                m_UpdateReadHandler_9(readEventArgs.ReadEventData);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error en el evento de lectura de tags", ex);
            }
        }

        private void Events_ReadNotify_Reader_10(object sender, Events.ReadEventArgs readEventArgs)
        {
            try
            {
                m_UpdateReadHandler_10(readEventArgs.ReadEventData);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error en el evento de lectura de tags", ex);
            }
        }

        private void Events_ReadNotify_Reader_11(object sender, Events.ReadEventArgs readEventArgs)
        {
            try
            {
                m_UpdateReadHandler_11(readEventArgs.ReadEventData);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error en el evento de lectura de tags", ex);
            }
        }

        private void Events_ReadNotify_Reader_12(object sender, Events.ReadEventArgs readEventArgs)
        {
            try
            {
                m_UpdateReadHandler_12(readEventArgs.ReadEventData);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error en el evento de lectura de tags", ex);
            }
        }

        private void Events_ReadNotify_Reader_13(object sender, Events.ReadEventArgs readEventArgs)
        {
            try
            {
                m_UpdateReadHandler_13(readEventArgs.ReadEventData);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error en el evento de lectura de tags", ex);
            }
        }

        private void Events_ReadNotify_Reader_14(object sender, Events.ReadEventArgs readEventArgs)
        {
            try
            {
                m_UpdateReadHandler_14(readEventArgs.ReadEventData);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error en el evento de lectura de tags", ex);
            }
        }

        private void Events_ReadNotify_Reader_15(object sender, Events.ReadEventArgs readEventArgs)
        {
            try
            {
                m_UpdateReadHandler_15(readEventArgs.ReadEventData);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error en el evento de lectura de tags", ex);
            }
        }

        private void Events_ReadNotify_Reader_16(object sender, Events.ReadEventArgs readEventArgs)
        {
            try
            {
                m_UpdateReadHandler_16(readEventArgs.ReadEventData);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error en el evento de lectura de tags", ex);
            }
        }

        private void Events_ReadNotify_Reader_17(object sender, Events.ReadEventArgs readEventArgs)
        {
            try
            {
                m_UpdateReadHandler_17(readEventArgs.ReadEventData);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error en el evento de lectura de tags", ex);
            }
        }

        private void Events_ReadNotify_Reader_18(object sender, Events.ReadEventArgs readEventArgs)
        {
            try
            {
                m_UpdateReadHandler_18(readEventArgs.ReadEventData);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error en el evento de lectura de tags", ex);
            }
        }

        private void Events_ReadNotify_Reader_19(object sender, Events.ReadEventArgs readEventArgs)
        {
            try
            {
                m_UpdateReadHandler_19(readEventArgs.ReadEventData);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error en el evento de lectura de tags", ex);
            }
        }

        private void Events_ReadNotify_Reader_20(object sender, Events.ReadEventArgs readEventArgs)
        {
            try
            {
                m_UpdateReadHandler_20(readEventArgs.ReadEventData);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error en el evento de lectura de tags", ex);
            }
        }


        #endregion

        //--------------------

        #region Log

        internal static class Log
        {
            public static Logger Instance { get; private set; }
            static Log()
            {
                LogManager.ReconfigExistingLoggers();

                Instance = LogManager.GetCurrentClassLogger();
            }
        }

        #endregion


        ////////////////////////////////////////////////////////////////////////
        //                          EVENTOS                                   //
        ////////////////////////////////////////////////////////////////////////

        #region EVENTOS

        //ES UN ESTADO QUE PERMITE EJECUTAR O NO, TODO EL PROCESO DEL EVENTO DEL COMBOX, 
        //PERMITIENDO ASI , NO REALIZAR TODO EL PROCESO, AL INICIAR LA APLICACION.
        int ESTADO_INICIO_PANEL_1 = 0;
        int ESTADO_INICIO_PANEL_2 = 0;
        int ESTADO_INICIO_PANEL_3 = 0;
        int ESTADO_INICIO_PANEL_4 = 0;
        int ESTADO_INICIO_PANEL_5 = 0;
        int ESTADO_INICIO_PANEL_6 = 0;
        int ESTADO_INICIO_PANEL_7 = 0;
        int ESTADO_INICIO_PANEL_8 = 0;
        int ESTADO_INICIO_PANEL_9 = 0;
        int ESTADO_INICIO_PANEL_10 = 0;
        int ESTADO_INICIO_PANEL_11 = 0;
        int ESTADO_INICIO_PANEL_12 = 0;
        int ESTADO_INICIO_PANEL_13 = 0;
        int ESTADO_INICIO_PANEL_14 = 0;
        int ESTADO_INICIO_PANEL_15 = 0;
        int ESTADO_INICIO_PANEL_16 = 0;
        int ESTADO_INICIO_PANEL_17 = 0;
        int ESTADO_INICIO_PANEL_18 = 0;
        int ESTADO_INICIO_PANEL_19 = 0;
        int ESTADO_INICIO_PANEL_20 = 0;


        /// <summary>
        /// EVENTO CMB PORTAL 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CMB_PORTAL_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ESTADO_INICIO_PANEL_1 == 0)
                {
                    ESTADO_INICIO_PANEL_1 = 1;
                }
                else
                {
                    //VARIABLES
                    int ID_PORTAL = 1;

                    //CONSULTAR EL ITEM SELECCIONADO DEL CMBX
                    string ESTADO = CMB_PORTAL_1.SelectedItem.ToString();

                    if (ESTADO == "ON")
                    {
                        //INICIAR PORTAL
                        INICIAR_PORTAL(ID_PORTAL);

                        //VALIDAR SI ESTÁ CONECTADO EL READER
                        if (RFID_READER_1.IsConnected)
                        {
                            //////////////////////////////////////////////////////////////////////////////////////////////////
                            //NUMERO DE ANTENNAS DISPONIBLES POR REDADER RFID

                            int NUM_ANTENNAS_READER_ = RFID_READER_1.Config.Antennas.Length;

                            //MOSTRAR DATO

                            LBL_ANTENNAS_1.Text = RFID_READER_1.Config.Antennas.AvailableAntennas.IsReadOnly.ToString();
                            //////////////////////////////////////////////////////////////////////////////////////////////////
                            //NUMERO DE ANTENNAS CONECTADOS EN EL REDADER RFID

                            //AntennaInfo_Load();


                            int NUM_ANTENNAS_ONLINE = RFID_READER_1.Config.Antennas[2].GetConfig().TransmitPowerIndex; // Convert.ToInt32( RFID_READER_1.Config.GPI.Length.ToString());

                            LBL_ANTENNAS_ON_1.Text = NUM_ANTENNAS_ONLINE.ToString();

                            //////////////////////////////////////////////////////////////////////////////////////////////////
                        }
                        else
                        {
                            LBL_ANTENNAS_1.Text = "0";
                        }
                    }
                    else if (ESTADO == "OFF")
                    {
                        //DETENER PORTAL
                        DETENER_LECTOR(ID_PORTAL);

                        LBL_ANTENNAS_1.Text = "0";
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// EVENTO CMB PORTAL 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CMB_PORTAL_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ESTADO_INICIO_PANEL_2 == 0)
                {
                    ESTADO_INICIO_PANEL_2 = 1;
                }
                else
                {
                    //VARIABLES
                    int ID_PORTAL = 2;

                    //CONSULTAR EL ITEM SELECCIONADO DEL CMBX
                    string ESTADO = CMB_PORTAL_2.SelectedItem.ToString();

                    if (ESTADO == "ON")
                    {
                        //INICIAR PORTAL
                        INICIAR_PORTAL(ID_PORTAL);
                    }
                    else if (ESTADO == "OFF")
                    {
                        //DETENER PORTAL
                        DETENER_LECTOR(ID_PORTAL);

                        LBL_ANTENNAS_2.Text = "0";
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// EVENTO CMBX PORTAL 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CMB_PORTAL_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ESTADO_INICIO_PANEL_3 == 0)
                {
                    ESTADO_INICIO_PANEL_3 = 1;
                }
                else
                {
                    //VARIABLES
                    int ID_PORTAL = 3;

                    //CONSULTAR EL ITEM SELECCIONADO DEL CMBX
                    string ESTADO = CMB_PORTAL_3.SelectedItem.ToString();

                    if (ESTADO == "ON")
                    {
                        //INICIAR PORTAL
                        INICIAR_PORTAL(ID_PORTAL);

                        if (RFID_READER_3.IsConnected)
                        {
                            //////////////////////////////////////////////////////////////////////////////////////////////////
                            //NUMERO DE ANTENNAS DISPONIBLES POR REDADER RFID
                            int NUM_ANTENNAS_READER = RFID_READER_3.Config.Antennas.AvailableAntennas.Length;

                            //MOSTRAR DATO
                            LBL_ANTENNAS_3.Text = NUM_ANTENNAS_READER.ToString();
                        }
                        else
                        {
                            LBL_ANTENNAS_3.Text = "0";
                        }
                    }
                    else if (ESTADO == "OFF")
                    {
                        //DETENER PORTAL
                        DETENER_LECTOR(ID_PORTAL);

                        LBL_ANTENNAS_3.Text = "0";
                    }
                }
            }
            catch (Exception)
            {

            }

        }

        /// <summary>
        /// EVENTO CMBX PORTAL 4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CMB_PORTAL_4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ESTADO_INICIO_PANEL_4 == 0)
                {
                    ESTADO_INICIO_PANEL_4 = 1;
                }
                else
                {
                    //VARIABLES
                    int ID_PORTAL = 4;

                    //CONSULTAR EL ITEM SELECCIONADO DEL CMBX
                    string ESTADO = CMB_PORTAL_4.SelectedItem.ToString();

                    if (ESTADO == "ON")
                    {
                        //INICIAR PORTAL
                        INICIAR_PORTAL(ID_PORTAL);

                        if (RFID_READER_4.IsConnected)
                        {
                            //////////////////////////////////////////////////////////////////////////////////////////////////
                            //NUMERO DE ANTENNAS DISPONIBLES POR REDADER RFID
                            int NUM_ANTENNAS_READER = RFID_READER_4.Config.Antennas.AvailableAntennas.Length;

                            //MOSTRAR DATO
                            LBL_ANTENNAS_4.Text = NUM_ANTENNAS_READER.ToString();
                        }
                        else
                        {
                            LBL_ANTENNAS_4.Text = "0";
                        }
                    }
                    else if (ESTADO == "OFF")
                    {
                        //DETENER PORTAL
                        DETENER_LECTOR(ID_PORTAL);

                        LBL_ANTENNAS_4.Text = "0";
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// EVENTO CMBX PORTAL 5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CMB_PORTAL_5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ESTADO_INICIO_PANEL_5 == 0)
                {
                    ESTADO_INICIO_PANEL_5 = 1;
                }
                else
                {
                    //VARIABLES
                    int ID_PORTAL = 5;

                    //CONSULTAR EL ITEM SELECCIONADO DEL CMBX
                    string ESTADO = CMB_PORTAL_5.SelectedItem.ToString();

                    if (ESTADO == "ON")
                    {
                        //INICIAR PORTAL
                        INICIAR_PORTAL(ID_PORTAL);

                        if (RFID_READER_5.IsConnected)
                        {
                            //////////////////////////////////////////////////////////////////////////////////////////////////
                            //NUMERO DE ANTENNAS DISPONIBLES POR REDADER RFID
                            int NUM_ANTENNAS_READER = RFID_READER_5.Config.Antennas.AvailableAntennas.Length;

                            //MOSTRAR DATO
                            LBL_ANTENNAS_5.Text = NUM_ANTENNAS_READER.ToString();
                        }
                        else
                        {
                            LBL_ANTENNAS_5.Text = "0";
                        }
                    }
                    else if (ESTADO == "OFF")
                    {
                        //DETENER PORTAL
                        DETENER_LECTOR(ID_PORTAL);

                        LBL_ANTENNAS_5.Text = "0";
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// EVENTO CMBX PORTAL 6
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CMB_PORTAL_6_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ESTADO_INICIO_PANEL_6 == 0)
                {
                    ESTADO_INICIO_PANEL_6 = 1;
                }
                else
                {
                    //VARIABLES
                    int ID_PORTAL = 6;

                    //CONSULTAR EL ITEM SELECCIONADO DEL CMBX
                    string ESTADO = CMB_PORTAL_6.SelectedItem.ToString();

                    if (ESTADO == "ON")
                    {
                        //INICIAR PORTAL
                        INICIAR_PORTAL(ID_PORTAL);

                        if (RFID_READER_6.IsConnected)
                        {
                            //////////////////////////////////////////////////////////////////////////////////////////////////
                            //NUMERO DE ANTENNAS DISPONIBLES POR REDADER RFID
                            int NUM_ANTENNAS_READER = RFID_READER_6.Config.Antennas.AvailableAntennas.Length;

                            //MOSTRAR DATO
                            LBL_ANTENNAS_6.Text = NUM_ANTENNAS_READER.ToString();
                        }
                        else
                        {
                            LBL_ANTENNAS_6.Text = "0";
                        }
                    }
                    else if (ESTADO == "OFF")
                    {
                        //DETENER PORTAL
                        DETENER_LECTOR(ID_PORTAL);

                        LBL_ANTENNAS_6.Text = "0";
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// EVENTO CMBX PORTAL 7
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CMB_PORTAL_7_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ESTADO_INICIO_PANEL_7 == 0)
                {
                    ESTADO_INICIO_PANEL_7 = 1;
                }
                else
                {
                    //VARIABLES
                    int ID_PORTAL = 7;

                    //CONSULTAR EL ITEM SELECCIONADO DEL CMBX
                    string ESTADO = CMB_PORTAL_7.SelectedItem.ToString();

                    if (ESTADO == "ON")
                    {
                        //INICIAR PORTAL
                        INICIAR_PORTAL(ID_PORTAL);

                        if (RFID_READER_7.IsConnected)
                        {
                            //////////////////////////////////////////////////////////////////////////////////////////////////
                            //NUMERO DE ANTENNAS DISPONIBLES POR REDADER RFID
                            int NUM_ANTENNAS_READER = RFID_READER_7.Config.Antennas.AvailableAntennas.Length;

                            //MOSTRAR DATO
                            LBL_ANTENNAS_7.Text = NUM_ANTENNAS_READER.ToString();
                        }
                        else
                        {
                            LBL_ANTENNAS_7.Text = "0";
                        }
                    }
                    else if (ESTADO == "OFF")
                    {
                        //DETENER PORTAL
                        DETENER_LECTOR(ID_PORTAL);

                        LBL_ANTENNAS_7.Text = "0";
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// EVENTO CMBX PORTAL 8
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CMB_PORTAL_8_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ESTADO_INICIO_PANEL_8 == 0)
                {
                    ESTADO_INICIO_PANEL_8 = 1;
                }
                else
                {
                    //VARIABLES
                    int ID_PORTAL = 8;

                    //CONSULTAR EL ITEM SELECCIONADO DEL CMBX
                    string ESTADO = CMB_PORTAL_8.SelectedItem.ToString();

                    if (ESTADO == "ON")
                    {
                        //INICIAR PORTAL
                        INICIAR_PORTAL(ID_PORTAL);

                        if (RFID_READER_8.IsConnected)
                        {
                            //////////////////////////////////////////////////////////////////////////////////////////////////
                            //NUMERO DE ANTENNAS DISPONIBLES POR REDADER RFID
                            int NUM_ANTENNAS_READER = RFID_READER_8.Config.Antennas.AvailableAntennas.Length;

                            //MOSTRAR DATO
                            LBL_ANTENNAS_8.Text = NUM_ANTENNAS_READER.ToString();
                        }
                        else
                        {
                            LBL_ANTENNAS_8.Text = "0";
                        }
                    }
                    else if (ESTADO == "OFF")
                    {
                        //DETENER PORTAL
                        DETENER_LECTOR(ID_PORTAL);

                        LBL_ANTENNAS_8.Text = "0";
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// EVENTO CMBX PORTAL 9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CMB_PORTAL_9_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ESTADO_INICIO_PANEL_9 == 0)
                {
                    ESTADO_INICIO_PANEL_9 = 1;
                }
                else
                {
                    //VARIABLES
                    int ID_PORTAL = 9;

                    //CONSULTAR EL ITEM SELECCIONADO DEL CMBX
                    string ESTADO = CMB_PORTAL_9.SelectedItem.ToString();

                    if (ESTADO == "ON")
                    {
                        //INICIAR PORTAL
                        INICIAR_PORTAL(ID_PORTAL);

                        if (RFID_READER_9.IsConnected)
                        {
                            //////////////////////////////////////////////////////////////////////////////////////////////////
                            //NUMERO DE ANTENNAS DISPONIBLES POR REDADER RFID
                            int NUM_ANTENNAS_READER = RFID_READER_9.Config.Antennas.AvailableAntennas.Length;

                            //MOSTRAR DATO
                            LBL_ANTENNAS_9.Text = NUM_ANTENNAS_READER.ToString();
                        }
                        else
                        {
                            LBL_ANTENNAS_9.Text = "0";
                        }
                    }
                    else if (ESTADO == "OFF")
                    {
                        //DETENER PORTAL
                        DETENER_LECTOR(ID_PORTAL);

                        LBL_ANTENNAS_9.Text = "0";
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// EVENTO CMBX PORTAL 10
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CMB_PORTAL_10_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ESTADO_INICIO_PANEL_10 == 0)
                {
                    ESTADO_INICIO_PANEL_10 = 1;
                }
                else
                {
                    //VARIABLES
                    int ID_PORTAL = 10;

                    //CONSULTAR EL ITEM SELECCIONADO DEL CMBX
                    string ESTADO = CMB_PORTAL_10.SelectedItem.ToString();

                    if (ESTADO == "ON")
                    {
                        //INICIAR PORTAL
                        INICIAR_PORTAL(ID_PORTAL);

                        if (RFID_READER_10.IsConnected)
                        {
                            //////////////////////////////////////////////////////////////////////////////////////////////////
                            //NUMERO DE ANTENNAS DISPONIBLES POR REDADER RFID
                            int NUM_ANTENNAS_READER = RFID_READER_10.Config.Antennas.AvailableAntennas.Length;

                            //MOSTRAR DATO
                            LBL_ANTENNAS_10.Text = NUM_ANTENNAS_READER.ToString();
                        }
                        else
                        {
                            LBL_ANTENNAS_10.Text = "0";
                        }
                    }
                    else if (ESTADO == "OFF")
                    {
                        //DETENER PORTAL
                        DETENER_LECTOR(ID_PORTAL);

                        LBL_ANTENNAS_10.Text = "0";
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// EVENTO CMBX PORTAL 11
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CMB_PORTAL_11_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ESTADO_INICIO_PANEL_11 == 0)
                {
                    ESTADO_INICIO_PANEL_11 = 1;
                }
                else
                {
                    //VARIABLES
                    int ID_PORTAL = 11;

                    //CONSULTAR EL ITEM SELECCIONADO DEL CMBX
                    string ESTADO = CMB_PORTAL_11.SelectedItem.ToString();

                    if (ESTADO == "ON")
                    {
                        //INICIAR PORTAL
                        INICIAR_PORTAL(ID_PORTAL);

                        if (RFID_READER_11.IsConnected)
                        {
                            //////////////////////////////////////////////////////////////////////////////////////////////////
                            //NUMERO DE ANTENNAS DISPONIBLES POR REDADER RFID
                            int NUM_ANTENNAS_READER = RFID_READER_11.Config.Antennas.AvailableAntennas.Length;

                            //MOSTRAR DATO
                            LBL_ANTENNAS_11.Text = NUM_ANTENNAS_READER.ToString();
                        }
                        else
                        {
                            LBL_ANTENNAS_11.Text = "0";
                        }
                    }
                    else if (ESTADO == "OFF")
                    {
                        //DETENER PORTAL
                        DETENER_LECTOR(ID_PORTAL);

                        LBL_ANTENNAS_11.Text = "0";
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// EVENTO CMBX PORTAL 12
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CMB_PORTAL_12_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ESTADO_INICIO_PANEL_12 == 0)
                {
                    ESTADO_INICIO_PANEL_12 = 1;
                }
                else
                {
                    //VARIABLES
                    int ID_PORTAL = 12;

                    //CONSULTAR EL ITEM SELECCIONADO DEL CMBX
                    string ESTADO = CMB_PORTAL_12.SelectedItem.ToString();

                    if (ESTADO == "ON")
                    {
                        //INICIAR PORTAL
                        INICIAR_PORTAL(ID_PORTAL);

                        if (RFID_READER_12.IsConnected)
                        {
                            //////////////////////////////////////////////////////////////////////////////////////////////////
                            //NUMERO DE ANTENNAS DISPONIBLES POR REDADER RFID
                            int NUM_ANTENNAS_READER = RFID_READER_12.Config.Antennas.AvailableAntennas.Length;

                            //MOSTRAR DATO
                            LBL_ANTENNAS_12.Text = NUM_ANTENNAS_READER.ToString();
                        }
                        else
                        {
                            LBL_ANTENNAS_12.Text = "0";
                        }
                    }
                    else if (ESTADO == "OFF")
                    {
                        //DETENER PORTAL
                        DETENER_LECTOR(ID_PORTAL);

                        LBL_ANTENNAS_12.Text = "0";
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// EVENTO CMBX PORTAL 13
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CMB_PORTAL_13_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ESTADO_INICIO_PANEL_13 == 0)
                {
                    ESTADO_INICIO_PANEL_13 = 1;
                }
                else
                {
                    //VARIABLES
                    int ID_PORTAL = 13;

                    //CONSULTAR EL ITEM SELECCIONADO DEL CMBX
                    string ESTADO = CMB_PORTAL_13.SelectedItem.ToString();

                    if (ESTADO == "ON")
                    {
                        //INICIAR PORTAL
                        INICIAR_PORTAL(ID_PORTAL);

                        if (RFID_READER_13.IsConnected)
                        {
                            //////////////////////////////////////////////////////////////////////////////////////////////////
                            //NUMERO DE ANTENNAS DISPONIBLES POR REDADER RFID
                            int NUM_ANTENNAS_READER = RFID_READER_13.Config.Antennas.AvailableAntennas.Length;

                            //MOSTRAR DATO
                            LBL_ANTENNAS_13.Text = NUM_ANTENNAS_READER.ToString();
                        }
                        else
                        {
                            LBL_ANTENNAS_13.Text = "0";
                        }
                    }
                    else if (ESTADO == "OFF")
                    {
                        //DETENER PORTAL
                        DETENER_LECTOR(ID_PORTAL);


                        LBL_ANTENNAS_13.Text = "0";
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// EVENTO CMBX PORTAL 14
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CMB_PORTAL_14_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ESTADO_INICIO_PANEL_14 == 0)
                {
                    ESTADO_INICIO_PANEL_14 = 1;
                }
                else
                {
                    //VARIABLES
                    int ID_PORTAL = 14;

                    //CONSULTAR EL ITEM SELECCIONADO DEL CMBX
                    string ESTADO = CMB_PORTAL_14.SelectedItem.ToString();

                    if (ESTADO == "ON")
                    {
                        //INICIAR PORTAL
                        INICIAR_PORTAL(ID_PORTAL);

                        if (RFID_READER_14.IsConnected)
                        {
                            //////////////////////////////////////////////////////////////////////////////////////////////////
                            //NUMERO DE ANTENNAS DISPONIBLES POR REDADER RFID
                            int NUM_ANTENNAS_READER = RFID_READER_14.Config.Antennas.AvailableAntennas.Length;

                            //MOSTRAR DATO
                            LBL_ANTENNAS_14.Text = NUM_ANTENNAS_READER.ToString();
                        }
                        else
                        {
                            LBL_ANTENNAS_14.Text = "0";
                        }
                    }
                    else if (ESTADO == "OFF")
                    {
                        //DETENER PORTAL
                        DETENER_LECTOR(ID_PORTAL);

                        LBL_ANTENNAS_14.Text = "0";
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// EVENTO CMBX PORTAL 15
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CMB_PORTAL_15_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ESTADO_INICIO_PANEL_15 == 0)
                {
                    ESTADO_INICIO_PANEL_15 = 1;
                }
                else
                {
                    //VARIABLES
                    int ID_PORTAL = 15;

                    //CONSULTAR EL ITEM SELECCIONADO DEL CMBX
                    string ESTADO = CMB_PORTAL_15.SelectedItem.ToString();

                    if (ESTADO == "ON")
                    {
                        //INICIAR PORTAL
                        INICIAR_PORTAL(ID_PORTAL);

                        if (RFID_READER_15.IsConnected)
                        {
                            //////////////////////////////////////////////////////////////////////////////////////////////////
                            //NUMERO DE ANTENNAS DISPONIBLES POR REDADER RFID
                            int NUM_ANTENNAS_READER = RFID_READER_15.Config.Antennas.AvailableAntennas.Length;

                            //MOSTRAR DATO
                            LBL_ANTENNAS_15.Text = NUM_ANTENNAS_READER.ToString();
                        }
                        else
                        {
                            LBL_ANTENNAS_15.Text = "0";
                        }
                    }
                    else if (ESTADO == "OFF")
                    {
                        //DETENER PORTAL
                        DETENER_LECTOR(ID_PORTAL);

                        LBL_ANTENNAS_15.Text = "0";
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// EVENTO CMBX PORTAL 16
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CMB_PORTAL_16_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ESTADO_INICIO_PANEL_16 == 0)
                {
                    ESTADO_INICIO_PANEL_16 = 1;
                }
                else
                {
                    //VARIABLES
                    int ID_PORTAL = 16;

                    //CONSULTAR EL ITEM SELECCIONADO DEL CMBX
                    string ESTADO = CMB_PORTAL_16.SelectedItem.ToString();

                    if (ESTADO == "ON")
                    {
                        //INICIAR PORTAL
                        INICIAR_PORTAL(ID_PORTAL);

                        if (RFID_READER_16.IsConnected)
                        {
                            //////////////////////////////////////////////////////////////////////////////////////////////////
                            //NUMERO DE ANTENNAS DISPONIBLES POR REDADER RFID
                            int NUM_ANTENNAS_READER = RFID_READER_16.Config.Antennas.AvailableAntennas.Length;

                            //MOSTRAR DATO
                            LBL_ANTENNAS_16.Text = NUM_ANTENNAS_READER.ToString();
                        }
                        else
                        {
                            LBL_ANTENNAS_16.Text = "0";
                        }
                    }
                    else if (ESTADO == "OFF")
                    {
                        //DETENER PORTAL
                        DETENER_LECTOR(ID_PORTAL);

                        LBL_ANTENNAS_16.Text = "0";
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// EVENTO CMBX PORTAL 17
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CMB_PORTAL_17_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ESTADO_INICIO_PANEL_17 == 0)
                {
                    ESTADO_INICIO_PANEL_17 = 1;
                }
                else
                {
                    //VARIABLES
                    int ID_PORTAL = 17;

                    //CONSULTAR EL ITEM SELECCIONADO DEL CMBX
                    string ESTADO = CMB_PORTAL_17.SelectedItem.ToString();

                    if (ESTADO == "ON")
                    {
                        //INICIAR PORTAL
                        INICIAR_PORTAL(ID_PORTAL);

                        if (RFID_READER_17.IsConnected)
                        {
                            //////////////////////////////////////////////////////////////////////////////////////////////////
                            //NUMERO DE ANTENNAS DISPONIBLES POR REDADER RFID
                            int NUM_ANTENNAS_READER = RFID_READER_17.Config.Antennas.AvailableAntennas.Length;

                            //MOSTRAR DATO
                            LBL_ANTENNAS_17.Text = NUM_ANTENNAS_READER.ToString();
                        }
                        else
                        {
                            LBL_ANTENNAS_17.Text = "0";
                        }
                    }
                    else if (ESTADO == "OFF")
                    {
                        //DETENER PORTAL
                        DETENER_LECTOR(ID_PORTAL);

                        LBL_ANTENNAS_17.Text = "0";
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// EVENTO CMBX PORTAL 18
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CMB_PORTAL_18_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ESTADO_INICIO_PANEL_18 == 0)
                {
                    ESTADO_INICIO_PANEL_18 = 1;
                }
                else
                {
                    //VARIABLES
                    int ID_PORTAL = 18;

                    //CONSULTAR EL ITEM SELECCIONADO DEL CMBX
                    string ESTADO = CMB_PORTAL_18.SelectedItem.ToString();

                    if (ESTADO == "ON")
                    {
                        //INICIAR PORTAL
                        INICIAR_PORTAL(ID_PORTAL);

                        if (RFID_READER_18.IsConnected)
                        {
                            //////////////////////////////////////////////////////////////////////////////////////////////////
                            //NUMERO DE ANTENNAS DISPONIBLES POR REDADER RFID
                            int NUM_ANTENNAS_READER = RFID_READER_18.Config.Antennas.AvailableAntennas.Length;

                            //MOSTRAR DATO
                            LBL_ANTENNAS_18.Text = NUM_ANTENNAS_READER.ToString();
                        }
                        else
                        {
                            LBL_ANTENNAS_18.Text = "0";
                        }
                    }
                    else if (ESTADO == "OFF")
                    {
                        //DETENER PORTAL
                        DETENER_LECTOR(ID_PORTAL);

                        LBL_ANTENNAS_18.Text = "0";
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// EVENTO CMBX PORTAL 19
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CMB_PORTAL_19_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ESTADO_INICIO_PANEL_19 == 0)
                {
                    ESTADO_INICIO_PANEL_19 = 1;
                }
                else
                {
                    //VARIABLES
                    int ID_PORTAL = 19;

                    //CONSULTAR EL ITEM SELECCIONADO DEL CMBX
                    string ESTADO = CMB_PORTAL_19.SelectedItem.ToString();

                    if (ESTADO == "ON")
                    {
                        //INICIAR PORTAL
                        INICIAR_PORTAL(ID_PORTAL);

                        if (RFID_READER_19.IsConnected)
                        {
                            //////////////////////////////////////////////////////////////////////////////////////////////////
                            //NUMERO DE ANTENNAS DISPONIBLES POR REDADER RFID
                            int NUM_ANTENNAS_READER = RFID_READER_19.Config.Antennas.AvailableAntennas.Length;

                            //MOSTRAR DATO
                            LBL_ANTENNAS_19.Text = NUM_ANTENNAS_READER.ToString();
                        }
                        else
                        {
                            LBL_ANTENNAS_19.Text = "0";
                        }
                    }
                    else if (ESTADO == "OFF")
                    {
                        //DETENER PORTAL
                        DETENER_LECTOR(ID_PORTAL);

                        LBL_ANTENNAS_19.Text = "0";
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// EVENTO CMBX PORTAL 20
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CMB_PORTAL_20_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ESTADO_INICIO_PANEL_20 == 0)
                {
                    ESTADO_INICIO_PANEL_20 = 1;
                }
                else
                {
                    //VARIABLES
                    int ID_PORTAL = 20;

                    //CONSULTAR EL ITEM SELECCIONADO DEL CMBX
                    string ESTADO = CMB_PORTAL_20.SelectedItem.ToString();

                    if (ESTADO == "ON")
                    {
                        //INICIAR PORTAL
                        INICIAR_PORTAL(ID_PORTAL);

                        if (RFID_READER_20.IsConnected)
                        {
                            //////////////////////////////////////////////////////////////////////////////////////////////////
                            //NUMERO DE ANTENNAS DISPONIBLES POR REDADER RFID
                            int NUM_ANTENNAS_READER = RFID_READER_20.Config.Antennas.AvailableAntennas.Length;

                            //MOSTRAR DATO
                            LBL_ANTENNAS_20.Text = NUM_ANTENNAS_READER.ToString();
                        }
                        else
                        {
                            LBL_ANTENNAS_20.Text = "0";
                        }
                    }
                    else if (ESTADO == "OFF")
                    {
                        //DETENER PORTAL
                        DETENER_LECTOR(ID_PORTAL);

                        LBL_ANTENNAS_20.Text = "0";
                    }
                }
            }
            catch (Exception)
            {

            }
        }



        #endregion


        ////////////////////////////////////////////////////////////////////////
        //                          METODOS                                   //
        ////////////////////////////////////////////////////////////////////////

        #region METODOS

        /// <summary>
        /// METODO ENCARGADO DE CARGAR LOS ITEMS DE LOS COMBOX
        /// </summary>
        public void CARGAR_COMBOX_ITEMS_ESTADO()
        {

            CMB_PORTAL_1.Items.Insert(0, "ON");
            CMB_PORTAL_1.Items.Insert(1, "OFF");
            //CMB_PORTAL_1.SelectedItem = "ON";

            CMB_PORTAL_2.Items.Insert(0, "ON");
            CMB_PORTAL_2.Items.Insert(1, "OFF");
            //CMB_PORTAL_2.SelectedItem = "OFF";

            CMB_PORTAL_3.Items.Insert(0, "ON");
            CMB_PORTAL_3.Items.Insert(1, "OFF");
            //CMB_PORTAL_3.SelectedItem = "OFF";

            CMB_PORTAL_4.Items.Insert(0, "ON");
            CMB_PORTAL_4.Items.Insert(1, "OFF");
            //CMB_PORTAL_4.SelectedItem = "OFF";

            CMB_PORTAL_5.Items.Insert(0, "ON");
            CMB_PORTAL_5.Items.Insert(1, "OFF");
            //CMB_PORTAL_5.SelectedItem = "OFF";

            CMB_PORTAL_6.Items.Insert(0, "ON");
            CMB_PORTAL_6.Items.Insert(1, "OFF");
            //CMB_PORTAL_6.SelectedItem = "OFF";

            CMB_PORTAL_7.Items.Insert(0, "ON");
            CMB_PORTAL_7.Items.Insert(1, "OFF");
            //CMB_PORTAL_7.SelectedItem = "OFF";

            CMB_PORTAL_8.Items.Insert(0, "ON");
            CMB_PORTAL_8.Items.Insert(1, "OFF");
            //CMB_PORTAL_8.SelectedItem = "OFF";

            CMB_PORTAL_9.Items.Insert(0, "ON");
            CMB_PORTAL_9.Items.Insert(1, "OFF");
            //CMB_PORTAL_9.SelectedItem = "OFF";

            CMB_PORTAL_10.Items.Insert(0, "ON");
            CMB_PORTAL_10.Items.Insert(1, "OFF");
            //CMB_PORTAL_10.SelectedItem = "OFF";

            CMB_PORTAL_11.Items.Insert(0, "ON");
            CMB_PORTAL_11.Items.Insert(1, "OFF");
            //CMB_PORTAL_11.SelectedItem = "OFF";

            CMB_PORTAL_12.Items.Insert(0, "ON");
            CMB_PORTAL_12.Items.Insert(1, "OFF");
            //CMB_PORTAL_12.SelectedItem = "OFF";

            CMB_PORTAL_13.Items.Insert(0, "ON");
            CMB_PORTAL_13.Items.Insert(1, "OFF");
            //CMB_PORTAL_13.SelectedItem = "OFF";

            CMB_PORTAL_14.Items.Insert(0, "ON");
            CMB_PORTAL_14.Items.Insert(1, "OFF");
            //CMB_PORTAL_14.SelectedItem = "OFF";

            CMB_PORTAL_15.Items.Insert(0, "ON");
            CMB_PORTAL_15.Items.Insert(1, "OFF");
            //CMB_PORTAL_15.SelectedItem = "OFF";

            CMB_PORTAL_16.Items.Insert(0, "ON");
            CMB_PORTAL_16.Items.Insert(1, "OFF");
            //CMB_PORTAL_16.SelectedItem = "OFF";

            CMB_PORTAL_17.Items.Insert(0, "ON");
            CMB_PORTAL_17.Items.Insert(1, "OFF");
            //CMB_PORTAL_17.SelectedItem = "OFF";

            CMB_PORTAL_18.Items.Insert(0, "ON");
            CMB_PORTAL_18.Items.Insert(1, "OFF");
            //CMB_PORTAL_18.SelectedItem = "OFF";

            CMB_PORTAL_19.Items.Insert(0, "ON");
            CMB_PORTAL_19.Items.Insert(1, "OFF");
            //CMB_PORTAL_19.SelectedItem = "OFF";

            CMB_PORTAL_20.Items.Insert(0, "ON");
            CMB_PORTAL_20.Items.Insert(1, "OFF");
            //CMB_PORTAL_20.SelectedItem = "OFF";
        }

        /// <summary>
        /// VALIDAR PERMISO DEL PROCESO
        /// </summary>
        /// <returns></returns>
        public string VALIDAR_PROCESO()
        {
            VALIDAR_PROCESO FRM_VALIDAR = new VALIDAR_PROCESO();
            FRM_VALIDAR.ShowDialog();

            //VALIDAR PROCESO POR USUARIO AUTORIZADO
            VALIDAR_PROCESO frm = new VALIDAR_PROCESO();
            string Permiso = frm.PermitirAcceso.ToString();

            //RETORNAMOS EL RESULTADO
            return Permiso;

        }


        #endregion


        ////////////////////////////////////////////////////////////////////////
        //                          CONSULTAS                                 //
        ////////////////////////////////////////////////////////////////////////

        #region CONSULTAS

        /// <summary>
        /// CONSULTAMOS LOS NOMBRES DE LOS PORTALES
        /// </summary>
        public void CONSULTA_PORTALES()
        {

            DataTable DT = new DataTable();

            //CONSULTA Y CONSUMO
            DT = consulta_DB.SWITCH_PANEL_GET_PORTALES();

            DataRow dr = null;

            if (DT.Rows.Count > 0)
            {
                //ASIGNACION DE LOS NOMBRE AL LABEL
                if (DT.Rows.Count >= 1)
                    LBL_PORTAL_1.Text = DT.Rows[0][1].ToString();
                if (DT.Rows.Count >= 2)
                    LBL_PORTAL_2.Text = DT.Rows[1][1].ToString();
                if (DT.Rows.Count >= 3)
                    LBL_PORTAL_3.Text = DT.Rows[2][1].ToString();
                if (DT.Rows.Count >= 4)
                    LBL_PORTAL_4.Text = DT.Rows[3][1].ToString();
                if (DT.Rows.Count >= 5)
                    LBL_PORTAL_5.Text = DT.Rows[4][1].ToString();
                if (DT.Rows.Count >= 6)
                    LBL_PORTAL_6.Text = DT.Rows[5][1].ToString();
                if (DT.Rows.Count >= 7)
                    LBL_PORTAL_7.Text = DT.Rows[6][1].ToString();
                if (DT.Rows.Count >= 8)
                    LBL_PORTAL_8.Text = DT.Rows[7][1].ToString();
                if (DT.Rows.Count >= 9)
                    LBL_PORTAL_9.Text = DT.Rows[8][1].ToString();
                if (DT.Rows.Count >= 10)
                    LBL_PORTAL_10.Text = DT.Rows[9][1].ToString();
                if (DT.Rows.Count >= 11)
                    LBL_PORTAL_11.Text = DT.Rows[10][1].ToString();
                if (DT.Rows.Count >= 12)
                    LBL_PORTAL_12.Text = DT.Rows[11][1].ToString();
                if (DT.Rows.Count >= 13)
                    LBL_PORTAL_13.Text = DT.Rows[12][1].ToString();
                if (DT.Rows.Count >= 14)
                    LBL_PORTAL_14.Text = DT.Rows[13][1].ToString();
                if (DT.Rows.Count >= 15)
                    LBL_PORTAL_15.Text = DT.Rows[14][1].ToString();
                if (DT.Rows.Count >= 16)
                    LBL_PORTAL_16.Text = DT.Rows[15][1].ToString();
                if (DT.Rows.Count >= 17)
                    LBL_PORTAL_17.Text = DT.Rows[16][1].ToString();
                if (DT.Rows.Count >= 18)
                    LBL_PORTAL_18.Text = DT.Rows[17][1].ToString();
                if (DT.Rows.Count >= 19)
                    LBL_PORTAL_19.Text = DT.Rows[18][1].ToString();
                if (DT.Rows.Count >= 20)
                    LBL_PORTAL_20.Text = DT.Rows[19][1].ToString();

            }
        }

        /// <summary>
        /// CONSULTAR LICENCIAS
        /// </summary>
        private void CONSULTA_LICECNICA_PORTAL()
        {
            DATA_BASE.CONSULTAS portal = new DATA_BASE.CONSULTAS();

            DataTable dt1 = portal.CONSULTAR_LICENCIA_PORTAL(1);
            DataTable dt2 = portal.CONSULTAR_LICENCIA_PORTAL(2);
            DataTable dt3 = portal.CONSULTAR_LICENCIA_PORTAL(3);
            DataTable dt4 = portal.CONSULTAR_LICENCIA_PORTAL(4);
            DataTable dt5 = portal.CONSULTAR_LICENCIA_PORTAL(5);
            DataTable dt6 = portal.CONSULTAR_LICENCIA_PORTAL(6);
            DataTable dt7 = portal.CONSULTAR_LICENCIA_PORTAL(7);
            DataTable dt8 = portal.CONSULTAR_LICENCIA_PORTAL(8);
            DataTable dt9 = portal.CONSULTAR_LICENCIA_PORTAL(9);
            DataTable dt10 = portal.CONSULTAR_LICENCIA_PORTAL(10);
            DataTable dt11 = portal.CONSULTAR_LICENCIA_PORTAL(11);
            DataTable dt12 = portal.CONSULTAR_LICENCIA_PORTAL(12);
            DataTable dt13 = portal.CONSULTAR_LICENCIA_PORTAL(13);
            DataTable dt14 = portal.CONSULTAR_LICENCIA_PORTAL(14);
            DataTable dt15 = portal.CONSULTAR_LICENCIA_PORTAL(15);
            DataTable dt16 = portal.CONSULTAR_LICENCIA_PORTAL(16);
            DataTable dt17 = portal.CONSULTAR_LICENCIA_PORTAL(17);
            DataTable dt18 = portal.CONSULTAR_LICENCIA_PORTAL(18);
            DataTable dt19 = portal.CONSULTAR_LICENCIA_PORTAL(19);
            DataTable dt20 = portal.CONSULTAR_LICENCIA_PORTAL(20);

            //PORTAL 1
            if (dt1.Rows.Count > 0)
            {
                //ASIGNAR LA DATA AL DATAROW
                DataRow dr = dt1.Rows[0];

                //LICENCIA
                string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                if (LICENCIA_PORTAL == "True")
                {
                    //MOSTRAR EL PORTAL DEL SWICTH PANEL
                    PANEL_1.Visible = true;
                }
                else
                {
                    //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                    PANEL_1.Visible = false;

                }
            }

            //PORTAL 2
            if (dt2.Rows.Count > 0)
            {
                //ASIGNAR LA DATA AL DATAROW
                DataRow dr = dt2.Rows[0];

                //LICENCIA
                string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                if (LICENCIA_PORTAL == "True")
                {
                    //MOSTRAR EL PORTAL DEL SWICTH PANEL
                    PANEL_2.Visible = true;
                }
                else
                {
                    //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                    PANEL_2.Visible = false;

                }
            }

            //PORTAL 3
            if (dt3.Rows.Count > 0)
            {
                //ASIGNAR LA DATA AL DATAROW
                DataRow dr = dt3.Rows[0];

                //LICENCIA
                string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                if (LICENCIA_PORTAL == "True")
                {
                    //MOSTRAR EL PORTAL DEL SWICTH PANEL
                    PANEL_3.Visible = true;
                }
                else
                {
                    //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                    PANEL_3.Visible = false;

                }
            }

            //PORTAL 4
            if (dt4.Rows.Count > 0)
            {
                //ASIGNAR LA DATA AL DATAROW
                DataRow dr = dt4.Rows[0];

                //LICENCIA
                string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                if (LICENCIA_PORTAL == "True")
                {
                    //MOSTRAR EL PORTAL DEL SWICTH PANEL
                    PANEL_4.Visible = true;
                }
                else
                {
                    //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                    PANEL_4.Visible = false;

                }
            }

            //PORTAL 5
            if (dt5.Rows.Count > 0)
            {
                //ASIGNAR LA DATA AL DATAROW
                DataRow dr = dt5.Rows[0];

                //LICENCIA
                string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                if (LICENCIA_PORTAL == "True")
                {
                    //MOSTRAR EL PORTAL DEL SWICTH PANEL
                    PANEL_5.Visible = true;
                }
                else
                {
                    //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                    PANEL_5.Visible = false;

                }
            }

            //PORTAL 6
            if (dt6.Rows.Count > 0)
            {
                //ASIGNAR LA DATA AL DATAROW
                DataRow dr = dt6.Rows[0];

                //LICENCIA
                string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                if (LICENCIA_PORTAL == "True")
                {
                    //MOSTRAR EL PORTAL DEL SWICTH PANEL
                    PANEL_6.Visible = true;
                }
                else
                {
                    //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                    PANEL_6.Visible = false;

                }
            }

            //PORTAL 7
            if (dt7.Rows.Count > 0)
            {
                //ASIGNAR LA DATA AL DATAROW
                DataRow dr = dt7.Rows[0];

                //LICENCIA
                string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                if (LICENCIA_PORTAL == "True")
                {
                    //MOSTRAR EL PORTAL DEL SWICTH PANEL
                    PANEL_7.Visible = true;
                }
                else
                {
                    //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                    PANEL_7.Visible = false;

                }
            }

            //PORTAL 8
            if (dt8.Rows.Count > 0)
            {
                //ASIGNAR LA DATA AL DATAROW
                DataRow dr = dt8.Rows[0];

                //LICENCIA
                string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                if (LICENCIA_PORTAL == "True")
                {
                    //MOSTRAR EL PORTAL DEL SWICTH PANEL
                    PANEL_8.Visible = true;
                }
                else
                {
                    //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                    PANEL_8.Visible = false;

                }
            }

            //PORTAL 9
            if (dt9.Rows.Count > 0)
            {
                //ASIGNAR LA DATA AL DATAROW
                DataRow dr = dt9.Rows[0];

                //LICENCIA
                string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                if (LICENCIA_PORTAL == "True")
                {
                    //MOSTRAR EL PORTAL DEL SWICTH PANEL
                    PANEL_9.Visible = true;
                }
                else
                {
                    //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                    PANEL_9.Visible = false;

                }
            }

            //PORTAL 10
            if (dt10.Rows.Count > 0)
            {
                //ASIGNAR LA DATA AL DATAROW
                DataRow dr = dt10.Rows[0];

                //LICENCIA
                string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                if (LICENCIA_PORTAL == "True")
                {
                    //MOSTRAR EL PORTAL DEL SWICTH PANEL
                    PANEL_10.Visible = true;
                }
                else
                {
                    //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                    PANEL_10.Visible = false;

                }
            }

            //PORTAL 11
            if (dt11.Rows.Count > 0)
            {
                //ASIGNAR LA DATA AL DATAROW
                DataRow dr = dt11.Rows[0];

                //LICENCIA
                string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                if (LICENCIA_PORTAL == "True")
                {
                    //MOSTRAR EL PORTAL DEL SWICTH PANEL
                    PANEL_11.Visible = true;
                }
                else
                {
                    //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                    PANEL_11.Visible = false;

                }
            }

            //PORTAL 12
            if (dt12.Rows.Count > 0)
            {
                //ASIGNAR LA DATA AL DATAROW
                DataRow dr = dt12.Rows[0];

                //LICENCIA
                string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                if (LICENCIA_PORTAL == "True")
                {
                    //MOSTRAR EL PORTAL DEL SWICTH PANEL
                    PANEL_12.Visible = true;
                }
                else
                {
                    //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                    PANEL_12.Visible = false;

                }
            }

            //PORTAL 13
            if (dt13.Rows.Count > 0)
            {
                //ASIGNAR LA DATA AL DATAROW
                DataRow dr = dt13.Rows[0];

                //LICENCIA
                string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                if (LICENCIA_PORTAL == "True")
                {
                    //MOSTRAR EL PORTAL DEL SWICTH PANEL
                    PANEL_13.Visible = true;
                }
                else
                {
                    //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                    PANEL_13.Visible = false;

                }
            }

            //PORTAL 14
            if (dt14.Rows.Count > 0)
            {
                //ASIGNAR LA DATA AL DATAROW
                DataRow dr = dt14.Rows[0];

                //LICENCIA
                string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                if (LICENCIA_PORTAL == "True")
                {
                    //MOSTRAR EL PORTAL DEL SWICTH PANEL
                    PANEL_14.Visible = true;
                }
                else
                {
                    //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                    PANEL_14.Visible = false;

                }
            }

            //PORTAL 15
            if (dt15.Rows.Count > 0)
            {
                //ASIGNAR LA DATA AL DATAROW
                DataRow dr = dt15.Rows[0];

                //LICENCIA
                string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                if (LICENCIA_PORTAL == "True")
                {
                    //MOSTRAR EL PORTAL DEL SWICTH PANEL
                    PANEL_15.Visible = true;
                }
                else
                {
                    //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                    PANEL_15.Visible = false;

                }
            }

            //PORTAL 16
            if (dt16.Rows.Count > 0)
            {
                //ASIGNAR LA DATA AL DATAROW
                DataRow dr = dt16.Rows[0];

                //LICENCIA
                string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                if (LICENCIA_PORTAL == "True")
                {
                    //MOSTRAR EL PORTAL DEL SWICTH PANEL
                    PANEL_16.Visible = true;
                }
                else
                {
                    //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                    PANEL_16.Visible = false;

                }
            }

            //PORTAL 17
            if (dt17.Rows.Count > 0)
            {
                //ASIGNAR LA DATA AL DATAROW
                DataRow dr = dt17.Rows[0];

                //LICENCIA
                string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                if (LICENCIA_PORTAL == "True")
                {
                    //MOSTRAR EL PORTAL DEL SWICTH PANEL
                    PANEL_17.Visible = true;
                }
                else
                {
                    //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                    PANEL_17.Visible = false;

                }
            }

            //PORTAL 18
            if (dt18.Rows.Count > 0)
            {
                //ASIGNAR LA DATA AL DATAROW
                DataRow dr = dt18.Rows[0];

                //LICENCIA
                string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                if (LICENCIA_PORTAL == "True")
                {
                    //MOSTRAR EL PORTAL DEL SWICTH PANEL
                    PANEL_18.Visible = true;
                }
                else
                {
                    //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                    PANEL_18.Visible = false;

                }
            }

            //PORTAL 1
            if (dt19.Rows.Count > 0)
            {
                //ASIGNAR LA DATA AL DATAROW
                DataRow dr = dt19.Rows[0];

                //LICENCIA
                string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                if (LICENCIA_PORTAL == "True")
                {
                    //MOSTRAR EL PORTAL DEL SWICTH PANEL
                    PANEL_19.Visible = true;
                }
                else
                {
                    //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                    PANEL_19.Visible = false;

                }
            }

            //PORTAL 20
            if (dt20.Rows.Count > 0)
            {
                //ASIGNAR LA DATA AL DATAROW
                DataRow dr = dt20.Rows[0];

                //LICENCIA
                string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                if (LICENCIA_PORTAL == "True")
                {
                    //MOSTRAR EL PORTAL DEL SWICTH PANEL
                    PANEL_20.Visible = true;
                }
                else
                {
                    //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                    PANEL_20.Visible = false;

                }
            }
        }


        /// <summary>
        /// ACTUALIZAR EL SWICTH PANEL
        /// </summary>
        public void ACTUALIZAR_SWITCH_PANEL(string ID_PORT)
        {
            ///////////////////////////////////////////////////////////////////////////
            DATA_BASE.CONSULTAS portal = new DATA_BASE.CONSULTAS();

            int ID_PORTAL = Convert.ToInt32(ID_PORT);


            /////////////////////////////////////////////////////////
            ///       ACTUALIZAR DATOS DEL PORTAL MODIFICADO      ///
            /////////////////////////////////////////////////////////


            if (ID_PORTAL == 1)
            {
                DataTable dt_1 = portal.SWITCH_PANEL_GET_INFO_PORTAL(1);
                if (dt_1.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_1.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //IMAGEN
                        byte[] Imagen = new byte[0];
                        Imagen = (byte[])dr["IMAGEN_READER"];

                        if (Imagen != null)
                        {
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX1.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_1.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 
                            CMB_PORTAL_1.BackColor = Color.Green;
                            CMB_PORTAL_1.ForeColor = Color.White;
                            CMB_PORTAL_1.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 
                            CMB_PORTAL_1.BackColor = Color.Red;
                            CMB_PORTAL_1.ForeColor = Color.White;
                            CMB_PORTAL_1.SelectedIndex = 1;
                        }
                    }
                }
            }


            if (ID_PORTAL == 2)
            {
                DataTable dt_2 = portal.SWITCH_PANEL_GET_INFO_PORTAL(2);
                if (dt_2.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_2.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //IMAGEN
                        byte[] Imagen = new byte[0];
                        Imagen = (byte[])dr["IMAGEN_READER"];

                        if (Imagen != null)
                        {
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX2.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_2.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 
                            CMB_PORTAL_2.BackColor = Color.Green;
                            CMB_PORTAL_2.ForeColor = Color.White;
                            CMB_PORTAL_2.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 
                            CMB_PORTAL_2.BackColor = Color.Red;
                            CMB_PORTAL_2.ForeColor = Color.White;
                            CMB_PORTAL_2.SelectedIndex = 1;
                        }
                    }
                }
            }




            if (ID_PORTAL == 3)
            {
                DataTable dt_3 = portal.SWITCH_PANEL_GET_INFO_PORTAL(3);


                if (dt_3.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_3.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //IMAGEN
                        byte[] Imagen = new byte[0];
                        Imagen = (byte[])dr["IMAGEN_READER"];

                        if (Imagen != null)
                        {
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX3.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_3.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 
                            CMB_PORTAL_3.BackColor = Color.Green;
                            CMB_PORTAL_3.ForeColor = Color.White;
                            CMB_PORTAL_3.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 
                            CMB_PORTAL_3.BackColor = Color.Red;
                            CMB_PORTAL_3.ForeColor = Color.White;
                            CMB_PORTAL_3.SelectedIndex = 1;
                        }
                    }
                }
            }
            if (ID_PORTAL == 4)
            {
                DataTable dt_4 = portal.SWITCH_PANEL_GET_INFO_PORTAL(4);

                if (dt_4.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_4.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //IMAGEN
                        byte[] Imagen = new byte[0];
                        Imagen = (byte[])dr["IMAGEN_READER"];

                        if (Imagen != null)
                        {
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX4.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_4.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 
                            CMB_PORTAL_4.BackColor = Color.Green;
                            CMB_PORTAL_4.ForeColor = Color.White;
                            CMB_PORTAL_4.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 
                            CMB_PORTAL_4.BackColor = Color.Red;
                            CMB_PORTAL_4.ForeColor = Color.White;
                            CMB_PORTAL_4.SelectedIndex = 1;
                        }
                    }
                }
            }

            if (ID_PORTAL == 5)
            {
                DataTable dt_5 = portal.SWITCH_PANEL_GET_INFO_PORTAL(5);
                if (dt_5.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_5.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //IMAGEN
                        byte[] Imagen = new byte[0];
                        Imagen = (byte[])dr["IMAGEN_READER"];

                        if (Imagen != null)
                        {
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX5.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_5.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 
                            CMB_PORTAL_5.BackColor = Color.Green;
                            CMB_PORTAL_5.ForeColor = Color.White;
                            CMB_PORTAL_5.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 
                            CMB_PORTAL_5.BackColor = Color.Red;
                            CMB_PORTAL_5.ForeColor = Color.White;
                            CMB_PORTAL_5.SelectedIndex = 1;
                        }
                    }

                }
            }

            if (ID_PORTAL == 6)
            {
                DataTable dt_6 = portal.SWITCH_PANEL_GET_INFO_PORTAL(6);

                if (dt_6.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_6.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //IMAGEN
                        byte[] Imagen = new byte[0];
                        Imagen = (byte[])dr["IMAGEN_READER"];

                        if (Imagen != null)
                        {
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX6.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_6.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 
                            CMB_PORTAL_6.BackColor = Color.Green;
                            CMB_PORTAL_6.ForeColor = Color.White;
                            CMB_PORTAL_6.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 
                            CMB_PORTAL_6.BackColor = Color.Red;
                            CMB_PORTAL_6.ForeColor = Color.White;
                            CMB_PORTAL_6.SelectedIndex = 1;
                        }
                    }

                }
            }

            if (ID_PORTAL == 7)
            {
                DataTable dt_7 = portal.SWITCH_PANEL_GET_INFO_PORTAL(7);
                if (dt_7.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_7.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //IMAGEN
                        byte[] Imagen = new byte[0];
                        Imagen = (byte[])dr["IMAGEN_READER"];

                        if (Imagen != null)
                        {
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX7.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_7.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 
                            CMB_PORTAL_7.BackColor = Color.Green;
                            CMB_PORTAL_7.ForeColor = Color.White;
                            CMB_PORTAL_7.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 
                            CMB_PORTAL_7.BackColor = Color.Red;
                            CMB_PORTAL_7.ForeColor = Color.White;
                            CMB_PORTAL_7.SelectedIndex = 1;
                        }
                    }

                }
            }

            if (ID_PORTAL == 8)
            {
                DataTable dt_8 = portal.SWITCH_PANEL_GET_INFO_PORTAL(8);

                if (dt_8.Rows.Count > 0)
                {

                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_8.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //IMAGEN
                        byte[] Imagen = new byte[0];
                        Imagen = (byte[])dr["IMAGEN_READER"];

                        if (Imagen != null)
                        {
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX8.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_8.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 
                            CMB_PORTAL_8.BackColor = Color.Green;
                            CMB_PORTAL_8.ForeColor = Color.White;
                            CMB_PORTAL_8.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 
                            CMB_PORTAL_8.BackColor = Color.Red;
                            CMB_PORTAL_8.ForeColor = Color.White;
                            CMB_PORTAL_8.SelectedIndex = 1;
                        }

                    }
                }
            }

            if (ID_PORTAL == 9)
            {
                DataTable dt_9 = portal.SWITCH_PANEL_GET_INFO_PORTAL(9);

                if (dt_9.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_9.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //IMAGEN
                        byte[] Imagen = new byte[0];
                        Imagen = (byte[])dr["IMAGEN_READER"];

                        if (Imagen != null)
                        {
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX9.Image = Image.FromStream(ms);
                        }


                        //NOMBRE PORTAL
                        LBL_PORTAL_9.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 
                            CMB_PORTAL_9.BackColor = Color.Green;
                            CMB_PORTAL_9.ForeColor = Color.White;
                            CMB_PORTAL_9.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 
                            CMB_PORTAL_9.BackColor = Color.Red;
                            CMB_PORTAL_9.ForeColor = Color.White;
                            CMB_PORTAL_9.SelectedIndex = 1;
                        }
                    }
                }
            }

            if (ID_PORTAL == 10)
            {
                DataTable dt_10 = portal.SWITCH_PANEL_GET_INFO_PORTAL(10);

                if (dt_10.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_10.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //IMAGEN
                        byte[] Imagen = new byte[0];
                        Imagen = (byte[])dr["IMAGEN_READER"];

                        if (Imagen != null)
                        {
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX10.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_10.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 
                            CMB_PORTAL_10.BackColor = Color.Green;
                            CMB_PORTAL_10.ForeColor = Color.White;
                            CMB_PORTAL_10.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 
                            CMB_PORTAL_10.BackColor = Color.Red;
                            CMB_PORTAL_10.ForeColor = Color.White;
                            CMB_PORTAL_10.SelectedIndex = 1;
                        }
                    }
                }
            }
            if (ID_PORTAL == 11)
            {
                DataTable dt_11 = portal.SWITCH_PANEL_GET_INFO_PORTAL(11);


                if (dt_11.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_11.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //IMAGEN
                        byte[] Imagen = new byte[0];
                        Imagen = (byte[])dr["IMAGEN_READER"];

                        if (Imagen != null)
                        {
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX11.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_11.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 
                            CMB_PORTAL_11.BackColor = Color.Green;
                            CMB_PORTAL_11.ForeColor = Color.White;
                            CMB_PORTAL_11.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 
                            CMB_PORTAL_11.BackColor = Color.Red;
                            CMB_PORTAL_11.ForeColor = Color.White;
                            CMB_PORTAL_11.SelectedIndex = 1;
                        }
                    }
                }
            }

            if (ID_PORTAL == 12)
            {
                DataTable dt_12 = portal.SWITCH_PANEL_GET_INFO_PORTAL(12);

                if (dt_12.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_12.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //IMAGEN
                        byte[] Imagen = new byte[0];
                        Imagen = (byte[])dr["IMAGEN_READER"];

                        if (Imagen != null)
                        {
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX12.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_12.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 
                            CMB_PORTAL_12.BackColor = Color.Green;
                            CMB_PORTAL_12.ForeColor = Color.White;
                            CMB_PORTAL_12.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 
                            CMB_PORTAL_12.BackColor = Color.Red;
                            CMB_PORTAL_12.ForeColor = Color.White;
                            CMB_PORTAL_12.SelectedIndex = 1;
                        }
                    }
                }
            }

            if (ID_PORTAL == 13)
            {
                DataTable dt_13 = portal.SWITCH_PANEL_GET_INFO_PORTAL(13);

                if (dt_13.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_13.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //IMAGEN
                        byte[] Imagen = new byte[0];
                        Imagen = (byte[])dr["IMAGEN_READER"];

                        if (Imagen != null)
                        {
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX13.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_13.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 
                            CMB_PORTAL_13.BackColor = Color.Green;
                            CMB_PORTAL_13.ForeColor = Color.White;
                            CMB_PORTAL_13.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 
                            CMB_PORTAL_13.BackColor = Color.Red;
                            CMB_PORTAL_13.ForeColor = Color.White;
                            CMB_PORTAL_13.SelectedIndex = 1;
                        }
                    }
                }
            }

            if (ID_PORTAL == 14)
            {
                DataTable dt_14 = portal.SWITCH_PANEL_GET_INFO_PORTAL(14);

                if (dt_14.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_14.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //IMAGEN
                        byte[] Imagen = new byte[0];
                        Imagen = (byte[])dr["IMAGEN_READER"];

                        if (Imagen != null)
                        {
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX14.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_14.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 
                            CMB_PORTAL_14.BackColor = Color.Green;
                            CMB_PORTAL_14.ForeColor = Color.White;
                            CMB_PORTAL_14.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 
                            CMB_PORTAL_14.BackColor = Color.Red;
                            CMB_PORTAL_14.ForeColor = Color.White;
                            CMB_PORTAL_14.SelectedIndex = 1;
                        }
                    }
                }
            }

            if (ID_PORTAL == 15)
            {
                DataTable dt_15 = portal.SWITCH_PANEL_GET_INFO_PORTAL(15);

                if (dt_15.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_15.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //IMAGEN
                        byte[] Imagen = new byte[0];
                        Imagen = (byte[])dr["IMAGEN_READER"];

                        if (Imagen != null)
                        {
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX15.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_15.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 
                            CMB_PORTAL_15.BackColor = Color.Green;
                            CMB_PORTAL_15.ForeColor = Color.White;
                            CMB_PORTAL_15.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 
                            CMB_PORTAL_15.BackColor = Color.Red;
                            CMB_PORTAL_15.ForeColor = Color.White;
                            CMB_PORTAL_15.SelectedIndex = 1;
                        }
                    }
                }
            }

            if (ID_PORTAL == 16)
            {
                DataTable dt_16 = portal.SWITCH_PANEL_GET_INFO_PORTAL(16);

                if (dt_16.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_16.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //IMAGEN
                        byte[] Imagen = new byte[0];
                        Imagen = (byte[])dr["IMAGEN_READER"];

                        if (Imagen != null)
                        {
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX16.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_16.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 
                            CMB_PORTAL_16.BackColor = Color.Green;
                            CMB_PORTAL_16.ForeColor = Color.White;
                            CMB_PORTAL_16.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 
                            CMB_PORTAL_16.BackColor = Color.Red;
                            CMB_PORTAL_16.ForeColor = Color.White;
                            CMB_PORTAL_16.SelectedIndex = 1;
                        }
                    }
                }
            }

            if (ID_PORTAL == 17)
            {
                DataTable dt_17 = portal.SWITCH_PANEL_GET_INFO_PORTAL(17);

                if (dt_17.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_17.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //IMAGEN
                        byte[] Imagen = new byte[0];
                        Imagen = (byte[])dr["IMAGEN_READER"];

                        if (Imagen != null)
                        {
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX17.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_17.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 
                            CMB_PORTAL_17.BackColor = Color.Green;
                            CMB_PORTAL_17.ForeColor = Color.White;
                            CMB_PORTAL_17.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 
                            CMB_PORTAL_17.BackColor = Color.Red;
                            CMB_PORTAL_17.ForeColor = Color.White;
                            CMB_PORTAL_17.SelectedIndex = 1;
                        }
                    }
                }
            }

            if (ID_PORTAL == 18)
            {
                DataTable dt_18 = portal.SWITCH_PANEL_GET_INFO_PORTAL(18);

                if (dt_18.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_18.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //IMAGEN
                        byte[] Imagen = new byte[0];
                        Imagen = (byte[])dr["IMAGEN_READER"];

                        if (Imagen != null)
                        {
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX18.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_18.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 
                            CMB_PORTAL_18.BackColor = Color.Green;
                            CMB_PORTAL_18.ForeColor = Color.White;
                            CMB_PORTAL_18.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 
                            CMB_PORTAL_18.BackColor = Color.Red;
                            CMB_PORTAL_18.ForeColor = Color.White;
                            CMB_PORTAL_18.SelectedIndex = 1;
                        }

                    }
                }
            }

            if (ID_PORTAL == 19)
            {
                DataTable dt_19 = portal.SWITCH_PANEL_GET_INFO_PORTAL(19);

                if (dt_19.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_19.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //IMAGEN
                        byte[] Imagen = new byte[0];
                        Imagen = (byte[])dr["IMAGEN_READER"];

                        if (Imagen != null)
                        {
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX19.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_19.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 
                            CMB_PORTAL_19.BackColor = Color.Green;
                            CMB_PORTAL_19.ForeColor = Color.White;
                            CMB_PORTAL_19.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 
                            CMB_PORTAL_19.BackColor = Color.Red;
                            CMB_PORTAL_19.ForeColor = Color.White;
                            CMB_PORTAL_19.SelectedIndex = 1;
                        }
                    }
                }
            }

            if (ID_PORTAL == 20)
            {
                DataTable dt_20 = portal.SWITCH_PANEL_GET_INFO_PORTAL(20);

                if (dt_20.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_20.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //IMAGEN
                        byte[] Imagen = new byte[0];
                        Imagen = (byte[])dr["IMAGEN_READER"];

                        if (Imagen != null)
                        {
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX20.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_20.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 
                            CMB_PORTAL_20.BackColor = Color.Green;
                            CMB_PORTAL_20.ForeColor = Color.White;
                            CMB_PORTAL_20.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 
                            CMB_PORTAL_20.BackColor = Color.Red;
                            CMB_PORTAL_20.ForeColor = Color.White;
                            CMB_PORTAL_20.SelectedIndex = 1;
                        }
                    }
                }
            }

        }

        private void configuracionBDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FORMS.SEGURIDAD.CONFIG_DATA_BASE FRM = new FORMS.SEGURIDAD.CONFIG_DATA_BASE();
            FRM.ShowDialog();
        }


        #endregion


        ////////////////////////////////////////////////////////////////////////
        //                          VISTA DE FORMS                            //
        ////////////////////////////////////////////////////////////////////////

        #region VISTA DE FORMS




        #endregion


        ////////////////////////////////////////////////////////////////////////
        //                          CAMBIAR ESTADO PORTAL                     //
        ////////////////////////////////////////////////////////////////////////

        #region CAMBIAR ESTADO PORTAL     ON/OFF

        /// <summary>
        /// ESTE METODO MODIFICA LA APARIENCIA DEL COMBO SEGUN EL CUAL FUE SELECCIONADO POR EL USUARIO
        /// PASANDO A VERDE CUANDO ESTA EN ESATDO: ON
        /// Y ROJO CUANDO ES ESTADO: OFF
        /// </summary>
        /// <param name="ID_PORTAL"></param>
        private void CAMBIAR_ESTADO_PORTAL(int ID_PORTAL, bool ESTADO_PORTAL)
        {
            try
            {
                switch (ID_PORTAL)
                {
                    case 1:

                        #region PORTAL 1



                        //SI ESTADO ES ON, PROCESO LA INSTRUCCION
                        if (ESTADO_PORTAL == true && Estado_Test_1 == false)
                        {
                            //ESTILO 


                            BTN_PORTAL_LUZ_ROJA_1.BackColor = Color.Green;


                            /////////////////////////////////////////////////////////
                            //              MOSTRAR BARRA DE PROGRESO              //
                            /////////////////////////////////////////////////////////
                            PrgBar_1.BackColor = Color.Green;
                            PrgBar_1.Visible = true;
                            PrgBar_1.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_1.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_1.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_1.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_1.SelectedIndex = 0;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_1.Visible = false;
                        }
                        else if (ESTADO_PORTAL == false && Estado_Test_1 == false)
                        {
                            //ENCENDER PORTAL

                            //ESTILO 
                            BTN_PORTAL_LUZ_ROJA_1.BackColor = Color.DarkRed;


                            //MOSTRAR BARRA DE PROGRESO
                            PrgBar_1.BackColor = Color.Green;
                            PrgBar_1.Visible = true;
                            PrgBar_1.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_1.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_1.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_1.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_1.SelectedIndex = 1;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_1.Visible = false;

                        }
                        break;

                    #endregion

                    case 2:
                        #region PORTAL 2



                        //SI ESTADO ES ON, PROCESO LA INSTRUCCION
                        if (ESTADO_PORTAL == true && Estado_Test_2 == false)
                        {
                            //ESTILO 


                            BTN_PORTAL_LUZ_ROJA_2.BackColor = Color.Green;


                            /////////////////////////////////////////////////////////
                            //              MOSTRAR BARRA DE PROGRESO              //
                            /////////////////////////////////////////////////////////
                            PrgBar_2.BackColor = Color.Green;
                            PrgBar_2.Visible = true;
                            PrgBar_2.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_2.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_2.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_2.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_2.SelectedIndex = 0;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_2.Visible = false;
                        }
                        else if (ESTADO_PORTAL == false && Estado_Test_2 == false)
                        {
                            //ENCENDER PORTAL

                            //ESTILO 
                            BTN_PORTAL_LUZ_ROJA_2.BackColor = Color.DarkRed;


                            //MOSTRAR BARRA DE PROGRESO
                            PrgBar_2.BackColor = Color.Green;
                            PrgBar_2.Visible = true;
                            PrgBar_2.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_2.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_2.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_2.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_2.SelectedIndex = 1;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_2.Visible = false;

                        }
                        break;

                    #endregion

                    case 3:
                        #region PORTAL 3



                        //SI ESTADO ES ON, PROCESO LA INSTRUCCION
                        if (ESTADO_PORTAL == true && Estado_Test_3 == false)
                        {
                            //ESTILO 


                            BTN_PORTAL_LUZ_ROJA_3.BackColor = Color.Green;


                            /////////////////////////////////////////////////////////
                            //              MOSTRAR BARRA DE PROGRESO              //
                            /////////////////////////////////////////////////////////
                            PrgBar_3.BackColor = Color.Green;
                            PrgBar_3.Visible = true;
                            PrgBar_3.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_3.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_3.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_3.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_3.SelectedIndex = 0;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_3.Visible = false;
                        }
                        else if (ESTADO_PORTAL == false && Estado_Test_3 == false)
                        {
                            //ENCENDER PORTAL

                            //ESTILO 
                            BTN_PORTAL_LUZ_ROJA_3.BackColor = Color.DarkRed;


                            //MOSTRAR BARRA DE PROGRESO
                            PrgBar_3.BackColor = Color.Green;
                            PrgBar_3.Visible = true;
                            PrgBar_3.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_3.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_3.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_3.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_3.SelectedIndex = 1;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_3.Visible = false;

                        }
                        break;

                    #endregion

                    case 4:
                        #region PORTAL 4



                        //SI ESTADO ES ON, PROCESO LA INSTRUCCION
                        if (ESTADO_PORTAL == true && Estado_Test_4 == false)
                        {
                            //ESTILO 


                            BTN_PORTAL_LUZ_ROJA_4.BackColor = Color.Green;


                            /////////////////////////////////////////////////////////
                            //              MOSTRAR BARRA DE PROGRESO              //
                            /////////////////////////////////////////////////////////
                            PrgBar_4.BackColor = Color.Green;
                            PrgBar_4.Visible = true;
                            PrgBar_4.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_4.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_4.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_4.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_4.SelectedIndex = 0;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_4.Visible = false;
                        }
                        else if (ESTADO_PORTAL == false && Estado_Test_4 == false)
                        {
                            //ENCENDER PORTAL

                            //ESTILO 
                            BTN_PORTAL_LUZ_ROJA_4.BackColor = Color.DarkRed;


                            //MOSTRAR BARRA DE PROGRESO
                            PrgBar_4.BackColor = Color.Green;
                            PrgBar_4.Visible = true;
                            PrgBar_4.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_4.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_4.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_4.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_4.SelectedIndex = 1;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_4.Visible = false;

                        }
                        break;

                    #endregion

                    case 5:
                        #region PORTAL 5



                        //SI ESTADO ES ON, PROCESO LA INSTRUCCION
                        if (ESTADO_PORTAL == true && Estado_Test_5 == false)
                        {
                            //ESTILO 


                            BTN_PORTAL_LUZ_ROJA_5.BackColor = Color.Green;


                            /////////////////////////////////////////////////////////
                            //              MOSTRAR BARRA DE PROGRESO              //
                            /////////////////////////////////////////////////////////
                            PrgBar_5.BackColor = Color.Green;
                            PrgBar_5.Visible = true;
                            PrgBar_5.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_5.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_5.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_5.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_5.SelectedIndex = 0;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_5.Visible = false;
                        }
                        else if (ESTADO_PORTAL == false && Estado_Test_5 == false)
                        {
                            //ENCENDER PORTAL

                            //ESTILO 
                            BTN_PORTAL_LUZ_ROJA_5.BackColor = Color.DarkRed;


                            //MOSTRAR BARRA DE PROGRESO
                            PrgBar_5.BackColor = Color.Green;
                            PrgBar_5.Visible = true;
                            PrgBar_5.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_5.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_5.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_5.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_5.SelectedIndex = 1;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_5.Visible = false;

                        }
                        break;

                    #endregion


                    case 6:
                        #region PORTAL 6



                        //SI ESTADO ES ON, PROCESO LA INSTRUCCION
                        if (ESTADO_PORTAL == true && Estado_Test_6 == false)
                        {
                            //ESTILO 


                            BTN_PORTAL_LUZ_ROJA_6.BackColor = Color.Green;


                            /////////////////////////////////////////////////////////
                            //              MOSTRAR BARRA DE PROGRESO              //
                            /////////////////////////////////////////////////////////
                            PrgBar_6.BackColor = Color.Green;
                            PrgBar_6.Visible = true;
                            PrgBar_6.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_6.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_6.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_6.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_6.SelectedIndex = 0;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_6.Visible = false;
                        }
                        else if (ESTADO_PORTAL == false && Estado_Test_6 == false)
                        {
                            //ENCENDER PORTAL

                            //ESTILO 
                            BTN_PORTAL_LUZ_ROJA_6.BackColor = Color.DarkRed;


                            //MOSTRAR BARRA DE PROGRESO
                            PrgBar_6.BackColor = Color.Green;
                            PrgBar_6.Visible = true;
                            PrgBar_6.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_6.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_6.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_6.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_6.SelectedIndex = 1;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_6.Visible = false;

                        }
                        break;

                    #endregion

                    case 7:
                        #region PORTAL 7



                        //SI ESTADO ES ON, PROCESO LA INSTRUCCION
                        if (ESTADO_PORTAL == true && Estado_Test_7 == false)
                        {
                            //ESTILO 


                            BTN_PORTAL_LUZ_ROJA_7.BackColor = Color.Green;


                            /////////////////////////////////////////////////////////
                            //              MOSTRAR BARRA DE PROGRESO              //
                            /////////////////////////////////////////////////////////
                            PrgBar_7.BackColor = Color.Green;
                            PrgBar_7.Visible = true;
                            PrgBar_7.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_7.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_7.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_7.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_7.SelectedIndex = 0;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_7.Visible = false;
                        }
                        else if (ESTADO_PORTAL == false && Estado_Test_7 == false)
                        {
                            //ENCENDER PORTAL

                            //ESTILO 
                            BTN_PORTAL_LUZ_ROJA_7.BackColor = Color.DarkRed;


                            //MOSTRAR BARRA DE PROGRESO
                            PrgBar_7.BackColor = Color.Green;
                            PrgBar_7.Visible = true;
                            PrgBar_7.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_7.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_7.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_7.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_7.SelectedIndex = 1;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_7.Visible = false;

                        }
                        break;

                    #endregion

                    case 8:
                        #region PORTAL 8



                        //SI ESTADO ES ON, PROCESO LA INSTRUCCION
                        if (ESTADO_PORTAL == true && Estado_Test_8 == false)
                        {
                            //ESTILO 


                            BTN_PORTAL_LUZ_ROJA_8.BackColor = Color.Green;


                            /////////////////////////////////////////////////////////
                            //              MOSTRAR BARRA DE PROGRESO              //
                            /////////////////////////////////////////////////////////
                            PrgBar_8.BackColor = Color.Green;
                            PrgBar_8.Visible = true;
                            PrgBar_8.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_8.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_8.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_8.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_8.SelectedIndex = 0;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_8.Visible = false;
                        }
                        else if (ESTADO_PORTAL == false && Estado_Test_8 == false)
                        {
                            //ENCENDER PORTAL

                            //ESTILO 
                            BTN_PORTAL_LUZ_ROJA_8.BackColor = Color.DarkRed;


                            //MOSTRAR BARRA DE PROGRESO
                            PrgBar_8.BackColor = Color.Green;
                            PrgBar_8.Visible = true;
                            PrgBar_8.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_8.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_8.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_5.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_8.SelectedIndex = 1;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_8.Visible = false;

                        }
                        break;

                    #endregion

                    case 9:
                        #region PORTAL 9



                        //SI ESTADO ES ON, PROCESO LA INSTRUCCION
                        if (ESTADO_PORTAL == true && Estado_Test_9 == false)
                        {
                            //ESTILO 


                            BTN_PORTAL_LUZ_ROJA_9.BackColor = Color.Green;


                            /////////////////////////////////////////////////////////
                            //              MOSTRAR BARRA DE PROGRESO              //
                            /////////////////////////////////////////////////////////
                            PrgBar_9.BackColor = Color.Green;
                            PrgBar_9.Visible = true;
                            PrgBar_9.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_9.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_9.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_9.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_9.SelectedIndex = 0;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_9.Visible = false;
                        }
                        else if (ESTADO_PORTAL == false && Estado_Test_9 == false)
                        {
                            //ENCENDER PORTAL

                            //ESTILO 
                            BTN_PORTAL_LUZ_ROJA_9.BackColor = Color.DarkRed;


                            //MOSTRAR BARRA DE PROGRESO
                            PrgBar_9.BackColor = Color.Green;
                            PrgBar_9.Visible = true;
                            PrgBar_9.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_9.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_9.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_9.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_9.SelectedIndex = 1;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_9.Visible = false;

                        }
                        break;

                    #endregion

                    case 10:
                        #region PORTAL 10



                        //SI ESTADO ES ON, PROCESO LA INSTRUCCION
                        if (ESTADO_PORTAL == true && Estado_Test_10 == false)
                        {
                            //ESTILO 


                            BTN_PORTAL_LUZ_ROJA_10.BackColor = Color.Green;


                            /////////////////////////////////////////////////////////
                            //              MOSTRAR BARRA DE PROGRESO              //
                            /////////////////////////////////////////////////////////
                            PrgBar_10.BackColor = Color.Green;
                            PrgBar_10.Visible = true;
                            PrgBar_10.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_10.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_10.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_10.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_10.SelectedIndex = 0;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_10.Visible = false;
                        }
                        else if (ESTADO_PORTAL == false && Estado_Test_10 == false)
                        {
                            //ENCENDER PORTAL

                            //ESTILO 
                            BTN_PORTAL_LUZ_ROJA_10.BackColor = Color.DarkRed;


                            //MOSTRAR BARRA DE PROGRESO
                            PrgBar_10.BackColor = Color.Green;
                            PrgBar_10.Visible = true;
                            PrgBar_10.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_10.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_10.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_10.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_10.SelectedIndex = 1;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_10.Visible = false;

                        }
                        break;

                    #endregion

                    case 11:

                        #region PORTAL 11



                        //SI ESTADO ES ON, PROCESO LA INSTRUCCION
                        if (ESTADO_PORTAL == true && Estado_Test_11 == false)
                        {
                            //ESTILO 


                            BTN_PORTAL_LUZ_ROJA_11.BackColor = Color.Green;


                            /////////////////////////////////////////////////////////
                            //              MOSTRAR BARRA DE PROGRESO              //
                            /////////////////////////////////////////////////////////
                            PrgBar_11.BackColor = Color.Green;
                            PrgBar_11.Visible = true;
                            PrgBar_11.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_11.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_11.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_11.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_11.SelectedIndex = 0;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_11.Visible = false;
                        }
                        else if (ESTADO_PORTAL == false && Estado_Test_11 == false)
                        {
                            //ENCENDER PORTAL

                            //ESTILO 
                            BTN_PORTAL_LUZ_ROJA_11.BackColor = Color.DarkRed;


                            //MOSTRAR BARRA DE PROGRESO
                            PrgBar_11.BackColor = Color.Green;
                            PrgBar_11.Visible = true;
                            PrgBar_11.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_11.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_11.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_11.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_11.SelectedIndex = 1;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_11.Visible = false;

                        }
                        break;

                    #endregion

                    case 12:

                        #region PORTAL 12



                        //SI ESTADO ES ON, PROCESO LA INSTRUCCION
                        if (ESTADO_PORTAL == true && Estado_Test_12 == false)
                        {
                            //ESTILO 


                            BTN_PORTAL_LUZ_ROJA_12.BackColor = Color.Green;


                            /////////////////////////////////////////////////////////
                            //              MOSTRAR BARRA DE PROGRESO              //
                            /////////////////////////////////////////////////////////
                            PrgBar_12.BackColor = Color.Green;
                            PrgBar_12.Visible = true;
                            PrgBar_12.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_12.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_12.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_12.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_12.SelectedIndex = 0;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_12.Visible = false;
                        }
                        else if (ESTADO_PORTAL == false && Estado_Test_12 == false)
                        {
                            //ENCENDER PORTAL

                            //ESTILO 
                            BTN_PORTAL_LUZ_ROJA_12.BackColor = Color.DarkRed;


                            //MOSTRAR BARRA DE PROGRESO
                            PrgBar_12.BackColor = Color.Green;
                            PrgBar_12.Visible = true;
                            PrgBar_12.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_12.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_12.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_12.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_12.SelectedIndex = 1;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_12.Visible = false;

                        }
                        break;

                    #endregion

                    case 13:

                        #region PORTAL 13



                        //SI ESTADO ES ON, PROCESO LA INSTRUCCION
                        if (ESTADO_PORTAL == true && Estado_Test_13 == false)
                        {
                            //ESTILO 


                            BTN_PORTAL_LUZ_ROJA_13.BackColor = Color.Green;


                            /////////////////////////////////////////////////////////
                            //              MOSTRAR BARRA DE PROGRESO              //
                            /////////////////////////////////////////////////////////
                            PrgBar_13.BackColor = Color.Green;
                            PrgBar_13.Visible = true;
                            PrgBar_13.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_13.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_13.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_13.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_13.SelectedIndex = 0;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_13.Visible = false;
                        }
                        else if (ESTADO_PORTAL == false && Estado_Test_13 == false)
                        {
                            //ENCENDER PORTAL

                            //ESTILO 
                            BTN_PORTAL_LUZ_ROJA_13.BackColor = Color.DarkRed;


                            //MOSTRAR BARRA DE PROGRESO
                            PrgBar_13.BackColor = Color.Green;
                            PrgBar_13.Visible = true;
                            PrgBar_13.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_13.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_13.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_13.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_13.SelectedIndex = 1;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_13.Visible = false;

                        }
                        break;

                    #endregion

                    case 14:

                        #region PORTAL 14



                        //SI ESTADO ES ON, PROCESO LA INSTRUCCION
                        if (ESTADO_PORTAL == true && Estado_Test_14 == false)
                        {
                            //ESTILO 


                            BTN_PORTAL_LUZ_ROJA_14.BackColor = Color.Green;


                            /////////////////////////////////////////////////////////
                            //              MOSTRAR BARRA DE PROGRESO              //
                            /////////////////////////////////////////////////////////
                            PrgBar_14.BackColor = Color.Green;
                            PrgBar_14.Visible = true;
                            PrgBar_14.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_14.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_14.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_14.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_14.SelectedIndex = 0;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_14.Visible = false;
                        }
                        else if (ESTADO_PORTAL == false && Estado_Test_14 == false)
                        {
                            //ENCENDER PORTAL

                            //ESTILO 
                            BTN_PORTAL_LUZ_ROJA_14.BackColor = Color.DarkRed;


                            //MOSTRAR BARRA DE PROGRESO
                            PrgBar_14.BackColor = Color.Green;
                            PrgBar_14.Visible = true;
                            PrgBar_14.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_14.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_14.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_14.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_14.SelectedIndex = 1;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_14.Visible = false;

                        }
                        break;

                    #endregion

                    case 15:

                        #region PORTAL 15



                        //SI ESTADO ES ON, PROCESO LA INSTRUCCION
                        if (ESTADO_PORTAL == true && Estado_Test_15 == false)
                        {
                            //ESTILO 


                            BTN_PORTAL_LUZ_ROJA_15.BackColor = Color.Green;


                            /////////////////////////////////////////////////////////
                            //              MOSTRAR BARRA DE PROGRESO              //
                            /////////////////////////////////////////////////////////
                            PrgBar_15.BackColor = Color.Green;
                            PrgBar_15.Visible = true;
                            PrgBar_15.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_15.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_15.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_15.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_15.SelectedIndex = 0;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_15.Visible = false;
                        }
                        else if (ESTADO_PORTAL == false && Estado_Test_15 == false)
                        {
                            //ENCENDER PORTAL

                            //ESTILO 
                            BTN_PORTAL_LUZ_ROJA_15.BackColor = Color.DarkRed;


                            //MOSTRAR BARRA DE PROGRESO
                            PrgBar_15.BackColor = Color.Green;
                            PrgBar_15.Visible = true;
                            PrgBar_15.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_15.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_15.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_15.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_15.SelectedIndex = 1;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_15.Visible = false;

                        }
                        break;

                    #endregion

                    case 16:

                        #region PORTAL 16



                        //SI ESTADO ES ON, PROCESO LA INSTRUCCION
                        if (ESTADO_PORTAL == true && Estado_Test_16 == false)
                        {
                            //ESTILO 


                            BTN_PORTAL_LUZ_ROJA_16.BackColor = Color.Green;


                            /////////////////////////////////////////////////////////
                            //              MOSTRAR BARRA DE PROGRESO              //
                            /////////////////////////////////////////////////////////
                            PrgBar_16.BackColor = Color.Green;
                            PrgBar_16.Visible = true;
                            PrgBar_16.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_16.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_16.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_16.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_16.SelectedIndex = 0;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_16.Visible = false;
                        }
                        else if (ESTADO_PORTAL == false && Estado_Test_16 == false)
                        {
                            //ENCENDER PORTAL

                            //ESTILO 
                            BTN_PORTAL_LUZ_ROJA_16.BackColor = Color.DarkRed;


                            //MOSTRAR BARRA DE PROGRESO
                            PrgBar_16.BackColor = Color.Green;
                            PrgBar_16.Visible = true;
                            PrgBar_16.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_16.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_16.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_16.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_16.SelectedIndex = 1;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_16.Visible = false;

                        }
                        break;

                    #endregion


                    case 17:

                        #region PORTAL 17



                        //SI ESTADO ES ON, PROCESO LA INSTRUCCION
                        if (ESTADO_PORTAL == true && Estado_Test_17 == false)
                        {
                            //ESTILO 


                            BTN_PORTAL_LUZ_ROJA_17.BackColor = Color.Green;


                            /////////////////////////////////////////////////////////
                            //              MOSTRAR BARRA DE PROGRESO              //
                            /////////////////////////////////////////////////////////
                            PrgBar_17.BackColor = Color.Green;
                            PrgBar_17.Visible = true;
                            PrgBar_17.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_17.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_17.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_17.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_17.SelectedIndex = 0;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_17.Visible = false;
                        }
                        else if (ESTADO_PORTAL == false && Estado_Test_17 == false)
                        {
                            //ENCENDER PORTAL

                            //ESTILO 
                            BTN_PORTAL_LUZ_ROJA_17.BackColor = Color.DarkRed;


                            //MOSTRAR BARRA DE PROGRESO
                            PrgBar_17.BackColor = Color.Green;
                            PrgBar_17.Visible = true;
                            PrgBar_17.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_17.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_17.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_17.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_17.SelectedIndex = 1;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_17.Visible = false;

                        }
                        break;

                    #endregion

                    case 18:

                        #region PORTAL 18



                        //SI ESTADO ES ON, PROCESO LA INSTRUCCION
                        if (ESTADO_PORTAL == true && Estado_Test_18 == false)
                        {
                            //ESTILO 


                            BTN_PORTAL_LUZ_ROJA_18.BackColor = Color.Green;


                            /////////////////////////////////////////////////////////
                            //              MOSTRAR BARRA DE PROGRESO              //
                            /////////////////////////////////////////////////////////
                            PrgBar_18.BackColor = Color.Green;
                            PrgBar_18.Visible = true;
                            PrgBar_18.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_18.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_18.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_18.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_18.SelectedIndex = 0;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_18.Visible = false;
                        }
                        else if (ESTADO_PORTAL == false && Estado_Test_18 == false)
                        {
                            //ENCENDER PORTAL

                            //ESTILO 
                            BTN_PORTAL_LUZ_ROJA_18.BackColor = Color.DarkRed;


                            //MOSTRAR BARRA DE PROGRESO
                            PrgBar_18.BackColor = Color.Green;
                            PrgBar_18.Visible = true;
                            PrgBar_18.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_18.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_18.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_18.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_18.SelectedIndex = 1;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_18.Visible = false;

                        }
                        break;

                    #endregion

                    case 19:

                        #region PORTAL 19



                        //SI ESTADO ES ON, PROCESO LA INSTRUCCION
                        if (ESTADO_PORTAL == true && Estado_Test_19 == false)
                        {
                            //ESTILO 


                            BTN_PORTAL_LUZ_ROJA_19.BackColor = Color.Green;


                            /////////////////////////////////////////////////////////
                            //              MOSTRAR BARRA DE PROGRESO              //
                            /////////////////////////////////////////////////////////
                            PrgBar_19.BackColor = Color.Green;
                            PrgBar_19.Visible = true;
                            PrgBar_19.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_19.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_19.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_19.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_19.SelectedIndex = 0;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_19.Visible = false;
                        }
                        else if (ESTADO_PORTAL == false && Estado_Test_19 == false)
                        {
                            //ENCENDER PORTAL

                            //ESTILO 
                            BTN_PORTAL_LUZ_ROJA_19.BackColor = Color.DarkRed;


                            //MOSTRAR BARRA DE PROGRESO
                            PrgBar_19.BackColor = Color.Green;
                            PrgBar_19.Visible = true;
                            PrgBar_19.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_19.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_19.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_19.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_19.SelectedIndex = 1;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_19.Visible = false;

                        }
                        break;

                    #endregion

                    case 20:

                        #region PORTAL 20



                        //SI ESTADO ES ON, PROCESO LA INSTRUCCION
                        if (ESTADO_PORTAL == true && Estado_Test_20 == false)
                        {
                            //ESTILO 


                            BTN_PORTAL_LUZ_ROJA_20.BackColor = Color.Green;


                            /////////////////////////////////////////////////////////
                            //              MOSTRAR BARRA DE PROGRESO              //
                            /////////////////////////////////////////////////////////
                            PrgBar_20.BackColor = Color.Green;
                            PrgBar_20.Visible = true;
                            PrgBar_20.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_20.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_20.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_20.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_20.SelectedIndex = 0;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_20.Visible = false;
                        }
                        else if (ESTADO_PORTAL == false && Estado_Test_20 == false)
                        {
                            //ENCENDER PORTAL

                            //ESTILO 
                            BTN_PORTAL_LUZ_ROJA_20.BackColor = Color.DarkRed;


                            //MOSTRAR BARRA DE PROGRESO
                            PrgBar_20.BackColor = Color.Green;
                            PrgBar_20.Visible = true;
                            PrgBar_20.Value = 20;
                            Thread.Sleep(500);
                            PrgBar_20.Value = 50;
                            Thread.Sleep(100);
                            PrgBar_20.Value = 90;
                            Thread.Sleep(500);
                            PrgBar_20.Value = 100;
                            Thread.Sleep(500);
                            CMB_PORTAL_20.SelectedIndex = 1;

                            //OCULTAMOS LA BARRA DE PROGRESO
                            PrgBar_20.Visible = false;

                        }
                        break;

                        #endregion
                }
            }
            catch (Exception)
            {

            }
        }


        #endregion






        ////////////////////////////////////////////////////////////////////////
        //                           ANTENNAS                                 //
        ////////////////////////////////////////////////////////////////////////
        #region ANTENNAS

        private Symbol.RFID3.AntennaInfo m_AntennaList = null;
        private ArrayList m_CheckBox = null;
        private bool m_IsLoaded = false;

        /// <summary>
        /// ANTENNA GET INFO
        /// </summary>
        /// <returns></returns>
        public Symbol.RFID3.AntennaInfo getInfo()
        {
            return m_AntennaList;
        }


        private void AntennaInfo_Load()
        {
            try
            {
                if (RFID_READER_1.IsConnected)
                {
                    int xIndex = 0;
                    int yIndex = 32;
                    int numAtenna = RFID_READER_1.Config.Antennas.AvailableAntennas.Length;

                    RFID_READER_1.Config.Antennas[2].GetConfig();


                    string status = RFID_READER_1.Config.Antennas[2].GetConfig().TransmitPowerIndex.ToString();

                    //RFID_READER_1.Config.RadioPowerState.ToString();



                    RFID_READER_1.Config.GPI.Length.ToString();
                }
            }
            catch (Exception ex)
            {
                //RFID_READER_1.functionCallStatusLabel.Text = ex.Message;
            }
        }

        #endregion







        ////////////////////////////////////////////////////////////////////////
        //                                 TIMERS                             //
        ////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// CARGAR CONFIGURACION DEL SWITCH PANEL
        /// </summary>
        private void CARGAR_CONFIGURACION()
        {
            try
            {
                FUNCIONES.ARCHIVOS File = new FUNCIONES.ARCHIVOS();
                int TIMER_SINCRONIZACION = 0;
                int TIMER_COMPROBACION_PORTAL = 0;

                //LEER FILE CONFIG
                DataTable DT = File.LEER_ARCHIVO();

                if (DT.Rows.Count > 0)
                {
                    DataRow dr = DT.Rows[0];

                    string VALOR_1 = dr["TM_SINCRONIZAR"].ToString();
                    string VALOR_2 = dr["TM_COMPROBACION_READER"].ToString();
                    string VALOR_3 = dr["STATUS_SINCRNIZADOR"].ToString();

                    //VALIDAR SI HAY DATOS DE CONFIGURACION

                    //TIMER SINCRONIZACION
                    if (VALOR_1 != "")
                    {
                        TIMER_SINCRONIZACION = Convert.ToInt32(VALOR_1);
                        TM_SINCRONIZAR_DATA_BASE.Interval = Convert.ToInt32(TimeSpan.FromMinutes(TIMER_SINCRONIZACION).TotalMilliseconds);
                    }

                    if (VALOR_2 != "")
                    {
                        TIMER_COMPROBACION_PORTAL = Convert.ToInt32(VALOR_2);
                        TM_REINICIO_PORTAL.Interval = Convert.ToInt32(TimeSpan.FromMinutes(TIMER_COMPROBACION_PORTAL).TotalMilliseconds);
                    }

                    if (VALOR_3 == "True")
                    {
                        TM_SINCRONIZAR_DATA_BASE.Enabled = true;
                    }
                    else
                    {
                        TM_SINCRONIZAR_DATA_BASE.Enabled = false;
                    }


                    TM_SINCRONIZAR_DATOS_PORTAL.Enabled = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        #region TIMERS


        /// <summary>
        /// SINCRONIZA LA INFORMACION DE LOS PORTALES
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Sincronizar_Tick(object sender, EventArgs e)
        {
            try
            {
                ///////////////////////////////////////////////////////////////////////////
                DATA_BASE.CONSULTAS portal = new DATA_BASE.CONSULTAS();

                //CONSULTAS
                DataTable dt_1 = portal.SWITCH_PANEL_GET_INFO_PORTAL(1);
                DataTable dt_2 = portal.SWITCH_PANEL_GET_INFO_PORTAL(2);
                DataTable dt_3 = portal.SWITCH_PANEL_GET_INFO_PORTAL(3);
                DataTable dt_4 = portal.SWITCH_PANEL_GET_INFO_PORTAL(4);
                DataTable dt_5 = portal.SWITCH_PANEL_GET_INFO_PORTAL(5);
                DataTable dt_6 = portal.SWITCH_PANEL_GET_INFO_PORTAL(6);
                DataTable dt_7 = portal.SWITCH_PANEL_GET_INFO_PORTAL(7);
                DataTable dt_8 = portal.SWITCH_PANEL_GET_INFO_PORTAL(8);
                DataTable dt_9 = portal.SWITCH_PANEL_GET_INFO_PORTAL(9);
                DataTable dt_10 = portal.SWITCH_PANEL_GET_INFO_PORTAL(10);
                DataTable dt_11 = portal.SWITCH_PANEL_GET_INFO_PORTAL(11);
                DataTable dt_12 = portal.SWITCH_PANEL_GET_INFO_PORTAL(12);
                DataTable dt_13 = portal.SWITCH_PANEL_GET_INFO_PORTAL(13);
                DataTable dt_14 = portal.SWITCH_PANEL_GET_INFO_PORTAL(14);
                DataTable dt_15 = portal.SWITCH_PANEL_GET_INFO_PORTAL(15);
                DataTable dt_16 = portal.SWITCH_PANEL_GET_INFO_PORTAL(16);
                DataTable dt_17 = portal.SWITCH_PANEL_GET_INFO_PORTAL(17);
                DataTable dt_18 = portal.SWITCH_PANEL_GET_INFO_PORTAL(18);
                DataTable dt_19 = portal.SWITCH_PANEL_GET_INFO_PORTAL(19);
                DataTable dt_20 = portal.SWITCH_PANEL_GET_INFO_PORTAL(20);

                //MOSTRAR INFORMACION DE CADA PORTAL EN EL SWITCH PANEL


                #region PORTAL 1


                if (dt_1.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_1.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {

                        //NOMBRE PORTAL
                        LBL_PORTAL_1.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            CMB_PORTAL_1.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 
                            CMB_PORTAL_1.SelectedIndex = 1;
                        }


                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_1.Visible = true;
                    }
                    else
                    {
                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_1.Visible = false;
                    }
                }

                #endregion

                #region PORTAL 2


                if (dt_2.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_2.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //NOMBRE PORTAL
                        LBL_PORTAL_2.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 
                            CMB_PORTAL_2.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 
                            CMB_PORTAL_2.SelectedIndex = 1;
                        }


                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_2.Visible = true;
                    }
                    else
                    {
                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_2.Visible = false;
                    }
                }

                #endregion

                #region PORTAL 3

                if (dt_3.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_3.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {

                        //NOMBRE PORTAL
                        LBL_PORTAL_3.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 
                            CMB_PORTAL_3.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 
                            CMB_PORTAL_3.SelectedIndex = 1;
                        }


                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_3.Visible = true;
                    }
                    else
                    {//OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_3.Visible = false;
                    }
                }


                #endregion

                #region PORTAL 4


                if (dt_4.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_4.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {

                        //NOMBRE PORTAL
                        LBL_PORTAL_4.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 
                            CMB_PORTAL_4.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 
                            CMB_PORTAL_4.SelectedIndex = 1;
                        }


                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_4.Visible = true;
                    }
                    else
                    {
                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_4.Visible = false;
                    }
                }

                #endregion

                #region PORTAL 5


                if (dt_5.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_5.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {


                        //NOMBRE PORTAL
                        LBL_PORTAL_5.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 
                            CMB_PORTAL_5.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 
                            CMB_PORTAL_5.SelectedIndex = 1;
                        }


                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_5.Visible = true;
                    }
                    else
                    {
                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_5.Visible = false;
                    }
                }

                #endregion

                #region PORTAL 6

                if (dt_6.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_6.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //NOMBRE PORTAL
                        LBL_PORTAL_6.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 

                            CMB_PORTAL_6.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 

                            CMB_PORTAL_6.SelectedIndex = 1;
                        }


                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_6.Visible = true;
                    }
                    else
                    {
                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_6.Visible = false;
                    }
                }

                #endregion

                #region PORTAL 7

                if (dt_7.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_7.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //NOMBRE PORTAL
                        LBL_PORTAL_7.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 

                            CMB_PORTAL_7.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 

                            CMB_PORTAL_7.SelectedIndex = 1;
                        }


                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_7.Visible = true;
                    }
                    else
                    {
                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_7.Visible = false;
                    }
                }

                #endregion

                #region PORTAL 8


                if (dt_8.Rows.Count > 0)
                {

                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_8.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //NOMBRE PORTAL
                        LBL_PORTAL_8.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 

                            CMB_PORTAL_8.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 

                            CMB_PORTAL_8.SelectedIndex = 1;
                        }


                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_8.Visible = true;
                    }
                    else
                    {
                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_8.Visible = false;
                    }
                }

                #endregion

                #region PORTAL 9

                if (dt_9.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_9.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //NOMBRE PORTAL
                        LBL_PORTAL_9.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 

                            CMB_PORTAL_9.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 

                            CMB_PORTAL_9.SelectedIndex = 1;
                        }


                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_9.Visible = true;
                    }
                    else
                    {
                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_9.Visible = false;
                    }
                }

                #endregion

                #region PORTAL 10

                if (dt_10.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_10.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //NOMBRE PORTAL
                        LBL_PORTAL_10.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 

                            CMB_PORTAL_10.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 

                            CMB_PORTAL_10.SelectedIndex = 1;
                        }


                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_10.Visible = true;
                    }
                    else
                    {
                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_10.Visible = false;
                    }
                }

                #endregion

                #region PORTAL 11

                if (dt_11.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_11.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //NOMBRE PORTAL
                        LBL_PORTAL_11.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 

                            CMB_PORTAL_11.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 

                            CMB_PORTAL_11.SelectedIndex = 1;
                        }


                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_11.Visible = true;
                    }
                    else
                    {
                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_11.Visible = false;
                    }
                }

                #endregion

                #region PORTAL 12

                if (dt_12.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_12.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //NOMBRE PORTAL
                        LBL_PORTAL_12.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 

                            CMB_PORTAL_12.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 

                            CMB_PORTAL_12.SelectedIndex = 1;
                        }


                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_12.Visible = true;
                    }
                    else
                    {
                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_12.Visible = false;
                    }
                }

                #endregion

                #region PORTAL 13

                if (dt_13.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_13.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //NOMBRE PORTAL
                        LBL_PORTAL_13.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 

                            CMB_PORTAL_13.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 

                            CMB_PORTAL_13.SelectedIndex = 1;
                        }


                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_13.Visible = true;
                    }
                    else
                    {
                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_13.Visible = false; ;
                    }
                }

                #endregion

                #region PORTAL 14

                if (dt_14.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_14.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //NOMBRE PORTAL
                        LBL_PORTAL_14.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 

                            CMB_PORTAL_14.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 

                            CMB_PORTAL_14.SelectedIndex = 1;
                        }


                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_14.Visible = true;
                    }
                    else
                    {
                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_14.Visible = false;
                    }
                }

                #endregion

                #region PORTAL 15

                if (dt_15.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_15.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //NOMBRE PORTAL
                        LBL_PORTAL_15.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 

                            CMB_PORTAL_15.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 

                            CMB_PORTAL_15.SelectedIndex = 1;
                        }


                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_15.Visible = true;
                    }
                    else
                    {
                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_15.Visible = false;
                    }
                }

                #endregion

                #region PORTAL 16

                if (dt_16.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_16.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //NOMBRE PORTAL
                        LBL_PORTAL_16.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 

                            CMB_PORTAL_16.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 

                            CMB_PORTAL_16.SelectedIndex = 1;
                        }


                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_16.Visible = true;
                    }
                    else
                    {
                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_16.Visible = false;
                    }
                }

                #endregion

                #region PORTAL 17

                if (dt_17.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_17.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //NOMBRE PORTAL
                        LBL_PORTAL_17.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 

                            CMB_PORTAL_17.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 

                            CMB_PORTAL_17.SelectedIndex = 1;
                        }


                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_17.Visible = true;
                    }
                    else
                    {
                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_17.Visible = false;
                    }
                }

                #endregion

                #region PORTAL 18

                if (dt_18.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_18.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //NOMBRE PORTAL
                        LBL_PORTAL_18.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 

                            CMB_PORTAL_18.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 

                            CMB_PORTAL_18.SelectedIndex = 1;
                        }


                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_18.Visible = true;
                    }
                    else
                    {
                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_18.Visible = false;
                    }
                }

                #endregion

                #region PORTAL 19


                if (dt_19.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_19.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //NOMBRE PORTAL
                        LBL_PORTAL_19.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 

                            CMB_PORTAL_19.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 

                            CMB_PORTAL_19.SelectedIndex = 1;
                        }


                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_19.Visible = true;
                    }
                    else
                    {
                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_19.Visible = false;
                    }
                }

                #endregion

                #region PORTAL 20


                if (dt_20.Rows.Count > 0)
                {
                    //ASIGNAR LA DATA AL DATAROW
                    DataRow dr = dt_20.Rows[0];

                    //LICENCIA
                    string LICENCIA_PORTAL = dr["LICENCIA"].ToString();

                    if (LICENCIA_PORTAL == "True")
                    {
                        //NOMBRE PORTAL
                        LBL_PORTAL_20.Text = dr["NOMBRE_PORTAL"].ToString();

                        //ESTADO PORTAL
                        string ESTADO = dr["ESTADO"].ToString();

                        if (ESTADO == "True")
                        {
                            //ESTILO 

                            CMB_PORTAL_20.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 

                            CMB_PORTAL_20.SelectedIndex = 1;
                        }


                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_20.Visible = true;
                    }
                    else
                    {
                        //OCULTAMOS EL PORTAL DEL SWICTH PANEL
                        PANEL_20.Visible = false;
                    }
                }

                #endregion


                ///////////////////////////////////////

                #region SINCRONIZADOR



                #endregion

                ///////////////////////////////////////

                //ONLINE
                LBL_ESTADO.Text = "ONLINE";
                LBL_ESTADO.ForeColor = Color.Green;

                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                TXT_BITACORA_ESTADO.AppendText(System.Environment.NewLine + "ONLINE:  " + DateTime.Now);
            }
            catch (Exception)
            {

                //OFFLINE
                LBL_ESTADO.Text = "OFFLINE";
                LBL_ESTADO.ForeColor = Color.DarkRed;
                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                TXT_BITACORA_ESTADO.AppendText(System.Environment.NewLine + "OFFLINE:  " + DateTime.Now);
            }

        }

        /// <summary>
        /// TIMER RELOJ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Reloj_Tick(object sender, EventArgs e)
        {
            lblFechaHora.Text = DateTime.Now.ToString();
        }

        /// <summary>
        /// TIMER INICIO DEL SWITCH PANEL [SOLO SE EJECUTA AL INICIO DE LA APLICACION]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Timer_Iniciar_Switch_Panel_Tick(object sender, EventArgs e)
        {
            try
            {

                var response = await SwicthPanel.Data.ApiConfiguracion.GetPortalInformation();
                string JsonString = FUNCIONES.Json.BeautifyJson(response);

                var result = JsonConvert.DeserializeObject<List<SwitchPanel.Entidades.PortalRFID>>(JsonString);
                var ObjPortal = result;



                //CONSULTAR LICENCIA
                //CONSULTA_LICECNICA_PORTAL();



                /////////////////////////////////////////////////////////

               

                //MOSTRAR INFORMACION DE CADA PORTAL EN EL SWITCH PANEL
                if (result.Count > 0)
                {

                    #region PORTAL 1
                    //LICENCIA
                    string ReaderVisible = ObjPortal[0].ReaderVisible.ToString();

                    if (ReaderVisible == "True")
                    {
                        PANEL_1.Visible = true;
                        //IMAGEN
                        byte[] Imagen = new byte[0];
                        ESTADO_COMPROBACION_READER_1 = true;
                        if (ObjPortal[0].ReaderImage != null)
                        {
                            Imagen = (byte[])ObjPortal[0].ReaderImage;
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX1.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_1.Text = ObjPortal[0].PortalName.ToString();

                        //ESTADO PORTAL
                        bool ReaderSatus = ObjPortal[0].ReaderSatus;

                        if (ReaderSatus == true)
                        {
                            ////ESTILO 

                            CMB_PORTAL_1.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 

                            CMB_PORTAL_1.SelectedIndex = 1;
                        }
                    }
                    #endregion

                    #region PORTAL 2

                    //LICENCIA
                    string ReaderVisible2 = ObjPortal[1].ReaderVisible.ToString();

                    if (ReaderVisible2 == "True")
                    {
                        PANEL_2.Visible = true;
                        //IMAGEN
                        byte[] Imagen = new byte[1];
                        ESTADO_COMPROBACION_READER_2 = true;
                        if (ObjPortal[1].ReaderImage != null)
                        {
                            Imagen = (byte[])ObjPortal[1].ReaderImage;
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX2.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_2.Text = ObjPortal[1].PortalName.ToString();

                        //ESTADO PORTAL
                        bool ReaderSatus = ObjPortal[1].ReaderSatus;

                        if (ReaderSatus == true)
                        {
                            ////ESTILO 

                            CMB_PORTAL_2.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 

                            CMB_PORTAL_2.SelectedIndex = 1;
                        }
                    }
                    #endregion

                    #region PORTAL 3

                    //LICENCIA
                    string ReaderVisible3 = ObjPortal[2].ReaderVisible.ToString();

                    if (ReaderVisible3 == "True")
                    {
                        PANEL_3.Visible = true;
                        //IMAGEN
                        byte[] Imagen = new byte[1];
                        ESTADO_COMPROBACION_READER_3 = true;
                        if (ObjPortal[2].ReaderImage != null)
                        {
                            Imagen = (byte[])ObjPortal[2].ReaderImage;
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX3.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_3.Text = ObjPortal[2].PortalName.ToString();

                        //ESTADO PORTAL
                        bool ReaderSatus = ObjPortal[2].ReaderSatus;

                        if (ReaderSatus == true)
                        {
                            ////ESTILO 

                            CMB_PORTAL_3.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 

                            CMB_PORTAL_3.SelectedIndex = 1;
                        }
                    }
                    #endregion

                    #region PORTAL 4

                    //LICENCIA
                    string ReaderVisible4 = ObjPortal[3].ReaderVisible.ToString();

                    if (ReaderVisible4 == "True")
                    {
                        PANEL_4.Visible = true;
                        //IMAGEN
                        byte[] Imagen = new byte[1];
                        ESTADO_COMPROBACION_READER_4 = true;
                        if (ObjPortal[3].ReaderImage != null)
                        {
                            Imagen = (byte[])ObjPortal[3].ReaderImage;
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX4.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_4.Text = ObjPortal[3].PortalName.ToString();

                        //ESTADO PORTAL
                        bool ReaderSatus = ObjPortal[3].ReaderSatus;

                        if (ReaderSatus == true)
                        {
                            ////ESTILO 

                            CMB_PORTAL_4.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 

                            CMB_PORTAL_4.SelectedIndex = 1;
                        }
                    }
                    #endregion

                    #region PORTAL 5

                    //LICENCIA
                    string ReaderVisible5 = ObjPortal[4].ReaderVisible.ToString();

                    if (ReaderVisible5 == "True")
                    {
                        PANEL_5.Visible = true;
                        //IMAGEN
                        byte[] Imagen = new byte[1];
                        ESTADO_COMPROBACION_READER_5 = true;
                        if (ObjPortal[4].ReaderImage != null)
                        {
                            Imagen = (byte[])ObjPortal[4].ReaderImage;
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX5.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_5.Text = ObjPortal[4].PortalName.ToString();

                        //ESTADO PORTAL
                        bool ReaderSatus = ObjPortal[4].ReaderSatus;

                        if (ReaderSatus == true)
                        {
                            ////ESTILO 

                            CMB_PORTAL_5.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 

                            CMB_PORTAL_5.SelectedIndex = 1;
                        }
                    }
                    #endregion

                    #region PORTAL 6

                    //LICENCIA
                    string ReaderVisible6 = ObjPortal[5].ReaderVisible.ToString();

                    if (ReaderVisible6 == "True")
                    {
                        PANEL_6.Visible = true;
                        //IMAGEN
                        byte[] Imagen = new byte[1];
                        ESTADO_COMPROBACION_READER_6 = true;
                        if (ObjPortal[5].ReaderImage != null)
                        {
                            Imagen = (byte[])ObjPortal[5].ReaderImage;
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX6.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_6.Text = ObjPortal[5].PortalName.ToString();

                        //ESTADO PORTAL
                        bool ReaderSatus = ObjPortal[5].ReaderSatus;

                        if (ReaderSatus == true)
                        {
                            ////ESTILO 

                            CMB_PORTAL_6.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 

                            CMB_PORTAL_6.SelectedIndex = 1;
                        }
                    }
                    #endregion

                    #region PORTAL 7

                    //LICENCIA
                    string ReaderVisible7 = ObjPortal[6].ReaderVisible.ToString();

                    if (ReaderVisible7 == "True")
                    {
                        PANEL_7.Visible = true;
                        //IMAGEN
                        byte[] Imagen = new byte[1];
                        ESTADO_COMPROBACION_READER_7 = true;
                        if (ObjPortal[6].ReaderImage != null)
                        {
                            Imagen = (byte[])ObjPortal[6].ReaderImage;
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX7.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_7.Text = ObjPortal[6].PortalName.ToString();

                        //ESTADO PORTAL
                        bool ReaderSatus = ObjPortal[6].ReaderSatus;

                        if (ReaderSatus == true)
                        {
                            ////ESTILO 

                            CMB_PORTAL_7.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 

                            CMB_PORTAL_7.SelectedIndex = 1;
                        }
                    }
                    #endregion

                    #region PORTAL 8

                    //LICENCIA
                    string ReaderVisible8 = ObjPortal[7].ReaderVisible.ToString();
                    
                    if (ReaderVisible8 == "True")
                    {
                        PANEL_8.Visible = true;
                        //IMAGEN
                        byte[] Imagen = new byte[1];
                        ESTADO_COMPROBACION_READER_8 = true;
                        if (ObjPortal[7].ReaderImage != null)
                        {
                            Imagen = (byte[])ObjPortal[7].ReaderImage;
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX8.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_8.Text = ObjPortal[7].PortalName.ToString();

                        //ESTADO PORTAL
                        bool ReaderSatus = ObjPortal[7].ReaderSatus;

                        if (ReaderSatus == true)
                        {
                            ////ESTILO 

                            CMB_PORTAL_8.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 

                            CMB_PORTAL_8.SelectedIndex = 1;
                        }
                    }
                    #endregion

                    #region PORTAL 9

                    //LICENCIA
                    string ReaderVisible9 = ObjPortal[8].ReaderVisible.ToString();

                    if (ReaderVisible9 == "True")
                    {
                        PANEL_9.Visible = true;
                        //IMAGEN
                        byte[] Imagen = new byte[1];
                        ESTADO_COMPROBACION_READER_9 = true;
                        if (ObjPortal[8].ReaderImage != null)
                        {
                            Imagen = (byte[])ObjPortal[8].ReaderImage;
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX9.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_9.Text = ObjPortal[8].PortalName.ToString();

                        //ESTADO PORTAL
                        bool ReaderSatus = ObjPortal[8].ReaderSatus;

                        if (ReaderSatus == true)
                        {
                            ////ESTILO 

                            CMB_PORTAL_9.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 

                            CMB_PORTAL_9.SelectedIndex = 1;
                        }
                    }
                    #endregion

                    #region PORTAL 10

                    //LICENCIA
                    string ReaderVisible10 = ObjPortal[9].ReaderVisible.ToString();

                    if (ReaderVisible10 == "True")
                    {
                        PANEL_10.Visible = true;
                        //IMAGEN
                        byte[] Imagen = new byte[1];
                        ESTADO_COMPROBACION_READER_10 = true;
                        if (ObjPortal[9].ReaderImage != null)
                        {
                            Imagen = (byte[])ObjPortal[9].ReaderImage;
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX10.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_10.Text = ObjPortal[9].PortalName.ToString();

                        //ESTADO PORTAL
                        bool ReaderSatus = ObjPortal[9].ReaderSatus;

                        if (ReaderSatus == true)
                        {
                            ////ESTILO 

                            CMB_PORTAL_10.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 

                            CMB_PORTAL_10.SelectedIndex = 1;
                        }
                    }
                    #endregion

                    #region PORTAL 11

                    //LICENCIA
                    string ReaderVisible11 = ObjPortal[10].ReaderVisible.ToString();

                    if (ReaderVisible11 == "True")
                    {
                        PANEL_11.Visible = true;
                        //IMAGEN
                        byte[] Imagen = new byte[1];
                        ESTADO_COMPROBACION_READER_11 = true;
                        if (ObjPortal[10].ReaderImage != null)
                        {
                            Imagen = (byte[])ObjPortal[10].ReaderImage;
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX11.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_11.Text = ObjPortal[10].PortalName.ToString();

                        //ESTADO PORTAL
                        bool ReaderSatus = ObjPortal[10].ReaderSatus;

                        if (ReaderSatus == true)
                        {
                            ////ESTILO 

                            CMB_PORTAL_11.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 

                            CMB_PORTAL_11.SelectedIndex = 1;
                        }
                    }
                    #endregion

                    #region PORTAL 12

                    //LICENCIA
                    string ReaderVisible12 = ObjPortal[11].ReaderVisible.ToString();

                    if (ReaderVisible12 == "True")
                    {
                        PANEL_12.Visible = true;
                        //IMAGEN
                        byte[] Imagen = new byte[1];
                        ESTADO_COMPROBACION_READER_12 = true;
                        if (ObjPortal[11].ReaderImage != null)
                        {
                            Imagen = (byte[])ObjPortal[11].ReaderImage;
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX12.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_12.Text = ObjPortal[11].PortalName.ToString();

                        //ESTADO PORTAL
                        bool ReaderSatus = ObjPortal[11].ReaderSatus;

                        if (ReaderSatus == true)
                        {
                            ////ESTILO 

                            CMB_PORTAL_12.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 

                            CMB_PORTAL_12.SelectedIndex = 1;
                        }
                    }
                    #endregion

                    #region PORTAL 13

                    //LICENCIA
                    string ReaderVisible13 = ObjPortal[12].ReaderVisible.ToString();

                    if (ReaderVisible13 == "True")
                    {
                        PANEL_13.Visible = true;
                        //IMAGEN
                        byte[] Imagen = new byte[1];
                        ESTADO_COMPROBACION_READER_13= true;
                        if (ObjPortal[12].ReaderImage != null)
                        {
                            Imagen = (byte[])ObjPortal[12].ReaderImage;
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX13.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_13.Text = ObjPortal[12].PortalName.ToString();

                        //ESTADO PORTAL
                        bool ReaderSatus = ObjPortal[12].ReaderSatus;

                        if (ReaderSatus == true)
                        {
                            ////ESTILO 

                            CMB_PORTAL_13.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 

                            CMB_PORTAL_13.SelectedIndex = 1;
                        }
                    }
                    #endregion

                    #region PORTAL 14

                    //LICENCIA
                    string ReaderVisible14 = ObjPortal[13].ReaderVisible.ToString();

                    if (ReaderVisible14 == "True")
                    {
                        PANEL_14.Visible = true;
                        //IMAGEN
                        byte[] Imagen = new byte[1];
                        ESTADO_COMPROBACION_READER_14 = true;
                        if (ObjPortal[13].ReaderImage != null)
                        {
                            Imagen = (byte[])ObjPortal[13].ReaderImage;
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX14.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_14.Text = ObjPortal[13].PortalName.ToString();

                        //ESTADO PORTAL
                        bool ReaderSatus = ObjPortal[13].ReaderSatus;

                        if (ReaderSatus == true)
                        {
                            ////ESTILO 

                            CMB_PORTAL_14.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 

                            CMB_PORTAL_14.SelectedIndex = 1;
                        }
                    }
                    #endregion

                    #region PORTAL 15

                    //LICENCIA
                    string ReaderVisible15 = ObjPortal[14].ReaderVisible.ToString();

                    if (ReaderVisible15 == "True")
                    {
                        PANEL_15.Visible = true;
                        //IMAGEN
                        byte[] Imagen = new byte[1];
                        ESTADO_COMPROBACION_READER_15 = true;
                        if (ObjPortal[14].ReaderImage != null)
                        {
                            Imagen = (byte[])ObjPortal[14].ReaderImage;
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX15.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_15.Text = ObjPortal[14].PortalName.ToString();

                        //ESTADO PORTAL
                        bool ReaderSatus = ObjPortal[14].ReaderSatus;

                        if (ReaderSatus == true)
                        {
                            ////ESTILO 

                            CMB_PORTAL_15.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 

                            CMB_PORTAL_15.SelectedIndex = 1;
                        }
                    }
                    #endregion

                    #region PORTAL 16

                    //LICENCIA
                    string ReaderVisible16 = ObjPortal[15].ReaderVisible.ToString();

                    if (ReaderVisible16 == "True")
                    {
                        PANEL_16.Visible = true;
                        //IMAGEN
                        byte[] Imagen = new byte[1];
                        ESTADO_COMPROBACION_READER_16 = true;
                        if (ObjPortal[15].ReaderImage != null)
                        {
                            Imagen = (byte[])ObjPortal[15].ReaderImage;
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX16.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_16.Text = ObjPortal[15].PortalName.ToString();

                        //ESTADO PORTAL
                        bool ReaderSatus = ObjPortal[15].ReaderSatus;

                        if (ReaderSatus == true)
                        {
                            ////ESTILO 

                            CMB_PORTAL_16.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 

                            CMB_PORTAL_16.SelectedIndex = 1;
                        }
                    }
                    #endregion

                    #region PORTAL 17

                    //LICENCIA
                    string ReaderVisible17= ObjPortal[16].ReaderVisible.ToString();

                    if (ReaderVisible17 == "True")
                    {
                        PANEL_17.Visible = true;
                        //IMAGEN
                        byte[] Imagen = new byte[1];
                        ESTADO_COMPROBACION_READER_17 = true;
                        if (ObjPortal[16].ReaderImage != null)
                        {
                            Imagen = (byte[])ObjPortal[16].ReaderImage;
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX17.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_17.Text = ObjPortal[16].PortalName.ToString();

                        //ESTADO PORTAL
                        bool ReaderSatus = ObjPortal[16].ReaderSatus;

                        if (ReaderSatus == true)
                        {
                            ////ESTILO 

                            CMB_PORTAL_17.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 

                            CMB_PORTAL_17.SelectedIndex = 1;
                        }
                    }
                    #endregion

                    #region PORTAL 18

                    //LICENCIA
                    string ReaderVisible18 = ObjPortal[17].ReaderVisible.ToString();

                    if (ReaderVisible18 == "True")
                    {
                        PANEL_18.Visible = true;
                        //IMAGEN
                        byte[] Imagen = new byte[1];
                        ESTADO_COMPROBACION_READER_18 = true;
                        if (ObjPortal[17].ReaderImage != null)
                        {
                            Imagen = (byte[])ObjPortal[17].ReaderImage;
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX18.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_18.Text = ObjPortal[17].PortalName.ToString();

                        //ESTADO PORTAL
                        bool ReaderSatus = ObjPortal[17].ReaderSatus;

                        if (ReaderSatus == true)
                        {
                            ////ESTILO 

                            CMB_PORTAL_18.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 

                            CMB_PORTAL_18.SelectedIndex = 1;
                        }
                    }
                    #endregion

                    #region PORTAL 19

                    //LICENCIA
                    string ReaderVisible19 = ObjPortal[18].ReaderVisible.ToString();

                    if (ReaderVisible19 == "True")
                    {
                        PANEL_19.Visible = true;
                        //IMAGEN
                        byte[] Imagen = new byte[1];
                        ESTADO_COMPROBACION_READER_19 = true;
                        if (ObjPortal[18].ReaderImage != null)
                        {
                            Imagen = (byte[])ObjPortal[18].ReaderImage;
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX19.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_19.Text = ObjPortal[18].PortalName.ToString();

                        //ESTADO PORTAL
                        bool ReaderSatus = ObjPortal[18].ReaderSatus;

                        if (ReaderSatus == true)
                        {
                            ////ESTILO 

                            CMB_PORTAL_19.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 

                            CMB_PORTAL_19.SelectedIndex = 1;
                        }
                    }
                    #endregion

                    #region PORTAL 20

                    //LICENCIA
                    string ReaderVisible20 = ObjPortal[19].ReaderVisible.ToString();

                    if (ReaderVisible20 == "True")
                    {
                        PANEL_20.Visible = true;
                        //IMAGEN
                        byte[] Imagen = new byte[1];
                        ESTADO_COMPROBACION_READER_20 = true;
                        if (ObjPortal[19].ReaderImage != null)
                        {
                            Imagen = (byte[])ObjPortal[19].ReaderImage;
                            MemoryStream ms = new MemoryStream(Imagen);
                            PIC_BOX20.Image = Image.FromStream(ms);
                        }

                        //NOMBRE PORTAL
                        LBL_PORTAL_20.Text = ObjPortal[19].PortalName.ToString();

                        //ESTADO PORTAL
                        bool ReaderSatus = ObjPortal[19].ReaderSatus;

                        if (ReaderSatus == true)
                        {
                            ////ESTILO 

                            CMB_PORTAL_20.SelectedIndex = 0;
                        }
                        else
                        {
                            //ESTILO 

                            CMB_PORTAL_20.SelectedIndex = 1;
                        }
                    }
                    #endregion
                }


                //INHABILITAMOS EL TIMER
                TM_INICIAR_SWITCH_PANEL.Enabled = false;

                ////DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                TXT_BITACORA_ESTADO.AppendText(System.Environment.NewLine + "ONLINE:  " + DateTime.Now);

                ////CONSULTAR MODO AUTOMATICO
                #region MODO AUTOMATICO

                //FUNCIONES.ARCHIVOS File = new FUNCIONES.ARCHIVOS();
                //string MODO_AUTOMATICO = "False";

                ////LEER FILE CONFIG
                //DataTable DT = File.LEER_ARCHIVO_CONFIG_MODO_AUTOMATICO();
                //if (DT.Rows.Count > 0)
                //{
                //    DataRow dr = DT.Rows[0];

                //    MODO_AUTOMATICO = dr["MODO_AUTOMATICO"].ToString();

                //    if(MODO_AUTOMATICO == "True")
                //    {
                //        TM_REINICIO_PORTAL.Enabled = true;
                //    }
                //    else
                //    {
                //        TM_REINICIO_PORTAL.Enabled = false;
                //    }

                //}

                #endregion
            }
            catch (Exception)
            {
                //OFFLINE
                LBL_ESTADO.Text = "OFFLINE";
                LBL_ESTADO.ForeColor = Color.DarkRed;

                //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE
                TXT_BITACORA_ESTADO.AppendText(System.Environment.NewLine + "OFFLINE:  " + DateTime.Now);

                //INHABILITAMOS EL TIMER
                TM_INICIAR_SWITCH_PANEL.Enabled = false;
            }
        }

        /// <summary>
        /// REVISA CUAL READER NO ESTA CONECTADO, Y LO RECONECTA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Reiniciar_Readers_Tick(object sender, EventArgs e)
        {
            try
            {
                ///////////////////////////////////////////////////////////
                //VALIDAR PORTALE EN ESTADO OFF

                #region PORTAL 1

                if (PANEL_1.Visible == true)
                {
                    string CMB_1 = CMB_PORTAL_1.SelectedItem.ToString();

                    if (CMB_1 == "OFF" && PIC_BOX1.Visible == true)
                    {
                        if (ESTADO_COMPROBACION_READER_1 == true)
                        {
                            //INICIAR NUEVAMENTE EL PORTAL
                            Thread.Sleep(5000);
                            INICIAR_PORTAL(1);
                        }
                    }
                }



                #endregion

                ///////////////////////////////////////////////////////////
                //VALIDAR PORTALE EN ESTADO OFF

                #region PORTAL 2

                if (PANEL_2.Visible == true)
                {
                    string CMB_2 = CMB_PORTAL_2.SelectedItem.ToString();

                    if (CMB_2 == "OFF" && PIC_BOX2.Visible == true)
                    {
                        if (ESTADO_COMPROBACION_READER_2 == true)
                        {
                            //INICIAR NUEVAMENTE EL PORTAL
                            Thread.Sleep(5000);
                            INICIAR_PORTAL(2);
                        }
                    }
                }


                #endregion

                ///////////////////////////////////////////////////////////
                //VALIDAR PORTALE EN ESTADO OFF

                #region PORTAL 3

                if (PANEL_3.Visible == true)
                {
                    string CMB_3 = CMB_PORTAL_3.SelectedItem.ToString();

                    if (CMB_3 == "OFF" && PIC_BOX3.Visible == true)
                    {
                        if (ESTADO_COMPROBACION_READER_3 == true)
                        {
                            //INICIAR NUEVAMENTE EL PORTAL
                            Thread.Sleep(5000);
                            INICIAR_PORTAL(3);
                        }
                    }
                }

                #endregion

                ///////////////////////////////////////////////////////////
                //VALIDAR PORTALE EN ESTADO OFF

                #region PORTAL 4

                if (PANEL_4.Visible == true)
                {
                    string CMB_4 = CMB_PORTAL_4.SelectedItem.ToString();

                    if (CMB_4 == "OFF" && PIC_BOX4.Visible == true)
                    {
                        if (ESTADO_COMPROBACION_READER_4 == true)
                        {
                            //INICIAR NUEVAMENTE EL PORTAL
                            Thread.Sleep(5000);
                            INICIAR_PORTAL(4);
                        }

                    }
                }

                #endregion

                ///////////////////////////////////////////////////////////
                //VALIDAR PORTALE EN ESTADO OFF

                #region PORTAL 5

                if (PANEL_5.Visible == true)
                {
                    string CMB_5 = CMB_PORTAL_5.SelectedItem.ToString();

                    if (CMB_5 == "OFF" && PIC_BOX5.Visible == true)
                    {
                        if (ESTADO_COMPROBACION_READER_5 == true)
                        {
                            //INICIAR NUEVAMENTE EL PORTAL
                            Thread.Sleep(5000);
                            INICIAR_PORTAL(5);
                        }
                    }
                }

                #endregion

                ///////////////////////////////////////////////////////////
                //VALIDAR PORTALE EN ESTADO OFF

                #region PORTAL 6

                if (PANEL_6.Visible == true)
                {
                    string CMB_6 = CMB_PORTAL_6.SelectedItem.ToString();

                    if (CMB_6 == "OFF" && PIC_BOX6.Visible == true)
                    {
                        if (ESTADO_COMPROBACION_READER_6 == true)
                        {
                            //INICIAR NUEVAMENTE EL PORTAL
                            Thread.Sleep(5000);
                            INICIAR_PORTAL(6);
                        }
                    }
                }

                #endregion

                ///////////////////////////////////////////////////////////
                //VALIDAR PORTALE EN ESTADO OFF

                #region PORTAL 7

                if (PANEL_7.Visible == true)
                {
                    string CMB_7 = CMB_PORTAL_7.SelectedItem.ToString();

                    if (CMB_7 == "OFF" && PIC_BOX7.Visible == true)
                    {
                        if (ESTADO_COMPROBACION_READER_7 == true)
                        {
                            //INICIAR NUEVAMENTE EL PORTAL
                            Thread.Sleep(5000);
                            INICIAR_PORTAL(7);
                        }
                    }
                }

                #endregion

                ///////////////////////////////////////////////////////////
                //VALIDAR PORTALE EN ESTADO OFF

                #region PORTAL 8

                if (PANEL_8.Visible == true)
                {
                    string CMB_8 = CMB_PORTAL_8.SelectedItem.ToString();

                    if (CMB_8 == "OFF" && PIC_BOX8.Visible == true)
                    {
                        if (ESTADO_COMPROBACION_READER_8 == true)
                        {
                            //INICIAR NUEVAMENTE EL PORTAL
                            Thread.Sleep(5000);
                            INICIAR_PORTAL(8);
                        }
                    }
                }

                #endregion

                ///////////////////////////////////////////////////////////
                //VALIDAR PORTALE EN ESTADO OFF

                #region PORTAL 9

                if (PANEL_9.Visible == true)
                {
                    string CMB_9 = CMB_PORTAL_9.SelectedItem.ToString();

                    if (CMB_9 == "OFF" && PIC_BOX9.Visible == true)
                    {
                        if (ESTADO_COMPROBACION_READER_9 == true)
                        {
                            //INICIAR NUEVAMENTE EL PORTAL
                            Thread.Sleep(5000);
                            INICIAR_PORTAL(9);
                        }
                    }
                }

                #endregion

                ///////////////////////////////////////////////////////////
                //VALIDAR PORTALE EN ESTADO OFF

                #region PORTAL 10

                if (PANEL_10.Visible == true)
                {
                    string CMB_10 = CMB_PORTAL_10.SelectedItem.ToString();

                    if (CMB_10 == "OFF" && PIC_BOX10.Visible == true)
                    {
                        if (ESTADO_COMPROBACION_READER_10 == true)
                        {
                            //INICIAR NUEVAMENTE EL PORTAL
                            Thread.Sleep(5000);
                            INICIAR_PORTAL(10);
                        }
                    }
                }

                #endregion

                ///////////////////////////////////////////////////////////
                //VALIDAR PORTALE EN ESTADO OFF

                #region PORTAL 11

                if (PANEL_11.Visible == true)
                {
                    string CMB_11 = CMB_PORTAL_11.SelectedItem.ToString();

                    if (CMB_11 == "OFF" && PIC_BOX11.Visible == true)
                    {
                        if (ESTADO_COMPROBACION_READER_11 == true)
                        {
                            //INICIAR NUEVAMENTE EL PORTAL
                            Thread.Sleep(5000);
                            INICIAR_PORTAL(11);
                        }
                    }
                }

                #endregion

                ///////////////////////////////////////////////////////////
                //VALIDAR PORTALE EN ESTADO OFF

                #region PORTAL 12

                if (PANEL_12.Visible == true)
                {
                    string CMB_12 = CMB_PORTAL_12.SelectedItem.ToString();

                    if (CMB_12 == "OFF" && PIC_BOX12.Visible == true)
                    {
                        if (ESTADO_COMPROBACION_READER_12 == true)
                        {
                            //TERMINAR THREAD
                            CONEXION_12.Abort();
                            ESTADO_COMPROBACION_READER_12 = false;

                            //INICIAR NUEVAMENTE EL PORTAL
                            Thread.Sleep(5000);
                            INICIAR_PORTAL(12);
                        }
                    }
                }

                #endregion

                ///////////////////////////////////////////////////////////
                //VALIDAR PORTALE EN ESTADO OFF

                #region PORTAL 13

                if (PANEL_13.Visible == true)
                {
                    string CMB_13 = CMB_PORTAL_13.SelectedItem.ToString();

                    if (CMB_13 == "OFF" && PIC_BOX13.Visible == true)
                    {
                        if (ESTADO_COMPROBACION_READER_13 == true)
                        {
                            //TERMINAR THREAD
                            CONEXION_13.Abort();
                            ESTADO_COMPROBACION_READER_13 = false;

                            //INICIAR NUEVAMENTE EL PORTAL
                            Thread.Sleep(5000);
                            INICIAR_PORTAL(13);
                        }
                    }
                }

                #endregion

                ///////////////////////////////////////////////////////////
                //VALIDAR PORTALE EN ESTADO OFF

                #region PORTAL 14

                if (PANEL_14.Visible == true)
                {
                    string CMB_14 = CMB_PORTAL_14.SelectedItem.ToString();

                    if (CMB_14 == "OFF" && PIC_BOX14.Visible == true)
                    {
                        if (ESTADO_COMPROBACION_READER_14 == true)
                        {
                            //TERMINAR THREAD
                            CONEXION_14.Abort();
                            ESTADO_COMPROBACION_READER_14 = false;

                            //INICIAR NUEVAMENTE EL PORTAL
                            Thread.Sleep(5000);
                            INICIAR_PORTAL(14);
                        }

                    }
                }

                #endregion

                ///////////////////////////////////////////////////////////
                //VALIDAR PORTALE EN ESTADO OFF

                #region PORTAL 15

                if (PANEL_15.Visible == true)
                {
                    string CMB_15 = CMB_PORTAL_15.SelectedItem.ToString();

                    if (CMB_15 == "OFF" && PIC_BOX15.Visible == true)
                    {
                        if (ESTADO_COMPROBACION_READER_15 == true)
                        {
                            //INICIAR NUEVAMENTE EL PORTAL
                            Thread.Sleep(5000);
                            INICIAR_PORTAL(15);
                        }
                    }
                }



                #endregion

                ///////////////////////////////////////////////////////////
                //VALIDAR PORTALE EN ESTADO OFF

                #region PORTAL 16

                if (PANEL_16.Visible == true)
                {
                    string CMB_16 = CMB_PORTAL_16.SelectedItem.ToString();

                    if (CMB_16 == "OFF" && PIC_BOX16.Visible == true)
                    {
                        if (ESTADO_COMPROBACION_READER_16 == true)
                        {
                            //INICIAR NUEVAMENTE EL PORTAL
                            Thread.Sleep(5000);
                            INICIAR_PORTAL(16);
                        }
                    }
                }


                #endregion

                ///////////////////////////////////////////////////////////
                //VALIDAR PORTALE EN ESTADO OFF

                #region PORTAL 17

                if (PANEL_17.Visible == true)
                {
                    string CMB_17 = CMB_PORTAL_17.SelectedItem.ToString();

                    if (CMB_17 == "OFF" && PIC_BOX17.Visible == true)
                    {
                        if (ESTADO_COMPROBACION_READER_17 == true)
                        {
                            //TERMINAR THREAD
                            CONEXION_17.Abort();
                            ESTADO_COMPROBACION_READER_17 = false;

                            //INICIAR NUEVAMENTE EL PORTAL
                            Thread.Sleep(5000);
                            INICIAR_PORTAL(17);
                        }
                    }
                }

                #endregion

                ///////////////////////////////////////////////////////////
                //VALIDAR PORTALE EN ESTADO OFF

                #region PORTAL 18

                if (PANEL_18.Visible == true)
                {
                    string CMB_18 = CMB_PORTAL_18.SelectedItem.ToString();


                    if (CMB_18 == "OFF" && PIC_BOX18.Visible == true)
                    {
                        if (ESTADO_COMPROBACION_READER_18 == true)
                        {
                            //INICIAR NUEVAMENTE EL PORTAL
                            Thread.Sleep(5000);
                            INICIAR_PORTAL(18);
                        }
                    }
                }

                #endregion

                ///////////////////////////////////////////////////////////
                //VALIDAR PORTALE EN ESTADO OFF

                #region PORTAL 19

                if (PANEL_19.Visible == true)
                {
                    string CMB_19 = CMB_PORTAL_19.SelectedItem.ToString();

                    if (CMB_19 == "OFF" && PIC_BOX19.Visible == true)
                    {
                        if (ESTADO_COMPROBACION_READER_19 == true)
                        {
                            //INICIAR NUEVAMENTE EL PORTAL
                            Thread.Sleep(5000);
                            INICIAR_PORTAL(19);
                        }
                    }
                }

                #endregion

                ///////////////////////////////////////////////////////////
                //VALIDAR PORTALE EN ESTADO OFF

                #region PORTAL 20

                if (PANEL_20.Visible == true)
                {
                    string CMB_20 = CMB_PORTAL_20.SelectedItem.ToString();

                    if (CMB_20 == "OFF" && PIC_BOX20.Visible == true)
                    {
                        if (ESTADO_COMPROBACION_READER_20 == true)
                        {
                            //INICIAR NUEVAMENTE EL PORTAL
                            Thread.Sleep(5000);
                            INICIAR_PORTAL(20);
                        }
                    }
                }


                #endregion

            }
            catch (Exception)
            {
                ////OFFLINE
                //LBL_ESTADO.Text = "OFFLINE";
                //LBL_ESTADO.ForeColor = Color.DarkRed;
            }
        }

        /// <summary>
        /// ESTE EJECUTA EL TRASPADO DE DATOS DE LECTURA A BITACORA, ENTRADA/SALIDA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Bitacora_Tick(object sender, EventArgs e)
        {
            //EJECUTAMOS EL METODO DE BITACORA
            //ESTE ACTUALIZA LA BITACORA ENTRADA/SALIDA
            //Y ASI MOSTRAR LAS LECTURA DE LOS TAGS EN EL EASY PASS
            SERVICIOS.BITACORA bitacora = new SERVICIOS.BITACORA();

            THR_BITACORA = new Thread(bitacora.ACTUALIZAR_LECTURAS_EASY_PASS);
            THR_BITACORA.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SWITCH_PANEL_FormClosing(object sender, FormClosingEventArgs e)
        {

            try
            {
                ////////////////////////////////////////
                ////         VALIDAR PERMISO          //
                ////////////////////////////////////////

                EASY_PASS_SWITCH_PANEL.VALIDAR_PROCESO FRM = new EASY_PASS_SWITCH_PANEL.VALIDAR_PROCESO();

                FRM.ShowDialog();

                //NO CERRAR FORM
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// BTN ABRIR FORM READER TESTING
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void testLecturaPortalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TESTING_READER FRM = new TESTING_READER();
            FRM.ShowDialog();
        }

        /// <summary>
        /// SINCRONIZAR SERVIDOR LOCAL, Y SERVIDOR NUBE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TM_SINCRONIZAR_DATA_BASE_Tick(object sender, EventArgs e)
        {
            FUNCIONES.ARCHIVOS File = new FUNCIONES.ARCHIVOS();
            string STATUS_SINCONIZADOR = "";

            //LEER FILE CONFIG
            DataTable DT = File.LEER_ARCHIVO();
            if (DT.Rows.Count > 0)
            {
                DataRow dr = DT.Rows[0];
                STATUS_SINCONIZADOR = dr["STATUS_SINCRNIZADOR"].ToString();

                if (STATUS_SINCONIZADOR == "True")
                {
                    FUNCIONES.SINCRONIZACION_DATOS SINCRONIZAR = new FUNCIONES.SINCRONIZACION_DATOS();

                    SINCRONIZAR.INCIAR();

                    //DETALLAMOS ULTIMO PROCESO EN EJECUTARSE

                    TXT_BITACORA_SINCRONIZACION.AppendText(System.Environment.NewLine + "Sincronización Completada: " + DateTime.Now);

                    //RESGISTRAR LOG SINCRONIZACION
                    log.LogBitacoraSincronizacion();
                }
            }
        }


        private void configuracionGeneralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FORMS.CONFIGURACION.CONFIGURACION_GENERAL FRM_CONFIG = new FORMS.CONFIGURACION.CONFIGURACION_GENERAL();
            FRM_CONFIG.ShowDialog();
        }

        private void catálogoReaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FORMS.CONFIGURACION.CATALOGO_READER frm = new FORMS.CONFIGURACION.CATALOGO_READER();
            frm.ShowDialog();
        }



        /////////////////////////////////////////////////////////////////////////////////


        #endregion

    }
}
