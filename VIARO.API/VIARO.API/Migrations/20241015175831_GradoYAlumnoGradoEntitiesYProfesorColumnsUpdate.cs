using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VIARO.API.Migrations
{
    /// <inheritdoc />
    public partial class GradoYAlumnoGradoEntitiesYProfesorColumnsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Apellidps",
                table: "Profesores",
                newName: "Apellidos");

            migrationBuilder.CreateTable(
                name: "Grado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfesorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grado_Profesores_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "Profesores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlumnoGrados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlumnoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GradoId = table.Column<int>(type: "int", nullable: false),
                    Seccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumnoGrados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlumnoGrados_Alumnos_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "Alumnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlumnoGrados_Grado_GradoId",
                        column: x => x.GradoId,
                        principalTable: "Grado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoGrados_AlumnoId",
                table: "AlumnoGrados",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoGrados_GradoId",
                table: "AlumnoGrados",
                column: "GradoId");

            migrationBuilder.CreateIndex(
                name: "IX_Grado_ProfesorId",
                table: "Grado",
                column: "ProfesorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlumnoGrados");

            migrationBuilder.DropTable(
                name: "Grado");

            migrationBuilder.RenameColumn(
                name: "Apellidos",
                table: "Profesores",
                newName: "Apellidps");
        }
    }
}
