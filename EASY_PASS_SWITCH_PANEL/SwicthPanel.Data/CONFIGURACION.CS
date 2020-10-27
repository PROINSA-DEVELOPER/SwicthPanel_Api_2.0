using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace EASY_PASS_SWITCH_PANEL.DATA_BASE
{
    class CONFIGURACION
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
        private string CARGAR_CONFIGURACION()
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

        //////////////////////////////////////////////////////////////////

        /// <summary>
        /// GET DATO PORTAL
        /// </summary>
        /// <param name="CODIGO_COMPANIA"></param>
        /// <returns></returns>
        public DataTable GET_DATOS_PORTALES(string ID_PORTAL)
        {
            DataTable dt = new DataTable();

            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            try
            {
                CN.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_GET_DATOS_PORTAL";
                SqlCommand cmd = new SqlCommand(SQL, CN);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@CODIGO_COMPANIA", CODIGO_COMPANIA);
                cmd.Parameters.AddWithValue("@ID_PORTAL", Convert.ToInt32(ID_PORTAL));
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
        /// 
        /// </summary>
        /// <param name="CODIGO_COMPANIA"></param>
        /// <returns></returns>
        public DataTable GET_PORTALES()
        {
            DataTable dt = new DataTable();

            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            try
            {
                CN.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_GET_PORTALES";
                SqlCommand cmd = new SqlCommand(SQL, CN);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@CODIGO_COMPANIA", CODIGO_COMPANIA);
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
        /// 
        /// </summary>
        /// <param name="CODIGO_COMPANIA"></param>
        /// <returns></returns>
        public DataTable GET_CATALOGO_MODELO_READERS(string ID_READER)
        {
            DataTable dt = new DataTable();

            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            try
            {

                if(ID_READER == "")
                {
                    ID_READER = "0";
                }

                CN.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_GET_CATALOGO_MODELO_READERS";
                SqlCommand cmd = new SqlCommand(SQL, CN);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_READER", Convert.ToInt32(ID_READER));
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
        /// INSERTAR O MODIFICAR DATOS DEL READER
        /// </summary>
        /// <param name="MODELO"></param>
        /// <param name="IMAGEN"></param>
        /// <returns></returns>
        public bool INSERT_UPDATE_DATOS_READER(string MODELO, byte[] IMAGEN)
        {
            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            try
            {
                CN.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_INSERT_MODELO_READER";
                SqlCommand cmd = new SqlCommand(SQL, CN);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NOMBRE_MODELO", MODELO);
                cmd.Parameters.AddWithValue("@IMAGEN", IMAGEN);
                cmd.ExecuteNonQuery();
                //--------------------------------------------
                CN.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CODIGO_COMPANIA"></param>
        /// <returns></returns>
        public bool UPDATE_DATOS_PORTAL(string ID_PORTAL,string IP_PORTAL, string NOMBRE_PORTAL, string NOMBRE_READER, int MODELO_READER, string SERIE_READER, string EMAIL_READER, string EMAIL_COPIAS, bool ESTADO)
        {

            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);


            try
            {
                CN.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_UPDATE_DATOS_PORTAL";
                SqlCommand cmd = new SqlCommand(SQL, CN);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_PORTAL", ID_PORTAL);
                cmd.Parameters.AddWithValue("@IP_PORTAL", IP_PORTAL);
                cmd.Parameters.AddWithValue("@NOMBRE_PORTAL", NOMBRE_PORTAL);
                cmd.Parameters.AddWithValue("@NOMBRE_READER", NOMBRE_READER);
                cmd.Parameters.AddWithValue("@MODELO_READER", MODELO_READER);
                cmd.Parameters.AddWithValue("@SERIE_READER", SERIE_READER);
                cmd.Parameters.AddWithValue("@EMAIL_READER", EMAIL_READER);
                cmd.Parameters.AddWithValue("@EMAIL_COPIAS", EMAIL_COPIAS);
                cmd.Parameters.AddWithValue("@ESTADO_EMAIL", ESTADO);
                cmd.ExecuteNonQuery();
                //--------------------------------------------
                CN.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
