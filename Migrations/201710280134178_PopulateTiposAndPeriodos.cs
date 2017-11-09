namespace Cashflow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTiposAndPeriodos : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Tipos (Id, Nombre) VALUES (1, 'Ingreso')");
            Sql("INSERT INTO Tipos (Id, Nombre) VALUES (2, 'Gasto')");

            Sql("INSERT INTO Periodos (Id, Nombre, Valor) VALUES (1, 'Ninguno', 0)");
            Sql("INSERT INTO Periodos (Id, Nombre, Valor) VALUES (2, 'Diario', 1)");
            Sql("INSERT INTO Periodos (Id, Nombre, Valor) VALUES (3, 'Semanal', 7)");
            Sql("INSERT INTO Periodos (Id, Nombre, Valor) VALUES (4, 'Mensual', 30)");


        }

        public override void Down()
        {
        }
    }
}
