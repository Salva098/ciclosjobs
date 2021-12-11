using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ciclojobs.DAL.Migrations
{
    public partial class CrearCicloOfertas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Ciclo_Oferta",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false)
                       .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                   idCiclo = table.Column<int>(type: "int", nullable: false),
                   OfertaId = table.Column<int>(type: "int", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Ciclo_Oferta", x => x.Id);
                   table.ForeignKey(
                       name: "FK_Ciclo_Oferta_Ciclo_idCiclo",
                       column: x => x.idCiclo,
                       principalTable: "Ciclo",
                       principalColumn: "id",
                       onDelete: ReferentialAction.Cascade);
                   table.ForeignKey(
                       name: "FK_Ciclo_Oferta_Ofertas_OfertaId",
                       column: x => x.OfertaId,
                       principalTable: "Ofertas",
                       principalColumn: "id",
                       onDelete: ReferentialAction.Cascade);
               })
               .Annotation("MySql:CharSet", "utf8mb4")
               .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");



            migrationBuilder.CreateIndex(
                name: "IX_Ciclo_Oferta_idCiclo",
                table: "Ciclo_Oferta",
                column: "idCiclo");

            migrationBuilder.CreateIndex(
                name: "IX_Ciclo_Oferta_OfertaId",
                table: "Ciclo_Oferta",
                column: "OfertaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ciclo_Oferta");
        }
    }
}
