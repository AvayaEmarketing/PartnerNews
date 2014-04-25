using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PartnerNews.Modelo;
using System.Web.Script.Serialization;

namespace PartnerNews.Controlador
{
    public class Tipo_Ediciones
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
        public Nullable<System.DateTime> fecha_actualizacion { get; set; }
        public Nullable<int> idioma { get; set; }
        PartnerNewsEntities context = new PartnerNewsEntities();

        public string cargarEdiciones(int idioma)
        {
            string result = "";
            var tipo_edicion = context.Tipo_Edicion.Where(te => te.idioma == idioma && te.estado == "ACT").Select(s => new { Id = s.Id, nombre = s.nombre });
            result = new JavaScriptSerializer().Serialize(tipo_edicion);
            return result;
        }

        public int traerIdIdioma(int edicion) {
            var idioma = context.Tipo_Edicion.Where(ed => ed.Id == edicion).Select(ed => ed.idioma).FirstOrDefault();
            return Convert.ToInt32(idioma);
        }
    }
}