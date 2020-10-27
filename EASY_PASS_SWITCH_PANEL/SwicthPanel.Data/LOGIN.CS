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
using System.Net;
using System.IO;
using System.Net.Http;

namespace EASY_PASS_SWITCH_PANEL.DATA_BASE
{
    class LOGIN
    {

        private static readonly string BaseApiURL = EASY_PASS_SWITCH_PANEL.Properties.Settings.Default.ApiURL;


        ////////////////////////////////////////////////////////////
        ////                        LOGIN                         //
        ////////////////////////////////////////////////////////////

        /// <summary>
        /// VALIDAR SESION DE USUARIO
        /// </summary>
        /// <param name="USUARIO"></param>
        /// <param name="PASSWORD"></param>
        /// <returns></returns>
        public string VALIDAR_LOGIN(string USUARIO, string PASSWORD)
        {

            var url = $"http://localhost:8080/item/" + USUARIO;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            string responseBody;

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null)
                            return "";
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            Console.WriteLine(responseBody);
                        }
                    }
                }

                return responseBody;
            }
            catch (WebException ex)
            {
                return "";
            }











            ////CARGAR CADENA CONEXION
            //string CNX = CARGAR_CONFIGURACION();
            //string CNX_DSC = seguridad.DESCENCRIPTAR(CNX);
            //SqlConnection CN = new SqlConnection(CNX_DSC);


            //DataTable DT = new DataTable();

            //try
            //{
            //    CN.Open();
            //    //--------------------------------------------
            //    string SQL = "EASY_PASS_SWITCH_PANEL_LOGIN_VALIDAR";
            //    SqlCommand cmd = new SqlCommand(SQL, CN);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@USER", USUARIO);
            //    cmd.Parameters.AddWithValue("@PASSWORD", PASSWORD);
            //    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            //    adpt.Fill(DT);
            //    //--------------------------------------------
            //    CN.Close();

            //    return DT;
            //}
            //catch (Exception)
            //{
            //    return null;
            //}
        }

        /// <summary>
        /// VALIDAR CREDENCIALES
        /// </summary>
        /// <param name="USUARIO"></param>
        /// <param name="PASSWORD"></param>
        /// <returns></returns>
        public static async Task<string> ValidarCredenciales(string USUARIO, string PASSWORD)
        {
            string APIMethod = "/api/Login/ValidarCredenciales";
            string data = string.Empty;

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(BaseApiURL + APIMethod + "?" + "USUARIO=" + USUARIO + "&" + "PASSWORD=" + PASSWORD))
                {
                    {
                        using (HttpContent content = res.Content)
                        {
                            data = await content.ReadAsStringAsync();

                            if (data != null)
                            {
                                Console.WriteLine(data);
                                return data;
                            }
                        }
                    }
                }

                return string.Empty;
            }
        }



    }
}
