using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using NLog;
using System.Data;

namespace EASY_PASS_SWITCH_PANEL.SERVICIOS
{
    class ENVIO_CORREO
    {
        EASY_PASS_SWITCH_PANEL.FUNCIONES.ARCHIVOS Archivos = new EASY_PASS_SWITCH_PANEL.FUNCIONES.ARCHIVOS();

        public bool ENVIAR( string IP_PORTAL, int ID_PORTAL, string TITULO, string MENSAJE)
        {

            /////////////////////////////////////////////////////////////////////
            //CONSULTAR PARAMETROS DEL EMAIL DEL PORTAL
            DATA_BASE.CONSULTAS portal = new DATA_BASE.CONSULTAS();
            DataTable dt_procesado = portal.SWITCH_PANEL_GET_INFO_PORTAL(ID_PORTAL);

            //VARIABLE 
            bool RESPUESTA = false;

            //VALIDAR SI LA CONSULTA ES CORRECTA
            if (dt_procesado.Rows.Count > 0)
            {
                DataRow dr_consultar = dt_procesado.Rows[0];

                //PARAMETROS PORTAL EMAIL
                string ESTADO = dr_consultar["ESTADO_EMAIL"].ToString();
                string EMAIL = dr_consultar["EMAIL"].ToString();
                string COPIAS = dr_consultar["COPIAS_EMAIL"].ToString();

                //VALIDAR ESTADO PARA SU PROCESO DE ENVIO
                if (ESTADO == "True")
                {
                    try
                    {
                        /////////////////////////////////////////////////////////////////////
                        //PARAMETROS DEL ENVIO DE CORREO



                        
                        string SERVIDOR_CONFIG = "";
                        string PUERTO_CONFIG = "";
                        string SSL_CONFIG = "";
                        string EMAIL_EMISOR_CONFIG = "";
                        string PASSWORD_EMISOR_CONFIG = "";

                        //LEER FILE CONFIG
                        DataTable DT = Archivos.LEER_ARCHIVO_CONFIG_SERVIDOR();

                        if (DT.Rows.Count > 0)
                        {
                            DataRow dr = DT.Rows[0];

                            SERVIDOR_CONFIG = dr["SERVIDOR"].ToString();
                            PUERTO_CONFIG = dr["PUERTO"].ToString();
                            SSL_CONFIG = dr["SSL"].ToString();
                            EMAIL_EMISOR_CONFIG = dr["EMAIL_EMISOR"].ToString();
                            PASSWORD_EMISOR_CONFIG = dr["PASSWORD_EMISOR"].ToString();

                        }


                        //EMISOR
                        string EMISOR = EMAIL_EMISOR_CONFIG;
                        string PASSWORD = PASSWORD_EMISOR_CONFIG;
                        //RECEPTOR
                        string RECEPTOR = EMAIL;
                        //COPIAS
                        string COPIA = COPIAS;
                        //SERVIDOR
                        string SERVIDOR = SERVIDOR_CONFIG;
                        string PUERTO = PUERTO_CONFIG;
                        string SSL = SSL_CONFIG;
                        //FECHA
                        DateTime fecha = DateTime.Now;


                        /////////////////////////////////////////////////////////////////////
                        /////////////////////////////////////////////////////////////////////
                        MailMessage _Correo = new MailMessage();
                        //EMISOR
                        _Correo.From = new MailAddress(EMISOR);
                        //RECEPTOR
                        _Correo.To.Add(RECEPTOR);
                        //COPIA
                        if(COPIA == "")
                        {
                            COPIA = "null";
                        }

                        if (COPIA != "null"  )
                        {
                            string[] cc = COPIA.Split(';');

                            if (cc.Length > 0)
                            {
                                for (int i = 0; i < cc.Length; i++)
                                {
                                    _Correo.CC.Add(cc[i]);
                                }
                            }
                        }
                        //ASUNTO
                        _Correo.Subject = TITULO;
                        //MENSAJE
                        _Correo.Body = MENSAJE;
                        /////////////////////////////////////////////////////////////////////
                        string mensaje_html = @"
                               <html lang=""en"">
                                   <head>    
                                       <meta content=""text/html; charset=utf-8"" http-equiv=""Content-Type"">
                                       <title>
                                           Upcoming topics
                                       </title>
                                       <style type=""text/css"">
                                           HTML{background-color: #FFFFFF;}
                                           .courses-table{font-size: 12px; padding: 3px; border:0; width:600px;}
                                           .courses-table .description{color: #505050;}
                                           .courses-table td{border: 1px solid #D1D1D1; background-color: #F3F3F3; padding: 0 10px;}
                                           .courses-table th{border: 1px solid #424242; color: #FFFFFF;text-align: left; padding: 0 10px;}
                                           .green{background-color: #4967a5;color:#ffffff;}
                                       </style>
                                   </head>
                                   <body>" +
                                                   "<h3 style=' color:#000000; width:600px;'>EASY PASS PORTALES [" + Properties.Settings.Default.Nombre_Cliente + "]</h3>" +
                                                   "</br>" +
                                                   "<hr style='color:#8B0000;'>" +
                                                   "<h3 style=' border-color:#FFFFFF; color:#000000; width:600px;'>SERVICIO PORTAL RFID</h3>" +
                                                   "<h5 style=' color:#000000; width:600px;'>FECHA:  [" + fecha + "]</h5>" +
                                                   "</br>" +
                                                   "</br>" +
                                                    "<table style='font-size: 12px; padding: 3px; border:0; width:900px;'>" +
                                                     "<tbody>" +
                                                                    "<tr>" +
                                                                          "<th style='background-color:#000000; border-color:#4967a5; color:#FFFFFF; font-size: 16px; width:300px;' >PORTAL RFID</th>" +
                                                                          "<td style='width:600px; text-align:center; color:#000000; font-size:14px;'>" + IP_PORTAL + "</td>" +
                                                                    "</tr>" +
                                                                    "<tr>" +
                                                                          "<th style='background-color:#000000; border-color:#4967a5; color:#FFFFFF; font-size: 16px; width:300px;' >MENSAJE</th>" +
                                                                          "<td style='width:600px; text-align:center; color:#000000; font-size:14px;'>" + MENSAJE + "</td>" +
                                                                    "</tr>" +
                                                        "</tbody>" +
                                                    "</table>" +
                                                    "</br>" +
                                                    "</br>" +
                                                    "</br>" +
                                                    "</br>" +
                                                    "</br>" +
                                                    "<hr style='color:#8B00005;'>" +
                                                    "</br>" +
                                                    "<h3 style=' color:#8B0000; width:600px;'> PROINSA S.A | www.proinsaca.com |  t: +506 40004940  |  f: +506 40004941  </h3>" +
                                                    "<h6 style=' color:#8B0000; width:600px;'> SERVICIO PORTALES V 2.1 </h6>" +
                                                "</body>" +
                                           "</html>";
                        /////////////////////////////////////////////////////////////////////
                        // MENSAJE
                        _Correo.IsBodyHtml = true;
                        _Correo.Body = mensaje_html;
                        _Correo.Priority = MailPriority.Normal;

                        /////////////////////////////////////////////////////////////////////
                        SmtpClient smtp = new SmtpClient();
                        smtp.Credentials = new NetworkCredential(EMISOR, PASSWORD);

                        smtp.Host = SERVIDOR;

                        if (SSL == "True")
                            smtp.EnableSsl = true;
                        else
                            smtp.EnableSsl = false;
                        if (PUERTO != "0")
                            smtp.Port = Convert.ToInt32(PUERTO);

                        smtp.Send(_Correo);

                        //RETORNA UN TRUE CUANDO SE PROCESO EL ENVIO DE CORREO
                        RESPUESTA = true;
                    }
                    catch (Exception ex)
                    {
                        //RETORNA UN FALSE CUANDO NO SE PROCESO EL ENVIO DE CORREO
                        RESPUESTA = false;
                    }
                }
            }

            //PROECESAR LA RESPUESTA DEL ENVIO DE CORREO
            if (RESPUESTA == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
