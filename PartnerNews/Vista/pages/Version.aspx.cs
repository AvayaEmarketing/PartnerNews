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
    public partial class Version : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string traerVersiones()
        {
            Versiones Class_version = new Versiones();
            string result = Class_version.traerVersiones();
            return result;
        }

        [WebMethod]
        public static string agregarVersion(string mes,int anio)
        {
            Versiones Class_version = new Versiones();
            string result = Class_version.agregarVersion(mes,anio);
            return result;
        }

        [WebMethod]
        public static bool validarToque(int version, int toque)
        {
            Ediciones Class_edicion = new Ediciones();
            bool result = Class_edicion.validarToque(version,toque);
            return result;
        }


        

        
    }
}