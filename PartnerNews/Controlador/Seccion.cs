using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PartnerNews.Modelo;
using System.Web.Script.Serialization;

namespace PartnerNews.Controlador
{
    public class Secciones
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
        public Nullable<System.DateTime> fecha_actualizacion { get; set; }
        public Nullable<int> idioma { get; set; }
        PartnerNewsEntities context = new PartnerNewsEntities();
        
        public string cargarSecciones()
        {
            string result = "";
            var secciones = context.Seccions.Select(s => new { Id = s.Id, nombre = s.nombre  });
            result = new JavaScriptSerializer().Serialize(secciones);
            return result;
        }

        public string nombreSeccion(int seccion)
        {
            string nombre = context.Seccions.Where(s => s.Id == seccion && s.idioma == 2).Select(s => s.nombre).FirstOrDefault();
            return nombre;
        }
    }
}