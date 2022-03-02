using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ciclojobs.DAL.Migrations
{
    public partial class CrearColRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contrato_ContratoEstado_EstadoID",
                table: "Contrato");

            migrationBuilder.DropTable(
                name: "ContratoEstado");

            migrationBuilder.DropIndex(
                name: "IX_Contrato_EstadoID",
                table: "Contrato");

            migrationBuilder.AddColumn<int>(
                name: "rol",
                table: "Empresa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadoContrato",
                table: "Contrato",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "rol",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "EstadoContrato",
                table: "Contrato");

            migrationBuilder.CreateTable(
                name: "ContratoEstado",
                columns: table => new
                {
                    EstadoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreEstado = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratoEstado", x => x.EstadoID);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_EstadoID",
                table: "Contrato",
                column: "EstadoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contrato_ContratoEstado_EstadoID",
                table: "Contrato",
                column: "EstadoID",
                principalTable: "ContratoEstado",
                principalColumn: "EstadoID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
