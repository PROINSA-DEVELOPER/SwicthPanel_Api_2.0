using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Data;
using System.Windows.Forms;

namespace EASY_PASS_SWITCH_PANEL.FUNCIONES
{
    public class ARCHIVOS
    {

        //INSTANCIAR OBJETO
        CLASES.SEGURIDAD seguridad = new CLASES.SEGURIDAD();

        /// <summary>
        /// CREAR DIRECTORIO CONFIG
        /// </summary>
        /// <param name="PATH_DIRECTORIO"></param>
        /// <param name="CONFIG_NAME"></param>
        /// <param name="TM_SINCRONIZACION"></param>
        /// <param name="TM_COMPROBAR_READER"></param>
        /// <param name="PATH_BLACKIST"></param>
        /// <returns></returns>
        public bool CREAR_DIRECTORIO_CONFIGURACION(string PATH_DIRECTORIO, string CONFIG_NAME, string TM_SINCRONIZACION, bool STATUS_SINCRONIZADOR, string TM_COMPROBAR_READER, string PATH_BLACKIST)
        {
            try
            {
                //VALIDAR SI EXISTE LA CARPETA PADRE
                if (!(Directory.Exists(PATH_DIRECTORIO)))
                {
                    //CREACION DEL DIRECTORIO PADRE
                    System.IO.Directory.CreateDirectory(PATH_DIRECTORIO);

                }

                //VALIDAR SI EXISTE LA CARPETA BLACKLIST
                if (!(Directory.Exists(PATH_BLACKIST)))
                {
                    //CREACION DEL DIRECTORIO BLACKLIST
                    System.IO.Directory.CreateDirectory(PATH_BLACKIST);

                }


                if (Directory.Exists(PATH_DIRECTORIO))
                {
                    //Verificamos si existe el archivo
                    if (System.IO.File.Exists(PATH_DIRECTORIO))
                    {
                        Console.WriteLine("\nEl archivo ya existe.");
                    }
                    else
                    {
                        //NOMBRE DEL ARCHIVO CONFIG
                        string NOMBRE_TXT = CONFIG_NAME;

                        using (StreamWriter sw = new StreamWriter(PATH_DIRECTORIO + NOMBRE_TXT))
                        {
                            //TM SINCRONIZACION
                            sw.WriteLine(seguridad.ENCRITAR(TM_SINCRONIZACION));
                            //TM_COMPROBACION_READER
                            sw.WriteLine(seguridad.ENCRITAR(TM_COMPROBAR_READER));
                            //PATH DIRECTORIO
                            sw.WriteLine(seguridad.ENCRITAR(PATH_DIRECTORIO));
                            //PATH BLACKLIST
                            sw.WriteLine(seguridad.ENCRITAR(PATH_BLACKIST));
                            //STATUS SINCRONIZADOR
                            sw.WriteLine(STATUS_SINCRONIZADOR);
                            sw.WriteLine("---------------------");
                            sw.WriteLine("PROINSA PROYECTOS INTELIGENTES");
                            sw.WriteLine("SWITCH PANEL V1.0.0");
                        }
                    }
                }

                return true;
            }
            catch (Exception errorC)
            {

                return false;
            } 
        }

