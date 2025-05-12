using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIA_MAD.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFieldsInDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cfdi",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Codigopostal",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Domicilio",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RegimenFiscal",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FolioFactura",
                table: "CheckOut",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RutaPdfFactura",
                table: "CheckOut",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SerieFactura",
                table: "CheckOut",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cfdi",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Codigopostal",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Domicilio",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "RegimenFiscal",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "FolioFactura",
                table: "CheckOut");

            migrationBuilder.DropColumn(
                name: "RutaPdfFactura",
                table: "CheckOut");

            migrationBuilder.DropColumn(
                name: "SerieFactura",
                table: "CheckOut");
        }
    }
}
