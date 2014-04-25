using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PartnerNews.Modelo;
using System.Web.Script.Serialization;



namespace PartnerNews.Controlador
{
    public class Ediciones
    {
        public int Id_Version { get; set; }
        public int Id_Toque { get; set; }
        public string Articulos { get; set; }
        public string Id_Edicion { get; set; }
        public Nullable<int> Idioma { get; set; }
        PartnerNewsEntities context = new PartnerNewsEntities();
        

        public string crearEdiciones(int Id_Version) {
            //Eliminar las ediciones de la version
            eliminarEdiciones(Id_Version);
            var lista_ediciones_articulo = context.Articulos_Evento.Where(ae => ae.Id_Version == Id_Version);
            string result = "ok";
            int id;
            string ediciones;
            
            foreach (var items in lista_ediciones_articulo)
            {
                id = items.Id;
                ediciones = items.Edicion;
                result = armarEdiciones(Id_Version, id, ediciones);
            }
            if (result == "ok") {
                //Las ediciones deben tener 3 Top News y un Editorial
                validarEdiciones(Id_Version);
            }
            return result;
        }

        public void eliminarEdiciones(int Id_Version) {
            //Se eliminan todas las ediciones de la version, pues todos los datos necesarios los tenemos en la tabla Articulo y con esto se garantiza su actualizacion
            var ediciones_actuales = context.Edicions.Where(ed => ed.Id_Version == Id_Version);
            int id;
            int toque;
            foreach (var items in ediciones_actuales)
            {
                try
                {
                    id = items.Id_Edicion;
                    toque = items.Id_Toque;
                    using (var ctx = new PartnerNewsEntities())
                    {
                        var ed = ctx.Edicions.First(i => i.Id_Edicion == id && i.Id_Toque == toque);
                        ctx.Edicions.Remove(ed);
                        ctx.SaveChanges();
                    }
                    

                }
                catch (Exception ex)
                {
                    utilidades.WriteError(ex.Message, "Controlador - Edicion.cs", "limpiarEdiciones");
                }
            }
        }

        public string armarEdiciones(int version, int Articulo, string ediciones) {
            string result = "";
            string[] edicion = ediciones.Split(',');
            int Id_Edicion;
            string Articulo_str = Convert.ToString(Articulo);
            bool Existe = false;
            string articulos;
            try
            {
                foreach (string e in edicion)
                {

                    Id_Edicion = Convert.ToInt32(e);

                    var articulos_actuales = context.Edicions.Where(ed => ed.Id_Edicion == Id_Edicion && ed.Id_Version == version).Select(Ed => Ed.Articulos).FirstOrDefault();

                    if (articulos_actuales == null)
                    {
                        //Se crea la edicion y se ingresa el articulo para los 2 toques
                        ingresarEdicion(version, 1, Articulo_str, e);
                        ingresarEdicion(version, 2, Articulo_str, e);
                    }
                    else
                    {
                        //Se actualiza la edicion
                        string[] articulos_ant = articulos_actuales.Split(',');
                        foreach (string art_ant in articulos_ant)
                        {
                            if (Articulo_str == art_ant)
                            {
                                Existe = true;
                            }
                        }
                        if (!Existe)
                        {
                            articulos = articulos_actuales + "," + Articulo_str;
                            actualizarEdicion(version, 1, articulos, e);
                            actualizarEdicion(version, 2, articulos, e);
                        }

                    }
                }
                result = "ok";
            }
            catch (Exception ex) {
                result = "fail";
                utilidades.WriteError(ex.ToString(), "Controlador - Edicion.cs", "armarEdiciones");
            }
            return result;
        }

