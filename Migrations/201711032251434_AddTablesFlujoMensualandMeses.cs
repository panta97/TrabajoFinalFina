namespace Cashflow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTablesFlujoMensualandMeses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FlujosMensuales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MesId = c.Byte(nullable: false),
                        FlujoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Flujos", t => t.FlujoId, cascadeDelete: true)
                .ForeignKey("dbo.Meses", t => t.MesId, cascadeDelete: true)
                .Index(t => t.MesId)
                .Index(t => t.FlujoId);
            
            CreateTable(
                "dbo.Meses",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FlujosMensuales", "MesId", "dbo.Meses");
            DropForeignKey("dbo.FlujosMensuales", "FlujoId", "dbo.Flujos");
            DropIndex("dbo.FlujosMensuales", new[] { "FlujoId" });
            DropIndex("dbo.FlujosMensuales", new[] { "MesId" });
            DropTable("dbo.Meses");
            DropTable("dbo.FlujosMensuales");
        }
    }
}
