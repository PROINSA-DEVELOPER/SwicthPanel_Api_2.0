using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EASY_PASS_SWITCH_PANEL.SwicthPanel.Data
{
    public class ApiConfiguracion
    {
        private static readonly string BaseApiURL = EASY_PASS_SWITCH_PANEL.Properties.Settings.Default.ApiURL;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="USUARIO"></param>
        /// <param name="PASSWORD"></param>
        /// <returns></returns>
        public static async Task<string> GetPortalInformation()
        {
            string APIMethod = "/api/RFIDPortal";
            string data = string.Empty;

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(BaseApiURL + APIMethod))
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
