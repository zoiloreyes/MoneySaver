using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FinanzasPersonales.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("Email", this.Email.ToString()));
            userIdentity.AddClaim(new Claim("PhoneNumber", this.PhoneNumber.ToString()));
            userIdentity.AddClaim(new Claim("MoneySaverUserID", this.User.Id.ToString()));
            

            return userIdentity;
        }
        public virtual User User { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer<ApplicationDbContext>(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            // Configure Student & StudentAddress entity
            modelBuilder.Entity<ApplicationUser>()
                        .HasRequired(s => s.User) // Mark Address property optional in Student entity
                        .WithOptional(m => m.ApplicationUser); // mark Student property as required in StudentAddress entity. Cannot save StudentAddress without Student

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
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

        public System.Data.Entity.DbSet<FinanzasPersonales.Models.Moneda> Monedas { get; set; }

        public System.Data.Entity.DbSet<FinanzasPersonales.Models.User> Users1 { get; set; }

        public virtual DbSet<Banco> Bancos { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Contacto> Contactos { get; set; }
        public virtual DbSet<CuentaBanco> CuentasBanco { get; set; }
        public virtual DbSet<CuentaPrestamo> CuentasPrestamo { get; set; }
        public virtual DbSet<EstadoCategoria> EstadosCategoria { get; set; }
        public virtual DbSet<EstadoCuentaBanco> EstadosCuentaBanco { get; set; }
        public virtual DbSet<EstadoTarjetaCredito> EstadosTarjetaCredito { get; set; }
        public virtual DbSet<EstadoTarjetaDebito> EstadosTarjetaDebito { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<PatronRecurrente> PatronesRecurrente { get; set; }
        public virtual DbSet<PeriodoTemporal> PeriodosTemporales { get; set; }
        public virtual DbSet<Presupuesto> Presupuestos { get; set; }
        public virtual DbSet<PresupuestoCategoria> PresupuestoCategoria { get; set; }
        public virtual DbSet<Recordatorio> Recordatorio { get; set; }
        public virtual DbSet<TarjetaCredito> TarjetasCredito { get; set; }
        public virtual DbSet<TipoCategoria> TiposCategoria { get; set; }
        public virtual DbSet<TipoRecurrencia> TiposRecurrencia { get; set; }
        public virtual DbSet<Transaccion> Transacciones { get; set; }
    }
}