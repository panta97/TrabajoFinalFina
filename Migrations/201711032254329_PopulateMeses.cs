namespace Cashflow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMeses : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Meses (Id, Nombre) VALUES (1, 'Enero')");
            Sql("INSERT INTO Meses (Id, Nombre) VALUES (2, 'Febrero')");
            Sql("INSERT INTO Meses (Id, Nombre) VALUES (3, 'Marzo')");
            Sql("INSERT INTO Meses (Id, Nombre) VALUES (4, 'Abril')");
            Sql("INSERT INTO Meses (Id, Nombre) VALUES (5, 'Mayo')");
            Sql("INSERT INTO Meses (Id, Nombre) VALUES (6, 'Junio')");
            Sql("INSERT INTO Meses (Id, Nombre) VALUES (7, 'Julio')");
            Sql("INSERT INTO Meses (Id, Nombre) VALUES (8, 'Agosto')");
            Sql("INSERT INTO Meses (Id, Nombre) VALUES (9, 'Septiembre')");
            Sql("INSERT INTO Meses (Id, Nombre) VALUES (10, 'Octubre')");
            Sql("INSERT INTO Meses (Id, Nombre) VALUES (11, 'Noviembre')");
            Sql("INSERT INTO Meses (Id, Nombre) VALUES (12, 'Diciembre')");


        }

        public override void Down()
        {
        }
    }
}