        public void ingresarEdicion(int version,int toque,string Articulo, string edicion) {
            Tipo_Ediciones class_tipo_ediciones = new Tipo_Ediciones();
            int id_Edicion = Convert.ToInt32(edicion);
            int idioma = class_tipo_ediciones.traerIdIdioma(id_Edicion);
            try
            {
                Modelo.Edicion ed = new Modelo.Edicion();

                ed.Id_Version = version;
                ed.Id_Toque = toque;
                ed.Id_Edicion = id_Edicion;
                ed.Articulos = Articulo;
                ed.Idioma = idioma;
                using (var ctx = new PartnerNewsEntities())
                {
                    ctx.Edicions.Add(ed);
                    ctx.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                utilidades.WriteError(ex.ToString(), "Controlador - Edicion.cs", "ingresarEdicion");
            }

        }

        public void actualizarEdicion(int version, int toque, string Articulo, string edicion)
        {
            int id_Edicion = Convert.ToInt32(edicion);
            try
            {
                using (var ctx = new PartnerNewsEntities())
                {
                    var Edicion_edit = (from Edicions in ctx.Edicions
                                        where Edicions.Id_Edicion == id_Edicion && Edicions.Id_Toque == toque && Edicions.Id_Version == version
                                        select Edicions).FirstOrDefault();

                    Edicion_edit.Articulos = Articulo;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                utilidades.WriteError(ex.Message, "Controlador - Edicion.cs", "actualizarEdicion");
            }
        }

        //Las ediciones deben tener 3 Top News y un Editorial
        public string validarEdiciones(int Id_Version) {
            var ediciones_actuales = context.Edicions.Where(ed => ed.Id_Version == Id_Version);
            int id;
            int toque;
            string result = "";
            foreach (var items in ediciones_actuales)
            {
                try
                {

                    id = items.Id_Edicion;
                    toque = items.Id_Toque;
                    var articulos_actuales = context.Edicions.Where(ed => ed.Id_Edicion == id && ed.Id_Version == Id_Version).Select(Ed => Ed.Articulos).FirstOrDefault();
                    int top_news = context.Database.SqlQuery<int>("select count(*) from Articulo where Id in (" + articulos_actuales + ") and Top_new = 'yes'").FirstOrDefault<int>();
                    int editorial = context.Database.SqlQuery<int>("select count(*) from Articulo where Id in (" + articulos_actuales + ") and editorial = 'yes'").FirstOrDefault<int>();
                    if (top_news > 3 || editorial > 1)
                    {
                        result += armarMensaje(Id_Version, id, toque, top_news,editorial);
                    }
                    else {
                        result = "ok";
                    }
                }
                catch (Exception ex)
                {
                    result = "fail";
                    utilidades.WriteError(ex.Message, "Controlador - Edicion.cs", "limpiarEdiciones");
                }
            }


            return result;
        }

        public string armarMensaje(int Id_version,int Id_Edicion, int toque, int top_news, int editorial) {
            string result = "";
            Versiones ver = new Versiones();
            string version = ver.getNombreVersion(Id_version);
            string edicion = obtenerNombreEdicion(Id_Edicion);
            result += "{\"Version\": \"" + version + "\", \"Edicion\": \"" + edicion + "\",\"Toque\": \"" + toque + "\",\"Top News\": \"" + top_news + "\",\"Editorial\": \"" + editorial + "\"},";
            return result;
        }

        public string obtenerNombreEdicion(int Id_version) { 
            string nombre = context.Tipo_Edicion.Where(ed => ed.Id == Id_version).Select(ed => ed.nombre).FirstOrDefault();
            return nombre;
        }

        public bool validarToque(int version, int toque) {
            var id = context.Edicions.Where(e => e.Id_Version == version && e.Id_Toque == toque).FirstOrDefault();
            return (id == null) ? false : true;
        }

        public string nombreEdiciones(string ediciones) {
            string nombres = "";
            string[] edicion = ediciones.Split(',');
            foreach (string word in edicion)
	        {
                nombres += obtenerNombreEdicion(Convert.ToInt32(word)) + ",";
	        }
            nombres = utilidades.eliminarComa(nombres);
            return nombres;
        }

        public string traerEdiciones(int version,int toque) {
            string resultado = "";
            var listaEdiciones = context.Edicions.Where(e => e.Id_Version == version && e.Id_Toque == toque).ToList(); 
            Idiomas clase_idioma = new Idiomas();
            Secciones clase_seccion = new Secciones();
            Versiones clase_versiones = new Versiones();
            Ediciones clase_ediciones = new Ediciones();

            try
            {
                var contenido = (from edicion in listaEdiciones
                                 select new
                                 {
                                     Edition = clase_ediciones.obtenerNombreEdicion(Convert.ToInt32(edicion.Id_Edicion)),
                                     Version = clase_versiones.getNombreVersion(Convert.ToInt32(edicion.Id_Version)),
                                     Touch = edicion.Id_Toque,
                                     Language = clase_idioma.nombreIdioma(Convert.ToInt32(edicion.Idioma)),
                                     View = "<a href=\"#\" onclick=\"verEdicion(" + edicion.Id_Edicion + "); return false;\"><img src=\"../images/eye.png\"/></a>",
                                     Edit = "<a href=\"#\" onclick=\"editarEdicion(" + edicion.Id_Edicion + "); return false;\"><img src=\"../images/edit.png\"/></a>",
                                     Delete = "<a href=\"#\" onclick=\"borrarEdicion(" + edicion.Id_Edicion + "); return false;\"><img src=\"../images/delete.png\"/></a>",
                                     Publish = "<a href=\"#\" onclick=\"publicarEdicion(" + edicion.Id_Edicion + "); return false;\"><img src=\"../images/edit.png\"/></a>"
                                     
                                 });

                resultado = new JavaScriptSerializer().Serialize(contenido);
            }
            catch (Exception ex)
            {
                resultado = "fail";
                utilidades.WriteError(ex.Message, "Controlador - Articulo.cs", "traerArticulo");
            }
           
            return resultado;
        }

    }

}