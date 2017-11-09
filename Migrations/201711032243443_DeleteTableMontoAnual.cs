namespace Cashflow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteTableMontoAnual : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MontoAnual", "FlujoId", "dbo.Flujos");
            DropIndex("dbo.MontoAnual", new[] { "FlujoId" });
            DropTable("dbo.MontoAnual");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MontoAnual",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FlujoId = c.Int(nullable: false),
                        Enero = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Febrero = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Marzo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Abril = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mayo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Junio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Julio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Agosto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Septiembre = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Octubre = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Noviembre = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Diciembre = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.MontoAnual", "FlujoId");
            AddForeignKey("dbo.MontoAnual", "FlujoId", "dbo.Flujos", "Id", cascadeDelete: true);
        }
    }
}
