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
    public partial class ver_articulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
        [WebMethod]
        public static string traerArticulos(int version)
        {
            Articulos Class_articulo = new Articulos();
            string result = Class_articulo.traerArticulos(version);
            return result;
        }

        [WebMethod]
        public static string traerContenido(int articulo)
        {
            Articulos Class_articulo = new Articulos();
            string result = Class_articulo.traerContenido(articulo);
            return result;
        }

        [WebMethod]
        public static string eliminarArticulo(int articulo)
        {
            Articulos Class_articulo = new Articulos();
            string result = Class_articulo.eliminarArticulo(articulo);
            return result;
        }
    }
}