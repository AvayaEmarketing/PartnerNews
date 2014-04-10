using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using PartnerNews.Modelo;

namespace PartnerNews.Controlador
{
    public class Versiones
    {
        public int Id { get; set; }
        public string mes { get; set; }
        public Nullable<int> anio { get; set; }
        public int toque { get; set; }
        PartnerNewsEntities context = new PartnerNewsEntities();

        public string getNombreVersion(int id_version) {
            var datos = context.Versions.Where(ve => ve.Id == id_version).FirstOrDefault();
            //var  anios = context.Versions.Where(ve => ve.Id == id_version).Select(ed => ed.anio).FirstOrDefault();
            var anios = datos.anio;
            string year = Convert.ToString(anios);
            string nombre = datos.mes + " " + year;
            return nombre;
        }

        public string traerVersiones()
        {

            string respuesta = "";
            var listacontenido = context.Versions.Where(ver => ver.toque == 1).ToList();
            try
            {
                var contenido = (from ver in listacontenido
                                 select new
                                 {
                                              //traer el nombre del mes, se envia el id del mes y el id del idioma.
                                     nombre = utilidades.getnombreMes(Convert.ToInt32(ver.mes),1) + " " + ver.anio,
                                     Details_t1 = "<a href=\"#\" onclick=\"ver_version(" + ver.Id + "," + 1 +"); return false;\">Admin&nbsp;<img src=\"../images/edit.png\"/></a>",
                                     Details_t2 = "<a href=\"#\" onclick=\"ver_version(" + ver.Id + "," + 2 +"); return false;\">Admin&nbsp;<img src=\"../images/edit.png\"/></a>",
                                 });

                respuesta = new JavaScriptSerializer().Serialize(contenido);
            }
            catch (Exception ex)
            {
                respuesta = "fail";
                utilidades.WriteError(ex.ToString(), "Controlador - Versiones.cs", "traerVersiones");
            }
            return respuesta;
        }

        public string agregarVersion(string mes, int anio) {
            string result;
            if (!validarVersion(mes, anio))
            {
                int id = traerUltimoId();
                if (id != -1)
                {
                    result = agregarVersionesToque(id, mes, anio, 1);
                    result = agregarVersionesToque(id, mes, anio, 2);
                }
                else {
                    result = "fail";
                }
            }
            else {
                result = "exist";
            }
            return result;
        }

        public bool validarVersion(string mes,int anio) {
            var id = context.Versions.Where(v => v.mes == mes && v.anio == anio).FirstOrDefault();
            return (id == null) ? false : true;
        }

        public int traerUltimoId() {
            int id = 0;
            try
            {
                var id2 = context.Versions.OrderByDescending(v => v.Id).Select(v => v.Id).FirstOrDefault();
                id = Convert.ToInt32(id2);
                id = id + 1;
            }
            catch (Exception ex) {
                id = -1;
                utilidades.WriteError(ex.ToString(), "Controlador - Versiones.cs", "traerUltimoId");
            }
            return id;
        }

        public string agregarVersionesToque(int id,string mes, int anio, int toque) {
            string result = "";
            try
            {
                Modelo.Version ver = new Modelo.Version();
                ver.Id = id;
                ver.mes = mes;
                ver.anio = anio;
                ver.toque = toque;
                context.Versions.Add(ver);
                context.SaveChanges();
                result = "ok";
            }
            catch (Exception ex)
            {
                result = "fail";
                utilidades.WriteError(ex.Message, "Controlador - Versiones.cs", "agregarVersionesToque");
            }
            return result;
        }

    }

    
}