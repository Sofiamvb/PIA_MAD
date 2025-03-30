using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIA_MAD.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nomina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaNa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contra = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Operativos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nomina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaNa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contra = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operativos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RegistroContra",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContraPasada = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroContra", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ReporteVentas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaGen = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PagosT = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReporteVentas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Reservaciones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CantPersonas = table.Column<int>(type: "int", nullable: false),
                    Anticipo = table.Column<int>(type: "int", nullable: false),
                    Rangofech = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodigoReserva = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaEnt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaSal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaReserva = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReporteVentasid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservaciones", x => x.id);
                    table.ForeignKey(
                        name: "FK_Reservaciones_ReporteVentas_ReporteVentasid",
                        column: x => x.ReporteVentasid,
                        principalTable: "ReporteVentas",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Habitaciones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CantHab = table.Column<int>(type: "int", nullable: false),
                    NoCamas = table.Column<int>(type: "int", nullable: false),
                    tipoCama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecioNoche = table.Column<int>(type: "int", nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    nivelHab = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visita = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    caracteristicas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amenidades = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reservacionid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitaciones", x => x.id);
                    table.ForeignKey(
                        name: "FK_Habitaciones_Reservaciones_Reservacionid",
                        column: x => x.Reservacionid,
                        principalTable: "Reservaciones",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RFC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaNa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoCivil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reservacionid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Reservaciones_Reservacionid",
                        column: x => x.Reservacionid,
                        principalTable: "Reservaciones",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Hoteles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    domicilio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pisos = table.Column<int>(type: "int", nullable: false),
                    ZonaTur = table.Column<bool>(type: "bit", nullable: false),
                    caracteristicas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    amennidades = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cantHab = table.Column<int>(type: "int", nullable: false),
                    serviciosAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrentePlaya = table.Column<bool>(type: "bit", nullable: false),
                    CantPiscina = table.Column<int>(type: "int", nullable: false),
                    SalonEv = table.Column<bool>(type: "bit", nullable: false),
                    Habitacionesid = table.Column<int>(type: "int", nullable: true),
                    Reservacionid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoteles", x => x.id);
                    table.ForeignKey(
                        name: "FK_Hoteles_Habitaciones_Habitacionesid",
                        column: x => x.Habitacionesid,
                        principalTable: "Habitaciones",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Hoteles_Reservaciones_Reservacionid",
                        column: x => x.Reservacionid,
                        principalTable: "Reservaciones",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Habitaciones_Reservacionid",
                table: "Habitaciones",
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
                name: "IX_Reservaciones_ReporteVentasid",
                table: "Reservaciones",
                column: "ReporteVentasid");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Reservacionid",
                table: "Usuarios",
                column: "Reservacionid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "Hoteles");

            migrationBuilder.DropTable(
                name: "Operativos");

            migrationBuilder.DropTable(
                name: "RegistroContra");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Habitaciones");

            migrationBuilder.DropTable(
                name: "Reservaciones");

            migrationBuilder.DropTable(
                name: "ReporteVentas");
        }
    }
}
