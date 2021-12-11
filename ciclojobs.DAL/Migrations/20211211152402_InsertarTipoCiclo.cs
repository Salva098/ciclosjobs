using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

namespace ciclojobs.DAL.Migrations
{
    public partial class InsertarTipoCiclo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlFile = @"../ciclojobs.DAL/Scripts/20211210_InsertarTipoCiclo.sql";


            migrationBuilder.Sql("ALTER TABLE tipociclo AUTO_INCREMENT = 1");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from tipociclo;");
        }
    }
}
