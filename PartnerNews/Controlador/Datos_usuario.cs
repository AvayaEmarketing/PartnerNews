using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartnerNews.Controlador
{
    public class Datos_usuarios
    {
        public int Id { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
    }
}