using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIA_MAD.Migrations
{
    /// <inheritdoc />
    public partial class ModificarDbContextConRelaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habitaciones_Administradores_Creadorid",
                table: "Habitaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Operativos_Administradores_Creadorid",
                table: "Operativos");

            migrationBuilder.DropForeignKey(
                name: "FK_Operativos_Administradores_Modificadorid",
                table: "Operativos");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Administradores_Creadorid",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Administradores_Modificadorid",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Creadorid",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Modificadorid",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Operativos_Creadorid",
                table: "Operativos");

            migrationBuilder.DropIndex(
                name: "IX_Operativos_Modificadorid",
                table: "Operativos");

            migrationBuilder.DropIndex(
                name: "IX_Habitaciones_Creadorid",
                table: "Habitaciones");

            migrationBuilder.DropColumn(
                name: "Creadorid",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Modificadorid",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Creadorid",
                table: "Operativos");

            migrationBuilder.DropColumn(
                name: "Modificadorid",
                table: "Operativos");

            migrationBuilder.DropColumn(
                name: "Creadorid",
                table: "Habitaciones");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CreadorAdministradorId",
                table: "Usuarios",
                column: "CreadorAdministradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ModificadorAdministradorId",
                table: "Usuarios",
                column: "ModificadorAdministradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Operativos_CreadorAdministradorId",
                table: "Operativos",
                column: "CreadorAdministradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Operativos_ModificadorAdministradorId",
                table: "Operativos",
                column: "ModificadorAdministradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Habitaciones_CreadorAdministradorId",
                table: "Habitaciones",
                column: "CreadorAdministradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Habitaciones_Administradores_CreadorAdministradorId",
                table: "Habitaciones",
                column: "CreadorAdministradorId",
                principalTable: "Administradores",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Operativos_Administradores_CreadorAdministradorId",
                table: "Operativos",
                column: "CreadorAdministradorId",
                principalTable: "Administradores",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Operativos_Administradores_ModificadorAdministradorId",
                table: "Operativos",
                column: "ModificadorAdministradorId",
                principalTable: "Administradores",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Administradores_CreadorAdministradorId",
                table: "Usuarios",
                column: "CreadorAdministradorId",
                principalTable: "Administradores",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Administradores_ModificadorAdministradorId",
                table: "Usuarios",
                column: "ModificadorAdministradorId",
                principalTable: "Administradores",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habitaciones_Administradores_CreadorAdministradorId",
                table: "Habitaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Operativos_Administradores_CreadorAdministradorId",
                table: "Operativos");

            migrationBuilder.DropForeignKey(
                name: "FK_Operativos_Administradores_ModificadorAdministradorId",
                table: "Operativos");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Administradores_CreadorAdministradorId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Administradores_ModificadorAdministradorId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_CreadorAdministradorId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_ModificadorAdministradorId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Operativos_CreadorAdministradorId",
                table: "Operativos");

            migrationBuilder.DropIndex(
                name: "IX_Operativos_ModificadorAdministradorId",
                table: "Operativos");

            migrationBuilder.DropIndex(
                name: "IX_Habitaciones_CreadorAdministradorId",
                table: "Habitaciones");

            migrationBuilder.AddColumn<int>(
                name: "Creadorid",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Modificadorid",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Creadorid",
                table: "Operativos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Modificadorid",
                table: "Operativos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Creadorid",
                table: "Habitaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Creadorid",
                table: "Usuarios",
                column: "Creadorid");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Modificadorid",
                table: "Usuarios",
                column: "Modificadorid");

            migrationBuilder.CreateIndex(
                name: "IX_Operativos_Creadorid",
                table: "Operativos",
                column: "Creadorid");

            migrationBuilder.CreateIndex(
                name: "IX_Operativos_Modificadorid",
                table: "Operativos",
                column: "Modificadorid");

            migrationBuilder.CreateIndex(
                name: "IX_Habitaciones_Creadorid",
                table: "Habitaciones",
                column: "Creadorid");

            migrationBuilder.AddForeignKey(
                name: "FK_Habitaciones_Administradores_Creadorid",
                table: "Habitaciones",
                column: "Creadorid",
                principalTable: "Administradores",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Operativos_Administradores_Creadorid",
                table: "Operativos",
                column: "Creadorid",
                principalTable: "Administradores",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Operativos_Administradores_Modificadorid",
                table: "Operativos",
                column: "Modificadorid",
                principalTable: "Administradores",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Administradores_Creadorid",
                table: "Usuarios",
                column: "Creadorid",
                principalTable: "Administradores",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Administradores_Modificadorid",
                table: "Usuarios",
                column: "Modificadorid",
                principalTable: "Administradores",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
