using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EASY_PASS_SWITCH_PANEL.CLASES
{
    class SEGURIDAD
    {
        /// <summary>
        /// ENCRIPTAR DATOS BASE 64
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public string ENCRITAR(string cadena)
        {
            try
            {
                string result = string.Empty;
                byte[] encryted = System.Text.Encoding.Unicode.GetBytes(cadena);
                result = Convert.ToBase64String(encryted);

                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// DESCENCRIPTAR DATOS BASE 64
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public string DESCENCRIPTAR(string cadena)
        {
            try
            {
                string result = string.Empty;
                byte[] decryted = Convert.FromBase64String(cadena);
                result = System.Text.Encoding.Unicode.GetString(decryted);

                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }


    }
}
