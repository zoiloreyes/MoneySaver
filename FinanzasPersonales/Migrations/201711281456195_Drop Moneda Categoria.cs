namespace FinanzasPersonales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropMonedaCategoria : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categoria", "Moneda_MonedaID", "dbo.Moneda");
            DropIndex("dbo.Categoria", new[] { "Moneda_MonedaID" });
            DropColumn("dbo.Categoria", "Moneda_MonedaID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categoria", "Moneda_MonedaID", c => c.Int());
            CreateIndex("dbo.Categoria", "Moneda_MonedaID");
            AddForeignKey("dbo.Categoria", "Moneda_MonedaID", "dbo.Moneda", "MonedaID");
        }
    }
}
