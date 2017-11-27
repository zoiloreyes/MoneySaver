namespace FinanzasPersonales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Agregarcampoiconoacategorias : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categoria", "Icono", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categoria", "Icono");
        }
    }
}
