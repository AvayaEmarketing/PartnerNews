//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PartnerNews.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Seccion_detalle
    {
        public int Id { get; set; }
        public int Id_seccion { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
        public Nullable<System.DateTime> fecha_actualizacion { get; set; }
        public int idioma { get; set; }
    }
}