        /// <summary>
        /// CREAR DIRECTORIO CONFIG
        /// </summary>
        /// <param name="PATH_DIRECTORIO"></param>
        /// <param name="CONFIG_NAME"></param>
        /// <param name="TM_SINCRONIZACION"></param>
        /// <param name="TM_COMPROBAR_READER"></param>
        /// <param name="PATH_BLACKIST"></param>
        /// <returns></returns>
        public bool CREAR_DIRECTORIO_CONFIGURACION_SERVIDOR_CORREO(string SERVIDOR, string PUERTO, string SSL, string EMISOR_EMAIL, string PASSWORD_EMAIL)
        {

            try
            {
                //RUTA DEL DIRECTORIO
                string PATH_DIRECTORIO = Application.StartupPath.ToString() + "\\Settings\\Email\\";

                //VALIDAR SI EXISTE LA CARPETA PADRE
                if (!(Directory.Exists(PATH_DIRECTORIO)))
                {
                    //CREACION DEL DIRECTORIO PADRE
                    System.IO.Directory.CreateDirectory(PATH_DIRECTORIO);

                }

                if (Directory.Exists(PATH_DIRECTORIO))
                {
                    //Verificamos si existe el archivo
                    if (System.IO.File.Exists(PATH_DIRECTORIO))
                    {
                        Console.WriteLine("\nEl archivo ya existe.");
                    }
                    else
                    {
                        //NOMBRE DEL ARCHIVO CONFIG
                        string NOMBRE_TXT = "ConfigEmail.txt";

                        using (StreamWriter sw = new StreamWriter(PATH_DIRECTORIO + NOMBRE_TXT))
                        {
                            //SERVIDOR
                            sw.WriteLine(seguridad.ENCRITAR(SERVIDOR));
                            //PUERTO
                            sw.WriteLine(seguridad.ENCRITAR(PUERTO));
                            //SSL
                            sw.WriteLine(seguridad.ENCRITAR(SSL));
                            //EMAIL EMISOR
                            sw.WriteLine(seguridad.ENCRITAR(EMISOR_EMAIL));
                            //EMAIL PASSWORD
                            sw.WriteLine(seguridad.ENCRITAR(PASSWORD_EMAIL));
                            sw.WriteLine("---------------------");
                            sw.WriteLine("PROINSA PROYECTOS INTELIGENTES");
                            sw.WriteLine("SWITCH PANEL V1.0.0");
                        }
                    }
                }

                return true;
            }
            catch (Exception EX)
            {
                return false;
            }
        }

        /// <summary>
        /// CREAR Y AGREGAR TAG RFID AL ARCHIVO 
        /// </summary>
        /// <param name="PATH_BLACKLIST"></param>
        /// <param name="NOMBRE_ARCHIVO"></param>
        /// <param name="TAG_RFID"></param>
        /// <returns></returns>
        public string CREAR_ARCHIVO_BLACKLIST(string PATH_BLACKLIST, string NOMBRE_ARCHIVO, string TAG_RFID)
        {
            string RESPUESTA = "";

            try
            {
                //NOMBRE Y FORMATO
                NOMBRE_ARCHIVO = NOMBRE_ARCHIVO + ".txt";
                //PATH
                PATH_BLACKLIST = System.IO.Path.Combine(PATH_BLACKLIST, NOMBRE_ARCHIVO);

                using (StreamWriter sw = File.AppendText(PATH_BLACKLIST))
                {
                    sw.WriteLine(TAG_RFID);
                }

                RESPUESTA = "TAG AGREGADO A LA BLACKLIST";

                
                return RESPUESTA;
                
            }
            catch (Exception e)
            {
                RESPUESTA = e.ToString();
                return RESPUESTA;
            }
        }

        /// <summary>
        /// LECTURA DEL ARCHIVO CONFIG
        /// </summary>
        /// <returns></returns>
        public DataTable  LEER_ARCHIVO()
        {
            //VARIABLES
            DataTable DT_CONFIG = new DataTable();

            string TM_SINRONIZAR = "";
            string TM_COMPROBACION_READER = ""; 
            string PATH_PADRE = "";
            string PATH_BLACKLIST = "";
            string STATUS_SINCRONIZADOR = "";

            try
            {
               string PATH = Application.StartupPath.ToString() + "\\Settings\\";
               string FILE_CONFIG = "Config";
               string FORMATO = ".txt";
               string PATH_VERIFICAR = PATH + FILE_CONFIG + FORMATO;

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
                           TM_SINRONIZAR = seguridad.DESCENCRIPTAR(line);
                       }
                       if (counter == 2)
                       {
                           TM_COMPROBACION_READER = seguridad.DESCENCRIPTAR(line);
                       }
                       if (counter == 3)
                       {
                           PATH_PADRE = seguridad.DESCENCRIPTAR(line);
                       }
                       if (counter == 4)
                       {
                           PATH_BLACKLIST = seguridad.DESCENCRIPTAR(line);
                       }
                       if (counter == 5)
                       {
                           STATUS_SINCRONIZADOR = line;
                       }

                   }

