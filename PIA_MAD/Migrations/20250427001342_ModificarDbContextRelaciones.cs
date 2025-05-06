using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIA_MAD.Migrations
{
    /// <inheritdoc />
    public partial class ModificarDbContextRelaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habitaciones_Administradores_Modificadorid",
                table: "Habitaciones");

            migrationBuilder.DropIndex(
                name: "IX_Habitaciones_Modificadorid",
                table: "Habitaciones");

            migrationBuilder.DropColumn(
                name: "Modificadorid",
                table: "Habitaciones");

            migrationBuilder.CreateIndex(
                name: "IX_Habitaciones_ModificadorAdministradorId",
                table: "Habitaciones",
                column: "ModificadorAdministradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Habitaciones_Administradores_ModificadorAdministradorId",
                table: "Habitaciones",
                column: "ModificadorAdministradorId",
                principalTable: "Administradores",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habitaciones_Administradores_ModificadorAdministradorId",
                table: "Habitaciones");

            migrationBuilder.DropIndex(
                name: "IX_Habitaciones_ModificadorAdministradorId",
                table: "Habitaciones");

            migrationBuilder.AddColumn<int>(
                name: "Modificadorid",
                table: "Habitaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Habitaciones_Modificadorid",
                table: "Habitaciones",
                column: "Modificadorid");

            migrationBuilder.AddForeignKey(
                name: "FK_Habitaciones_Administradores_Modificadorid",
                table: "Habitaciones",
                column: "Modificadorid",
                principalTable: "Administradores",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
