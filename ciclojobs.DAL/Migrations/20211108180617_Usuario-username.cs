using Microsoft.EntityFrameworkCore.Migrations;

namespace ciclojobs.DAL.Migrations
{
    public partial class Usuariousername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "Usuarios",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "username",
                table: "Usuarios");
        }
    }
}
