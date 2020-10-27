using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EASY_PASS_SWITCH_PANEL
{
    public partial class LOGIN : Form
    {

        public LOGIN()
        {
            InitializeComponent();
        }

        /// <summary>
        /// BTN ENTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BTN_LOGIN_ENTER_Click(object sender, EventArgs e)
        {

            try
            {
                //////////////////////////////////////
                //         VALIDAR INGRESO          //
                //////////////////////////////////////

                var response = await DATA_BASE.LOGIN.ValidarCredenciales(TXT_LOGIN_USER.Text, TXT_LOGIN_PASSWORD.Text);
                string JsonString = FUNCIONES.Json.BeautifyJson(response);

                var result = JsonConvert.DeserializeObject<List<SwitchPanel.Entidades.Login>>(JsonString);
                var ObjLogin = result;

                //if (ObjLogin.status == "TRUE")
                if (result.Count > 0)
                {
                    LOGIN FRM_LOGIN = new LOGIN();
                    SWITCH_PANEL FRM_SWITCH_PANEL = new SWITCH_PANEL();

                    FRM_SWITCH_PANEL.LBL_USUARIO.Text = TXT_LOGIN_USER.Text;

                    //APAGAR TODOS LOS PORTALES
                    DATA_BASE.CONSULTAS PORTALES = new DATA_BASE.CONSULTAS();
                    PORTALES.TURN_OFF_ALL_READER();

                    //CERRAMOS VENTANA LOGIN
                    this.Hide();
                    FRM_LOGIN.Visible = false;

                    //ABRIR SWITCH PANEL
                    FRM_SWITCH_PANEL.ShowDialog();
                }
                else
                {
                    MessageBox.Show("USUARIO INVÁLIDO");
                }



            }
            catch (Exception ex)
            {
            }

        }

        /// <summary>
        /// BTN CONFIGURACION
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_CONFIGURACION_Click(object sender, EventArgs e)
        {
            FORMS.SEGURIDAD.CONFIG_DATA_BASE FRM = new FORMS.SEGURIDAD.CONFIG_DATA_BASE();
            FRM.ShowDialog();
        }

        private void LOGIN_Load(object sender, EventArgs e)
        {

        }
    }
}
