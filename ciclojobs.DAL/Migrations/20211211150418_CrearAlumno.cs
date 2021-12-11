using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ciclojobs.DAL.Migrations
{
    public partial class CrearAlumno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                            name: "Alumno",
                            columns: table => new
                            {
                                id = table.Column<int>(type: "int", nullable: false)
                                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                                email = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                                    .Annotation("MySql:CharSet", "utf8mb4"),
                                contrasena = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                                    .Annotation("MySql:CharSet", "utf8mb4"),
                                nombre = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                                    .Annotation("MySql:CharSet", "utf8mb4"),
                                apellidos = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                                    .Annotation("MySql:CharSet", "utf8mb4"),
                                fechanacimiento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                                idprovincias = table.Column<int>(type: "int", nullable: false),
                                localidad = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                                    .Annotation("MySql:CharSet", "utf8mb4"),
                                id_ciclo = table.Column<int>(type: "int", nullable: false),
                                calificacion_media = table.Column<double>(type: "double", nullable: false),
                                foto = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                                    .Annotation("MySql:CharSet", "utf8mb4")
                            },
                            constraints: table =>
                            {
                                table.PrimaryKey("PK_Alumno", x => x.id);
                                table.ForeignKey(
                                    name: "FK_Alumno_Ciclo_id_ciclo",
                                    column: x => x.id_ciclo,
                                    principalTable: "Ciclo",
                                    principalColumn: "id",
                                    onDelete: ReferentialAction.Cascade);
                                table.ForeignKey(
                                    name: "FK_Alumno_Provincias_idprovincias",
                                    column: x => x.idprovincias,
                                    principalTable: "Provincias",
                                    principalColumn: "id",
                                    onDelete: ReferentialAction.Cascade);
                            })
                            .Annotation("MySql:CharSet", "utf8mb4")
                            .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_id_ciclo",
                table: "Alumno",
                column: "id_ciclo");

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_idprovincias",
                table: "Alumno",
                column: "idprovincias");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
              name: "Alumno");
        }
    }
}
