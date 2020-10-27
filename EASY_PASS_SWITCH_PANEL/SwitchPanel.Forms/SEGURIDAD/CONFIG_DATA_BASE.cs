using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EASY_PASS_SWITCH_PANEL.FORMS.SEGURIDAD
{
    public partial class CONFIG_DATA_BASE : Form
    {
        public CONFIG_DATA_BASE()
        {
            InitializeComponent();
        }


        /// <summary>
        /// CREAR ARCHIVO DE CONFIGURACION DE LAS CADENAS DE CONEXION DATA BASE
        /// </summary>
        /// <param name="CONEXION_PADRE"></param>
        /// <param name="CONEXION_SINCRONIZACION_NUBE"></param>
        private void GENERAR_ARCHIVO_CONFIG(string DDS_CNX , string DCT_CNX, string DUS_CNX, string DPW_CNX, string DDS_SINC, string DCT_SINC, string DUS_SINC, string DPW_SINC, string CONEXION_PADRE,string CONEXION_SINCRONIZACION_NUBE, string MODO_AUTOMATICO)
        {
            try
            {
                //RUTA APP 
                string PATH = Application.StartupPath.ToString() + "\\";

                //VALIDAR SI NO EXISTE LA CARPETA PADRE
                if (!(Directory.Exists(PATH)))
                {
                    //CREACION DEL DIRECTORIO PADRE
                    System.IO.Directory.CreateDirectory(PATH);

                }
                
                //SI EXISTE
                if (Directory.Exists(PATH))
                {
                    //Verificamos si existe el archivo
                    if (System.IO.File.Exists(PATH))
                    {
                        Console.WriteLine("\nEl archivo ya existe.");
                    }
                    else
                    {
                        //NOMBRE DEL ARCHIVO CONFIG
                        string NOMBRE_TXT = "Config_DB.txt";

                        using (StreamWriter sw = new StreamWriter(PATH + NOMBRE_TXT))
                        {

                            //DATA SOURCE
                            sw.WriteLine(DDS_CNX);
                            //CATALOG
                            sw.WriteLine(DCT_CNX);
                            //USER
                            sw.WriteLine(DUS_CNX);
                            //PASS
                            sw.WriteLine(DPW_CNX);

                            //CONEXION PADRE
                            sw.WriteLine(CONEXION_PADRE);

                            //DATA SOURCE
                            sw.WriteLine(DDS_SINC);
                            //CATALOG
                            sw.WriteLine(DCT_SINC);
                            //USER
                            sw.WriteLine(DUS_SINC);
                            //PASS
                            sw.WriteLine(DPW_SINC);

                            //MODO AUTOMATICO
                            sw.WriteLine(MODO_AUTOMATICO);

                            //CONEXION SINCRONIZACION NUBE
                            sw.WriteLine(CONEXION_SINCRONIZACION_NUBE);

                            sw.WriteLine("---------------------");
                            sw.WriteLine("PROINSA PROYECTOS INTELIGENTES");
                            sw.WriteLine("SWITCH PANEL V1.0.0");
                        }
                    }
                }

            }
            catch (Exception )
            {

            } 
        }

        /// <summary>
        /// LECTURA DEL ARCHIVO CONFIG
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

                string MODO_AUTOMATICO = "";

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
                            MODO_AUTOMATICO = line;
                        }
                        if (counter == 12)
                        {
                            //CNX SINC
                            //MODO_AUTOMATICO = line;
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

                    DT.Columns.Add("MODO_AUTOMATICO", typeof(string));

                    //ROWS
                    DT.Rows.Add(DDS_CNX, DCT_CNX, DUS_CNX, DPW_CNX, CNX, DDS_SINC, DCT_SINC, DUS_SINC, DPW_SINC, CNX_SINC, MODO_AUTOMATICO);

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
        private void CARGAR_CONFIGURACION()
        {
            try
            {
                //INSTANCIAR OBJETO

                CLASES.SEGURIDAD seguridad = new CLASES.SEGURIDAD();

                 DataTable DT = LEER_ARCHIVO();

                if(DT.Rows.Count > 0)
                {
                    DataRow DR = DT.Rows[0];

                    TXT_DB_DATA_SOURCE.Text = seguridad.DESCENCRIPTAR(DR["DDS_CNX"].ToString());
                    TXT_DB_CATALOGO.Text = seguridad.DESCENCRIPTAR(DR["DCT_CNX"].ToString());
                    TXT_DB_USER.Text = seguridad.DESCENCRIPTAR(DR["DUS_CNX"].ToString());
                    TXT_DB_PASSWORD.Text = seguridad.DESCENCRIPTAR(DR["DPW_CNX"].ToString());

                    LBL_DB_CADENA.Text = seguridad.DESCENCRIPTAR(DR["CNX"].ToString());

                    TXT_SINC_DATA_SOURCE.Text = seguridad.DESCENCRIPTAR(DR["DDS_SINC"].ToString());
                    TXT_SINC_CATALOGO.Text = seguridad.DESCENCRIPTAR(DR["DCT_SINC"].ToString());
                    TXT_SINC_USER.Text = seguridad.DESCENCRIPTAR(DR["DUS_SINC"].ToString());
                    TXT_SINC_PASSWORD.Text = seguridad.DESCENCRIPTAR(DR["DPW_SINC"].ToString());

                    LBL_SINCRONIZACION.Text = seguridad.DESCENCRIPTAR(DR["CNX_SINC"].ToString());

                    string MODO_AUTOMATICO = DR["MODO_AUTOMATICO"].ToString();//seguridad.DESCENCRIPTAR(DR["MODO_AUTOMATICO"].ToString());

                    if (MODO_AUTOMATICO == "True")
                    {
                        RD_SI.Checked = true;
                    }
                    else
                    {
                        RD_NO.Checked = true;
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// BTN GENERAR CADENAS DE CONEXION DATA BASE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_DB_GENERAR_Click(object sender, EventArgs e)
        {
            #region CONEXION PADRE


            if (radioButton_SQL_USER_ACCOUNT.Checked == true)
            {
                //CADENA DE CONEXION
                LBL_DB_CADENA.Text = "Data Source= " + TXT_DB_DATA_SOURCE.Text + ";" + "Initial Catalog= " + TXT_DB_CATALOGO.Text + ";" + "Persist Security Info= True; User ID=" + TXT_DB_USER.Text + ";" + "Password= " + TXT_DB_PASSWORD.Text + ";";
            }
            if (radioButton_SERVICE_ACCOUNT.Checked == true)
            {
                //CADENA DE CONEXION
                LBL_DB_CADENA.Text = "Data Source= " + TXT_DB_DATA_SOURCE.Text + ";" + "Initial Catalog= " + TXT_DB_CATALOGO.Text + ";" + "Network Library=DBMSSOCN; Persist Security Info= True; Integrated Security=SSPI; User ID=" + TXT_DB_USER.Text + ";" + "Password= " + TXT_DB_PASSWORD.Text + ";";
            }



            #endregion

            #region CONEXION SINCRONIZACION NUBE

            if (radioButton_SQL_USER_ACCOUNT.Checked == true)
            {
                //CADENA DE CONEXION
                LBL_SINCRONIZACION.Text = "Data Source= " + TXT_DB_DATA_SOURCE.Text + ";" + "Initial Catalog= " + TXT_DB_CATALOGO.Text + ";" + "Persist Security Info= True; User ID=" + TXT_DB_USER.Text + ";" + "Password= " + TXT_DB_PASSWORD.Text + ";";
            }
            if (radioButton_SERVICE_ACCOUNT.Checked == true)
            {
                //CADENA DE CONEXION
                LBL_SINCRONIZACION.Text = "Data Source= " + TXT_DB_DATA_SOURCE.Text + ";" + "Initial Catalog= " + TXT_DB_CATALOGO.Text + ";" + "Network Library=DBMSSOCN; Persist Security Info= True; Integrated Security=SSPI; User ID=" + TXT_DB_USER.Text + ";" + "Password= " + TXT_DB_PASSWORD.Text + ";";
            }

            #endregion


            //RUTA APP 
            string PATH = Application.StartupPath.ToString();
            LBL_PATH.Text = PATH;

            BTN_DB_GUARDAR.Visible = true;
        }

        /// <summary>
        /// BTN GUARDAR CADENAS DE CONEXION DATA BASE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_DB_GUARDAR_Click(object sender, EventArgs e)
        {
            //INSTANCIAR OBJETO

            CLASES.SEGURIDAD seguridad = new CLASES.SEGURIDAD();


            #region ENCRIPTAR DATOS
            
            ///////////////////////////////
            //LOCAL
            ///////////////////////////////

            //DATA SOURCE
            string DB_DATA_SOURCE = seguridad.ENCRITAR(TXT_DB_DATA_SOURCE.Text);
            //CATALOGO
            string DB_CATALOGO = seguridad.ENCRITAR( TXT_DB_CATALOGO.Text);
            //USER
            string BD_USER = seguridad.ENCRITAR(TXT_DB_USER.Text);
            //PASWORD
            string DB_PASSWORD = seguridad.ENCRITAR(TXT_DB_PASSWORD.Text);

            //CADENA
            string DB_CADENA = seguridad.ENCRITAR(LBL_DB_CADENA.Text);

            ///////////////////////////////
            //SINCRONIZAR
            ///////////////////////////////

            //DATA SOURCE
            string DB_SC_DATA_SOURCE = seguridad.ENCRITAR(TXT_SINC_DATA_SOURCE.Text);
            //CATALOGO
            string DB_SC_CATALOGO = seguridad.ENCRITAR(TXT_SINC_CATALOGO.Text);
            //USER
            string BD_SC_USER = seguridad.ENCRITAR(TXT_SINC_USER.Text);
            //PASWORD
            string DB_SC_PASSWORD = seguridad.ENCRITAR(TXT_SINC_PASSWORD.Text);

            //CADENA
            string DB_SC_CADENA = seguridad.ENCRITAR(LBL_SINCRONIZACION.Text);

            string MODO_AUTOMATICO = "False";

            #endregion


            if (RD_SI.Checked == true)
            {
                MODO_AUTOMATICO = "True";// seguridad.ENCRITAR("True");
            }
            else
            {
                MODO_AUTOMATICO = "False";//seguridad.ENCRITAR("False");
            }

            GENERAR_ARCHIVO_CONFIG(DB_DATA_SOURCE, DB_CATALOGO, BD_USER, DB_PASSWORD, DB_SC_DATA_SOURCE, DB_SC_CATALOGO, BD_SC_USER, DB_SC_PASSWORD, DB_CADENA, DB_SC_CADENA,MODO_AUTOMATICO);

            MessageBox.Show("CONEXION CREADA", "CONEXION DATA BASE", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_INGRESAR_Click(object sender, EventArgs e)
        {
            if(TXT_USER.Text == "Proinsa" && TXT_PASS.Text == "Proins1.")
            {
                PANEL_DB.Visible = true;
                LBL_MSJ_LOGIN.Visible = false;

                TXT_USER.Enabled = false;
                TXT_PASS.Enabled = false; 
            }
            else
            {
                PANEL_DB.Visible = false;
                LBL_MSJ_LOGIN.Visible = true;
            }
        }

        private void CONFIG_DATA_BASE_Load(object sender, EventArgs e)
        {
            CARGAR_CONFIGURACION();
        }
    }
}
