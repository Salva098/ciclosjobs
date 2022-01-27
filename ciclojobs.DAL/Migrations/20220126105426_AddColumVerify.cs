using Microsoft.EntityFrameworkCore.Migrations;

namespace ciclojobs.DAL.Migrations
{
    public partial class AddColumVerify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "verificado",
                table: "Empresa",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "verificado",
                table: "Alumno",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "verificado",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "verificado",
                table: "Alumno");
        }
    }
}
