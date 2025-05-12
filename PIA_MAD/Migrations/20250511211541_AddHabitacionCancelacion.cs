using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIA_MAD.Migrations
{
    /// <inheritdoc />
    public partial class AddHabitacionCancelacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HabitacionReservada_Cancelaciones_Cancelacionesid",
                table: "HabitacionReservada");

            migrationBuilder.DropIndex(
                name: "IX_HabitacionReservada_Cancelacionesid",
                table: "HabitacionReservada");

            migrationBuilder.DropColumn(
                name: "Cancelacionesid",
                table: "HabitacionReservada");

            migrationBuilder.CreateTable(
                name: "HabitacionCancelacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HabitacionId = table.Column<int>(type: "int", nullable: false),
                    CancelacionId = table.Column<int>(type: "int", nullable: false),
                    CantidadPersonas = table.Column<int>(type: "int", nullable: false),
                    Cancelacionesid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabitacionCancelacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HabitacionCancelacion_Cancelaciones_CancelacionId",
                        column: x => x.CancelacionId,
                        principalTable: "Cancelaciones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HabitacionCancelacion_Cancelaciones_Cancelacionesid",
                        column: x => x.Cancelacionesid,
                        principalTable: "Cancelaciones",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_HabitacionCancelacion_Habitaciones_HabitacionId",
                        column: x => x.HabitacionId,
                        principalTable: "Habitaciones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HabitacionCancelacion_Cancelacionesid",
                table: "HabitacionCancelacion",
                column: "Cancelacionesid");

            migrationBuilder.CreateIndex(
                name: "IX_HabitacionCancelacion_CancelacionId",
                table: "HabitacionCancelacion",
                column: "CancelacionId");

            migrationBuilder.CreateIndex(
                name: "IX_HabitacionCancelacion_HabitacionId",
                table: "HabitacionCancelacion",
                column: "HabitacionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HabitacionCancelacion");

            migrationBuilder.AddColumn<int>(
                name: "Cancelacionesid",
                table: "HabitacionReservada",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HabitacionReservada_Cancelacionesid",
                table: "HabitacionReservada",
                column: "Cancelacionesid");

            migrationBuilder.AddForeignKey(
                name: "FK_HabitacionReservada_Cancelaciones_Cancelacionesid",
                table: "HabitacionReservada",
                column: "Cancelacionesid",
                principalTable: "Cancelaciones",
                principalColumn: "id");
        }
    }
}