                   //CREAR DATATABLE

                   //COLUMNAS
                   DT_CONFIG.Columns.Add("TM_SINCRONIZAR", typeof(string));
                   DT_CONFIG.Columns.Add("TM_COMPROBACION_READER", typeof(string));
                   DT_CONFIG.Columns.Add("PATH_CONFIG", typeof(string));
                   DT_CONFIG.Columns.Add("PATH_BLACKLIST", typeof(string));
                   DT_CONFIG.Columns.Add("STATUS_SINCRNIZADOR", typeof(string));

                   //ROWS
                   DT_CONFIG.Rows.Add(TM_SINRONIZAR, TM_COMPROBACION_READER, PATH_PADRE, PATH_BLACKLIST, STATUS_SINCRONIZADOR);

                   file.Close();

               }
               else
               {
                   Console.WriteLine("El archivo especificado no se ha encontrado.");
               }
               return DT_CONFIG;
            }
            catch (Exception)
            {

                return null;
            }
        }

        /// <summary>
        /// LECTURA DEL ARCHIVO CONFIG
        /// </summary>
        /// <returns></returns>
        public DataTable LEER_ARCHIVO_CONFIG_SERVIDOR()
        {
            //VARIABLES
            DataTable DT_CONFIG = new DataTable();

            string SERVIDOR = "";
            string PUERTO = "";
            string SSL = "";
            string EMAIL_EMISOR = "";
            string PASSWORD_EMISOR = "";

            try
            {
                //RUTA DEL DIRECTORIO
                string PATH_DIRECTORIO = Application.StartupPath.ToString() + "\\Settings\\Email\\";
                string NOMBRE_TXT = "ConfigEmail.txt";
                string PATH_VERIFICAR = PATH_DIRECTORIO + NOMBRE_TXT;

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
                            SERVIDOR = seguridad.DESCENCRIPTAR(line);
                        }
                        if (counter == 2)
                        {
                            PUERTO = seguridad.DESCENCRIPTAR(line);
                        }
                        if (counter == 3)
                        {
                            SSL = seguridad.DESCENCRIPTAR(line);
                        }
                        if (counter == 4)
                        {
                            EMAIL_EMISOR = seguridad.DESCENCRIPTAR(line);
                        }
                        if (counter == 5)
                        {
                            PASSWORD_EMISOR = seguridad.DESCENCRIPTAR(line);
                        }

                    }

                    //CREAR DATATABLE

                    //COLUMNAS
                    DT_CONFIG.Columns.Add("SERVIDOR", typeof(string));
                    DT_CONFIG.Columns.Add("PUERTO", typeof(string));
                    DT_CONFIG.Columns.Add("SSL", typeof(string));
                    DT_CONFIG.Columns.Add("EMAIL_EMISOR", typeof(string));
                    DT_CONFIG.Columns.Add("PASSWORD_EMISOR", typeof(string));

                    //ROWS
                    DT_CONFIG.Rows.Add(SERVIDOR, PUERTO, SSL, EMAIL_EMISOR, PASSWORD_EMISOR);

                    file.Close();

                }
                else
                {
                    Console.WriteLine("El archivo especificado no se ha encontrado.");
                }
                return DT_CONFIG;
            }
            catch (Exception)
            {

                return null;
            }
        }

        /// <summary>
        /// LECTURA DEL ARCHIVO CONFIG DEL MODO AUTOMATICO
        /// </summary>
        /// <returns></returns>
        public DataTable LEER_ARCHIVO_CONFIG_MODO_AUTOMATICO()
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

                        if (counter == 10)
                        {
                            //CNX SINC
                            MODO_AUTOMATICO = line;
                        }
                    }


                    //CREAR DATATABLE

                    //COLUMNAS CNX
                    DT.Columns.Add("MODO_AUTOMATICO", typeof(string));

                    //ROWS
                    DT.Rows.Add( MODO_AUTOMATICO);

                    file.Close();
                }
                return DT;
            }
            catch (Exception)
            {

                return null;
            }
        }

       
        public void EDITAR_ARCHIVO()
        {

        }

    }

}
