namespace Cashflow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTablesPeridoAndTipo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Periodos",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Nombre = c.String(nullable: false),
                        Valor = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tipos",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Flujos", "TipoId", c => c.Byte(nullable: false));
            AddColumn("dbo.Flujos", "PeriodoId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Flujos", "TipoId");
            CreateIndex("dbo.Flujos", "PeriodoId");
            AddForeignKey("dbo.Flujos", "PeriodoId", "dbo.Periodos", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Flujos", "TipoId", "dbo.Tipos", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Flujos", "TipoId", "dbo.Tipos");
            DropForeignKey("dbo.Flujos", "PeriodoId", "dbo.Periodos");
            DropIndex("dbo.Flujos", new[] { "PeriodoId" });
            DropIndex("dbo.Flujos", new[] { "TipoId" });
            DropColumn("dbo.Flujos", "PeriodoId");
            DropColumn("dbo.Flujos", "TipoId");
            DropTable("dbo.Tipos");
            DropTable("dbo.Periodos");
        }
    }
}
