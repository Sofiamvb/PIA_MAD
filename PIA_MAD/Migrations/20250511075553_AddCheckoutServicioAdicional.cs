using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIA_MAD.Migrations
{
    /// <inheritdoc />
    public partial class AddCheckoutServicioAdicional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CantidadDescuento",
                table: "CheckOut",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MontoTotal",
                table: "CheckOut",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PorcentajeDescuento",
                table: "CheckOut",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "CheckOutServiciosAdicionales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckOutId = table.Column<int>(type: "int", nullable: false),
                    ServicioAdicionalHotelId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckOutServiciosAdicionales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckOutServiciosAdicionales_CheckOut_CheckOutId",
                        column: x => x.CheckOutId,
                        principalTable: "CheckOut",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckOutServiciosAdicionales_ServiciosAdicionalesHotel_ServicioAdicionalHotelId",
                        column: x => x.ServicioAdicionalHotelId,
                        principalTable: "ServiciosAdicionalesHotel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckOutServiciosAdicionales_CheckOutId",
                table: "CheckOutServiciosAdicionales",
                column: "CheckOutId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckOutServiciosAdicionales_ServicioAdicionalHotelId",
                table: "CheckOutServiciosAdicionales",
                column: "ServicioAdicionalHotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckOutServiciosAdicionales");

            migrationBuilder.DropColumn(
                name: "CantidadDescuento",
                table: "CheckOut");

            migrationBuilder.DropColumn(
                name: "MontoTotal",
                table: "CheckOut");

            migrationBuilder.DropColumn(
                name: "PorcentajeDescuento",
                table: "CheckOut");
        }
    }
}
