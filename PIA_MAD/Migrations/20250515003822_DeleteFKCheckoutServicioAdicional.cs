using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIA_MAD.Migrations
{
    /// <inheritdoc />
    public partial class DeleteFKCheckoutServicioAdicional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckOutServiciosAdicionales_ServiciosAdicionalesHotel_ServicioAdicionalHotelId",
                table: "CheckOutServiciosAdicionales");

            migrationBuilder.DropIndex(
                name: "IX_CheckOutServiciosAdicionales_ServicioAdicionalHotelId",
                table: "CheckOutServiciosAdicionales");

            migrationBuilder.DropColumn(
                name: "ServicioAdicionalHotelId",
                table: "CheckOutServiciosAdicionales");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "CheckOutServiciosAdicionales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Precio",
                table: "CheckOutServiciosAdicionales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "CheckOutServiciosAdicionales");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "CheckOutServiciosAdicionales");

            migrationBuilder.AddColumn<int>(
                name: "ServicioAdicionalHotelId",
                table: "CheckOutServiciosAdicionales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CheckOutServiciosAdicionales_ServicioAdicionalHotelId",
                table: "CheckOutServiciosAdicionales",
                column: "ServicioAdicionalHotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckOutServiciosAdicionales_ServiciosAdicionalesHotel_ServicioAdicionalHotelId",
                table: "CheckOutServiciosAdicionales",
                column: "ServicioAdicionalHotelId",
                principalTable: "ServiciosAdicionalesHotel",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
