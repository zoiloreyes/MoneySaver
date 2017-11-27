namespace FinanzasPersonales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nuevoCampoNombre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CuentaBanco", "NombreCuentaBanco", c => c.String(nullable: false, maxLength: 120));
            AddColumn("dbo.CuentaPrestamo", "NombrePrestamo", c => c.String(nullable: false, maxLength: 120));
            AddColumn("dbo.TarjetaCredito", "NombreTarjetaCredito", c => c.String(nullable: false, maxLength: 120));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TarjetaCredito", "NombreTarjetaCredito");
            DropColumn("dbo.CuentaPrestamo", "NombrePrestamo");
            DropColumn("dbo.CuentaBanco", "NombreCuentaBanco");
        }
    }
}
