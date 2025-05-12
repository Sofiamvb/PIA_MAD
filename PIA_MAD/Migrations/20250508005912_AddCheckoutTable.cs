using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIA_MAD.Migrations
{
    /// <inheritdoc />
    public partial class AddCheckoutTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CheckOUtRealizado",
                table: "Reservaciones",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CheckOutid",
                table: "HabitacionReservada",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CheckOut",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperativoId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    CantPersonas = table.Column<int>(type: "int", nullable: false),
                    Anticipo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CodigoReserva = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaEntReserva = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaSalReserva = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaSalReal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaReserva = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckInRealizado = table.Column<bool>(type: "bit", nullable: false),
                    CheckOUtRealizado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckOut", x => x.id);
                    table.ForeignKey(
                        name: "FK_CheckOut_Hoteles_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hoteles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheckOut_Operativos_OperativoId",
                        column: x => x.OperativoId,
                        principalTable: "Operativos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheckOut_Usuarios_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HabitacionReservada_CheckOutid",
                table: "HabitacionReservada",
                column: "CheckOutid");

            migrationBuilder.CreateIndex(
                name: "IX_CheckOut_ClienteId",
                table: "CheckOut",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckOut_HotelId",
                table: "CheckOut",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckOut_OperativoId",
                table: "CheckOut",
                column: "OperativoId");

            migrationBuilder.AddForeignKey(
                name: "FK_HabitacionReservada_CheckOut_CheckOutid",
                table: "HabitacionReservada",
                column: "CheckOutid",
                principalTable: "CheckOut",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HabitacionReservada_CheckOut_CheckOutid",
                table: "HabitacionReservada");

            migrationBuilder.DropTable(
                name: "CheckOut");

            migrationBuilder.DropIndex(
                name: "IX_HabitacionReservada_CheckOutid",
                table: "HabitacionReservada");

            migrationBuilder.DropColumn(
                name: "CheckOUtRealizado",
                table: "Reservaciones");

            migrationBuilder.DropColumn(
                name: "CheckOutid",
                table: "HabitacionReservada");
        }
    }
}
