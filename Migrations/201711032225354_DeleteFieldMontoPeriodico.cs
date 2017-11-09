namespace Cashflow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteFieldMontoPeriodico : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Flujos", "MontoPeriodico");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Flujos", "MontoPeriodico", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
