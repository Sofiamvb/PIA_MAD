using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIA_MAD.Migrations
{
    /// <inheritdoc />
    public partial class FixCascadeError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habitaciones_Reservaciones_Reservacionid",
                table: "Habitaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Hoteles_Habitaciones_Habitacionesid",
                table: "Hoteles");

            migrationBuilder.DropForeignKey(
                name: "FK_Hoteles_Reservaciones_Reservacionid",
                table: "Hoteles");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Reservaciones_Reservacionid",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Reservacionid",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Hoteles_Habitacionesid",
                table: "Hoteles");

            migrationBuilder.DropIndex(
                name: "IX_Hoteles_Reservacionid",
                table: "Hoteles");

            migrationBuilder.DropIndex(
                name: "IX_Habitaciones_Reservacionid",
                table: "Habitaciones");

            migrationBuilder.DropColumn(
                name: "Contra",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Reservacionid",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Rangofech",
                table: "Reservaciones");

            migrationBuilder.DropColumn(
                name: "Habitacionesid",
                table: "Hoteles");

            migrationBuilder.DropColumn(
                name: "Reservacionid",
                table: "Hoteles");

            migrationBuilder.DropColumn(
                name: "Reservacionid",
                table: "Habitaciones");

            migrationBuilder.RenameColumn(
                name: "amennidades",
                table: "Hoteles",
                newName: "amenidades");

            migrationBuilder.RenameColumn(
                name: "Visita",
                table: "Habitaciones",
                newName: "Vista");

            migrationBuilder.RenameColumn(
                name: "CantHab",
                table: "Habitaciones",
                newName: "HotelId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Anticipo",
                table: "Reservaciones",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Reservaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "Reservaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechNaH",
                table: "Hoteles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechNaHab",
                table: "Habitaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "HabitacionReservada",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HabitacionId = table.Column<int>(type: "int", nullable: false),
                    ReservacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabitacionReservada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HabitacionReservada_Habitaciones_HabitacionId",
                        column: x => x.HabitacionId,
                        principalTable: "Habitaciones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HabitacionReservada_Reservaciones_ReservacionId",
                        column: x => x.ReservacionId,
                        principalTable: "Reservaciones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservaciones_ClienteId",
                table: "Reservaciones",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservaciones_HotelId",
                table: "Reservaciones",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Habitaciones_HotelId",
                table: "Habitaciones",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_HabitacionReservada_HabitacionId",
                table: "HabitacionReservada",
                column: "HabitacionId");

            migrationBuilder.CreateIndex(
                name: "IX_HabitacionReservada_ReservacionId",
                table: "HabitacionReservada",
                column: "ReservacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Habitaciones_Hoteles_HotelId",
                table: "Habitaciones",
                column: "HotelId",
                principalTable: "Hoteles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservaciones_Hoteles_HotelId",
                table: "Reservaciones",
                column: "HotelId",
                principalTable: "Hoteles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservaciones_Usuarios_ClienteId",
                table: "Reservaciones",
                column: "ClienteId",
                principalTable: "Usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habitaciones_Hoteles_HotelId",
                table: "Habitaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservaciones_Hoteles_HotelId",
                table: "Reservaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservaciones_Usuarios_ClienteId",
                table: "Reservaciones");

            migrationBuilder.DropTable(
                name: "HabitacionReservada");

            migrationBuilder.DropIndex(
                name: "IX_Reservaciones_ClienteId",
                table: "Reservaciones");

            migrationBuilder.DropIndex(
                name: "IX_Reservaciones_HotelId",
                table: "Reservaciones");

            migrationBuilder.DropIndex(
                name: "IX_Habitaciones_HotelId",
                table: "Habitaciones");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Reservaciones");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Reservaciones");

            migrationBuilder.DropColumn(
                name: "FechNaH",
                table: "Hoteles");

            migrationBuilder.DropColumn(
                name: "fechNaHab",
                table: "Habitaciones");

            migrationBuilder.RenameColumn(
                name: "amenidades",
                table: "Hoteles",
                newName: "amennidades");

            migrationBuilder.RenameColumn(
                name: "Vista",
                table: "Habitaciones",
                newName: "Visita");

            migrationBuilder.RenameColumn(
                name: "HotelId",
                table: "Habitaciones",
                newName: "CantHab");

            migrationBuilder.AddColumn<string>(
                name: "Contra",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Reservacionid",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Anticipo",
                table: "Reservaciones",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<DateTime>(
                name: "Rangofech",
                table: "Reservaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Habitacionesid",
                table: "Hoteles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Reservacionid",
                table: "Hoteles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Reservacionid",
                table: "Habitaciones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Reservacionid",
                table: "Usuarios",
                column: "Reservacionid");

            migrationBuilder.CreateIndex(
                name: "IX_Hoteles_Habitacionesid",
                table: "Hoteles",
                column: "Habitacionesid");

            migrationBuilder.CreateIndex(
                name: "IX_Hoteles_Reservacionid",
                table: "Hoteles",
                column: "Reservacionid");

            migrationBuilder.CreateIndex(
                name: "IX_Habitaciones_Reservacionid",
                table: "Habitaciones",
                column: "Reservacionid");

            migrationBuilder.AddForeignKey(
                name: "FK_Habitaciones_Reservaciones_Reservacionid",
                table: "Habitaciones",
                column: "Reservacionid",
                principalTable: "Reservaciones",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hoteles_Habitaciones_Habitacionesid",
                table: "Hoteles",
                column: "Habitacionesid",
                principalTable: "Habitaciones",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hoteles_Reservaciones_Reservacionid",
                table: "Hoteles",
                column: "Reservacionid",
                principalTable: "Reservaciones",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Reservaciones_Reservacionid",
                table: "Usuarios",
                column: "Reservacionid",
                principalTable: "Reservaciones",
                principalColumn: "id");
        }
    }
}
