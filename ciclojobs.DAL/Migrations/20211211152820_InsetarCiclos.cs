using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

namespace ciclojobs.DAL.Migrations
{
    public partial class InsetarCiclos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlFile = @"../ciclojobs.DAL/Scripts/20211210_InsertarCiclos.sql";

            migrationBuilder.Sql("ALTER TABLE ciclo AUTO_INCREMENT = 1");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from ciclo;");

        }
    }
}
