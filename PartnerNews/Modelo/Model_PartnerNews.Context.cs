﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PartnerNewsEntities : DbContext
    {
        public PartnerNewsEntities()
            : base("name=PartnerNewsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Articulo> Articuloes { get; set; }
        public DbSet<Datos_usuario> Datos_usuario { get; set; }
        public DbSet<Edicion> Edicions { get; set; }
        public DbSet<Idioma> Idiomas { get; set; }
        public DbSet<Seccion> Seccions { get; set; }
        public DbSet<Seccion_detalle> Seccion_detalle { get; set; }
        public DbSet<Tipo_Edicion> Tipo_Edicion { get; set; }
        public DbSet<Version> Versions { get; set; }
        public DbSet<Articulos_Evento> Articulos_Evento { get; set; }
    }
}
