﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinanzasPersonales.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MoneySaverEntities : DbContext
    {
        public MoneySaverEntities()
            : base("name=MoneySaverEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Banco> Banco { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Contacto> Contacto { get; set; }
        public virtual DbSet<CuentaBanco> CuentaBanco { get; set; }
        public virtual DbSet<CuentaPrestamo> CuentaPrestamo { get; set; }
        public virtual DbSet<EstadoCategoria> EstadoCategoria { get; set; }
        public virtual DbSet<EstadoCuentaBanco> EstadoCuentaBanco { get; set; }
        public virtual DbSet<EstadoTarjetaCredito> EstadoTarjetaCredito { get; set; }
        public virtual DbSet<EstadoTarjetaDebito> EstadoTarjetaDebito { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Moneda> Moneda { get; set; }
        public virtual DbSet<PatronRecurrente> PatronRecurrente { get; set; }
        public virtual DbSet<PeriodoTemporal> PeriodoTemporal { get; set; }
        public virtual DbSet<Presupuesto> Presupuesto { get; set; }
        public virtual DbSet<PresupuestoCategoria> PresupuestoCategoria { get; set; }
        public virtual DbSet<Recordatorio> Recordatorio { get; set; }
        public virtual DbSet<TarjetaCredito> TarjetaCredito { get; set; }
        public virtual DbSet<TipoCategoria> TipoCategoria { get; set; }
        public virtual DbSet<TipoRecurrencia> TipoRecurrencia { get; set; }
        public virtual DbSet<Transaccion> Transaccion { get; set; }
    }
}