using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIA_MAD.Migrations
{
    /// <inheritdoc />
    public partial class EnableCascadeDelete_HabitacionReservada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_Habitaciones_Hoteles_HotelId",
                table: "Habitaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_HabitacionReservada_Cancelaciones_Cancelacionesid",
                table: "HabitacionReservada");

            migrationBuilder.DropForeignKey(
                name: "FK_HabitacionReservada_Reservaciones_ReservacionId",
                table: "HabitacionReservada");

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
                name: "FK_ServiciosAdicionalesHotel_Hoteles_HotelId",
                table: "ServiciosAdicionalesHotel");

            migrationBuilder.AddForeignKey(
                name: "FK_Cancelaciones_Administradores_AdministradorId",
                table: "Cancelaciones",
                column: "AdministradorId",
                principalTable: "Administradores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_HabitacionReservada_Reservaciones_ReservacionId",
                table: "HabitacionReservada",
                column: "ReservacionId",
                principalTable: "Reservaciones",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroContra_Usuarios_UsuarioId",
                table: "RegistroContra",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReporteVentas_Administradores_AdministradorId",
                table: "ReporteVentas",
                column: "AdministradorId",
                principalTable: "Administradores",
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
                name: "FK_Reservaciones_Operativos_OperativoId",
                table: "Reservaciones",
                column: "OperativoId",
                principalTable: "Operativos",
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

            migrationBuilder.AddForeignKey(
                name: "FK_ServiciosAdicionalesHotel_Hoteles_HotelId",
                table: "ServiciosAdicionalesHotel",
                column: "HotelId",
                principalTable: "Hoteles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
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
                name: "FK_Habitaciones_Hoteles_HotelId",
                table: "Habitaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_HabitacionReservada_Cancelaciones_Cancelacionesid",
                table: "HabitacionReservada");

            migrationBuilder.DropForeignKey(
                name: "FK_HabitacionReservada_Reservaciones_ReservacionId",
                table: "HabitacionReservada");

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
                name: "FK_ServiciosAdicionalesHotel_Hoteles_HotelId",
                table: "ServiciosAdicionalesHotel");

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
                name: "FK_HabitacionReservada_Reservaciones_ReservacionId",
                table: "HabitacionReservada",
                column: "ReservacionId",
                principalTable: "Reservaciones",
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
                name: "FK_ServiciosAdicionalesHotel_Hoteles_HotelId",
                table: "ServiciosAdicionalesHotel",
                column: "HotelId",
                principalTable: "Hoteles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
