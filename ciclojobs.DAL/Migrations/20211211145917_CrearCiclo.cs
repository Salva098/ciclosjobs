using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ciclojobs.DAL.Migrations
{
    public partial class CrearCiclo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ciclo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idfamiliaprofe = table.Column<int>(type: "int", nullable: false),
                    idtipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciclo", x => x.id);
                    table.ForeignKey(
                        name: "FK_Ciclo_FamiliaProfe_idfamiliaprofe",
                        column: x => x.idfamiliaprofe,
                        principalTable: "FamiliaProfe",
                        principalColumn: "idprofe",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ciclo_TipoCiclo_idtipo",
                        column: x => x.idtipo,
                        principalTable: "TipoCiclo",
                        principalColumn: "idtipo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
               name: "IX_Ciclo_idfamiliaprofe",
               table: "Ciclo",
               column: "idfamiliaprofe");

            migrationBuilder.CreateIndex(
                name: "IX_Ciclo_idtipo",
                table: "Ciclo",
                column: "idtipo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                           name: "Ciclo");
        }
    }
}
