using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIA_MAD.Migrations
{
    /// <inheritdoc />
    public partial class AgregarServiciosAdicionalesHotelFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cancelaciones_Hoteles_HotelId",
                table: "Cancelaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Cancelaciones_Usuarios_ClienteId",
                table: "Cancelaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Habitaciones_Hoteles_HotelId",
                table: "Habitaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_HabitacionReservada_Cancelaciones_Cancelacionesid",
                table: "HabitacionReservada");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservaciones_Hoteles_HotelId",
                table: "Reservaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservaciones_ReporteVentas_ReporteVentasid",
                table: "Reservaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservaciones_Usuarios_ClienteId",
                table: "Reservaciones");

            migrationBuilder.DropColumn(
                name: "serviciosAd",
                table: "Hoteles");

            migrationBuilder.AddColumn<int>(
                name: "OperativoId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OperativoId",
                table: "Reservaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AdministradorId",
                table: "ReporteVentas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "RegistroContra",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AdministradorId",
                table: "Operativos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AdministradorId",
                table: "Hoteles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AdministradorId",
                table: "Habitaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "AnticipoADevolver",
                table: "Cancelaciones",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "AdministradorId",
                table: "Cancelaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ServiciosAdicionalesHotel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiciosAdicionalesHotel", x => x.id);
                    table.ForeignKey(
                        name: "FK_ServiciosAdicionalesHotel_Hoteles_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hoteles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_OperativoId",
                table: "Usuarios",
                column: "OperativoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservaciones_OperativoId",
                table: "Reservaciones",
                column: "OperativoId");

            migrationBuilder.CreateIndex(
                name: "IX_ReporteVentas_AdministradorId",
                table: "ReporteVentas",
                column: "AdministradorId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroContra_UsuarioId",
                table: "RegistroContra",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Operativos_AdministradorId",
                table: "Operativos",
                column: "AdministradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Hoteles_AdministradorId",
                table: "Hoteles",
                column: "AdministradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Habitaciones_AdministradorId",
                table: "Habitaciones",
                column: "AdministradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cancelaciones_AdministradorId",
                table: "Cancelaciones",
                column: "AdministradorId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiciosAdicionalesHotel_HotelId",
                table: "ServiciosAdicionalesHotel",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cancelaciones_Administradores_AdministradorId",
                table: "Cancelaciones",
                column: "AdministradorId",
                principalTable: "Administradores",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cancelaciones_Hoteles_HotelId",
                table: "Cancelaciones",
                column: "HotelId",
                principalTable: "Hoteles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cancelaciones_Usuarios_ClienteId",
                table: "Cancelaciones",
                column: "ClienteId",
                principalTable: "Usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Habitaciones_Administradores_AdministradorId",
                table: "Habitaciones",
                column: "AdministradorId",
                principalTable: "Administradores",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Habitaciones_Hoteles_HotelId",
                table: "Habitaciones",
                column: "HotelId",
                principalTable: "Hoteles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HabitacionReservada_Cancelaciones_Cancelacionesid",
                table: "HabitacionReservada",
                column: "Cancelacionesid",
                principalTable: "Cancelaciones",
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
                name: "FK_RegistroContra_Usuarios_UsuarioId",
                table: "RegistroContra",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReporteVentas_Administradores_AdministradorId",
                table: "ReporteVentas",
                column: "AdministradorId",
                principalTable: "Administradores",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservaciones_Hoteles_HotelId",
                table: "Reservaciones",
                column: "HotelId",
                principalTable: "Hoteles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservaciones_Operativos_OperativoId",
                table: "Reservaciones",
                column: "OperativoId",
                principalTable: "Operativos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservaciones_ReporteVentas_ReporteVentasid",
                table: "Reservaciones",
                column: "ReporteVentasid",
                principalTable: "ReporteVentas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservaciones_Usuarios_ClienteId",
                table: "Reservaciones",
                column: "ClienteId",
                principalTable: "Usuarios",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cancelaciones_Administradores_AdministradorId",
                table: "Cancelaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Cancelaciones_Hoteles_HotelId",
                table: "Cancelaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Cancelaciones_Usuarios_ClienteId",
                table: "Cancelaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Habitaciones_Administradores_AdministradorId",
                table: "Habitaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Habitaciones_Hoteles_HotelId",
                table: "Habitaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_HabitacionReservada_Cancelaciones_Cancelacionesid",
                table: "HabitacionReservada");

            migrationBuilder.DropForeignKey(
                name: "FK_Hoteles_Administradores_AdministradorId",
                table: "Hoteles");

            migrationBuilder.DropForeignKey(
                name: "FK_Operativos_Administradores_AdministradorId",
                table: "Operativos");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistroContra_Usuarios_UsuarioId",
                table: "RegistroContra");

            migrationBuilder.DropForeignKey(
                name: "FK_ReporteVentas_Administradores_AdministradorId",
                table: "ReporteVentas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservaciones_Hoteles_HotelId",
                table: "Reservaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservaciones_Operativos_OperativoId",
                table: "Reservaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservaciones_ReporteVentas_ReporteVentasid",
                table: "Reservaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservaciones_Usuarios_ClienteId",
                table: "Reservaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Operativos_OperativoId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "ServiciosAdicionalesHotel");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_OperativoId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Reservaciones_OperativoId",
                table: "Reservaciones");

            migrationBuilder.DropIndex(
                name: "IX_ReporteVentas_AdministradorId",
                table: "ReporteVentas");

            migrationBuilder.DropIndex(
                name: "IX_RegistroContra_UsuarioId",
                table: "RegistroContra");

            migrationBuilder.DropIndex(
                name: "IX_Operativos_AdministradorId",
                table: "Operativos");

            migrationBuilder.DropIndex(
                name: "IX_Hoteles_AdministradorId",
                table: "Hoteles");

            migrationBuilder.DropIndex(
                name: "IX_Habitaciones_AdministradorId",
                table: "Habitaciones");

            migrationBuilder.DropIndex(
                name: "IX_Cancelaciones_AdministradorId",
                table: "Cancelaciones");

            migrationBuilder.DropColumn(
                name: "OperativoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "OperativoId",
                table: "Reservaciones");

            migrationBuilder.DropColumn(
                name: "AdministradorId",
                table: "ReporteVentas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "RegistroContra");

            migrationBuilder.DropColumn(
                name: "AdministradorId",
                table: "Operativos");

            migrationBuilder.DropColumn(
                name: "AdministradorId",
                table: "Hoteles");

            migrationBuilder.DropColumn(
                name: "AdministradorId",
                table: "Habitaciones");

            migrationBuilder.DropColumn(
                name: "AdministradorId",
                table: "Cancelaciones");

            migrationBuilder.AddColumn<string>(
                name: "serviciosAd",
                table: "Hoteles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "AnticipoADevolver",
                table: "Cancelaciones",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AddForeignKey(
                name: "FK_Cancelaciones_Hoteles_HotelId",
                table: "Cancelaciones",
                column: "HotelId",
                principalTable: "Hoteles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cancelaciones_Usuarios_ClienteId",
                table: "Cancelaciones",
                column: "ClienteId",
                principalTable: "Usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Habitaciones_Hoteles_HotelId",
                table: "Habitaciones",
                column: "HotelId",
                principalTable: "Hoteles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HabitacionReservada_Cancelaciones_Cancelacionesid",
                table: "HabitacionReservada",
                column: "Cancelacionesid",
                principalTable: "Cancelaciones",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservaciones_Hoteles_HotelId",
                table: "Reservaciones",
                column: "HotelId",
                principalTable: "Hoteles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservaciones_ReporteVentas_ReporteVentasid",
                table: "Reservaciones",
                column: "ReporteVentasid",
                principalTable: "ReporteVentas",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservaciones_Usuarios_ClienteId",
                table: "Reservaciones",
                column: "ClienteId",
                principalTable: "Usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
