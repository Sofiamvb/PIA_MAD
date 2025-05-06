using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIA_MAD.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRegistroDeModificadores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habitaciones_Administradores_AdministradorId",
                table: "Habitaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Hoteles_Administradores_AdministradorId",
                table: "Hoteles");

            migrationBuilder.DropForeignKey(
                name: "FK_Operativos_Administradores_AdministradorId",
                table: "Operativos");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Operativos_OperativoId",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "OperativoId",
                table: "Usuarios",
                newName: "Modificadorid");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_OperativoId",
                table: "Usuarios",
                newName: "IX_Usuarios_Modificadorid");

            migrationBuilder.RenameColumn(
                name: "AdministradorId",
                table: "Operativos",
                newName: "Modificadorid");

            migrationBuilder.RenameIndex(
                name: "IX_Operativos_AdministradorId",
                table: "Operativos",
                newName: "IX_Operativos_Modificadorid");

            migrationBuilder.RenameColumn(
                name: "AdministradorId",
                table: "Hoteles",
                newName: "Modificadorid");

            migrationBuilder.RenameIndex(
                name: "IX_Hoteles_AdministradorId",
                table: "Hoteles",
                newName: "IX_Hoteles_Modificadorid");

            migrationBuilder.RenameColumn(
                name: "fechNaHab",
                table: "Habitaciones",
                newName: "FechaRegistro");

            migrationBuilder.RenameColumn(
                name: "AdministradorId",
                table: "Habitaciones",
                newName: "Modificadorid");

            migrationBuilder.RenameIndex(
                name: "IX_Habitaciones_AdministradorId",
                table: "Habitaciones",
                newName: "IX_Habitaciones_Modificadorid");

            migrationBuilder.AddColumn<int>(
                name: "CreadorAdministradorId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Creadorid",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModificadorAdministradorId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreadorAdministradorId",
                table: "Operativos",
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
                name: "ModificadorAdministradorId",
                table: "Operativos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreadorAdministradorId",
                table: "Hoteles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModificadorAdministradorId",
                table: "Hoteles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreadorAdministradorId",
                table: "Habitaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Creadorid",
                table: "Habitaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModificacion",
                table: "Habitaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModificadorAdministradorId",
                table: "Habitaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModificacion",
                table: "Administradores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "Administradores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Creadorid",
                table: "Usuarios",
                column: "Creadorid");

            migrationBuilder.CreateIndex(
                name: "IX_Operativos_Creadorid",
                table: "Operativos",
                column: "Creadorid");

            migrationBuilder.CreateIndex(
                name: "IX_Hoteles_CreadorAdministradorId",
                table: "Hoteles",
                column: "CreadorAdministradorId");

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
                name: "FK_Habitaciones_Administradores_Modificadorid",
                table: "Habitaciones",
                column: "Modificadorid",
                principalTable: "Administradores",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hoteles_Administradores_CreadorAdministradorId",
                table: "Hoteles",
                column: "CreadorAdministradorId",
                principalTable: "Administradores",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hoteles_Administradores_Modificadorid",
                table: "Hoteles",
                column: "Modificadorid",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habitaciones_Administradores_Creadorid",
                table: "Habitaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Habitaciones_Administradores_Modificadorid",
                table: "Habitaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Hoteles_Administradores_CreadorAdministradorId",
                table: "Hoteles");

            migrationBuilder.DropForeignKey(
                name: "FK_Hoteles_Administradores_Modificadorid",
                table: "Hoteles");

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
                name: "IX_Operativos_Creadorid",
                table: "Operativos");

            migrationBuilder.DropIndex(
                name: "IX_Hoteles_CreadorAdministradorId",
                table: "Hoteles");

            migrationBuilder.DropIndex(
                name: "IX_Habitaciones_Creadorid",
                table: "Habitaciones");

            migrationBuilder.DropColumn(
                name: "CreadorAdministradorId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Creadorid",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ModificadorAdministradorId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CreadorAdministradorId",
                table: "Operativos");

            migrationBuilder.DropColumn(
                name: "Creadorid",
                table: "Operativos");

            migrationBuilder.DropColumn(
                name: "ModificadorAdministradorId",
                table: "Operativos");

            migrationBuilder.DropColumn(
                name: "CreadorAdministradorId",
                table: "Hoteles");

            migrationBuilder.DropColumn(
                name: "ModificadorAdministradorId",
                table: "Hoteles");

            migrationBuilder.DropColumn(
                name: "CreadorAdministradorId",
                table: "Habitaciones");

            migrationBuilder.DropColumn(
                name: "Creadorid",
                table: "Habitaciones");

            migrationBuilder.DropColumn(
                name: "FechaModificacion",
                table: "Habitaciones");

            migrationBuilder.DropColumn(
                name: "ModificadorAdministradorId",
                table: "Habitaciones");

            migrationBuilder.DropColumn(
                name: "FechaModificacion",
                table: "Administradores");

            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "Administradores");

            migrationBuilder.RenameColumn(
                name: "Modificadorid",
                table: "Usuarios",
                newName: "OperativoId");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_Modificadorid",
                table: "Usuarios",
                newName: "IX_Usuarios_OperativoId");

            migrationBuilder.RenameColumn(
                name: "Modificadorid",
                table: "Operativos",
                newName: "AdministradorId");

            migrationBuilder.RenameIndex(
                name: "IX_Operativos_Modificadorid",
                table: "Operativos",
                newName: "IX_Operativos_AdministradorId");

            migrationBuilder.RenameColumn(
                name: "Modificadorid",
                table: "Hoteles",
                newName: "AdministradorId");

            migrationBuilder.RenameIndex(
                name: "IX_Hoteles_Modificadorid",
                table: "Hoteles",
                newName: "IX_Hoteles_AdministradorId");

            migrationBuilder.RenameColumn(
                name: "Modificadorid",
                table: "Habitaciones",
                newName: "AdministradorId");

            migrationBuilder.RenameColumn(
                name: "FechaRegistro",
                table: "Habitaciones",
                newName: "fechNaHab");

            migrationBuilder.RenameIndex(
                name: "IX_Habitaciones_Modificadorid",
                table: "Habitaciones",
                newName: "IX_Habitaciones_AdministradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Habitaciones_Administradores_AdministradorId",
                table: "Habitaciones",
                column: "AdministradorId",
                principalTable: "Administradores",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hoteles_Administradores_AdministradorId",
                table: "Hoteles",
                column: "AdministradorId",
                principalTable: "Administradores",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Operativos_Administradores_AdministradorId",
                table: "Operativos",
                column: "AdministradorId",
                principalTable: "Administradores",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Operativos_OperativoId",
                table: "Usuarios",
                column: "OperativoId",
                principalTable: "Operativos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
