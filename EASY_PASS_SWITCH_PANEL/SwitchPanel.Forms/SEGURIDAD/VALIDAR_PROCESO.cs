using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EASY_PASS_SWITCH_PANEL
{
    public partial class VALIDAR_PROCESO : Form
    {
        public bool PermitirAcceso = false;

        public VALIDAR_PROCESO()
        {
            InitializeComponent();
        }

        private void BTN_LOGIN_ENTER_Click(object sender, EventArgs e)
        {
            //////////////////////////////////////
            //         VALIDAR PROCESO          //
            //////////////////////////////////////

            DATA_BASE.LOGIN login = new DATA_BASE.LOGIN();

            //BLOQUEAR PANTALLA
            SWITCH_PANEL FRM_SWITCH_PANEL = new SWITCH_PANEL();
            FRM_SWITCH_PANEL.Enabled = false;

            //CONSUMO Y CONSULTA
            //DataTable dt = login.VALIDAR_LOGIN(TXT_LOGIN_USER.Text, TXT_LOGIN_PASSWORD.Text);


            //if (dt.Rows[0][0].ToString() != "FALSE")
            //{
            //    //APAGAR TODOS LOS PORTALES
            //    DATA_BASE.CONSULTAS PORTALES = new DATA_BASE.CONSULTAS();
            //    PORTALES.TURN_OFF_ALL_READER();


            //    VALIDAR_PROCESO FRM_LOGIN = new VALIDAR_PROCESO();

            //    //CONCEDEMOS EL PERMISO
            //    PermitirAcceso = true;

            //    //CERRAMOS VENTANA LOGIN
            //    FRM_LOGIN.Close();

            //    Environment.Exit(1);
            //}
            //else
            //{
            //    MessageBox.Show("USUARIO INVÁLIDO");
            //}
        }

    }
}
