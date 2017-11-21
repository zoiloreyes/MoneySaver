namespace FinanzasPersonales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class añadidaRelacionTransaccion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaccion", "CategoriaID", c => c.Int());
            CreateIndex("dbo.Transaccion", "CategoriaID");
            AddForeignKey("dbo.Transaccion", "CategoriaID", "dbo.Categoria", "CategoriaID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaccion", "CategoriaID", "dbo.Categoria");
            DropIndex("dbo.Transaccion", new[] { "CategoriaID" });
            DropColumn("dbo.Transaccion", "CategoriaID");
        }
    }
}
