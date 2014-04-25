using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PartnerNews.Modelo;

namespace PartnerNews.Controlador
{
    public class Idiomas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        PartnerNewsEntities context = new PartnerNewsEntities();

        public string nombreIdioma(int idioma) {
            string nombre = context.Idiomas.Where(i => i.Id == idioma).Select(i => i.Nombre).FirstOrDefault();
            return nombre;
        }
    }
}