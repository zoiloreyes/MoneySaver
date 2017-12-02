namespace FinanzasPersonales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambioMontro : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaccion", "MontoEgreso", c => c.Decimal(precision: 19, scale: 4));
            DropColumn("dbo.Transaccion", "MontroEgreso");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transaccion", "MontroEgreso", c => c.Decimal(precision: 19, scale: 4));
            DropColumn("dbo.Transaccion", "MontoEgreso");
        }
    }
}
