using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PartnerNews.Modelo;

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

            


        
    }
}