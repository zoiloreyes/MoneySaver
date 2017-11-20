namespace FinanzasPersonales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class identityConnection : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
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
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Apellido = c.String(nullable: false, maxLength: 50),
                        Sexo = c.String(nullable: false, maxLength: 1),
                        Direccion = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        CategoriaID = c.Int(nullable: false, identity: true),
                        EstadoCategoriaID = c.Int(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                        TipoCategoriaID = c.Int(nullable: false),
                        PadreCategoriaID = c.Int(),
                        MonedaID = c.Int(nullable: false),
                        Comentario = c.String(maxLength: 800),
                        Nombre = c.String(maxLength: 400),
                        Categoria2_CategoriaID = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.CategoriaID)
                .ForeignKey("dbo.Categoria", t => t.Categoria2_CategoriaID)
                .ForeignKey("dbo.EstadoCategoria", t => t.EstadoCategoriaID, cascadeDelete: true)
                .ForeignKey("dbo.Moneda", t => t.MonedaID, cascadeDelete: true)
                .ForeignKey("dbo.TipoCategoria", t => t.TipoCategoriaID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.EstadoCategoriaID)
                .Index(t => t.TipoCategoriaID)
                .Index(t => t.MonedaID)
                .Index(t => t.Categoria2_CategoriaID)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.EstadoCategoria",
                c => new
                    {
                        EstadoCategoriaID = c.Int(nullable: false, identity: true),
                        Estado = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.EstadoCategoriaID);
            
            CreateTable(
                "dbo.Moneda",
                c => new
                    {
                        MonedaID = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 3),
                        Nombre = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.MonedaID);
            
            CreateTable(
                "dbo.CuentaBanco",
                c => new
                    {
                        CuentaBancoID = c.Int(nullable: false, identity: true),
                        BancoID = c.Int(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                        EstadoCuentaBancoID = c.Int(nullable: false),
                        MonedaID = c.Int(nullable: false),
                        NumeroCuenta = c.String(nullable: false, maxLength: 40),
                        NombreTitular = c.String(nullable: false, maxLength: 80),
                        ApellidoTitular = c.String(nullable: false, maxLength: 80),
                        FechaInicio = c.DateTime(nullable: false, storeType: "date"),
                        BalanceInicial = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comentario = c.String(maxLength: 800),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.CuentaBancoID)
                .ForeignKey("dbo.Banco", t => t.BancoID, cascadeDelete: true)
                .ForeignKey("dbo.EstadoCuentaBanco", t => t.EstadoCuentaBancoID, cascadeDelete: true)
                .ForeignKey("dbo.Moneda", t => t.MonedaID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.BancoID)
                .Index(t => t.EstadoCuentaBancoID)
                .Index(t => t.MonedaID)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Banco",
                c => new
                    {
                        BancoID = c.Int(nullable: false, identity: true),
                        NombreBanco = c.String(nullable: false, maxLength: 200),
                        Pais = c.String(nullable: false, maxLength: 30),
                        UsuarioID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.BancoID);
            
            CreateTable(
                "dbo.TarjetaCredito",
                c => new
                    {
                        TarjetaCreditoID = c.Int(nullable: false, identity: true),
                        UsuarioID = c.Int(nullable: false),
                        BancoID = c.Int(nullable: false),
                        EstadoTarjetaCreditoID = c.Int(nullable: false),
                        MonedaID = c.Int(nullable: false),
                        NumeroTarjeta = c.String(nullable: false, maxLength: 40),
                        NombreTitular = c.String(nullable: false, maxLength: 80),
                        ApellidoTitular = c.String(nullable: false, maxLength: 80),
                        FechaInicio = c.DateTime(nullable: false, storeType: "date"),
                        FechaExpiracion = c.DateTime(nullable: false, storeType: "date"),
                        MarcaID = c.Int(nullable: false),
                        CVC = c.String(nullable: false, maxLength: 3),
                        TasaEfectivaAnual = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeudaInicial = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LimiteCredito = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comentario = c.String(maxLength: 800),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.TarjetaCreditoID)
                .ForeignKey("dbo.Banco", t => t.BancoID, cascadeDelete: true)
                .ForeignKey("dbo.EstadoTarjetaCredito", t => t.EstadoTarjetaCreditoID, cascadeDelete: true)
                .ForeignKey("dbo.Marca", t => t.MarcaID, cascadeDelete: true)
                .ForeignKey("dbo.Moneda", t => t.MonedaID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.BancoID)
                .Index(t => t.EstadoTarjetaCreditoID)
                .Index(t => t.MonedaID)
                .Index(t => t.MarcaID)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.EstadoTarjetaCredito",
                c => new
                    {
                        EstadoTarjetaCreditoID = c.Int(nullable: false, identity: true),
                        Estado = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.EstadoTarjetaCreditoID);
            
            CreateTable(
                "dbo.Marca",
                c => new
                    {
                        MarcaID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 200),
                        UsuarioID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.MarcaID);
            
            CreateTable(
                "dbo.Transaccion",
                c => new
                    {
                        TransaccionID = c.Int(nullable: false, identity: true),
                        UsuarioID = c.Int(nullable: false),
                        CuentaBancoID = c.Int(),
                        TarjetaCreditoID = c.Int(),
                        CuentaPrestamoID = c.Int(),
                        ContactoID = c.Int(),
                        No_Ref_Externo = c.String(maxLength: 100),
                        Fecha = c.DateTime(storeType: "date"),
                        EFECTIVO = c.Boolean(),
                        Adjunto = c.String(maxLength: 900),
                        MontoIngreso = c.Decimal(precision: 18, scale: 2),
                        MontroEgreso = c.Decimal(precision: 18, scale: 2),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.TransaccionID)
                .ForeignKey("dbo.Contacto", t => t.ContactoID)
                .ForeignKey("dbo.CuentaBanco", t => t.CuentaBancoID)
                .ForeignKey("dbo.CuentaPrestamo", t => t.CuentaPrestamoID)
                .ForeignKey("dbo.TarjetaCredito", t => t.TarjetaCreditoID)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.CuentaBancoID)
                .Index(t => t.TarjetaCreditoID)
                .Index(t => t.CuentaPrestamoID)
                .Index(t => t.ContactoID)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Contacto",
                c => new
                    {
                        ContactoID = c.Int(nullable: false, identity: true),
                        UsuarioID = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 300),
                        Email = c.String(maxLength: 256),
                        Direccion = c.String(maxLength: 500),
                        Telefono = c.String(maxLength: 400),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ContactoID)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.CuentaPrestamo",
                c => new
                    {
                        CuentaPrestamoID = c.Int(nullable: false, identity: true),
                        MonedaID = c.Int(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                        CapitalInicial = c.Decimal(precision: 18, scale: 2),
                        TasaAnual = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PagosPorAno = c.Int(),
                        FechaInicio = c.DateTime(storeType: "date"),
                        NumeroPagos = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.CuentaPrestamoID)
                .ForeignKey("dbo.Moneda", t => t.MonedaID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.MonedaID)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Recordatorio",
                c => new
                    {
                        RecordatorioID = c.Int(nullable: false, identity: true),
                        UsuarioID = c.Int(nullable: false),
                        TransaccionID = c.Int(),
                        Descripcion = c.String(nullable: false, maxLength: 500),
                        FechaInicio = c.DateTime(storeType: "date"),
                        FechaFin = c.DateTime(storeType: "date"),
                        EsRecurrente = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(storeType: "date"),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.RecordatorioID)
                .ForeignKey("dbo.Transaccion", t => t.TransaccionID)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.TransaccionID)
                .Index(t => t.User_Id);
            
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
                .ForeignKey("dbo.Recordatorio", t => t.RecordatorioID, cascadeDelete: true)
                .ForeignKey("dbo.TipoRecurrencia", t => t.TipoRecurrenciaID, cascadeDelete: true)
                .Index(t => t.RecordatorioID)
                .Index(t => t.TipoRecurrenciaID);
            
            CreateTable(
                "dbo.TipoRecurrencia",
                c => new
                    {
                        TipoRecurrenciaID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.TipoRecurrenciaID);
            
            CreateTable(
                "dbo.EstadoCuentaBanco",
                c => new
                    {
                        EstadoCuentaBancoID = c.Int(nullable: false, identity: true),
                        Estado = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.EstadoCuentaBancoID);
            
            CreateTable(
                "dbo.PresupuestoCategoria",
                c => new
                    {
                        PresupuestoCategoriaID = c.Int(nullable: false, identity: true),
                        CategoriaID = c.Int(nullable: false),
                        PresupuestoID = c.Int(nullable: false),
                        Monto = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PresupuestoCategoriaID)
                .ForeignKey("dbo.Categoria", t => t.CategoriaID, cascadeDelete: true)
                .ForeignKey("dbo.Presupuesto", t => t.PresupuestoID, cascadeDelete: true)
                .Index(t => t.CategoriaID)
                .Index(t => t.PresupuestoID);
            
            CreateTable(
                "dbo.Presupuesto",
                c => new
                    {
                        PresupuestoID = c.Int(nullable: false, identity: true),
                        PeriodoTemporalID = c.Int(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 200),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.PresupuestoID)
                .ForeignKey("dbo.PeriodoTemporal", t => t.PeriodoTemporalID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.PeriodoTemporalID)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.PeriodoTemporal",
                c => new
                    {
                        PeriodoTemporalID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.PeriodoTemporalID);
            
            CreateTable(
                "dbo.TipoCategoria",
                c => new
                    {
                        TipoCategoriaID = c.Int(nullable: false, identity: true),
                        Tipo = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.TipoCategoriaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUsers", "User_Id", "dbo.User");
            DropForeignKey("dbo.Categoria", "User_Id", "dbo.User");
            DropForeignKey("dbo.Categoria", "TipoCategoriaID", "dbo.TipoCategoria");
            DropForeignKey("dbo.Presupuesto", "User_Id", "dbo.User");
            DropForeignKey("dbo.PresupuestoCategoria", "PresupuestoID", "dbo.Presupuesto");
            DropForeignKey("dbo.Presupuesto", "PeriodoTemporalID", "dbo.PeriodoTemporal");
            DropForeignKey("dbo.PresupuestoCategoria", "CategoriaID", "dbo.Categoria");
            DropForeignKey("dbo.CuentaBanco", "User_Id", "dbo.User");
            DropForeignKey("dbo.CuentaBanco", "MonedaID", "dbo.Moneda");
            DropForeignKey("dbo.CuentaBanco", "EstadoCuentaBancoID", "dbo.EstadoCuentaBanco");
            DropForeignKey("dbo.TarjetaCredito", "User_Id", "dbo.User");
            DropForeignKey("dbo.Transaccion", "User_Id", "dbo.User");
            DropForeignKey("dbo.Transaccion", "TarjetaCreditoID", "dbo.TarjetaCredito");
            DropForeignKey("dbo.Recordatorio", "User_Id", "dbo.User");
            DropForeignKey("dbo.Recordatorio", "TransaccionID", "dbo.Transaccion");
            DropForeignKey("dbo.PatronRecurrente", "TipoRecurrenciaID", "dbo.TipoRecurrencia");
            DropForeignKey("dbo.PatronRecurrente", "RecordatorioID", "dbo.Recordatorio");
            DropForeignKey("dbo.CuentaPrestamo", "User_Id", "dbo.User");
            DropForeignKey("dbo.Transaccion", "CuentaPrestamoID", "dbo.CuentaPrestamo");
            DropForeignKey("dbo.CuentaPrestamo", "MonedaID", "dbo.Moneda");
            DropForeignKey("dbo.Transaccion", "CuentaBancoID", "dbo.CuentaBanco");
            DropForeignKey("dbo.Contacto", "User_Id", "dbo.User");
            DropForeignKey("dbo.Transaccion", "ContactoID", "dbo.Contacto");
            DropForeignKey("dbo.TarjetaCredito", "MonedaID", "dbo.Moneda");
            DropForeignKey("dbo.TarjetaCredito", "MarcaID", "dbo.Marca");
            DropForeignKey("dbo.TarjetaCredito", "EstadoTarjetaCreditoID", "dbo.EstadoTarjetaCredito");
            DropForeignKey("dbo.TarjetaCredito", "BancoID", "dbo.Banco");
            DropForeignKey("dbo.CuentaBanco", "BancoID", "dbo.Banco");
            DropForeignKey("dbo.Categoria", "MonedaID", "dbo.Moneda");
            DropForeignKey("dbo.Categoria", "EstadoCategoriaID", "dbo.EstadoCategoria");
            DropForeignKey("dbo.Categoria", "Categoria2_CategoriaID", "dbo.Categoria");
            DropForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropIndex("dbo.Presupuesto", new[] { "User_Id" });
            DropIndex("dbo.Presupuesto", new[] { "PeriodoTemporalID" });
            DropIndex("dbo.PresupuestoCategoria", new[] { "PresupuestoID" });
            DropIndex("dbo.PresupuestoCategoria", new[] { "CategoriaID" });
            DropIndex("dbo.PatronRecurrente", new[] { "TipoRecurrenciaID" });
            DropIndex("dbo.PatronRecurrente", new[] { "RecordatorioID" });
            DropIndex("dbo.Recordatorio", new[] { "User_Id" });
            DropIndex("dbo.Recordatorio", new[] { "TransaccionID" });
            DropIndex("dbo.CuentaPrestamo", new[] { "User_Id" });
            DropIndex("dbo.CuentaPrestamo", new[] { "MonedaID" });
            DropIndex("dbo.Contacto", new[] { "User_Id" });
            DropIndex("dbo.Transaccion", new[] { "User_Id" });
            DropIndex("dbo.Transaccion", new[] { "ContactoID" });
            DropIndex("dbo.Transaccion", new[] { "CuentaPrestamoID" });
            DropIndex("dbo.Transaccion", new[] { "TarjetaCreditoID" });
            DropIndex("dbo.Transaccion", new[] { "CuentaBancoID" });
            DropIndex("dbo.TarjetaCredito", new[] { "User_Id" });
            DropIndex("dbo.TarjetaCredito", new[] { "MarcaID" });
            DropIndex("dbo.TarjetaCredito", new[] { "MonedaID" });
            DropIndex("dbo.TarjetaCredito", new[] { "EstadoTarjetaCreditoID" });
            DropIndex("dbo.TarjetaCredito", new[] { "BancoID" });
            DropIndex("dbo.CuentaBanco", new[] { "User_Id" });
            DropIndex("dbo.CuentaBanco", new[] { "MonedaID" });
            DropIndex("dbo.CuentaBanco", new[] { "EstadoCuentaBancoID" });
            DropIndex("dbo.CuentaBanco", new[] { "BancoID" });
            DropIndex("dbo.Categoria", new[] { "User_Id" });
            DropIndex("dbo.Categoria", new[] { "Categoria2_CategoriaID" });
            DropIndex("dbo.Categoria", new[] { "MonedaID" });
            DropIndex("dbo.Categoria", new[] { "TipoCategoriaID" });
            DropIndex("dbo.Categoria", new[] { "EstadoCategoriaID" });
            DropIndex("dbo.IdentityUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUsers", new[] { "User_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropTable("dbo.TipoCategoria");
            DropTable("dbo.PeriodoTemporal");
            DropTable("dbo.Presupuesto");
            DropTable("dbo.PresupuestoCategoria");
            DropTable("dbo.EstadoCuentaBanco");
            DropTable("dbo.TipoRecurrencia");
            DropTable("dbo.PatronRecurrente");
            DropTable("dbo.Recordatorio");
            DropTable("dbo.CuentaPrestamo");
            DropTable("dbo.Contacto");
            DropTable("dbo.Transaccion");
            DropTable("dbo.Marca");
            DropTable("dbo.EstadoTarjetaCredito");
            DropTable("dbo.TarjetaCredito");
            DropTable("dbo.Banco");
            DropTable("dbo.CuentaBanco");
            DropTable("dbo.Moneda");
            DropTable("dbo.EstadoCategoria");
            DropTable("dbo.Categoria");
            DropTable("dbo.User");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityRoles");
        }
    }
}
