using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Globalization;

namespace PartnerNews.Controlador
{
    public class utilidades
    {
        //Metodo para escribir el error en un archivo log  *** Parametros error, archivo donde ocurrio el error, metodo donde ocurrio el error.
        public static string WriteError(string error, string file, string metodo)
        {
            string path1 = HttpContext.Current.Server.MapPath("~");
            string respuesta = "";
            DateTime datt = DateTime.Now;
            string fecha = datt.ToString();
            string path = path1 + "\\Errores\\";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            string nombre = "Error.log";

            string fullPath = path1 + "\\Errores\\" + nombre;
            string contenido = "Date: " + ' ' + fecha + "  File: " + ' ' + file + "  Method:" + ' ' + metodo + "  Error :" + ' ' + error;

            try
            {
                FileStream fs = new FileStream(fullPath, FileMode.Append, FileAccess.Write);
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.WriteLine(contenido);
                }
            }
            catch (Exception ex)
            {
                respuesta = "fail";


            }
            finally
            {
                respuesta = nombre;
            }
            return respuesta;
        }

        //Retorna el nombre del mes (idiomas => 1 Igles,2 Español,3 Portugues)
        public static string getnombreMes(int id, int idioma)
        {
            string nombre = "";
            if (idioma == 1)
            {
                DateTimeFormatInfo dtinfo = new CultureInfo("en-US", false).DateTimeFormat;
                nombre = dtinfo.GetMonthName(id);
            }
            else if (idioma == 2)
            {
                DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
                nombre = dtinfo.GetMonthName(id);
            }
            else if (idioma == 3)
            {
                DateTimeFormatInfo dtinfo = new CultureInfo("pt-BR", false).DateTimeFormat;
                nombre = dtinfo.GetMonthName(id);
            }
            return nombre;

        }

        public static string generarKey() {
               Random rand = new Random();
               string str = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
               string cad = "";
               for(int i=0; i<4; i++) {
                   
                  cad += str.Substring(rand.Next(0,62),1);
                }
                return cad;	

        }

    }
}