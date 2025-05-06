using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIA_MAD.Migrations
{
    /// <inheritdoc />
    public partial class AgregarFechasDeModificacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechNaH",
                table: "Hoteles",
                newName: "FechaRegistro");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModificacion",
                table: "Operativos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "Operativos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModificacion",
                table: "Hoteles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaModificacion",
                table: "Operativos");

            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "Operativos");

            migrationBuilder.DropColumn(
                name: "FechaModificacion",
                table: "Hoteles");

            migrationBuilder.RenameColumn(
                name: "FechaRegistro",
                table: "Hoteles",
                newName: "FechNaH");
        }
    }
}
