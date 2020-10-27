using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Collections;

namespace EASY_PASS_SWITCH_PANEL.FORMS.CONFIGURACION
{
    public partial class CATALOGO_READER : Form
    {
        public CATALOGO_READER()
        {
            InitializeComponent();
        }

        private void BTN_GUARDAR_CATALOGO_READERS_Click(object sender, EventArgs e)
        {
            try
            {
                //PARAMETROS
                OpenFileDialog openDialog = new OpenFileDialog();
                DATA_BASE.CONFIGURACION reader = new DATA_BASE.CONFIGURACION();
                byte[] bytes;


                //RUTA Y NOMBRE
                string file = TXT_PATH.Text;
                //RUTA DEL ARCHIVO
                string filePath = file;
                //NOMBRE Y FORMATO DEL ARCHIVO
                string filename = Path.GetFileName(filePath);
                string ext = Path.GetExtension(filename);
                string contenttype = string.Empty;

                //VALIDAR FORMATO
                switch (ext)
                {
                    case ".jpg":
                        contenttype = "image/jpg";
                        break;
                    case ".png":
                        contenttype = "image/png";
                        break;
                    case ".jpeg":
                        contenttype = "image/jpeg";
                        break;
                }

                if (contenttype != String.Empty)
                {
                    Stream fs = File.OpenRead(filePath);
                    BinaryReader br = new BinaryReader(fs);
                    bytes = br.ReadBytes((Int32)fs.Length);

                    bool respu = reader.INSERT_UPDATE_DATOS_READER(TXT_MODELO.Text, bytes);

                    if (respu == true)
                    {
                        MessageBox.Show("REGISTRO COMPLETADO CON EXITO");
                    }
                    else
                    {
                        MessageBox.Show("ERROR: REGISTRO NO COMPLETADO ");
                    }
                }
                else
                {
                    bytes = null;

                    bool respu = reader.INSERT_UPDATE_DATOS_READER(TXT_MODELO.Text, bytes);

                    if (respu == true)
                    {
                        MessageBox.Show("REGISTRO COMPLETADO CON EXITO");
                    }
                    else
                    {
                        MessageBox.Show("ERROR: REGISTRO NO COMPLETADO ");
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// BTN FILEUPLOAD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_FileUpload_Click(object sender, EventArgs e)
        {

            try
            {
                OpenFileDialog openDialog = new OpenFileDialog();
                openDialog.Title = "Select A File";
                openDialog.Filter = "Image Files (*.png;*.jpg)|*.png;*.jpg";

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    TXT_PATH.Text = openDialog.FileName;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
