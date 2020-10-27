using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace EASY_PASS_SWITCH_PANEL.FUNCIONES
{
    class Json
    {
        /// <summary>
        /// CONVERT JSON STRING TO JSON
        /// </summary>
        /// <param name="JsonString"></param>
        /// <returns></returns>
        public static string BeautifyJson(string JsonString)
        {
            JToken parseJson = JToken.Parse(JsonString);
            return parseJson.ToString(Formatting.Indented);
        }

    }
}
