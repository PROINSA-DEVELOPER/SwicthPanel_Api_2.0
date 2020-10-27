using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace EASY_PASS_SWITCH_PANEL.DATA_BASE
{
    class SINCRONIZACION
    {

        string CONEXION_DB = "";

        /// <summary>
        /// LECTURA DEL ARCHIVO CONFIG CONEXION
        /// </summary>
        /// <returns></returns>
        public DataTable LEER_ARCHIVO()
        {
            try
            {
                /////////////////////////////////////////////////
                //VARIABLES

                //RUTA APP 
                string PATH = Application.StartupPath.ToString() + "\\";

                string FILE_CONFIG = "Config_DB";
                string FORMATO = ".txt";
                string PATH_VERIFICAR = PATH + FILE_CONFIG + FORMATO;

                string DDS_CNX = "";
                string DCT_CNX = "";
                string DUS_CNX = "";
                string DPW_CNX = "";
                string CNX = "";

                string DDS_SINC = "";
                string DCT_SINC = "";
                string DUS_SINC = "";
                string DPW_SINC = "";
                string CNX_SINC = "";

                DataTable DT = new DataTable();

                //Comprobamos si existe el archivo especificado
                if (System.IO.File.Exists(PATH_VERIFICAR))
                {
                    System.IO.StreamReader file = new System.IO.StreamReader(PATH_VERIFICAR);

                    int counter = 0;
                    string line;
                    //Mostramos todas las lineas que hay escritas en el archivo
                    while ((line = file.ReadLine()) != null)
                    {
                        counter++;

                        if (counter == 1)
                        {
                            //DATA SOURCE CNX
                            DDS_CNX = line;
                        }
                        if (counter == 2)
                        {
                            //CATALOG CNX
                            DCT_CNX = line;
                        }
                        if (counter == 3)
                        {
                            //USER CNX
                            DUS_CNX = line;
                        }
                        if (counter == 4)
                        {
                            //PASSWORD CNX
                            DPW_CNX = line;
                        }
                        if (counter == 5)
                        {
                            //CNX 
                            CNX = line;
                        }
                        if (counter == 6)
                        {
                            //DATA SOURCE SINC
                            DDS_SINC = line;
                        }
                        if (counter == 7)
                        {
                            //CATALOG SINC
                            DCT_SINC = line;
                        }
                        if (counter == 8)
                        {
                            //USER SINC
                            DUS_SINC = line;
                        }
                        if (counter == 9)
                        {
                            //PASSWORD SINC
                            DPW_SINC = line;
                        }
                        if (counter == 10)
                        {
                            //CNX SINC
                            CNX_SINC = line;
                        }
                    }


                    //CREAR DATATABLE

                    //COLUMNAS CNX
                    DT.Columns.Add("DDS_CNX", typeof(string));
                    DT.Columns.Add("DCT_CNX", typeof(string));
                    DT.Columns.Add("DUS_CNX", typeof(string));
                    DT.Columns.Add("DPW_CNX", typeof(string));

                    DT.Columns.Add("CNX", typeof(string));

                    DT.Columns.Add("DDS_SINC", typeof(string));
                    DT.Columns.Add("DCT_SINC", typeof(string));
                    DT.Columns.Add("DUS_SINC", typeof(string));
                    DT.Columns.Add("DPW_SINC", typeof(string));

                    DT.Columns.Add("CNX_SINC", typeof(string));

                    //ROWS
                    DT.Rows.Add(DDS_CNX, DCT_CNX, DUS_CNX, DPW_CNX, CNX, DDS_SINC, DCT_SINC, DUS_SINC, DPW_SINC, CNX_SINC);

                    file.Close();


                }
                return DT;
            }
            catch (Exception)
            {

                return null;
            }
        }

        /// <summary>
        /// CARGAR CONFIGURACION
        /// </summary>
        private string CARGAR_CONFIGURACION_LOCAL()
        {
            try
            {
                CLASES.SEGURIDAD seguridad = new CLASES.SEGURIDAD();
                DataTable DT = LEER_ARCHIVO();

                if (DT.Rows.Count > 0)
                {
                    DataRow DR = DT.Rows[0];

                    CONEXION_DB = seguridad.DESCENCRIPTAR(DR["CNX"].ToString());
                }

                return CONEXION_DB;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// CARGAR CONFIGURACION SINC
        /// </summary>
        /// <returns></returns>
        private string CARGAR_CONFIGURACION_SERVIDOR_NUBE()
        {
            try
            {
                CLASES.SEGURIDAD seguridad = new CLASES.SEGURIDAD();
                DataTable DT = LEER_ARCHIVO();

                if (DT.Rows.Count > 0)
                {
                    DataRow DR = DT.Rows[0];

                    CONEXION_DB = seguridad.DESCENCRIPTAR(DR["CNX_SINC"].ToString());
                }

                return CONEXION_DB;
            }
            catch (Exception)
            {
                return null;
            }
        }

 

        ///////////////////////////////////////


        #region EXPORTAR SERVIDOR NUBE
        

        /// <summary>
        /// EXPORTAR BITACORA HISTRORICO
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="fecha"></param>
        /// <param name="num_activo"></param>
        /// <param name="cod_empleado"></param>
        /// <param name="entrada_salida"></param>
        /// <param name="portal"></param>
        /// <param name="transito"></param>
        /// <param name="compania"></param>
        /// <param name="salida_entrada"></param>
        /// <param name="realizarSelect"></param>
        /// <returns></returns>
        public DataTable EXPORTAR_BITACORA_HISTORICO(String tag, DateTime fecha, string num_activo, string cod_empleado, Boolean entrada_salida, int portal, Boolean transito, string compania, Boolean salida_entrada, Boolean realizarSelect)
        {
            string CNX = CARGAR_CONFIGURACION_SERVIDOR_NUBE();
            SqlConnection CN_EX = new SqlConnection(CNX);

            DataTable dt = new DataTable();
            try
            {
                CN_EX.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWICTH_PANEL_SINCRONIZAR_BITACORA_HISTORICO";
                SqlCommand cmd = new SqlCommand(SQL, CN_EX);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(@"TAG", tag);
                cmd.Parameters.AddWithValue(@"FECH", fecha);
                cmd.Parameters.AddWithValue(@"ACTIVO_NUM", num_activo);
                cmd.Parameters.AddWithValue(@"EMPLEADO_COD", cod_empleado);
                cmd.Parameters.AddWithValue(@"ENTRADA_SALIDA", entrada_salida);
                cmd.Parameters.AddWithValue(@"PORTAL_ID", portal);
                cmd.Parameters.AddWithValue(@"TRANSITO", transito);
                cmd.Parameters.AddWithValue(@"COMPANIA", compania);
                cmd.Parameters.AddWithValue(@"SALIDA_ENTRADA", salida_entrada);
                cmd.Parameters.AddWithValue(@"RealizarSelect", realizarSelect);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                //--------------------------------------------
                CN_EX.Close();

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// EXPORTAR ACTIVOS  (SERVIDOR A LOCAL)
        /// </summary>
        /// <param name="Ultima_Fecha"></param>
        /// <returns></returns>
        public DataTable IMPORTAR_CONSULTAR_ACTIVOS(DateTime Ultima_Fecha)
        {
            string CNX = CARGAR_CONFIGURACION_SERVIDOR_NUBE();
            SqlConnection CN_EX = new SqlConnection(CNX);

            DataTable dt = new DataTable();
            try
            {
                CN_EX.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWICTH_PANEL_SINCRONIZAR_EXPORTAR_ACTIVOS";
                SqlCommand cmd = new SqlCommand(SQL, CN_EX);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(@"fecha", Ultima_Fecha);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                //--------------------------------------------
                CN_EX.Close();

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
           
        }

        /// <summary>
        /// EXPORTAR BITACORA ACTIVOS (LOCAL A SERVIDOR)
        /// </summary>
        /// <returns></returns>
        public DataTable EXPORTAR_BITACORA_ACTIVOS()
        {
            string CNX = CARGAR_CONFIGURACION_LOCAL();
            SqlConnection CN_EX = new SqlConnection(CNX);

            DataTable dt = new DataTable();
            try
            {
                CN_EX.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWICTH_PANEL_EXPORTAR_BITACORA_ACTIVOS";
                SqlCommand cmd = new SqlCommand(SQL, CN_EX);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                //--------------------------------------------
                CN_EX.Close();

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// ELIMINAR REGISTROS BITACORA ACTIVOS (LOCAL)
        /// </summary>
        /// <returns></returns>
        public DataTable EXPORTAR_BITACORA_ACTIVOS_DELETE()
        {
            string CNX = CARGAR_CONFIGURACION_LOCAL();
            SqlConnection CN_EX = new SqlConnection(CNX);

            DataTable dt = new DataTable();
            try
            {
                CN_EX.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWICTH_PANEL_EXPORTAR_BITACORA_ACTIVOS_DELETE";
                SqlCommand cmd = new SqlCommand(SQL, CN_EX);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                //--------------------------------------------
                CN_EX.Close();

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion


        ///////////////////////////////////////


        #region IMPORTA SERVIDOR LOCAL

        /// <summary>
        /// 
        /// </summary>
        /// <param name="compania"></param>
        /// <param name="num_activo"></param>
        /// <param name="serie_activo"></param>
        /// <param name="descripcion_activo"></param>
        /// <param name="marca_activo"></param>
        /// <param name="tag_rfid_activo"></param>
        /// <param name="cod_empleado"></param>
        /// <param name="nombre_empleado"></param>
        /// <param name="tag_rfid_empleado"></param>
        /// <param name="activo_out_in"></param>
        /// <param name="img"></param>
        /// <param name="fecha_actualizacion"></param>
        /// <returns></returns>
        public void IMPORTAR_ACTIVOS(string compania, string num_activo, string serie_activo, string descripcion_activo, string marca_activo, string tag_rfid_activo, string cod_empleado, string nombre_empleado, string tag_rfid_empleado, Boolean activo_out_in, byte[] img, DateTime fecha_actualizacion)
        {
            //CONEXION
            string CNX = CARGAR_CONFIGURACION_LOCAL();
            SqlConnection CN_IM = new SqlConnection(CNX);

            try
            {
                CN_IM.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_IMPORTAR_ACTIVOS";
                SqlCommand cmd = new SqlCommand(SQL, CN_IM);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(@"COD_COMPANIA", compania);
                cmd.Parameters.AddWithValue(@"NUM_ACTIVO", num_activo);
                cmd.Parameters.AddWithValue(@"ACTIVO_SERIE", serie_activo);
                cmd.Parameters.AddWithValue(@"ACTIVO_DESCRIPCION", descripcion_activo);
                cmd.Parameters.AddWithValue(@"ACTIVO_MARCA", marca_activo);
                cmd.Parameters.AddWithValue(@"ACTIVO_TAG_RFID", tag_rfid_activo);
                cmd.Parameters.AddWithValue(@"COD_EMPLEADO", cod_empleado);
                cmd.Parameters.AddWithValue(@"NOMBRE_EMPLEADO", nombre_empleado);
                cmd.Parameters.AddWithValue(@"TAG_RFID_EMPLEADO", tag_rfid_empleado);
                cmd.Parameters.AddWithValue(@"ACTIVO_OUT_IN", activo_out_in);
                cmd.Parameters.AddWithValue(@"IMG", img);
                cmd.Parameters.AddWithValue(@"FECHA_ACTUALIZACION", fecha_actualizacion);
                cmd.ExecuteNonQuery();
                //--------------------------------------------
                CN_IM.Close();

            }
            catch (Exception ex)
            {

            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="compania"></param>
        /// <param name="num_activo"></param>
        /// <param name="serie_activo"></param>
        /// <param name="descripcion_activo"></param>
        /// <param name="marca_activo"></param>
        /// <param name="tag_rfid_activo"></param>
        /// <param name="cod_empleado"></param>
        /// <param name="nombre_empleado"></param>
        /// <param name="tag_rfid_empleado"></param>
        /// <param name="activo_out_in"></param>
        /// <param name="img"></param>
        /// <param name="fecha_actualizacion"></param>
        /// <returns></returns>
        public DataTable IMPORTAR_IMAGES(DateTime fecha)
        {
            //CONEXION
            string CNX = CARGAR_CONFIGURACION_SERVIDOR_NUBE();
            SqlConnection CN_IM = new SqlConnection(CNX);

            DataTable dt = new DataTable();
            try
            {
                CN_IM.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_IMPORTAR_IMAGES";
                SqlCommand cmd = new SqlCommand(SQL, CN_IM);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(@"fecha", fecha);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                //--------------------------------------------
                CN_IM.Close();

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void IMPORTAR_ACTUALIZAR_IMAGENES(byte[] IMAGEN, string CODIGO_EMPLEADO , string TAG_RFID)
        {
            //CONEXION
            string CNX = CARGAR_CONFIGURACION_LOCAL();
            SqlConnection CN_IM = new SqlConnection(CNX);

            try
            {
                CN_IM.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_IMPORTAR_ACTUALIZAR_IMAGES";
                SqlCommand cmd = new SqlCommand(SQL, CN_IM);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(@"IMG_EMPLEADO", IMAGEN);
                cmd.Parameters.AddWithValue(@"COD_EMPLEADO", CODIGO_EMPLEADO);
                cmd.Parameters.AddWithValue(@"TAG_RFID", TAG_RFID);
                cmd.ExecuteNonQuery();
                //--------------------------------------------
                CN_IM.Close();

            }
            catch (Exception ex)
            {

            }
        }


        #endregion

        ///////////////////////////////////////


        #region CONSULTAR FECHA ACTUALIZACION
        
        
        /// <summary>
        /// CONSULTAR FECHA DE ULTIMA ACTUALIZACION
        /// </summary>
        /// <returns></returns>
        public DataTable FECHA_ULTIMA_ACTUALIZACION()
        {
            string CNX = CARGAR_CONFIGURACION_LOCAL();
            SqlConnection CN_EX = new SqlConnection(CNX);

            DataTable dt = new DataTable();
            try
            {
                CN_EX.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_FECHA_ULTIMA_ACTUALIZACION";
                SqlCommand cmd = new SqlCommand(SQL, CN_EX);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                //--------------------------------------------
                CN_EX.Close();

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion


        ///////////////////////////////////////


        #region ENVIAR_EMAIL

        public bool ENVIAR_EMAIL(string estado, DateTime fecha, string mensaje_Exportacion, int registros_exportados, string mensaje_Importacion_Catalogo_activos, int registros_importados, string estado_de_arranque)
        {
            try
            {
                /////////////////////////////////////////////////////////////////////
                //PARAMETROS DEL ENVIO DE CORREO

                //EMISOR
                string emisor = Properties.Settings.Default.EmisorCorreo;
                string contraseña = Properties.Settings.Default.ContrasenaCorreo;
                //RECEPTOR
                string receptor = Properties.Settings.Default.DestinatarioCorreo;
                //COPIAS
                string Copia = Properties.Settings.Default.CorreoCopia;
                //SERVIDOR
                string servidor = Properties.Settings.Default.ServidorCorreo;
                string puerto = Properties.Settings.Default.PuertoCorreo;
                string ssl = Properties.Settings.Default.Ssl;

                /////////////////////////////////////////////////////////////////////

                /////////////////////////////////////////////////////////////////////
                MailMessage _Correo = new MailMessage(emisor, receptor);
                string destinatario_ = receptor.Trim();
                string emisor_ = emisor.Trim();
                string contraseña_ = contraseña.Trim();
                string servidor_ = servidor;
                string puerto_ = puerto;
                string ssl_ = ssl;
                /////////////////////////////////////////////////////////////////////
                _Correo.From = new MailAddress(emisor);

                //COPIA
                if (Copia != "null")
                {
                    string[] cc = Copia.Split(';');

                    if (cc.Length > 0)
                    {
                        for (int i = 0; i < cc.Length; i++)
                        {
                            _Correo.CC.Add(cc[i]);
                        }
                    }
                }

                //_Correo.CC.Add(Copia); 

                /////////////////////////////////////////////////////////////////////
                _Correo.Subject = "EASY PASS [SINCRONIZACION]";
                /////////////////////////////////////////////////////////////////////
                string html_prueba = @"
                                    <html lang=""en"">
                                        <head>    
                                            <meta content=""text/html; charset=utf-8"" http-equiv=""Content-Type"">
                                            <title>
                                                Upcoming topics
                                            </title>
                                            <style type=""text/css"">
                                                HTML{background-color: #FFFFFF;}
                                                .courses-table{font-size: 12px; padding: 3px; border:0; width:600px;}
                                                .courses-table .description{color: #505050;}
                                                .courses-table td{border: 1px solid #D1D1D1; background-color: #F3F3F3; padding: 0 10px;}
                                                .courses-table th{border: 1px solid #424242; color: #FFFFFF;text-align: left; padding: 0 10px;}
                                                .green{background-color: #4967a5;color:#ffffff;}
                                            </style>
                                        </head>
                                        <body>" +
                                           "<h3 style=' color:#000000; width:600px;'>EASY PASS [" + Properties.Settings.Default.Nombre_Cliente +"] </h3>" +
                                           "</br>" +
                                           "<hr style='color:#980202;'>" +
                                           "<h3 style=' border-color:#FFFFFF; color:#000000; width:600px;'> EL SERVICIO SINCRONIZACIÓN INICIO:  [" + estado_de_arranque + "]</h3>" +
                                           "<h5 style=' color:#000000; width:600px;'>FECHA:  [" + fecha + "]</h5>" +
                                           "</br>" +
                                           "</br>" +
                                            "<table style='font-size: 12px; padding: 3px; border:0; width:900px;'>" +
                                             "<tbody>" +
                                                            "<tr>" +
                                                                  "<th style='background-color:#000000; border-color:#4967a5; color:#FFFFFF; font-size: 16px; width:300px;' >AMS CONTROL PANEL [PORTALES]</th>" +
                                                                  "<td style='width:200px; text-align:center; color:#000000; font-size:14px;'>" + mensaje_Exportacion + "</td>" +
                                                                  "<td style='width:300px; text-align:center; color:#000000; font-size:14px;'>Registros Enviados [AMS Control Panel]:  [ " + registros_exportados + " ]</td>" +
                                                            "</tr>" +
                                                            "<tr>" +
                                                                    "<th>" +
                                                                        "<hr style='color:#000; width:300px;'>" +
                                                                    "</th>" +
                                                                    "<td>" +
                                                                        "<hr style='color:#000; width:300px;'>" +
                                                                    "</td>" +
                                                                    "<td>" +
                                                                        "<hr style='color:#000; width:300px;'>" +
                                                                    "</td>" +

                                                            "</tr>" +
                                                            "<tr>" +
                                                                  "<th style='background-color:#000000; border-color:#4967a5; color:#FFFFFF; font-size: 16px; width:300px;' >EASY PASS</th>" +
                                                                  "<td style='width:200px; text-align:center; color:#000000; font-size:14px;'>" + mensaje_Importacion_Catalogo_activos + "</td>" +
                                                                  "<td style='width:300px; text-align:center; color:#000000; font-size:14px;'>Registros Actualizados [Easy Pass]:  [ " + registros_importados + " ]</td>" +
                                                            "</tr>" +
                                                "</tbody>" +
                                            "</table>" +
                                            "</br>" +
                                            "</br>" +
                                            "</br>" +
                                            "</br>" +
                                            "</br>" +
                                            "<hr style='color:#980202;'>" +
                                            "</br>" +
                                            "<h3 style=' color:#980202; width:600px;'> PROINSA S.A | www.proinsaca.com |  t: +506 40004940  |  f: +506 40004941  </h3>" +
                                            "<h6 style=' color:#980202; width:600px;'> SERVICIO SINCRONIZACIÓN V 2.1 </h6>" +
                                        "</body>" +
                                   "</html>";
                /////////////////////////////////////////////////////////////////////



                /////////////////////////////////////////////////////////////////////
                // MENSAJE
                _Correo.IsBodyHtml = true;
                _Correo.Body = html_prueba;
                _Correo.Priority = MailPriority.Normal;

                /////////////////////////////////////////////////////////////////////
                SmtpClient smtp = new SmtpClient();
                smtp.Credentials = new NetworkCredential(emisor, contraseña);

                smtp.Host = servidor;

                if (ssl == "True")
                    smtp.EnableSsl = true;
                else
                    smtp.EnableSsl = false;
                if (puerto != "0")
                    smtp.Port = Convert.ToInt32(puerto);

                smtp.Send(_Correo);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        
        #endregion
    }
}
