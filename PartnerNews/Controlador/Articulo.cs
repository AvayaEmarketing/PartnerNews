using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PartnerNews.Modelo;
using System.Web.Script.Serialization;


namespace PartnerNews.Controlador
{
    public class Articulos
    {

        public int Id { get; set; }
        public int Id_Version { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public int Idioma { get; set; }
        public int Seccion { get; set; }
        public Nullable<int> Seccion_detalle { get; set; }
        public string Edicion { get; set; }
        public string Top_new { get; set; }
        public string Visible { get; set; }
        public string Destacada { get; set; }
        public string Editorial { get; set; }
        public Nullable<System.DateTime> fecha_creacion { get; set; }
        public Nullable<System.DateTime> fecha_editado { get; set; }
        public Nullable<int> creador { get; set; }

            PartnerNewsEntities context = new PartnerNewsEntities();
            DateTime fecha = DateTime.Now;

            public string agregarArticulo(int Id_Version, string Titulo, string Contenido, int Idioma, int Seccion, int Seccion_detalle, string Edicion, string Top_new, string Visible, string Destacada, string Editorial, int creador)
            {
                string result = "";
                try
                {
                    Modelo.Articulo Entidad_Articulo = new Modelo.Articulo();

                    Entidad_Articulo.Id_Version = Id_Version;
                    Entidad_Articulo.Titulo = Titulo;
                    Entidad_Articulo.Contenido = Contenido;
                    Entidad_Articulo.Idioma = Idioma;
                    Entidad_Articulo.Seccion = Seccion;
                    if (Seccion_detalle == 0)
                    {
                        Entidad_Articulo.Seccion_detalle = null;
                    }
                    else {
                        Entidad_Articulo.Seccion_detalle = Seccion_detalle;
                    }
                    Entidad_Articulo.Edicion = Edicion;
                    Entidad_Articulo.Top_new = Top_new;
                    Entidad_Articulo.Visible = Visible;
                    Entidad_Articulo.Destacada = Destacada;
                    Entidad_Articulo.Editorial = Editorial;
                    Entidad_Articulo.creador = creador;
                    Entidad_Articulo.fecha_creacion = fecha;

                    context.Articuloes.Add(Entidad_Articulo);
                    context.SaveChanges();
                    result = "ok";
                }
                catch (Exception ex)
                {
                    result = "fail";
                    utilidades.WriteError(ex.Message, "Controlador - Articulo.cs", "agregarArticulo");
                }

                return result;
            }

            public string traerArticulos(int version)
            {

                string respuesta = "";
                var listaArticulos = context.Articuloes.Where(a => a.Id_Version == version).ToList();
                Idiomas clase_idioma = new Idiomas();
                Secciones clase_seccion = new Secciones();
                Ediciones clase_edicion = new Ediciones();
                try
                {
                    var contenido = (from articulo in listaArticulos
                                     select new
                                     {
                                         titulo = articulo.Titulo,
                                         idioma = clase_idioma.nombreIdioma(articulo.Idioma),
                                         edicion = clase_edicion.nombreEdiciones(articulo.Edicion),
                                         seccion = clase_seccion.nombreSeccion(articulo.Seccion),
                                         top_new = articulo.Top_new,
                                         destacada = articulo.Destacada,
                                         editorial = articulo.Editorial,
                                         visible = articulo.Visible,
                                         detalles = "<a href=\"#\" onclick=\"detalleArticulo(" + articulo.Id + "); return false;\"><img src=\"../images/eye.png\"/></a>",
                                         editar = "<a href=\"#\" onclick=\"editarArticulo(" + articulo.Id +"); return false;\"><img src=\"../images/edit.png\"/></a>",
                                         borrar = "<a href=\"#\" onclick=\"borrarArticulo(" + articulo.Id +"); return false;\"><img src=\"../images/delete.png\"/></a>"
                                     });

                    respuesta = new JavaScriptSerializer().Serialize(contenido);
                }
                catch (Exception ex)
                {
                    respuesta = "fail";
                    utilidades.WriteError(ex.Message, "Controlador - Articulo.cs", "traerArticulo");
                }
                return respuesta;
            }

            public string traerContenido(int articulo) { 
                var respuesta = "";
                try
                {
                    var contenido = context.Articuloes.Where(a => a.Id == articulo).Select(a => new { titulo = a.Titulo, contenido = a.Contenido });
                    respuesta = new JavaScriptSerializer().Serialize(contenido);
                }
                catch (Exception ex) {
                    respuesta = "fail";
                    utilidades.WriteError(ex.Message, "Controlador - Articulo.cs", "traerContenido");
                }
                return respuesta;
            }

            public string eliminarArticulo(int Id_Articulo)
            {
                string resultado = "";
                    try
                    {
                        using (var ctx = new PartnerNewsEntities()) { ctx.Articuloes.Remove(ctx.Articuloes.First(a => a.Id == Id_Articulo));   ctx.SaveChanges();  }
                        resultado = "ok";
                    }
                    catch (Exception ex)
                    {
                        resultado = "fail";
                        utilidades.WriteError(ex.Message, "Controlador - Articulo.cs", "eliminarArticulo");
                    }
                    return resultado;
            }

            public string traerInfoEditarArticulo(int Id) {
                string respuesta = "";
                var atributosArticulo = context.Articuloes.Where(a => a.Id == Id).ToList();
                try
                {
                    var contenido = (from articulo in atributosArticulo
                                     select new
                                     {
                                         Id = articulo.Id,
                                         titulo = articulo.Titulo,
                                         idioma = articulo.Idioma,
                                         edicion = articulo.Edicion,
                                         seccion = articulo.Seccion,
                                         top_new = articulo.Top_new,
                                         destacada = articulo.Destacada,
                                         editorial = articulo.Editorial,
                                         visible = articulo.Visible,
                                         contenido = articulo.Contenido,
                                         Seccion_detalle = articulo.Seccion_detalle
                                         
                                     }).FirstOrDefault();

                    respuesta = new JavaScriptSerializer().Serialize(contenido);
                }
                catch (Exception ex)
                {
                    respuesta = "fail";
                    utilidades.WriteError(ex.Message, "Controlador - Articulo.cs", "traerInfoEditarArticulo");
                }
                return respuesta;
            }

            public string actualizarArticulo(int id_articulo, int Id_Version, string Titulo, string Contenido, int Idioma, int Seccion, int Seccion_detalle, string Edicion, string Top_new, string Visible, string Destacada, string Editorial, int creador)
            {
                var result = "";
                try
                {
                    using (var ctx = new PartnerNewsEntities())
                    {
                        var Articulo_edit = (from datosArticulo in ctx.Articuloes
                                             where datosArticulo.Id == id_articulo
                                            select datosArticulo).FirstOrDefault();

                        Articulo_edit.Titulo = Titulo;
                        Articulo_edit.Contenido = Contenido;
                        Articulo_edit.Idioma = Idioma;
                        Articulo_edit.Seccion = Seccion;
                        Articulo_edit.Seccion_detalle = Seccion_detalle;
                        Articulo_edit.Edicion = Edicion;
                        Articulo_edit.Top_new = Top_new;
                        Articulo_edit.Visible = Visible;
                        Articulo_edit.Destacada = Destacada;
                        Articulo_edit.Editorial = Editorial;
                        Articulo_edit.creador = creador;
                        Articulo_edit.fecha_editado = fecha;

                        ctx.SaveChanges();
                        result = "ok";
                    }
                }
                catch (Exception ex)
                {
                    result = "fail";
                    utilidades.WriteError(ex.Message, "Controlador - Articulo.cs", "actualizarArticulo");
                }
                return result;
            }



            


        
    }
}