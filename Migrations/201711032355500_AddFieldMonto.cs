namespace Cashflow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldMonto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FlujosMensuales", "Monto", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FlujosMensuales", "Monto");
        }
    }
}
