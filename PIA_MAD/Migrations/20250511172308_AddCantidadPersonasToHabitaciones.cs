using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIA_MAD.Migrations
{
    /// <inheritdoc />
    public partial class AddCantidadPersonasToHabitaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "VentasYAnticiposView");

            migrationBuilder.AddColumn<int>(
                name: "Anio",
                table: "VentasYAnticiposView",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Anticipo",
                table: "VentasYAnticiposView",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CantidadDescuento",
                table: "VentasYAnticiposView",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Ciudad",
                table: "VentasYAnticiposView",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Mes",
                table: "VentasYAnticiposView",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombreHotel",
                table: "VentasYAnticiposView",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "ServiciosAdicionales",
                table: "VentasYAnticiposView",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "CantidadPersonas",
                table: "HabitacionReservada",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CantidadPersonas",
                table: "HabitacionCheckout",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "HotelesPorUbicacion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelesPorUbicacion", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelesPorUbicacion");

            migrationBuilder.DropColumn(
                name: "Anio",
                table: "VentasYAnticiposView");

            migrationBuilder.DropColumn(
                name: "Anticipo",
                table: "VentasYAnticiposView");

            migrationBuilder.DropColumn(
                name: "CantidadDescuento",
                table: "VentasYAnticiposView");

            migrationBuilder.DropColumn(
                name: "Ciudad",
                table: "VentasYAnticiposView");

            migrationBuilder.DropColumn(
                name: "Mes",
                table: "VentasYAnticiposView");

            migrationBuilder.DropColumn(
                name: "NombreHotel",
                table: "VentasYAnticiposView");

            migrationBuilder.DropColumn(
                name: "ServiciosAdicionales",
                table: "VentasYAnticiposView");

            migrationBuilder.DropColumn(
                name: "CantidadPersonas",
                table: "HabitacionReservada");

            migrationBuilder.DropColumn(
                name: "CantidadPersonas",
                table: "HabitacionCheckout");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "VentasYAnticiposView",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
