﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Transportes_MVC_gen_12.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TransportesEntities : DbContext
    {
        public TransportesEntities()
            : base("name=TransportesEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Camiones> Camiones { get; set; }
        public virtual DbSet<bitacora_camiones> bitacora_camiones { get; set; }
        public virtual DbSet<Cargamentos> Cargamentos { get; set; }
        public virtual DbSet<Choferes> Choferes { get; set; }
        public virtual DbSet<Direcciones> Direcciones { get; set; }
        public virtual DbSet<Rutas> Rutas { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<View_Rutas> View_Rutas { get; set; }
    }
}
