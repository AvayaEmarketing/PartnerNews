using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using PartnerNews.Modelo;

namespace PartnerNews.Controlador
{
    public class Seccion_detalles
    {
        public int Id { get; set; }
        public Nullable<int> Id_seccion { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
        public Nullable<System.DateTime> fecha_actualizacion { get; set; }
        public Nullable<int> idioma { get; set; }
        PartnerNewsEntities context = new PartnerNewsEntities();
        
        public bool validarDetalleSeccion(int seccion)
        {
            var datos = context.Seccion_detalle.Where(sd => sd.Id_seccion == seccion).FirstOrDefault();
            return (datos == null) ? false : true;
        }

        
        public string cargarDetalleSeccion(int seccion)
        {
            string result = "";
            var detalles = context.Seccion_detalle.Where(sd => sd.Id_seccion == seccion && sd.idioma == 1).Select(sd => new { Id = sd.Id,nombre = sd.nombre });
            result = new JavaScriptSerializer().Serialize(detalles);
            return result;
        }
    }
}