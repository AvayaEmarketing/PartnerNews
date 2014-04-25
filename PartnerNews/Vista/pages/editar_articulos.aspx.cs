using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using PartnerNews.Controlador;

namespace PartnerNews.Vista.pages
{
    public partial class editar_articulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string traerInfoEditarArticulo(int articulo)
        {
            Articulos Class_articulos = new Articulos();
            string result = Class_articulos.traerInfoEditarArticulo(articulo);
            return result;
        }

        [WebMethod]
        public static string actualizarArticulo(int id_articulo, int Id_Version, string Titulo, string Contenido, int Idioma, int Seccion, int Seccion_detalle, string Edicion, string Top_new, string Visible, string Destacada, string Editorial, int creador)
        {
            Articulos Class_articulos = new Articulos();
            string result = Class_articulos.actualizarArticulo(id_articulo, Id_Version, Titulo, Contenido, Idioma, Seccion, Seccion_detalle, Edicion, Top_new, Visible, Destacada, Editorial, creador);
            return result;
        }

    }
}