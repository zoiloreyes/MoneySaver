namespace FinanzasPersonales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Categoriasinmoneda : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categoria", "MonedaID", "dbo.Moneda");
            AddForeignKey("dbo.Categoria", "MonedaID", "dbo.Moneda", "MonedaID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categoria", "MonedaID", "dbo.Moneda");
            AddForeignKey("dbo.Categoria", "MonedaID", "dbo.Moneda", "MonedaID");
        }
    }
}
