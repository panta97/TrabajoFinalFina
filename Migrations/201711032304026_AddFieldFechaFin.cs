namespace Cashflow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldFechaFin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flujos", "FechaFin", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Flujos", "FechaFin");
        }
    }
}
