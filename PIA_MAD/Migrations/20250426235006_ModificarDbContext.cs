using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIA_MAD.Migrations
{
    /// <inheritdoc />
    public partial class ModificarDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hoteles_Administradores_Modificadorid",
                table: "Hoteles");

            migrationBuilder.DropIndex(
                name: "IX_Hoteles_Modificadorid",
                table: "Hoteles");

            migrationBuilder.DropColumn(
                name: "Modificadorid",
                table: "Hoteles");

            migrationBuilder.CreateIndex(
                name: "IX_Hoteles_ModificadorAdministradorId",
                table: "Hoteles",
                column: "ModificadorAdministradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hoteles_Administradores_ModificadorAdministradorId",
                table: "Hoteles",
                column: "ModificadorAdministradorId",
                principalTable: "Administradores",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hoteles_Administradores_ModificadorAdministradorId",
                table: "Hoteles");

            migrationBuilder.DropIndex(
                name: "IX_Hoteles_ModificadorAdministradorId",
                table: "Hoteles");

            migrationBuilder.AddColumn<int>(
                name: "Modificadorid",
                table: "Hoteles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Hoteles_Modificadorid",
                table: "Hoteles",
                column: "Modificadorid");

            migrationBuilder.AddForeignKey(
                name: "FK_Hoteles_Administradores_Modificadorid",
                table: "Hoteles",
                column: "Modificadorid",
                principalTable: "Administradores",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
