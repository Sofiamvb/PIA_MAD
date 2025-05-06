using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIA_MAD.Migrations
{
    /// <inheritdoc />
    public partial class AgregarTablaCancelacionesYCheckIn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CheckInRealizado",
                table: "Reservaciones",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Cancelacionesid",
                table: "HabitacionReservada",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cancelaciones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoCancelacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    CantPersonas = table.Column<int>(type: "int", nullable: false),
                    AnticipoADevolver = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CodigoReserva = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaEnt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaSal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaReserva = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCancelacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckInRealizado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cancelaciones", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cancelaciones_Hoteles_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hoteles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cancelaciones_Usuarios_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HabitacionReservada_Cancelacionesid",
                table: "HabitacionReservada",
                column: "Cancelacionesid");

            migrationBuilder.CreateIndex(
                name: "IX_Cancelaciones_ClienteId",
                table: "Cancelaciones",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cancelaciones_HotelId",
                table: "Cancelaciones",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_HabitacionReservada_Cancelaciones_Cancelacionesid",
                table: "HabitacionReservada",
                column: "Cancelacionesid",
                principalTable: "Cancelaciones",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HabitacionReservada_Cancelaciones_Cancelacionesid",
                table: "HabitacionReservada");

            migrationBuilder.DropTable(
                name: "Cancelaciones");

            migrationBuilder.DropIndex(
                name: "IX_HabitacionReservada_Cancelacionesid",
                table: "HabitacionReservada");

            migrationBuilder.DropColumn(
                name: "CheckInRealizado",
                table: "Reservaciones");

            migrationBuilder.DropColumn(
                name: "Cancelacionesid",
                table: "HabitacionReservada");
        }
    }
}
