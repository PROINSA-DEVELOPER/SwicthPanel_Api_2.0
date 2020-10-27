using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace EASY_PASS_SWITCH_PANEL.CLASES
{
    class LOG
    {

        string PATH = Application.StartupPath.ToString() + "\\Logs\\";

        /// <summary>
        /// LOG CONECTION READER
        /// </summary>
        /// <param name="EX"></param>
        /// <param name="IP"></param>
        public void LogConectionReader(string EX, string IP, string PORTAL)
        {
            try
            {
                //NOMBRE DIRECTORIO
                string DIRECTORIO = "Conection\\";

                //NOMBRE ARCHIVO LOG
                string File_Log = "LogConectionReader_" + PORTAL + ".txt";

                //VALIDAR SI EXISTE LA CARPETA PADRE
                if (!(Directory.Exists(PATH + DIRECTORIO)))
                {
                    //CREACION DEL DIRECTORIO PADRE
                    System.IO.Directory.CreateDirectory(PATH + DIRECTORIO);
                }

                //SI EXISTE EL DIRECTORIO, APPEND LOG
                if (Directory.Exists(PATH + DIRECTORIO))
                {
                    using (StreamWriter w = File.AppendText(PATH + DIRECTORIO + File_Log))
                    {
                        w.WriteLine("--------------------------------------------------------");
                        w.WriteLine("FECHA/HORA: " + DateTime.Now);
                        w.WriteLine("");
                        w.WriteLine("PORTAL: " + IP);
                        w.WriteLine("");
                        w.WriteLine("ERROR: " + EX);
                        w.WriteLine("");
                        w.Flush();
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// LOG CONECTION READER
        /// </summary>
        /// <param name="EX"></param>
        /// <param name="IP"></param>
        public void LogBitacoraProcesos(string PORTAL, string ESTADO)
        {
            try
            {
                //NOMBRE DIRECTORIO
                string DIRECTORIO = "BitacoraProcesos\\";

                //NOMBRE ARCHIVO LOG
                string File_Log = "LogBitacoraProcesos.txt";

                //VALIDAR SI EXISTE LA CARPETA PADRE
                if (!(Directory.Exists(PATH + DIRECTORIO)))
                {
                    //CREACION DEL DIRECTORIO PADRE
                    System.IO.Directory.CreateDirectory(PATH + DIRECTORIO);
                }

                //SI EXISTE EL DIRECTORIO, APPEND LOG
                if (Directory.Exists(PATH + DIRECTORIO))
                {
                    using (StreamWriter w = File.AppendText(PATH + DIRECTORIO + File_Log))
                    {
                        w.WriteLine("FECHA/HORA, " + DateTime.Now + ",  PORTAL, " + PORTAL + ",  ESTADO, " + ESTADO);
                        w.WriteLine("");
                        w.Flush();
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// LOG CONECTION READER
        /// </summary>
        /// <param name="EX"></param>
        /// <param name="IP"></param>
        public void LogBitacoraSincronizacion()
        {
            try
            {
                //NOMBRE DIRECTORIO
                string DIRECTORIO = "BitacoraProcesos\\";
                string dia = Convert.ToString(DateTime.Now.Day);
                string mes = Convert.ToString(DateTime.Now.Month);
                string ano = Convert.ToString(DateTime.Now.Year);
                string fecha = dia + "-" + mes + "-" + ano;

                //NOMBRE ARCHIVO LOG
                string File_Log = fecha + "_BitacoraSincronizacion.txt";

                //VALIDAR SI EXISTE LA CARPETA PADRE
                if (!(Directory.Exists(PATH + DIRECTORIO)))
                {
                    //CREACION DEL DIRECTORIO PADRE
                    System.IO.Directory.CreateDirectory(PATH + DIRECTORIO);
                }

                //SI EXISTE EL DIRECTORIO, APPEND LOG
                if (Directory.Exists(PATH + DIRECTORIO))
                {
                    using (StreamWriter w = File.AppendText(PATH + DIRECTORIO + File_Log))
                    {
                        w.WriteLine("FECHA/HORA, " + DateTime.Now );
                        w.WriteLine("");
                        w.Flush();
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// LOG CONECTION EVENTOS
        /// </summary>
        /// <param name="EX"></param>
        /// <param name="IP"></param>
        /// <param name="PORTAL"></param>
        public void LogConectionEventos(string EX, string IP, string PORTAL)
        {
            try
            {
                //NOMBRE DIRECTORIO
                string DIRECTORIO = "Eventos\\";
                string dia = Convert.ToString(DateTime.Now.Day);
                string mes = Convert.ToString(DateTime.Now.Month);
                string ano = Convert.ToString(DateTime.Now.Year);
                string fecha = dia + "-" + mes + "-" + ano;

                //NOMBRE ARCHIVO LOG
                string File_Log = fecha + "_ConectionEventos.txt";

                //VALIDAR SI EXISTE LA CARPETA PADRE
                if (!(Directory.Exists(PATH + DIRECTORIO)))
                {
                    //CREACION DEL DIRECTORIO PADRE
                    System.IO.Directory.CreateDirectory(PATH + DIRECTORIO);
                }

                //SI EXISTE EL DIRECTORIO, APPEND LOG
                if (Directory.Exists(PATH + DIRECTORIO))
                {
                    using (StreamWriter w = File.AppendText(PATH + DIRECTORIO + File_Log))
                    {
                        w.WriteLine("--------------------------------------------------------");
                        w.WriteLine("FECHA/HORA: " + DateTime.Now);
                        w.WriteLine("");
                        w.WriteLine("PORTAL: " + IP);
                        w.WriteLine("");
                        w.WriteLine("ERROR: " + EX);
                        w.WriteLine("");
                        w.Flush();
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        /// <summary>
        /// LOG CONECTION EVENTOS
        /// </summary>
        /// <param name="EX"></param>
        /// <param name="IP"></param>
        /// <param name="PORTAL"></param>
        public void LogLecturasPortales(string IP, string PORTAL, string TAG)
        {
            try
            {
                //NOMBRE DIRECTORIO
                string DIRECTORIO = "Lecturas\\";

                //NOMBRE ARCHIVO LOG
                string dia = Convert.ToString(DateTime.Now.Day);
                string mes = Convert.ToString(DateTime.Now.Month);
                string ano = Convert.ToString(DateTime.Now.Year);
                string fecha = dia + "-" + mes + "-" + ano;
                string File_Log = fecha + "_Portal_" + IP + ".txt";

                //VALIDAR SI EXISTE LA CARPETA PADRE
                if (!(Directory.Exists(PATH + DIRECTORIO)))
                {
                    //CREACION DEL DIRECTORIO PADRE
                    System.IO.Directory.CreateDirectory(PATH + DIRECTORIO);
                }

                //SI EXISTE EL DIRECTORIO, APPEND LOG
                if (Directory.Exists(PATH + DIRECTORIO))
                {
                    using (StreamWriter w = File.AppendText(PATH + DIRECTORIO+ File_Log))
                    {
                        w.WriteLine("FECHA/HORA, " + DateTime.Now + ",  TAG , " + TAG);
                        w.WriteLine("");
                        w.Flush();
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// LOG ERRORES
        /// </summary>
        /// <param name="EX"></param>
        /// <param name="IP"></param>
        /// <param name="PORTAL"></param>
        public void LogError(string IP, string PORTAL, string EX)
        {
            try
            {
                //NOMBRE DIRECTORIO
                string DIRECTORIO = "Error\\";
                string dia = Convert.ToString(DateTime.Now.Day);
                string mes = Convert.ToString(DateTime.Now.Month);
                string ano = Convert.ToString(DateTime.Now.Year);
                string fecha = dia + "-" + mes + "-" + ano;

                //NOMBRE ARCHIVO LOG
                string File_Log = fecha + "_LogError.txt";

                //VALIDAR SI EXISTE LA CARPETA PADRE
                if (!(Directory.Exists(DIRECTORIO)))
                {
                    //CREACION DEL DIRECTORIO PADRE
                    System.IO.Directory.CreateDirectory(DIRECTORIO);
                }

                //SI EXISTE EL DIRECTORIO, APPEND LOG
                if (Directory.Exists(DIRECTORIO))
                {
                    using (StreamWriter w = File.AppendText(PATH + File_Log))
                    {
                        w.WriteLine("--------------------------------------------------------");
                        w.WriteLine("FECHA/HORA: " + DateTime.Now);
                        w.WriteLine("");
                        w.WriteLine("PORTAL: " + IP);
                        w.WriteLine("");
                        w.WriteLine("ERROR: " + EX);
                        w.WriteLine("");
                        w.Flush();
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }

  
}
