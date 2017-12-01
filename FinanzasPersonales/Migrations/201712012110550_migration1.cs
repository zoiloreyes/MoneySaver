namespace FinanzasPersonales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Banco",
                c => new
                    {
                        BancoID = c.Int(nullable: false, identity: true),
                        NombreBanco = c.String(nullable: false, maxLength: 200, unicode: false),
                        Pais = c.String(nullable: false, maxLength: 30, unicode: false),
                        UsuarioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BancoID);
            
            CreateTable(
                "dbo.CuentaBanco",
                c => new
                    {
                        CuentaBancoID = c.Int(nullable: false, identity: true),
                        BancoID = c.Int(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                        EstadoCuentaBancoID = c.Int(nullable: false),
                        MonedaID = c.Int(nullable: false),
                        NombreCuentaBanco = c.String(nullable: false, maxLength: 120),
                        NumeroCuenta = c.String(nullable: false, maxLength: 40, unicode: false),
                        NombreTitular = c.String(nullable: false, maxLength: 80, unicode: false),
                        ApellidoTitular = c.String(nullable: false, maxLength: 80, unicode: false),
                        FechaInicio = c.DateTime(nullable: false, storeType: "date"),
                        BalanceInicial = c.Decimal(nullable: false, precision: 19, scale: 4),
                        Comentario = c.String(maxLength: 800, unicode: false),
                    })
                .PrimaryKey(t => t.CuentaBancoID)
                .ForeignKey("dbo.EstadoCuentaBanco", t => t.EstadoCuentaBancoID)
                .ForeignKey("dbo.Moneda", t => t.MonedaID)
                .ForeignKey("dbo.User", t => t.UsuarioID)
                .ForeignKey("dbo.Banco", t => t.BancoID)
                .Index(t => t.BancoID)
                .Index(t => t.UsuarioID)
                .Index(t => t.EstadoCuentaBancoID)
                .Index(t => t.MonedaID);
            
            CreateTable(
                "dbo.EstadoCuentaBanco",
                c => new
                    {
                        EstadoCuentaBancoID = c.Int(nullable: false, identity: true),
                        Estado = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.EstadoCuentaBancoID);
            
            CreateTable(
                "dbo.Moneda",
                c => new
                    {
                        MonedaID = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 3, unicode: false),
                        Nombre = c.String(nullable: false, maxLength: 60, unicode: false),
                    })
                .PrimaryKey(t => t.MonedaID);
            
            CreateTable(
                "dbo.CuentaPrestamo",
                c => new
                    {
                        CuentaPrestamoID = c.Int(nullable: false, identity: true),
                        NombrePrestamo = c.String(nullable: false, maxLength: 120),
                        MonedaID = c.Int(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                        CapitalInicial = c.Decimal(precision: 19, scale: 4),
                        TasaAnual = c.Decimal(nullable: false, precision: 8, scale: 4),
                        PagosPorAno = c.Int(),
                        FechaInicio = c.DateTime(storeType: "date"),
                        NumeroPagos = c.Int(),
                    })
                .PrimaryKey(t => t.CuentaPrestamoID)
                .ForeignKey("dbo.User", t => t.UsuarioID)
                .ForeignKey("dbo.Moneda", t => t.MonedaID)
                .Index(t => t.MonedaID)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.Transaccion",
                c => new
                    {
                        TransaccionID = c.Int(nullable: false, identity: true),
                        UsuarioID = c.Int(nullable: false),
                        CategoriaID = c.Int(),
                        CuentaBancoID = c.Int(),
                        TarjetaCreditoID = c.Int(),
                        CuentaPrestamoID = c.Int(),
                        ContactoID = c.Int(),
                        No_Ref_Externo = c.String(maxLength: 100, unicode: false),
                        Fecha = c.DateTime(storeType: "date"),
                        EFECTIVO = c.Boolean(),
                        Adjunto = c.String(maxLength: 900, unicode: false),
                        MontoIngreso = c.Decimal(precision: 19, scale: 4),
                        MontroEgreso = c.Decimal(precision: 19, scale: 4),
                    })
                .PrimaryKey(t => t.TransaccionID)
                .ForeignKey("dbo.Contacto", t => t.ContactoID)
                .ForeignKey("dbo.TarjetaCredito", t => t.TarjetaCreditoID)
                .ForeignKey("dbo.User", t => t.UsuarioID)
                .ForeignKey("dbo.Categoria", t => t.CategoriaID)
                .ForeignKey("dbo.CuentaBanco", t => t.CuentaBancoID)
                .ForeignKey("dbo.CuentaPrestamo", t => t.CuentaPrestamoID)
                .Index(t => t.UsuarioID)
                .Index(t => t.CategoriaID)
                .Index(t => t.CuentaBancoID)
                .Index(t => t.TarjetaCreditoID)
                .Index(t => t.CuentaPrestamoID)
                .Index(t => t.ContactoID);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        CategoriaID = c.Int(nullable: false, identity: true),
                        PadreCategoriaID = c.Int(),
                        Comentario = c.String(maxLength: 800, unicode: false),
                        Nombre = c.String(maxLength: 400, unicode: false),
                        Icono = c.String(),
                        EstadoCategoriaID = c.Int(nullable: false),
                        TipoCategoriaID = c.Int(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoriaID)
                .ForeignKey("dbo.Categoria", t => t.PadreCategoriaID)
                .ForeignKey("dbo.EstadoCategoria", t => t.EstadoCategoriaID)
                .ForeignKey("dbo.User", t => t.UsuarioID)
                .ForeignKey("dbo.TipoCategoria", t => t.TipoCategoriaID)
                .Index(t => t.PadreCategoriaID)
                .Index(t => t.EstadoCategoriaID)
                .Index(t => t.TipoCategoriaID)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.EstadoCategoria",
                c => new
                    {
                        EstadoCategoriaID = c.Int(nullable: false, identity: true),
                        Estado = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.EstadoCategoriaID);
            
            CreateTable(
                "dbo.PresupuestoCategoria",
                c => new
                    {
                        PresupuestoCategoriaID = c.Int(nullable: false, identity: true),
                        CategoriaID = c.Int(nullable: false),
                        PresupuestoID = c.Int(nullable: false),
                        Monto = c.Decimal(precision: 19, scale: 4),
                    })
                .PrimaryKey(t => t.PresupuestoCategoriaID)
                .ForeignKey("dbo.Presupuesto", t => t.PresupuestoID)
                .ForeignKey("dbo.Categoria", t => t.CategoriaID)
                .Index(t => t.CategoriaID)
                .Index(t => t.PresupuestoID);
            
            CreateTable(
                "dbo.Presupuesto",
                c => new
                    {
                        PresupuestoID = c.Int(nullable: false, identity: true),
                        PeriodoTemporalID = c.Int(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.PresupuestoID)
                .ForeignKey("dbo.PeriodoTemporal", t => t.PeriodoTemporalID)
                .ForeignKey("dbo.User", t => t.UsuarioID)
                .Index(t => t.PeriodoTemporalID)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.PeriodoTemporal",
                c => new
                    {
                        PeriodoTemporalID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.PeriodoTemporalID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        Apellido = c.String(nullable: false, maxLength: 50, unicode: false),
                        Sexo = c.String(nullable: false, maxLength: 1, fixedLength: true, unicode: false),
                        Direccion = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.Contacto",
                c => new
                    {
                        ContactoID = c.Int(nullable: false, identity: true),
                        UsuarioID = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 300, unicode: false),
                        Email = c.String(maxLength: 256, unicode: false),
                        Direccion = c.String(maxLength: 500, unicode: false),
                        Telefono = c.String(maxLength: 400, unicode: false),
                    })
                .PrimaryKey(t => t.ContactoID)
                .ForeignKey("dbo.User", t => t.UsuarioID)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.Recordatorio",
                c => new
                    {
                        RecordatorioID = c.Int(nullable: false, identity: true),
                        UsuarioID = c.Int(nullable: false),
                        TransaccionID = c.Int(),
                        Descripcion = c.String(nullable: false, maxLength: 500, unicode: false),
                        FechaInicio = c.DateTime(storeType: "date"),
                        FechaFin = c.DateTime(storeType: "date"),
                        EsRecurrente = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.RecordatorioID)
                .ForeignKey("dbo.Transaccion", t => t.TransaccionID)
                .ForeignKey("dbo.User", t => t.UsuarioID)
                .Index(t => t.UsuarioID)
                .Index(t => t.TransaccionID);
            
            CreateTable(
                "dbo.PatronRecurrente",
                c => new
                    {
                        PatronRecurrenteID = c.Int(nullable: false, identity: true),
                        RecordatorioID = c.Int(nullable: false),
                        TipoRecurrenciaID = c.Int(nullable: false),
                        NumeroSeparaciones = c.Int(),
                        NumeroMaxOcurrencia = c.Int(),
                        DiaDeSemana = c.Int(),
                        SemanaDeMes = c.Int(),
                        DiaDeMes = c.Int(),
                        MesDeAno = c.Int(),
                    })
                .PrimaryKey(t => t.PatronRecurrenteID)
                .ForeignKey("dbo.TipoRecurrencia", t => t.TipoRecurrenciaID)
                .ForeignKey("dbo.Recordatorio", t => t.RecordatorioID)
                .Index(t => t.RecordatorioID)
                .Index(t => t.TipoRecurrenciaID);
            
            CreateTable(
                "dbo.TipoRecurrencia",
                c => new
                    {
                        TipoRecurrenciaID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.TipoRecurrenciaID);
            
            CreateTable(
                "dbo.TarjetaCredito",
                c => new
                    {
                        TarjetaCreditoID = c.Int(nullable: false, identity: true),
                        UsuarioID = c.Int(nullable: false),
                        BancoID = c.Int(nullable: false),
                        EstadoTarjetaCreditoID = c.Int(nullable: false),
                        MonedaID = c.Int(nullable: false),
                        NombreTarjetaCredito = c.String(nullable: false, maxLength: 120),
                        NumeroTarjeta = c.String(nullable: false, maxLength: 40, unicode: false),
                        NombreTitular = c.String(nullable: false, maxLength: 80, unicode: false),
                        ApellidoTitular = c.String(nullable: false, maxLength: 80, unicode: false),
                        FechaInicio = c.DateTime(nullable: false, storeType: "date"),
                        FechaExpiracion = c.DateTime(nullable: false, storeType: "date"),
                        CVC = c.String(nullable: false, maxLength: 3, unicode: false),
                        TasaEfectivaAnual = c.Decimal(nullable: false, precision: 8, scale: 4),
                        DeudaInicial = c.Decimal(nullable: false, precision: 19, scale: 4),
                        LimiteCredito = c.Decimal(nullable: false, precision: 19, scale: 4),
                        Comentario = c.String(maxLength: 800, unicode: false),
                    })
                .PrimaryKey(t => t.TarjetaCreditoID)
                .ForeignKey("dbo.EstadoTarjetaCredito", t => t.EstadoTarjetaCreditoID)
                .ForeignKey("dbo.User", t => t.UsuarioID)
                .ForeignKey("dbo.Moneda", t => t.MonedaID)
                .ForeignKey("dbo.Banco", t => t.BancoID)
                .Index(t => t.UsuarioID)
                .Index(t => t.BancoID)
                .Index(t => t.EstadoTarjetaCreditoID)
                .Index(t => t.MonedaID);
            
            CreateTable(
                "dbo.EstadoTarjetaCredito",
                c => new
                    {
                        EstadoTarjetaCreditoID = c.Int(nullable: false, identity: true),
                        Estado = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.EstadoTarjetaCreditoID);
            
            CreateTable(
                "dbo.TipoCategoria",
                c => new
                    {
                        TipoCategoriaID = c.Int(nullable: false, identity: true),
                        Tipo = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.TipoCategoriaID);
            
            CreateTable(
                "dbo.EstadoTarjetaDebito",
                c => new
                    {
                        EstadoTarjetaDebitoID = c.Int(nullable: false, identity: true),
                        Estado = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.EstadoTarjetaDebitoID);
            
            CreateTable(
                "dbo.Marca",
                c => new
                    {
                        MarcaID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 200, unicode: false),
                        UsuarioID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.MarcaID);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.TarjetaCredito", "BancoID", "dbo.Banco");
            DropForeignKey("dbo.CuentaBanco", "BancoID", "dbo.Banco");
            DropForeignKey("dbo.TarjetaCredito", "MonedaID", "dbo.Moneda");
            DropForeignKey("dbo.CuentaPrestamo", "MonedaID", "dbo.Moneda");
            DropForeignKey("dbo.Transaccion", "CuentaPrestamoID", "dbo.CuentaPrestamo");
            DropForeignKey("dbo.Transaccion", "CuentaBancoID", "dbo.CuentaBanco");
            DropForeignKey("dbo.Transaccion", "CategoriaID", "dbo.Categoria");
            DropForeignKey("dbo.Categoria", "TipoCategoriaID", "dbo.TipoCategoria");
            DropForeignKey("dbo.PresupuestoCategoria", "CategoriaID", "dbo.Categoria");
            DropForeignKey("dbo.Transaccion", "UsuarioID", "dbo.User");
            DropForeignKey("dbo.TarjetaCredito", "UsuarioID", "dbo.User");
            DropForeignKey("dbo.Transaccion", "TarjetaCreditoID", "dbo.TarjetaCredito");
            DropForeignKey("dbo.TarjetaCredito", "EstadoTarjetaCreditoID", "dbo.EstadoTarjetaCredito");
            DropForeignKey("dbo.Recordatorio", "UsuarioID", "dbo.User");
            DropForeignKey("dbo.Recordatorio", "TransaccionID", "dbo.Transaccion");
            DropForeignKey("dbo.PatronRecurrente", "RecordatorioID", "dbo.Recordatorio");
            DropForeignKey("dbo.PatronRecurrente", "TipoRecurrenciaID", "dbo.TipoRecurrencia");
            DropForeignKey("dbo.Presupuesto", "UsuarioID", "dbo.User");
            DropForeignKey("dbo.CuentaPrestamo", "UsuarioID", "dbo.User");
            DropForeignKey("dbo.CuentaBanco", "UsuarioID", "dbo.User");
            DropForeignKey("dbo.Contacto", "UsuarioID", "dbo.User");
            DropForeignKey("dbo.Transaccion", "ContactoID", "dbo.Contacto");
            DropForeignKey("dbo.Categoria", "UsuarioID", "dbo.User");
            DropForeignKey("dbo.ApplicationUsers", "User_Id", "dbo.User");
            DropForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.PresupuestoCategoria", "PresupuestoID", "dbo.Presupuesto");
            DropForeignKey("dbo.Presupuesto", "PeriodoTemporalID", "dbo.PeriodoTemporal");
            DropForeignKey("dbo.Categoria", "EstadoCategoriaID", "dbo.EstadoCategoria");
            DropForeignKey("dbo.Categoria", "PadreCategoriaID", "dbo.Categoria");
            DropForeignKey("dbo.CuentaBanco", "MonedaID", "dbo.Moneda");
            DropForeignKey("dbo.CuentaBanco", "EstadoCuentaBancoID", "dbo.EstadoCuentaBanco");
            DropIndex("dbo.TarjetaCredito", new[] { "MonedaID" });
            DropIndex("dbo.TarjetaCredito", new[] { "EstadoTarjetaCreditoID" });
            DropIndex("dbo.TarjetaCredito", new[] { "BancoID" });
            DropIndex("dbo.TarjetaCredito", new[] { "UsuarioID" });
            DropIndex("dbo.PatronRecurrente", new[] { "TipoRecurrenciaID" });
            DropIndex("dbo.PatronRecurrente", new[] { "RecordatorioID" });
            DropIndex("dbo.Recordatorio", new[] { "TransaccionID" });
            DropIndex("dbo.Recordatorio", new[] { "UsuarioID" });
            DropIndex("dbo.Contacto", new[] { "UsuarioID" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUsers", new[] { "User_Id" });
            DropIndex("dbo.Presupuesto", new[] { "UsuarioID" });
            DropIndex("dbo.Presupuesto", new[] { "PeriodoTemporalID" });
            DropIndex("dbo.PresupuestoCategoria", new[] { "PresupuestoID" });
            DropIndex("dbo.PresupuestoCategoria", new[] { "CategoriaID" });
            DropIndex("dbo.Categoria", new[] { "UsuarioID" });
            DropIndex("dbo.Categoria", new[] { "TipoCategoriaID" });
            DropIndex("dbo.Categoria", new[] { "EstadoCategoriaID" });
            DropIndex("dbo.Categoria", new[] { "PadreCategoriaID" });
            DropIndex("dbo.Transaccion", new[] { "ContactoID" });
            DropIndex("dbo.Transaccion", new[] { "CuentaPrestamoID" });
            DropIndex("dbo.Transaccion", new[] { "TarjetaCreditoID" });
            DropIndex("dbo.Transaccion", new[] { "CuentaBancoID" });
            DropIndex("dbo.Transaccion", new[] { "CategoriaID" });
            DropIndex("dbo.Transaccion", new[] { "UsuarioID" });
            DropIndex("dbo.CuentaPrestamo", new[] { "UsuarioID" });
            DropIndex("dbo.CuentaPrestamo", new[] { "MonedaID" });
            DropIndex("dbo.CuentaBanco", new[] { "MonedaID" });
            DropIndex("dbo.CuentaBanco", new[] { "EstadoCuentaBancoID" });
            DropIndex("dbo.CuentaBanco", new[] { "UsuarioID" });
            DropIndex("dbo.CuentaBanco", new[] { "BancoID" });
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.Marca");
            DropTable("dbo.EstadoTarjetaDebito");
            DropTable("dbo.TipoCategoria");
            DropTable("dbo.EstadoTarjetaCredito");
            DropTable("dbo.TarjetaCredito");
            DropTable("dbo.TipoRecurrencia");
            DropTable("dbo.PatronRecurrente");
            DropTable("dbo.Recordatorio");
            DropTable("dbo.Contacto");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.User");
            DropTable("dbo.PeriodoTemporal");
            DropTable("dbo.Presupuesto");
            DropTable("dbo.PresupuestoCategoria");
            DropTable("dbo.EstadoCategoria");
            DropTable("dbo.Categoria");
            DropTable("dbo.Transaccion");
            DropTable("dbo.CuentaPrestamo");
            DropTable("dbo.Moneda");
            DropTable("dbo.EstadoCuentaBanco");
            DropTable("dbo.CuentaBanco");
            DropTable("dbo.Banco");
        }
    }
}
