﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccesoDatos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class VerduEntities : DbContext
    {
        public VerduEntities()
            : base("name=VerduEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Tab_Bitacora_Movimientos> Tab_Bitacora_Movimientos { get; set; }
        public virtual DbSet<Tab_Bitacora_Sesiones> Tab_Bitacora_Sesiones { get; set; }
        public virtual DbSet<Tab_Clientes> Tab_Clientes { get; set; }
        public virtual DbSet<Tab_Devoluciones> Tab_Devoluciones { get; set; }
        public virtual DbSet<Tab_Permisos> Tab_Permisos { get; set; }
        public virtual DbSet<Tab_Productos> Tab_Productos { get; set; }
        public virtual DbSet<Tab_Roles> Tab_Roles { get; set; }
        public virtual DbSet<Tab_Tipo_Productos> Tab_Tipo_Productos { get; set; }
        public virtual DbSet<Tab_Usuarios> Tab_Usuarios { get; set; }
        public virtual DbSet<Tab_Venta> Tab_Venta { get; set; }
        public virtual DbSet<Tab_Venta_detallada> Tab_Venta_detallada { get; set; }
    }
}
