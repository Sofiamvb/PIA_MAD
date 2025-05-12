using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIA_MAD.Migrations
{
    /// <inheritdoc />
    public partial class AddMidTableCheckout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HabitacionReservada_CheckOut_CheckOutid",
                table: "HabitacionReservada");

            migrationBuilder.DropIndex(
                name: "IX_HabitacionReservada_CheckOutid",
                table: "HabitacionReservada");

            migrationBuilder.DropColumn(
                name: "CheckOutid",
                table: "HabitacionReservada");

            migrationBuilder.AlterColumn<decimal>(
                name: "Anticipo",
                table: "CheckOut",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "HabitacionCheckout",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HabitacionId = table.Column<int>(type: "int", nullable: false),
                    CheckOutId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabitacionCheckout", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HabitacionCheckout_CheckOut_CheckOutId",
                        column: x => x.CheckOutId,
                        principalTable: "CheckOut",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HabitacionCheckout_Habitaciones_HabitacionId",
                        column: x => x.HabitacionId,
                        principalTable: "Habitaciones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HabitacionCheckout_CheckOutId",
                table: "HabitacionCheckout",
                column: "CheckOutId");

            migrationBuilder.CreateIndex(
                name: "IX_HabitacionCheckout_HabitacionId",
                table: "HabitacionCheckout",
                column: "HabitacionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HabitacionCheckout");

            migrationBuilder.AddColumn<int>(
                name: "CheckOutid",
                table: "HabitacionReservada",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Anticipo",
                table: "CheckOut",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.CreateIndex(
                name: "IX_HabitacionReservada_CheckOutid",
                table: "HabitacionReservada",
                column: "CheckOutid");

            migrationBuilder.AddForeignKey(
                name: "FK_HabitacionReservada_CheckOut_CheckOutid",
                table: "HabitacionReservada",
                column: "CheckOutid",
                principalTable: "CheckOut",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
