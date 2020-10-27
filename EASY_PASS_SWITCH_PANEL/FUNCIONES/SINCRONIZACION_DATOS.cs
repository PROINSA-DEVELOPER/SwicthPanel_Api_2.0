using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace EASY_PASS_SWITCH_PANEL.FUNCIONES
{
    class SINCRONIZACION_DATOS
    {


        public string estado_de_arraque = "";

        /// <summary>
        /// INICAR METODO SINCRONIZACION
        /// </summary>
        public void INCIAR()
        {
            try
            {

                ////////////////////////////////////////////////////////////
                DataTable DT_LOCAL = new DataTable();
                DataTable DT_NUBE = new DataTable();
                DataTable DT_NUBE_IMAGENES = new DataTable();
                DataTable dt_Ultima_Fecha_Actualizacion = new DataTable();
                ////////////////////////////////////////////////////////////
                DATA_BASE.SINCRONIZACION Sincronizar = new DATA_BASE.SINCRONIZACION();

                FUNCIONES.SINCRONIZACION_DATOS EMAIL = new SINCRONIZACION_DATOS();
                ////////////////////////////////////////////////////////////
                int flag_Exportacion = 0;
                estado_de_arraque = "CORRECTAMENTE";

                int contador_registros_exportados = 0;
                int Registros_exportados = 0;

                int contador_registros_importados = 0;
                int Registros_importados = 0;


                /////////////////////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////////////////////
                ///////  INICIO DE EXPORTACION DE SERVIDOR LOCAL A SERVIDOR NUBE     ////////
                /////////////////////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////////////////////


                #region EXPORTACION DE SERVIDOR LOCAL A SERVIDOR NUBE

                //EXPORTAR BITACORA ACTIVOS
                try
                {
                    DT_LOCAL = Sincronizar.EXPORTAR_BITACORA_ACTIVOS();

                    //SI EL Data Table CONTIENE MAS DE UNA FILA
                    if (DT_LOCAL.Rows.Count > 0)
                    {
                        //Los datos obtenidos de la tabla bitacora entrada salida 
                        //Deben enviarse a la tabla bitacora entrada salida historico del otro servidor
                        for (int i = 0; i < DT_LOCAL.Rows.Count; i++)
                        {
                            //EXPORTACION BITACORA HISTORICO
                            Sincronizar.EXPORTAR_BITACORA_HISTORICO(DT_LOCAL.Rows[i][0].ToString().Trim(), Convert.ToDateTime(DT_LOCAL.Rows[i][1].ToString().Trim()), DT_LOCAL.Rows[i][2].ToString().Trim(), DT_LOCAL.Rows[i][3].ToString().Trim(), Convert.ToBoolean(DT_LOCAL.Rows[i][4].ToString().Trim()), Convert.ToInt32(DT_LOCAL.Rows[i][5].ToString().Trim()), Convert.ToBoolean(DT_LOCAL.Rows[i][6].ToString().Trim()), DT_LOCAL.Rows[i][7].ToString().Trim(), Convert.ToBoolean(DT_LOCAL.Rows[i][8].ToString().Trim()), false);

                            if (DT_LOCAL.Rows.Count != 0 && i == 0)
                            {
                                Sincronizar.EXPORTAR_BITACORA_ACTIVOS_DELETE();
                            }

                            //CONTADOR DE REGISTROS EXPORTADOS
                            contador_registros_exportados += 1;

                            //ASIGANMOS VALOR [FLAG]
                            flag_Exportacion = 1;
                        }
                        //LIMPIA TODO EL Data Table 
                        DT_NUBE.Clear();

                        //CONSULTAR ULTIMA FECHA DE ACTUALIZACION
                        dt_Ultima_Fecha_Actualizacion = Sincronizar.FECHA_ULTIMA_ACTUALIZACION();
                        DataRow dr_Ultima_Fecha_Actualizacion = dt_Ultima_Fecha_Actualizacion.Rows[0];
                        DateTime UltimaFechaActualizacion = Convert.ToDateTime(dr_Ultima_Fecha_Actualizacion["ULTIMA_FECHA"].ToString());

                        //IMPORTAR ACTIVOS SERVIDOR NUBE A SERVIDR LOCAL
                        DT_NUBE = Sincronizar.IMPORTAR_CONSULTAR_ACTIVOS(UltimaFechaActualizacion);

                    }
                    else
                    {
                        //LIMPIA TODO EL Data Table 
                        DT_NUBE.Clear();

                        //CONSULTAR ULTIMA FECHA DE ACTUALIZACION
                        dt_Ultima_Fecha_Actualizacion = Sincronizar.FECHA_ULTIMA_ACTUALIZACION();
                        DataRow dr_Ultima_Fecha_Actualizacion = dt_Ultima_Fecha_Actualizacion.Rows[0];
                        DateTime UltimaFechaActualizacion = Convert.ToDateTime(dr_Ultima_Fecha_Actualizacion["ULTIMA_FECHA"].ToString());

                        //IMPORTAR ACTIVOS SERVIDOR NUBE A SERVIDR LOCAL
                        DT_NUBE = Sincronizar.IMPORTAR_CONSULTAR_ACTIVOS(UltimaFechaActualizacion);

                        //ASIGANMOS VALOR [FLAG]
                        flag_Exportacion = 2;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                #endregion


                /////////////////////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////////////////////
                //////////////      INICIO DE IMPORTACION DE LOCAL A SERVIDOR     ///////////
                /////////////////////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////////////////////


                #region IMPORTACION SERVIDOR NUBE A SERVIDR LOCAL

                int flag_Importacion = 0;

                try
                {
                    

                    //SI EL Data Table CONTIENE MAS DE UNA FILA
                    if (DT_NUBE.Rows.Count > 0)
                    {
                        for (int i = 0; i < DT_NUBE.Rows.Count; i++)
                        {

                            byte[] IMAGEN = (byte[])(DT_NUBE.Rows[i][10]);

                            //IMPORTA ACTIVOS
                            Sincronizar.IMPORTAR_ACTIVOS(DT_NUBE.Rows[i][0].ToString().Trim(), DT_NUBE.Rows[i][1].ToString().Trim(), DT_NUBE.Rows[i][2].ToString().Trim(), DT_NUBE.Rows[i][3].ToString().Trim(), DT_NUBE.Rows[i][4].ToString().Trim(), DT_NUBE.Rows[i][5].ToString().Trim(), DT_NUBE.Rows[i][6].ToString().Trim(), DT_NUBE.Rows[i][7].ToString().Trim(), DT_NUBE.Rows[i][8].ToString().Trim(), Convert.ToBoolean(DT_NUBE.Rows[i][9].ToString().Trim()), IMAGEN, Convert.ToDateTime(DT_NUBE.Rows[i][11].ToString().Trim()));

                            //CONTADOR DE REGISTROS IMPORTADOS
                            contador_registros_importados += 1;

                            //FLAG IMPORTACION
                            flag_Importacion = 1;
                        }

                        //SI EL Data Table CONTIENE MAS DE UNA FILA
                        //for (int i = 0; i < DT_NUBE_IMAGENES.Rows.Count; i++)
                        //{
                        //    byte[] IMAGEN = Encoding.ASCII.GetBytes(DT_NUBE_IMAGENES.Rows[i][0].ToString().Trim());

                        //    //IMPORTA IMAGENES
                        //    Sincronizar.IMPORTAR_ACTUALIZAR_IMAGENES(IMAGEN, DT_NUBE_IMAGENES.Rows[i][1].ToString().Trim(), DT_NUBE_IMAGENES.Rows[i][2].ToString().Trim());
                        //}

                    }
                    else
                    {
                        //CONTADOR DE REGISTROS IMPORTADOS
                        contador_registros_importados = 0;

                        //FLAG IMPORTACION
                        flag_Importacion = 2;
                    }
                }
                catch (Exception EX)
                {
                    Console.WriteLine(EX.ToString());
                }

                #endregion


                /////////////////////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////////////////////
                ///  NOTIFICAR ESTADO DE SINCRONIZACION POR MEDIO DE UN E-MAIL AL CLIENTE  //
                /////////////////////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////////////////////


                #region NOTIFICAR CLIENTE [EMAIL]


                string msj_Estado = "ESTADO DE SINCRONIZACIÓN";
                string msj_Exportacion = "";
                string msj_Importacion_Catalogo_Activos = "";
                DateTime fecha = DateTime.Now;


                if (flag_Exportacion == 1 && flag_Importacion == 1 && estado_de_arraque == "CORRECTAMENTE")
                {
                    //*********************
                    Registros_exportados = contador_registros_exportados;
                    Registros_importados = contador_registros_importados;

                    //*********************
                    //Exportación Bitacora Entrada Salida (Portales)
                    msj_Exportacion = "[EJECUTADO CORRECTAMENTE] ";
                    //Importación Catalago RFID Activos
                    msj_Importacion_Catalogo_Activos = "[EJECUTADO CORRECTAMENTE] ";

                    //ENVIO DE MENSAJE
                    Sincronizar.ENVIAR_EMAIL(msj_Estado, fecha, msj_Exportacion, Registros_exportados, msj_Importacion_Catalogo_Activos, Registros_importados, estado_de_arraque);

                    //CERRAMOS EL FLAG
                    flag_Exportacion = 0;
                    contador_registros_exportados = 0;
                    contador_registros_importados = 0;
                }
                else if (flag_Exportacion == 2 && flag_Importacion == 1 && estado_de_arraque == "CORRECTAMENTE")
                {
                    //*********************
                    Registros_exportados = contador_registros_exportados;
                    Registros_importados = contador_registros_importados;

                    //*********************
                    //Exportacion Bitacora Entrada Salida (Portales)
                    msj_Exportacion = "[NO HAY REGISTROS A ENVIAR]";
                    //Importación Catalago RFID Activos
                    msj_Importacion_Catalogo_Activos = "[REGISTROS ACTUALIZADOS]";

                    //ENVIO DE MENSAJE
                    Sincronizar.ENVIAR_EMAIL(msj_Estado, fecha, msj_Exportacion, Registros_exportados, msj_Importacion_Catalogo_Activos, Registros_importados, estado_de_arraque);

                    //CERRAMOS EL FLAG
                    flag_Exportacion = 0;
                    contador_registros_exportados = 0;
                    contador_registros_importados = 0;
                }
                else if (flag_Exportacion == 1 && flag_Importacion == 2 && estado_de_arraque == "CORRECTAMENTE")
                {
                    //*********************
                    Registros_exportados = contador_registros_exportados;
                    Registros_importados = contador_registros_importados;

                    //*********************
                    //Exportación Bitacora Entrada Salida (Portales)
                    msj_Exportacion = "[REGISTROS ENVIADOS] ";
                    //Importación Catalago RFID Activos 
                    msj_Importacion_Catalogo_Activos = "[NO HAY REGISTROS A ACTUALIZAR";

                    //ENVIO DE MENSAJE
                    Sincronizar.ENVIAR_EMAIL(msj_Estado, fecha, msj_Exportacion, Registros_exportados, msj_Importacion_Catalogo_Activos, Registros_importados, estado_de_arraque);

                    //CERRAMOS EL FLAG
                    flag_Exportacion = 0;
                    contador_registros_exportados = 0;
                    contador_registros_importados = 0;
                }
                else if (flag_Exportacion == 2 && flag_Importacion == 2 && estado_de_arraque == "CORRECTAMENTE")
                {
                    //*********************
                    Registros_exportados = contador_registros_exportados;
                    Registros_importados = contador_registros_importados;

                    //*********************
                    //Exportacion Bitacora Entrada Salida (Portales) 
                    msj_Exportacion = "[NO HAY REGISTROS A ENVIAR]";
                    //Importación Catalago RFID Activos 
                    msj_Importacion_Catalogo_Activos = "[NO HAY REGISTROS A ACTUALIZAR]";

                    //ENVIO DE MENSAJE
                    Sincronizar.ENVIAR_EMAIL(msj_Estado, fecha, msj_Exportacion, Registros_exportados, msj_Importacion_Catalogo_Activos, Registros_importados, estado_de_arraque);

                    //CERRAMOS EL FLAG
                    flag_Exportacion = 0;
                    contador_registros_exportados = 0;
                    contador_registros_importados = 0;
                }

                #endregion


            }
            catch (Exception ex)
            {

            }

        }


    }
}
