namespace FinanzasPersonales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nomarca2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TarjetaCredito", "MarcaID", "dbo.Marca");
            DropIndex("dbo.TarjetaCredito", new[] { "MarcaID" });
            DropColumn("dbo.TarjetaCredito", "MarcaID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TarjetaCredito", "MarcaID", c => c.Int(nullable: false));
            CreateIndex("dbo.TarjetaCredito", "MarcaID");
            AddForeignKey("dbo.TarjetaCredito", "MarcaID", "dbo.Marca", "MarcaID", cascadeDelete: true);
        }
    }
}
