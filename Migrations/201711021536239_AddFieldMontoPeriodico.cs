namespace Cashflow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldMontoPeriodico : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flujos", "MontoPeriodico", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Flujos", "MontoPeriodico");
        }
    }
}
