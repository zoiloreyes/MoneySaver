namespace FinanzasPersonales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nomarca : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TarjetaCredito", "MarcaID", "dbo.Marca");
            AddForeignKey("dbo.TarjetaCredito", "MarcaID", "dbo.Marca", "MarcaID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TarjetaCredito", "MarcaID", "dbo.Marca");
            AddForeignKey("dbo.TarjetaCredito", "MarcaID", "dbo.Marca", "MarcaID");
        }
    }
}
