using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PartnerNews.Controlador;
using System.Web.Services;

namespace PartnerNews.Vista.pages
{
    public partial class crear_articulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string cargarSecciones()
        {
            Secciones Class_seccion = new Secciones();
            string result = Class_seccion.cargarSecciones();
            return result;
        }

        [WebMethod]
        public static bool validarDetalleSeccion(int seccion)
        {
            Seccion_detalles Class_seccion_detalles = new Seccion_detalles();
            bool result = Class_seccion_detalles.validarDetalleSeccion(seccion);
            return result;
        }

        [WebMethod]
        public static string cargarDetalleSeccion(int seccion)
        {
            Seccion_detalles Class_seccion_detalles = new Seccion_detalles();
            string result = Class_seccion_detalles.cargarDetalleSeccion(seccion);
            return result;
        }

        [WebMethod]
        public static string cargarEdiciones(int idioma)
        {
            Tipo_Ediciones Class_tipo_edicion = new Tipo_Ediciones();
            string result = Class_tipo_edicion.cargarEdiciones(idioma);
            return result;
        }

        [WebMethod(EnableSession = true)]
        public static string agregarArticulo(int Id_Version, string Titulo, string Contenido, int Idioma, int Seccion, int Seccion_detalle, string Edicion, string Top_new, string Visible, string Destacada, string Editorial)
        {
            string resultado;
            //var sessionUsuario = HttpContext.Current.Session;
            //if (sessionUsuario["ID"] == null)
            //{
            //    //si no tiene session mostrar mensaje de que la session ha caducado y enviarlo al login.
            //    resultado = "session";
            //}
            //else
            //{
            //    int creador = Convert.ToInt32(sessionUsuario["ID"]);
                int creador = 1;
                Articulos articulos = new Articulos();
                resultado = articulos.agregarArticulo(Id_Version, Titulo, Contenido, Idioma, Seccion, Seccion_detalle, Edicion, Top_new, Visible, Destacada, Editorial, creador);
            //}
            return resultado;
        }




    }
}