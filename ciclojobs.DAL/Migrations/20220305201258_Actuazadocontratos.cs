using Microsoft.EntityFrameworkCore.Migrations;

namespace ciclojobs.DAL.Migrations
{
    public partial class Actuazadocontratos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadoID",
                table: "Contrato");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstadoID",
                table: "Contrato",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
