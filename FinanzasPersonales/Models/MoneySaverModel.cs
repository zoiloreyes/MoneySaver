namespace FinanzasPersonales.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MoneySaverModel : DbContext
    {
        public MoneySaverModel()
            : base("name=MoneySaverCodeFirst")
        {
        }

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
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TarjetaCredito> TarjetaCredito { get; set; }
        public virtual DbSet<TipoCategoria> TipoCategoria { get; set; }
        public virtual DbSet<TipoRecurrencia> TipoRecurrencia { get; set; }
        public virtual DbSet<Transaccion> Transaccion { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Banco>()
                .Property(e => e.NombreBanco)
                .IsUnicode(false);

            modelBuilder.Entity<Banco>()
                .Property(e => e.Pais)
                .IsUnicode(false);

            modelBuilder.Entity<Banco>()
                .HasMany(e => e.CuentaBanco)
                .WithRequired(e => e.Banco)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Banco>()
                .HasMany(e => e.TarjetaCredito)
                .WithRequired(e => e.Banco)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Categoria>()
                .Property(e => e.Comentario)
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.Categoria1)
                .WithOptional(e => e.Categoria2)
                .HasForeignKey(e => e.PadreCategoriaID);

            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.PresupuestoCategoria)
                .WithRequired(e => e.Categoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contacto>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Contacto>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Contacto>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Contacto>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<CuentaBanco>()
                .Property(e => e.NumeroCuenta)
                .IsUnicode(false);

            modelBuilder.Entity<CuentaBanco>()
                .Property(e => e.NombreTitular)
                .IsUnicode(false);

            modelBuilder.Entity<CuentaBanco>()
                .Property(e => e.ApellidoTitular)
                .IsUnicode(false);

            modelBuilder.Entity<CuentaBanco>()
                .Property(e => e.BalanceInicial)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CuentaBanco>()
                .Property(e => e.Comentario)
                .IsUnicode(false);

            modelBuilder.Entity<CuentaPrestamo>()
                .Property(e => e.CapitalInicial)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CuentaPrestamo>()
                .Property(e => e.TasaAnual)
                .HasPrecision(8, 4);

            modelBuilder.Entity<EstadoCategoria>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<EstadoCategoria>()
                .HasMany(e => e.Categoria)
                .WithRequired(e => e.EstadoCategoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EstadoCuentaBanco>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<EstadoCuentaBanco>()
                .HasMany(e => e.CuentaBanco)
                .WithRequired(e => e.EstadoCuentaBanco)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EstadoTarjetaCredito>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<EstadoTarjetaCredito>()
                .HasMany(e => e.TarjetaCredito)
                .WithRequired(e => e.EstadoTarjetaCredito)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EstadoTarjetaDebito>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Marca>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            //modelBuilder.Entity<Marca>()
            //    .HasMany(e => e.TarjetaCredito)
            //    .WithRequired(e => e.Marca)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Moneda>()
                .Property(e => e.Codigo)
                .IsUnicode(false);

            modelBuilder.Entity<Moneda>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Moneda>()
                .HasMany(e => e.Categoria)
                .WithRequired(e => e.Moneda)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Moneda>()
                .HasMany(e => e.CuentaBanco)
                .WithRequired(e => e.Moneda)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Moneda>()
                .HasMany(e => e.CuentaPrestamo)
                .WithRequired(e => e.Moneda)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Moneda>()
                .HasMany(e => e.TarjetaCredito)
                .WithRequired(e => e.Moneda)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PeriodoTemporal>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<PeriodoTemporal>()
                .HasMany(e => e.Presupuesto)
                .WithRequired(e => e.PeriodoTemporal)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Presupuesto>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Presupuesto>()
                .HasMany(e => e.PresupuestoCategoria)
                .WithRequired(e => e.Presupuesto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PresupuestoCategoria>()
                .Property(e => e.Monto)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Recordatorio>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Recordatorio>()
                .HasMany(e => e.PatronRecurrente)
                .WithRequired(e => e.Recordatorio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TarjetaCredito>()
                .Property(e => e.NumeroTarjeta)
                .IsUnicode(false);

            modelBuilder.Entity<TarjetaCredito>()
                .Property(e => e.NombreTitular)
                .IsUnicode(false);

            modelBuilder.Entity<TarjetaCredito>()
                .Property(e => e.ApellidoTitular)
                .IsUnicode(false);

            modelBuilder.Entity<TarjetaCredito>()
                .Property(e => e.CVC)
                .IsUnicode(false);

            modelBuilder.Entity<TarjetaCredito>()
                .Property(e => e.TasaEfectivaAnual)
                .HasPrecision(8, 4);

            modelBuilder.Entity<TarjetaCredito>()
                .Property(e => e.DeudaInicial)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TarjetaCredito>()
                .Property(e => e.LimiteCredito)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TarjetaCredito>()
                .Property(e => e.Comentario)
                .IsUnicode(false);

            modelBuilder.Entity<TipoCategoria>()
                .Property(e => e.Tipo)
                .IsUnicode(false);

            modelBuilder.Entity<TipoCategoria>()
                .HasMany(e => e.Categoria)
                .WithRequired(e => e.TipoCategoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoRecurrencia>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<TipoRecurrencia>()
                .HasMany(e => e.PatronRecurrente)
                .WithRequired(e => e.TipoRecurrencia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Transaccion>()
                .Property(e => e.No_Ref_Externo)
                .IsUnicode(false);

            modelBuilder.Entity<Transaccion>()
                .Property(e => e.Adjunto)
                .IsUnicode(false);

            modelBuilder.Entity<Transaccion>()
                .Property(e => e.MontoIngreso)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Transaccion>()
                .Property(e => e.MontroEgreso)
                .HasPrecision(19, 4);

            modelBuilder.Entity<User>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Sexo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Categoria)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UsuarioID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Contacto)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UsuarioID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.CuentaBanco)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UsuarioID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.CuentaPrestamo)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UsuarioID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Presupuesto)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UsuarioID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Recordatorio)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UsuarioID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TarjetaCredito)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UsuarioID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Transaccion)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UsuarioID)
                .WillCascadeOnDelete(false);
        }
    }
}
