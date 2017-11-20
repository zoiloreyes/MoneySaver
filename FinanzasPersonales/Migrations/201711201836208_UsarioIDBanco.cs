namespace FinanzasPersonales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsarioIDBanco : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Banco", "UsuarioID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Banco", "UsuarioID", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
