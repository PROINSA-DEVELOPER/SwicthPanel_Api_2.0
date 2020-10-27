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
    class CONSULTAS
    {

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
        /// GET CATALOGO PORTALES
        /// </summary>
        /// <param name="CODIGO_COMPANIA"></param>
        /// <returns></returns>
        public DataTable SWITCH_PANEL_GET_PORTALES()
        {

            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            DataTable dt = new DataTable();
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
        /// CONSULTA LA INFORMACION DEL PORTAL
        /// </summary>
        /// <param name="CODIGO_COMPANIA"></param>
        /// <returns></returns>
        public DataTable SWITCH_PANEL_GET_INFO_PORTAL( int ID_PORTAL)
        {

            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            DataTable dt = new DataTable();
            try
            {
                CN.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_GET_INFO_PORTAL";
                SqlCommand cmd = new SqlCommand(SQL, CN);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@CODIGO_COMPANIA", CODIGO_COMPANIA);
                cmd.Parameters.AddWithValue("@ID_PORTAL", ID_PORTAL);
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
        /// CONSULTA LA LICENCIA DEL PORTAL
        /// </summary>
        /// <param name="CODIGO_COMPANIA"></param>
        /// <param name="ID_PORTAL"></param>
        /// <returns></returns>
        public DataTable CONSULTAR_LICENCIA_PORTAL( int ID_PORTAL)
        {
            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            DataTable dt = new DataTable();
            try
            {
                CN.Open();
                //--------------------------------------------
                string SQL = "AMS_EASY_PASS_SWITCH_PANEL_PORTAL_LICENCIA";
                SqlCommand cmd = new SqlCommand(SQL, CN);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@CODIGO_COMPANIA", CODIGO_COMPANIA);
                cmd.Parameters.AddWithValue("@ID_PORTAL", ID_PORTAL);
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
        /// LECTURA DEL ARCHIVO CONFIG
        /// </summary>
        /// <returns></returns>
        public DataTable PARAMETROS_GENERALES()
        {
            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            DataTable dt = new DataTable();
            try
            {
                CN.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_PARAMETROS";
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
        /// GUARDAR PARAMETRO
        /// </summary>
        /// <param name="PARAMETRO"></param>
        public void GUARDAR_PARAMETRO(string PARAMETRO)
        {
            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            try
            {
                CN.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_PARAMETROS_UPDATE";
                SqlCommand cmd = new SqlCommand(SQL, CN);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PARAMETRO", PARAMETRO);
                cmd.ExecuteNonQuery();
                //--------------------------------------------
                CN.Close();

            }
            catch (Exception ex)
            {

            }
        }


        /// <summary>
        /// GUARDAR PARAMETRO
        /// </summary>
        /// <param name="PARAMETRO"></param>
        public void TURN_OFF_ALL_READER()
        {
            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            try
            {
                CN.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_TURN_OFF";
                SqlCommand cmd = new SqlCommand(SQL, CN);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                //--------------------------------------------
                CN.Close();

            }
            catch (Exception ex)
            {

            }
        }



        #region PORTAL [FUNCIONES]
        
        
        /// <summary>
        /// CONSULTA EL ESTADO PARA PODER EJECUTAR LA FUNCIONALIDAD DEL PORTAL
        /// </summary>
        /// <param name="CODIGO_COMPANIA"></param>
        /// <param name="ID_PORTAL"></param>
        /// <returns></returns>
        public DataTable CONSULTAR_ESTADO_PORTAL( int ID_PORTAL)
        {
            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            DataTable dt = new DataTable();
            try
            {
                CN.Open();
                //--------------------------------------------
                string SQL = "EASY_PASS_SWITCH_PANEL_GET_INFO_PORTAL";
                SqlCommand cmd = new SqlCommand(SQL, CN);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@CODIGO_COMPANIA", "");
                cmd.Parameters.AddWithValue("@ID_PORTAL", ID_PORTAL);
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
        /// CAMBIAR ESTADO DEL PORTAL [ON / OFF]
        /// </summary>
        /// <param name="ID_PORTAL"></param>
        /// <returns></returns>
        public bool UPDATE_ESTADO_PORTAL(int ID_PORTAL, bool ESTADO)
        {
            //CARGAR CADENA CONEXION
            string CNX = CARGAR_CONFIGURACION();
            SqlConnection CN = new SqlConnection(CNX);

            DataTable dt = new DataTable();
            try
            {
                CN.Open();
                //--------------------------------------------
                string SQL = "AMS_EASY_PASS_SWITCH_PANEL_UPDATE_PORTAL_ESTADO";
                SqlCommand cmd = new SqlCommand(SQL, CN);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_PORTAL", ID_PORTAL);
                cmd.Parameters.AddWithValue("@ESTADO", ESTADO);
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




        #endregion
    }
}
