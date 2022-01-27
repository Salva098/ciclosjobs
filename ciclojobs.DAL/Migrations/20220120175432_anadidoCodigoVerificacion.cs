using Microsoft.EntityFrameworkCore.Migrations;

namespace ciclojobs.DAL.Migrations
{
    public partial class anadidoCodigoVerificacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<string>(
                name: "codeverify",
                table: "Empresa",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "codeverify",
                table: "Alumno",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "codeverify",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "codeverify",
                table: "Alumno");
        }
    }
}
