using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EASY_PASS_SWITCH_PANEL.SwicthPanel.Data
{
    public class ApiSincronizacion 
    {
        private static readonly string BaseApiURL = EASY_PASS_SWITCH_PANEL.Properties.Settings.Default.ApiURL;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="USUARIO"></param>
        /// <param name="PASSWORD"></param>
        /// <returns></returns>
        public static async Task<string> Get_ConsultarRFIDPortalStatusLicencia(string USUARIO, string PASSWORD)
        {
            string APIMethod = "/api/RFIDPortal";
            string data = string.Empty;

            var inputData = new Dictionary<string, string>
            {
                { "Usuario", USUARIO },
                { "Password", PASSWORD}
            };

            var input = new FormUrlEncodedContent(inputData);

            using (HttpClient client = new HttpClient())
            {
                string n = BaseApiURL + APIMethod + "?" + USUARIO + "&" + PASSWORD;
                using (HttpResponseMessage res = await client.GetAsync(BaseApiURL + APIMethod + "?" + "USUARIO=" + USUARIO + "&" + "PASSWORD=" + PASSWORD))
                {
                    using (HttpContent content = res.Content)
                    {
                        data = await content.ReadAsStringAsync();

                        if (data != null)
                        {

                            Console.WriteLine(n);
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