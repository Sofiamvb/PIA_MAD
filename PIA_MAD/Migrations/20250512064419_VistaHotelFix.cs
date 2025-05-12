using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIA_MAD.Migrations
{
    /// <inheritdoc />
    public partial class VistaHotelFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistroContra_Usuarios_UsuarioId",
                table: "RegistroContra");

            migrationBuilder.DropIndex(
                name: "IX_RegistroContra_UsuarioId",
                table: "RegistroContra");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "RegistroContra");

            migrationBuilder.AddColumn<int>(
                name: "AdministradorId",
                table: "RegistroContra",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OperativoId",
                table: "RegistroContra",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegistroContra_AdministradorId",
                table: "RegistroContra",
                column: "AdministradorId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroContra_OperativoId",
                table: "RegistroContra",
                column: "OperativoId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroContra_Administradores_AdministradorId",
                table: "RegistroContra",
                column: "AdministradorId",
                principalTable: "Administradores",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroContra_Operativos_OperativoId",
                table: "RegistroContra",
                column: "OperativoId",
                principalTable: "Operativos",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistroContra_Administradores_AdministradorId",
                table: "RegistroContra");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistroContra_Operativos_OperativoId",
                table: "RegistroContra");

            migrationBuilder.DropIndex(
                name: "IX_RegistroContra_AdministradorId",
                table: "RegistroContra");

            migrationBuilder.DropIndex(
                name: "IX_RegistroContra_OperativoId",
                table: "RegistroContra");

            migrationBuilder.DropColumn(
                name: "AdministradorId",
                table: "RegistroContra");

            migrationBuilder.DropColumn(
                name: "OperativoId",
                table: "RegistroContra");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "RegistroContra",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RegistroContra_UsuarioId",
                table: "RegistroContra",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroContra_Usuarios_UsuarioId",
                table: "RegistroContra",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
