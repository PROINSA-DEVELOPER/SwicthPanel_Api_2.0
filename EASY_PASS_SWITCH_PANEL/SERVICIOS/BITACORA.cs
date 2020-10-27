using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using NLog;
using System.Windows.Forms;

namespace EASY_PASS_SWITCH_PANEL.SERVICIOS
{
    class BITACORA
    {
        //INSTANCIAR OBJETO
        CLASES.SEGURIDAD seguridad = new CLASES.SEGURIDAD();

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
        private string CARGAR_CONFIGURACION()
        {
            try
            {
                DataTable DT = LEER_ARCHIVO();

                if (DT.Rows.Count > 0)
                {
                    DataRow DR = DT.Rows[0];

                    CONEXION_DB = seguridad.DESCENCRIPTAR( DR["CNX"].ToString());
                }

                return CONEXION_DB;
            }
            catch (Exception)
            {
                return null;
            }
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region METODOS PARA LA COMUNICACION DE LA DATA BASE
        
        
        /// <summary>
        /// QUERY | INSERTAR TAG ENTRADA/SALIDA 
        /// </summary>
        /// <param name="tagData"></param>
        /// <param name="hostName"></param>
        public void INSERTAR_ENTRADA_SALIDA_1(Symbol.RFID3.TagData[] tagData, string hostName)
        {
            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            int ID_ANTENA               = Convert.ToInt32(tagData[0].AntennaID.ToString());
            DateTime FECHA_HORA_LECTURA = DateTime.Now;
            string TAG_RFID             = tagData[0].TagID;
            string EPC_RFID             = tagData[0].TagID;
            string RRSI_READ            = tagData[0].PeakRSSI.ToString(); 
            string HOSTNAME             = hostName;

            try
            {
                //--------------------------------------------
                CN.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_INSERTAR_TAG_PRO_RFID_READS";
                SqlCommand cmd = new SqlCommand(SQL, CN);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_ANTENA",ID_ANTENA );
                cmd.Parameters.AddWithValue("@FECHA_HORA_LECTURA", FECHA_HORA_LECTURA);
                cmd.Parameters.AddWithValue("@TAG_RFID", TAG_RFID);
                cmd.Parameters.AddWithValue("@EPC_RFID", EPC_RFID );
                cmd.Parameters.AddWithValue("@RRSI_READ", RRSI_READ);
                cmd.Parameters.AddWithValue("@ID_READER", HOSTNAME);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                //--------------------------------------------
                CN.Close();
                //--------------------------------------------
                Log.Instance.Info("Tag insertado correctamente: " + tagData[0].TagID);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error al insertar el tag: " + tagData[0].TagID + " - " + ex.ToString(), ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagData"></param>
        /// <param name="hostName"></param>
        public void INSERTAR_ENTRADA_SALIDA_2(Symbol.RFID3.TagData[] tagData, string hostName)
        {
            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            int ID_ANTENA = Convert.ToInt32(tagData[0].AntennaID.ToString());
            DateTime FECHA_HORA_LECTURA = DateTime.Now;
            string TAG_RFID = tagData[0].TagID;
            string EPC_RFID = tagData[0].TagID;
            string RRSI_READ = tagData[0].PeakRSSI.ToString();
            string HOSTNAME = hostName;

            try
            {
                //--------------------------------------------
                CN.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_INSERTAR_TAG_PRO_RFID_READS";
                SqlCommand cmd = new SqlCommand(SQL, CN);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_ANTENA", ID_ANTENA);
                cmd.Parameters.AddWithValue("@FECHA_HORA_LECTURA", FECHA_HORA_LECTURA);
                cmd.Parameters.AddWithValue("@TAG_RFID", TAG_RFID);
                cmd.Parameters.AddWithValue("@EPC_RFID", EPC_RFID);
                cmd.Parameters.AddWithValue("@RRSI_READ", RRSI_READ);
                cmd.Parameters.AddWithValue("@ID_READER", HOSTNAME);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                //--------------------------------------------
                CN.Close();
                //--------------------------------------------
                Log.Instance.Info("Tag insertado correctamente: " + tagData[0].TagID);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error al insertar el tag: " + tagData[0].TagID + " - " + ex.ToString(), ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagData"></param>
        /// <param name="hostName"></param>
        public void INSERTAR_ENTRADA_SALIDA_3(Symbol.RFID3.TagData[] tagData, string hostName)
        {
            //CARGAR CADENA CONEXION
            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            int ID_ANTENA = Convert.ToInt32(tagData[0].AntennaID.ToString());
            DateTime FECHA_HORA_LECTURA = DateTime.Now;
            string TAG_RFID = tagData[0].TagID;
            string EPC_RFID = tagData[0].TagID;
            string RRSI_READ = tagData[0].PeakRSSI.ToString();
            string HOSTNAME = hostName;

            try
            {
                //--------------------------------------------
                CN.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_INSERTAR_TAG_PRO_RFID_READS";
                SqlCommand cmd = new SqlCommand(SQL, CN);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_ANTENA", ID_ANTENA);
                cmd.Parameters.AddWithValue("@FECHA_HORA_LECTURA", FECHA_HORA_LECTURA);
                cmd.Parameters.AddWithValue("@TAG_RFID", TAG_RFID);
                cmd.Parameters.AddWithValue("@EPC_RFID", EPC_RFID);
                cmd.Parameters.AddWithValue("@RRSI_READ", RRSI_READ);
                cmd.Parameters.AddWithValue("@ID_READER", HOSTNAME);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                //--------------------------------------------
                CN.Close();
                //--------------------------------------------
                Log.Instance.Info("Tag insertado correctamente: " + tagData[0].TagID);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error al insertar el tag: " + tagData[0].TagID + " - " + ex.ToString(), ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagData"></param>
        /// <param name="hostName"></param>
        public void INSERTAR_ENTRADA_SALIDA_4(Symbol.RFID3.TagData[] tagData, string hostName)
        {
            //CARGAR CADENA CONEXION
            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            int ID_ANTENA = Convert.ToInt32(tagData[0].AntennaID.ToString());
            DateTime FECHA_HORA_LECTURA = DateTime.Now;
            string TAG_RFID = tagData[0].TagID;
            string EPC_RFID = tagData[0].TagID;
            string RRSI_READ = tagData[0].PeakRSSI.ToString();
            string HOSTNAME = hostName;

            try
            {
                //--------------------------------------------
                CN.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_INSERTAR_TAG_PRO_RFID_READS";
                SqlCommand cmd = new SqlCommand(SQL, CN);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_ANTENA", ID_ANTENA);
                cmd.Parameters.AddWithValue("@FECHA_HORA_LECTURA", FECHA_HORA_LECTURA);
                cmd.Parameters.AddWithValue("@TAG_RFID", TAG_RFID);
                cmd.Parameters.AddWithValue("@EPC_RFID", EPC_RFID);
                cmd.Parameters.AddWithValue("@RRSI_READ", RRSI_READ);
                cmd.Parameters.AddWithValue("@ID_READER", HOSTNAME);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                //--------------------------------------------
                CN.Close();
                //--------------------------------------------
                Log.Instance.Info("Tag insertado correctamente: " + tagData[0].TagID);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error al insertar el tag: " + tagData[0].TagID + " - " + ex.ToString(), ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagData"></param>
        /// <param name="hostName"></param>
        public void INSERTAR_ENTRADA_SALIDA_5(Symbol.RFID3.TagData[] tagData, string hostName)
        {
            //CARGAR CADENA CONEXION
            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            int ID_ANTENA = Convert.ToInt32(tagData[0].AntennaID.ToString());
            DateTime FECHA_HORA_LECTURA = DateTime.Now;
            string TAG_RFID = tagData[0].TagID;
            string EPC_RFID = tagData[0].TagID;
            string RRSI_READ = tagData[0].PeakRSSI.ToString();
            string HOSTNAME = hostName;

            try
            {
                //--------------------------------------------
                CN.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_INSERTAR_TAG_PRO_RFID_READS";
                SqlCommand cmd = new SqlCommand(SQL, CN);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_ANTENA", ID_ANTENA);
                cmd.Parameters.AddWithValue("@FECHA_HORA_LECTURA", FECHA_HORA_LECTURA);
                cmd.Parameters.AddWithValue("@TAG_RFID", TAG_RFID);
                cmd.Parameters.AddWithValue("@EPC_RFID", EPC_RFID);
                cmd.Parameters.AddWithValue("@RRSI_READ", RRSI_READ);
                cmd.Parameters.AddWithValue("@ID_READER", HOSTNAME);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                //--------------------------------------------
                CN.Close();
                //--------------------------------------------
                Log.Instance.Info("Tag insertado correctamente: " + tagData[0].TagID);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error al insertar el tag: " + tagData[0].TagID + " - " + ex.ToString(), ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagData"></param>
        /// <param name="hostName"></param>
        public void INSERTAR_ENTRADA_SALIDA_6(Symbol.RFID3.TagData[] tagData, string hostName)
        {
            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            int ID_ANTENA = Convert.ToInt32(tagData[0].AntennaID.ToString());
            DateTime FECHA_HORA_LECTURA = DateTime.Now;
            string TAG_RFID = tagData[0].TagID;
            string EPC_RFID = tagData[0].TagID;
            string RRSI_READ = tagData[0].PeakRSSI.ToString();
            string HOSTNAME = hostName;

            try
            {
                //--------------------------------------------
                CN.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_INSERTAR_TAG_PRO_RFID_READS";
                SqlCommand cmd = new SqlCommand(SQL, CN);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_ANTENA", ID_ANTENA);
                cmd.Parameters.AddWithValue("@FECHA_HORA_LECTURA", FECHA_HORA_LECTURA);
                cmd.Parameters.AddWithValue("@TAG_RFID", TAG_RFID);
                cmd.Parameters.AddWithValue("@EPC_RFID", EPC_RFID);
                cmd.Parameters.AddWithValue("@RRSI_READ", RRSI_READ);
                cmd.Parameters.AddWithValue("@ID_READER", HOSTNAME);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                //--------------------------------------------
                CN.Close();
                //--------------------------------------------
                Log.Instance.Info("Tag insertado correctamente: " + tagData[0].TagID);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error al insertar el tag: " + tagData[0].TagID + " - " + ex.ToString(), ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagData"></param>
        /// <param name="hostName"></param>
        public void INSERTAR_ENTRADA_SALIDA_7(Symbol.RFID3.TagData[] tagData, string hostName)
        {
            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            int ID_ANTENA = Convert.ToInt32(tagData[0].AntennaID.ToString());
            DateTime FECHA_HORA_LECTURA = DateTime.Now;
            string TAG_RFID = tagData[0].TagID;
            string EPC_RFID = tagData[0].TagID;
            string RRSI_READ = tagData[0].PeakRSSI.ToString();
            string HOSTNAME = hostName;

            try
            {
                //--------------------------------------------
                CN.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_INSERTAR_TAG_PRO_RFID_READS";
                SqlCommand cmd = new SqlCommand(SQL, CN);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_ANTENA", ID_ANTENA);
                cmd.Parameters.AddWithValue("@FECHA_HORA_LECTURA", FECHA_HORA_LECTURA);
                cmd.Parameters.AddWithValue("@TAG_RFID", TAG_RFID);
                cmd.Parameters.AddWithValue("@EPC_RFID", EPC_RFID);
                cmd.Parameters.AddWithValue("@RRSI_READ", RRSI_READ);
                cmd.Parameters.AddWithValue("@ID_READER", HOSTNAME);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                //--------------------------------------------
                CN.Close();
                //--------------------------------------------
                Log.Instance.Info("Tag insertado correctamente: " + tagData[0].TagID);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error al insertar el tag: " + tagData[0].TagID + " - " + ex.ToString(), ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagData"></param>
        /// <param name="hostName"></param>
        public void INSERTAR_ENTRADA_SALIDA_8(Symbol.RFID3.TagData[] tagData, string hostName)
        {
            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            int ID_ANTENA = Convert.ToInt32(tagData[0].AntennaID.ToString());
            DateTime FECHA_HORA_LECTURA = DateTime.Now;
            string TAG_RFID = tagData[0].TagID;
            string EPC_RFID = tagData[0].TagID;
            string RRSI_READ = tagData[0].PeakRSSI.ToString();
            string HOSTNAME = hostName;

            try
            {
                //--------------------------------------------
                CN.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_INSERTAR_TAG_PRO_RFID_READS";
                SqlCommand cmd = new SqlCommand(SQL, CN);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_ANTENA", ID_ANTENA);
                cmd.Parameters.AddWithValue("@FECHA_HORA_LECTURA", FECHA_HORA_LECTURA);
                cmd.Parameters.AddWithValue("@TAG_RFID", TAG_RFID);
                cmd.Parameters.AddWithValue("@EPC_RFID", EPC_RFID);
                cmd.Parameters.AddWithValue("@RRSI_READ", RRSI_READ);
                cmd.Parameters.AddWithValue("@ID_READER", HOSTNAME);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                //--------------------------------------------
                CN.Close();
                //--------------------------------------------
                Log.Instance.Info("Tag insertado correctamente: " + tagData[0].TagID);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error al insertar el tag: " + tagData[0].TagID + " - " + ex.ToString(), ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagData"></param>
        /// <param name="hostName"></param>
        public void INSERTAR_ENTRADA_SALIDA_9(Symbol.RFID3.TagData[] tagData, string hostName)
        {
            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            int ID_ANTENA = Convert.ToInt32(tagData[0].AntennaID.ToString());
            DateTime FECHA_HORA_LECTURA = DateTime.Now;
            string TAG_RFID = tagData[0].TagID;
            string EPC_RFID = tagData[0].TagID;
            string RRSI_READ = tagData[0].PeakRSSI.ToString();
            string HOSTNAME = hostName;

            try
            {
                //--------------------------------------------
                CN.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_INSERTAR_TAG_PRO_RFID_READS";
                SqlCommand cmd = new SqlCommand(SQL, CN);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_ANTENA", ID_ANTENA);
                cmd.Parameters.AddWithValue("@FECHA_HORA_LECTURA", FECHA_HORA_LECTURA);
                cmd.Parameters.AddWithValue("@TAG_RFID", TAG_RFID);
                cmd.Parameters.AddWithValue("@EPC_RFID", EPC_RFID);
                cmd.Parameters.AddWithValue("@RRSI_READ", RRSI_READ);
                cmd.Parameters.AddWithValue("@ID_READER", HOSTNAME);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                //--------------------------------------------
                CN.Close();
                //--------------------------------------------
                Log.Instance.Info("Tag insertado correctamente: " + tagData[0].TagID);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error al insertar el tag: " + tagData[0].TagID + " - " + ex.ToString(), ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagData"></param>
        /// <param name="hostName"></param>
        public void INSERTAR_ENTRADA_SALIDA_10(Symbol.RFID3.TagData[] tagData, string hostName)
        {
            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            int ID_ANTENA = Convert.ToInt32(tagData[0].AntennaID.ToString());
            DateTime FECHA_HORA_LECTURA = DateTime.Now;
            string TAG_RFID = tagData[0].TagID;
            string EPC_RFID = tagData[0].TagID;
            string RRSI_READ = tagData[0].PeakRSSI.ToString();
            string HOSTNAME = hostName;

            try
            {
                //--------------------------------------------
                CN.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_INSERTAR_TAG_PRO_RFID_READS";
                SqlCommand cmd = new SqlCommand(SQL, CN);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_ANTENA", ID_ANTENA);
                cmd.Parameters.AddWithValue("@FECHA_HORA_LECTURA", FECHA_HORA_LECTURA);
                cmd.Parameters.AddWithValue("@TAG_RFID", TAG_RFID);
                cmd.Parameters.AddWithValue("@EPC_RFID", EPC_RFID);
                cmd.Parameters.AddWithValue("@RRSI_READ", RRSI_READ);
                cmd.Parameters.AddWithValue("@ID_READER", HOSTNAME);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                //--------------------------------------------
                CN.Close();
                //--------------------------------------------
                Log.Instance.Info("Tag insertado correctamente: " + tagData[0].TagID);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error al insertar el tag: " + tagData[0].TagID + " - " + ex.ToString(), ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagData"></param>
        /// <param name="hostName"></param>
        public void INSERTAR_ENTRADA_SALIDA_11(Symbol.RFID3.TagData[] tagData, string hostName)
        {
            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            int ID_ANTENA = Convert.ToInt32(tagData[0].AntennaID.ToString());
            DateTime FECHA_HORA_LECTURA = DateTime.Now;
            string TAG_RFID = tagData[0].TagID;
            string EPC_RFID = tagData[0].TagID;
            string RRSI_READ = tagData[0].PeakRSSI.ToString();
            string HOSTNAME = hostName;

            try
            {
                //--------------------------------------------
                CN.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_INSERTAR_TAG_PRO_RFID_READS";
                SqlCommand cmd = new SqlCommand(SQL, CN);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_ANTENA", ID_ANTENA);
                cmd.Parameters.AddWithValue("@FECHA_HORA_LECTURA", FECHA_HORA_LECTURA);
                cmd.Parameters.AddWithValue("@TAG_RFID", TAG_RFID);
                cmd.Parameters.AddWithValue("@EPC_RFID", EPC_RFID);
                cmd.Parameters.AddWithValue("@RRSI_READ", RRSI_READ);
                cmd.Parameters.AddWithValue("@ID_READER", HOSTNAME);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                //--------------------------------------------
                CN.Close();
                //--------------------------------------------
                Log.Instance.Info("Tag insertado correctamente: " + tagData[0].TagID);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error al insertar el tag: " + tagData[0].TagID + " - " + ex.ToString(), ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagData"></param>
        /// <param name="hostName"></param>
        public void INSERTAR_ENTRADA_SALIDA_12(Symbol.RFID3.TagData[] tagData, string hostName)
        {
            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            int ID_ANTENA = Convert.ToInt32(tagData[0].AntennaID.ToString());
            DateTime FECHA_HORA_LECTURA = DateTime.Now;
            string TAG_RFID = tagData[0].TagID;
            string EPC_RFID = tagData[0].TagID;
            string RRSI_READ = tagData[0].PeakRSSI.ToString();
            string HOSTNAME = hostName;

            try
            {
                //--------------------------------------------
                CN.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_INSERTAR_TAG_PRO_RFID_READS";
                SqlCommand cmd = new SqlCommand(SQL, CN);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_ANTENA", ID_ANTENA);
                cmd.Parameters.AddWithValue("@FECHA_HORA_LECTURA", FECHA_HORA_LECTURA);
                cmd.Parameters.AddWithValue("@TAG_RFID", TAG_RFID);
                cmd.Parameters.AddWithValue("@EPC_RFID", EPC_RFID);
                cmd.Parameters.AddWithValue("@RRSI_READ", RRSI_READ);
                cmd.Parameters.AddWithValue("@ID_READER", HOSTNAME);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                //--------------------------------------------
                CN.Close();
                //--------------------------------------------
                Log.Instance.Info("Tag insertado correctamente: " + tagData[0].TagID);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error al insertar el tag: " + tagData[0].TagID + " - " + ex.ToString(), ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagData"></param>
        /// <param name="hostName"></param>
        public void INSERTAR_ENTRADA_SALIDA_13(Symbol.RFID3.TagData[] tagData, string hostName)
        {
            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            int ID_ANTENA = Convert.ToInt32(tagData[0].AntennaID.ToString());
            DateTime FECHA_HORA_LECTURA = DateTime.Now;
            string TAG_RFID = tagData[0].TagID;
            string EPC_RFID = tagData[0].TagID;
            string RRSI_READ = tagData[0].PeakRSSI.ToString();
            string HOSTNAME = hostName;

            try
            {
                //--------------------------------------------
                CN.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_INSERTAR_TAG_PRO_RFID_READS";
                SqlCommand cmd = new SqlCommand(SQL, CN);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_ANTENA", ID_ANTENA);
                cmd.Parameters.AddWithValue("@FECHA_HORA_LECTURA", FECHA_HORA_LECTURA);
                cmd.Parameters.AddWithValue("@TAG_RFID", TAG_RFID);
                cmd.Parameters.AddWithValue("@EPC_RFID", EPC_RFID);
                cmd.Parameters.AddWithValue("@RRSI_READ", RRSI_READ);
                cmd.Parameters.AddWithValue("@ID_READER", HOSTNAME);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                //--------------------------------------------
                CN.Close();
                //--------------------------------------------
                Log.Instance.Info("Tag insertado correctamente: " + tagData[0].TagID);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error al insertar el tag: " + tagData[0].TagID + " - " + ex.ToString(), ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagData"></param>
        /// <param name="hostName"></param>
        public void INSERTAR_ENTRADA_SALIDA_14(Symbol.RFID3.TagData[] tagData, string hostName)
        {
            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            int ID_ANTENA = Convert.ToInt32(tagData[0].AntennaID.ToString());
            DateTime FECHA_HORA_LECTURA = DateTime.Now;
            string TAG_RFID = tagData[0].TagID;
            string EPC_RFID = tagData[0].TagID;
            string RRSI_READ = tagData[0].PeakRSSI.ToString();
            string HOSTNAME = hostName;

            try
            {
                //--------------------------------------------
                CN.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_INSERTAR_TAG_PRO_RFID_READS";
                SqlCommand cmd = new SqlCommand(SQL, CN);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_ANTENA", ID_ANTENA);
                cmd.Parameters.AddWithValue("@FECHA_HORA_LECTURA", FECHA_HORA_LECTURA);
                cmd.Parameters.AddWithValue("@TAG_RFID", TAG_RFID);
                cmd.Parameters.AddWithValue("@EPC_RFID", EPC_RFID);
                cmd.Parameters.AddWithValue("@RRSI_READ", RRSI_READ);
                cmd.Parameters.AddWithValue("@ID_READER", HOSTNAME);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                //--------------------------------------------
                CN.Close();
                //--------------------------------------------
                Log.Instance.Info("Tag insertado correctamente: " + tagData[0].TagID);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error al insertar el tag: " + tagData[0].TagID + " - " + ex.ToString(), ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagData"></param>
        /// <param name="hostName"></param>
        public void INSERTAR_ENTRADA_SALIDA_15(Symbol.RFID3.TagData[] tagData, string hostName)
        {
            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            int ID_ANTENA = Convert.ToInt32(tagData[0].AntennaID.ToString());
            DateTime FECHA_HORA_LECTURA = DateTime.Now;
            string TAG_RFID = tagData[0].TagID;
            string EPC_RFID = tagData[0].TagID;
            string RRSI_READ = tagData[0].PeakRSSI.ToString();
            string HOSTNAME = hostName;

            try
            {
                //--------------------------------------------
                CN.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_INSERTAR_TAG_PRO_RFID_READS";
                SqlCommand cmd = new SqlCommand(SQL, CN);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_ANTENA", ID_ANTENA);
                cmd.Parameters.AddWithValue("@FECHA_HORA_LECTURA", FECHA_HORA_LECTURA);
                cmd.Parameters.AddWithValue("@TAG_RFID", TAG_RFID);
                cmd.Parameters.AddWithValue("@EPC_RFID", EPC_RFID);
                cmd.Parameters.AddWithValue("@RRSI_READ", RRSI_READ);
                cmd.Parameters.AddWithValue("@ID_READER", HOSTNAME);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                //--------------------------------------------
                CN.Close();
                //--------------------------------------------
                Log.Instance.Info("Tag insertado correctamente: " + tagData[0].TagID);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error al insertar el tag: " + tagData[0].TagID + " - " + ex.ToString(), ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagData"></param>
        /// <param name="hostName"></param>
        public void INSERTAR_ENTRADA_SALIDA_16(Symbol.RFID3.TagData[] tagData, string hostName)
        {
            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            int ID_ANTENA = Convert.ToInt32(tagData[0].AntennaID.ToString());
            DateTime FECHA_HORA_LECTURA = DateTime.Now;
            string TAG_RFID = tagData[0].TagID;
            string EPC_RFID = tagData[0].TagID;
            string RRSI_READ = tagData[0].PeakRSSI.ToString();
            string HOSTNAME = hostName;

            try
            {
                //--------------------------------------------
                CN.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_INSERTAR_TAG_PRO_RFID_READS";
                SqlCommand cmd = new SqlCommand(SQL, CN);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_ANTENA", ID_ANTENA);
                cmd.Parameters.AddWithValue("@FECHA_HORA_LECTURA", FECHA_HORA_LECTURA);
                cmd.Parameters.AddWithValue("@TAG_RFID", TAG_RFID);
                cmd.Parameters.AddWithValue("@EPC_RFID", EPC_RFID);
                cmd.Parameters.AddWithValue("@RRSI_READ", RRSI_READ);
                cmd.Parameters.AddWithValue("@ID_READER", HOSTNAME);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                //--------------------------------------------
                CN.Close();
                //--------------------------------------------
                Log.Instance.Info("Tag insertado correctamente: " + tagData[0].TagID);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error al insertar el tag: " + tagData[0].TagID + " - " + ex.ToString(), ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagData"></param>
        /// <param name="hostName"></param>
        public void INSERTAR_ENTRADA_SALIDA_17(Symbol.RFID3.TagData[] tagData, string hostName)
        {
            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            int ID_ANTENA = Convert.ToInt32(tagData[0].AntennaID.ToString());
            DateTime FECHA_HORA_LECTURA = DateTime.Now;
            string TAG_RFID = tagData[0].TagID;
            string EPC_RFID = tagData[0].TagID;
            string RRSI_READ = tagData[0].PeakRSSI.ToString();
            string HOSTNAME = hostName;

            try
            {
                //--------------------------------------------
                CN.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_INSERTAR_TAG_PRO_RFID_READS";
                SqlCommand cmd = new SqlCommand(SQL, CN);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_ANTENA", ID_ANTENA);
                cmd.Parameters.AddWithValue("@FECHA_HORA_LECTURA", FECHA_HORA_LECTURA);
                cmd.Parameters.AddWithValue("@TAG_RFID", TAG_RFID);
                cmd.Parameters.AddWithValue("@EPC_RFID", EPC_RFID);
                cmd.Parameters.AddWithValue("@RRSI_READ", RRSI_READ);
                cmd.Parameters.AddWithValue("@ID_READER", HOSTNAME);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                //--------------------------------------------
                CN.Close();
                //--------------------------------------------
                Log.Instance.Info("Tag insertado correctamente: " + tagData[0].TagID);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error al insertar el tag: " + tagData[0].TagID + " - " + ex.ToString(), ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagData"></param>
        /// <param name="hostName"></param>
        public void INSERTAR_ENTRADA_SALIDA_18(Symbol.RFID3.TagData[] tagData, string hostName)
        {
            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            int ID_ANTENA = Convert.ToInt32(tagData[0].AntennaID.ToString());
            DateTime FECHA_HORA_LECTURA = DateTime.Now;
            string TAG_RFID = tagData[0].TagID;
            string EPC_RFID = tagData[0].TagID;
            string RRSI_READ = tagData[0].PeakRSSI.ToString();
            string HOSTNAME = hostName;

            try
            {
                //--------------------------------------------
                CN.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_INSERTAR_TAG_PRO_RFID_READS";
                SqlCommand cmd = new SqlCommand(SQL, CN);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_ANTENA", ID_ANTENA);
                cmd.Parameters.AddWithValue("@FECHA_HORA_LECTURA", FECHA_HORA_LECTURA);
                cmd.Parameters.AddWithValue("@TAG_RFID", TAG_RFID);
                cmd.Parameters.AddWithValue("@EPC_RFID", EPC_RFID);
                cmd.Parameters.AddWithValue("@RRSI_READ", RRSI_READ);
                cmd.Parameters.AddWithValue("@ID_READER", HOSTNAME);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                //--------------------------------------------
                CN.Close();
                //--------------------------------------------
                Log.Instance.Info("Tag insertado correctamente: " + tagData[0].TagID);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error al insertar el tag: " + tagData[0].TagID + " - " + ex.ToString(), ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagData"></param>
        /// <param name="hostName"></param>
        public void INSERTAR_ENTRADA_SALIDA_19(Symbol.RFID3.TagData[] tagData, string hostName)
        {
            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            int ID_ANTENA = Convert.ToInt32(tagData[0].AntennaID.ToString());
            DateTime FECHA_HORA_LECTURA = DateTime.Now;
            string TAG_RFID = tagData[0].TagID;
            string EPC_RFID = tagData[0].TagID;
            string RRSI_READ = tagData[0].PeakRSSI.ToString();
            string HOSTNAME = hostName;

            try
            {
                //--------------------------------------------
                CN.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_INSERTAR_TAG_PRO_RFID_READS";
                SqlCommand cmd = new SqlCommand(SQL, CN);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_ANTENA", ID_ANTENA);
                cmd.Parameters.AddWithValue("@FECHA_HORA_LECTURA", FECHA_HORA_LECTURA);
                cmd.Parameters.AddWithValue("@TAG_RFID", TAG_RFID);
                cmd.Parameters.AddWithValue("@EPC_RFID", EPC_RFID);
                cmd.Parameters.AddWithValue("@RRSI_READ", RRSI_READ);
                cmd.Parameters.AddWithValue("@ID_READER", HOSTNAME);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                //--------------------------------------------
                CN.Close();
                //--------------------------------------------
                Log.Instance.Info("Tag insertado correctamente: " + tagData[0].TagID);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error al insertar el tag: " + tagData[0].TagID + " - " + ex.ToString(), ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagData"></param>
        /// <param name="hostName"></param>
        public void INSERTAR_ENTRADA_SALIDA_20(Symbol.RFID3.TagData[] tagData, string hostName)
        {
            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            int ID_ANTENA = Convert.ToInt32(tagData[0].AntennaID.ToString());
            DateTime FECHA_HORA_LECTURA = DateTime.Now;
            string TAG_RFID = tagData[0].TagID;
            string EPC_RFID = tagData[0].TagID;
            string RRSI_READ = tagData[0].PeakRSSI.ToString();
            string HOSTNAME = hostName;

            try
            {
                //--------------------------------------------
                CN.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_INSERTAR_TAG_PRO_RFID_READS";
                SqlCommand cmd = new SqlCommand(SQL, CN);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_ANTENA", ID_ANTENA);
                cmd.Parameters.AddWithValue("@FECHA_HORA_LECTURA", FECHA_HORA_LECTURA);
                cmd.Parameters.AddWithValue("@TAG_RFID", TAG_RFID);
                cmd.Parameters.AddWithValue("@EPC_RFID", EPC_RFID);
                cmd.Parameters.AddWithValue("@RRSI_READ", RRSI_READ);
                cmd.Parameters.AddWithValue("@ID_READER", HOSTNAME);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                //--------------------------------------------
                CN.Close();
                //--------------------------------------------
                Log.Instance.Info("Tag insertado correctamente: " + tagData[0].TagID);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error al insertar el tag: " + tagData[0].TagID + " - " + ex.ToString(), ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagData"></param>
        /// <param name="hostName"></param>
        public void INSERTAR_ENTRADA_SALIDA_TEST(Symbol.RFID3.TagData[] tagData, string hostName)
        {
            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            int ID_ANTENA = Convert.ToInt32(tagData[0].AntennaID.ToString());
            DateTime FECHA_HORA_LECTURA = DateTime.Now;
            string TAG_RFID = tagData[0].TagID;
            string EPC_RFID = tagData[0].TagID;
            string RRSI_READ = tagData[0].PeakRSSI.ToString();
            string HOSTNAME = hostName;

            try
            {
                //--------------------------------------------
                CN.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_INSERTAR_TAG_PRO_RFID_READS_TEST";
                SqlCommand cmd = new SqlCommand(SQL, CN);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_ANTENA", ID_ANTENA);
                cmd.Parameters.AddWithValue("@FECHA_HORA_LECTURA", FECHA_HORA_LECTURA);
                cmd.Parameters.AddWithValue("@TAG_RFID", TAG_RFID);
                cmd.Parameters.AddWithValue("@EPC_RFID", EPC_RFID);
                cmd.Parameters.AddWithValue("@RRSI_READ", RRSI_READ);
                cmd.Parameters.AddWithValue("@ID_READER", HOSTNAME);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                //--------------------------------------------
                CN.Close();
                //--------------------------------------------
                Log.Instance.Info("Tag insertado correctamente: " + tagData[0].TagID);
            }
            catch (Exception ex)
            {
                Log.Instance.ErrorException("Error al insertar el tag: " + tagData[0].TagID + " - " + ex.ToString(), ex);
            }
        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region ACTUALIZAR LECTURAS
        
        public void ACTUALIZAR_LECTURAS_EASY_PASS()
        {
            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            try
            {
                //--------------------------------------------
                CN.Open();
                //--------------------------------------------
                string SQL = "RFID_READS_INTERVAL";
                SqlCommand cmd = new SqlCommand(SQL, CN);
                cmd.CommandType = CommandType.StoredProcedure;
                //SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                //--------------------------------------------
                CN.Close();
                //--------------------------------------------
              
            }
            catch (Exception ex)
            {
            }
        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region TEST READS

        /// <summary>
        /// GET TEST READS
        /// </summary>
        /// <returns></returns>
        public DataTable CARGAR_TEST_READS()
        {
            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            DataTable dt = new DataTable();
            try
            {
                CN.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_GET_TEST_READS";
                SqlCommand cmd = new SqlCommand(SQL, CN);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                //--------------------------------------------
                CN.Close();

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// DELETE TEST READS
        /// </summary>
        public void DELETE_TEST_READS()
        {
            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            try
            {
                CN.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_DELETE_TEST_READS";
                SqlCommand cmd = new SqlCommand(SQL, CN);
                cmd.CommandType = CommandType.StoredProcedure;
                //SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                //--------------------------------------------
                CN.Close();
                //--------------------------------------------
            }
            catch (Exception ex)
            {
                
            }
        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////////////

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

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
