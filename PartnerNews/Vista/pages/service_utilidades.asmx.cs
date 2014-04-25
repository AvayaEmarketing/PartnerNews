using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Collections.Specialized;
using PartnerNews.Controlador;

namespace PartnerNews.Vista.pages
{
    /// <summary>
    /// Descripción breve de service_utilidades
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class service_utilidades : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        public static string validaSession()
        {
            string result = "";
            var sessionUsuario = HttpContext.Current.Session;
            result = (sessionUsuario["id"] == null) ? "fail" : sessionUsuario["id"].ToString();
            return result;
        }


        public static NameValueCollection GetQueryStringCollection(string url)
        {
            string keyValue = string.Empty;
            NameValueCollection collection = new NameValueCollection();
            string[] querystrings = url.Split('&');
            if (querystrings != null && querystrings.Count() > 0)
            {
                for (int i = 0; i < querystrings.Count(); i++)
                {
                    string[] pair = querystrings[i].Split('=');
                    collection.Add(pair[0].Trim('?'), pair[1]);
                }
            }
            return collection;
        }

        [WebMethod(EnableSession = true)]
        public string versionActual()
        {
            string resultado;
            NameValueCollection collection = GetQueryStringCollection(HttpContext.Current.Request.UrlReferrer.Query);
            if (collection != null && collection.Count > 0)
            {
                resultado = HttpContext.Current.Server.UrlDecode(collection["version"]);
            }
            else
            {
                var versionAct = HttpContext.Current.Session;
                resultado = (versionAct["version"] == null) ? "fail" : versionAct["version"].ToString();
            }
            return resultado;
        }

        [WebMethod(EnableSession = true)]
        public string cerrarSession()
        {
            var sessionUsuario = HttpContext.Current.Session;
            var resultado = "";
            try
            {
                sessionUsuario.Clear();
                sessionUsuario.Abandon();
                resultado = "ok";
            }
            catch (Exception ex)
            {
                resultado = "fail";
                utilidades.WriteError(ex.Message, "service_utilidades.asmx", "cerrarSession");
            }
            return resultado;
        }

        [WebMethod(EnableSession = true)]
        public string goHome()
        {
            var sessionUsuario = HttpContext.Current.Session;
            var resultado = "";
            try
            {
                //No se mata la session, se deja vacia la variable version
                sessionUsuario.Remove("version");
                //sessionUsuario["version"] = "";
                resultado = "ok";
            }
            catch (Exception ex)
            {
                resultado = "fail";
                utilidades.WriteError(ex.Message, "service_utilidades.asmx", "goHome");
            }
            return resultado;
        }
    }
}
