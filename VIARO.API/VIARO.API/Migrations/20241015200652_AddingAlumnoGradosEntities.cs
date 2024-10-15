using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VIARO.API.Migrations
{
    /// <inheritdoc />
    public partial class AddingAlumnoGradosEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlumnoGrados_Grado_GradoId",
                table: "AlumnoGrados");

            migrationBuilder.DropForeignKey(
                name: "FK_Grado_Profesores_ProfesorId",
                table: "Grado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grado",
                table: "Grado");

            migrationBuilder.RenameTable(
                name: "Grado",
                newName: "Grados");

            migrationBuilder.RenameIndex(
                name: "IX_Grado_ProfesorId",
                table: "Grados",
                newName: "IX_Grados_ProfesorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grados",
                table: "Grados",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AlumnoGrados_Grados_GradoId",
                table: "AlumnoGrados",
                column: "GradoId",
                principalTable: "Grados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grados_Profesores_ProfesorId",
                table: "Grados",
                column: "ProfesorId",
                principalTable: "Profesores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlumnoGrados_Grados_GradoId",
                table: "AlumnoGrados");

            migrationBuilder.DropForeignKey(
                name: "FK_Grados_Profesores_ProfesorId",
                table: "Grados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grados",
                table: "Grados");

            migrationBuilder.RenameTable(
                name: "Grados",
                newName: "Grado");

            migrationBuilder.RenameIndex(
                name: "IX_Grados_ProfesorId",
                table: "Grado",
                newName: "IX_Grado_ProfesorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grado",
                table: "Grado",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AlumnoGrados_Grado_GradoId",
                table: "AlumnoGrados",
                column: "GradoId",
                principalTable: "Grado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grado_Profesores_ProfesorId",
                table: "Grado",
                column: "ProfesorId",
                principalTable: "Profesores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
