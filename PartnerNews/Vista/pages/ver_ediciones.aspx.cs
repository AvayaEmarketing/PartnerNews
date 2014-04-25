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
    public partial class ver_ediciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string traerEdiciones(int version, int toque)
        {
            Ediciones Class_ediciones = new Ediciones();
            string result = Class_ediciones.traerEdiciones(version,toque);
            return result;
        }

        [WebMethod]
        public static string crearEdiciones(int Id_Version)
        {
            Ediciones Class_ediciones = new Ediciones();
            string result = Class_ediciones.crearEdiciones(Id_Version);
            return result;
        }

        
    }
}