using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PartnerNews.Controlador;


namespace PartnerNews.Vista.pages
{
    /// <summary>
    /// Descripción breve de Upload
    /// </summary>
    public class Upload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            utilidades util = new utilidades();
            HttpPostedFile uploads = context.Request.Files["upload"];
            string CKEditorFuncNum = context.Request["CKEditorFuncNum"];
            string file = System.IO.Path.GetFileName(uploads.FileName);
            string key = Controlador.utilidades.generarKey();
            uploads.SaveAs(context.Server.MapPath("~") + "\\Images\\" + key + "_" + file);
            //provide direct URL here
            string url = "http://localhost:1257/Images/" + key + "_" + file;

            context.Response.Write("<script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", \"" + url + "\");</script>");
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}