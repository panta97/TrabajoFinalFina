namespace Cashflow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIntoFlujoTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flujos", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Flujos", "ApplicationUserId");
            AddForeignKey("dbo.Flujos", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Flujos", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Flujos", new[] { "ApplicationUserId" });
            DropColumn("dbo.Flujos", "ApplicationUserId");
        }
    }
}
