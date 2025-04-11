using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MensajeriaPaqueteria.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUbicacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ubicaciones",
                columns: table => new
                {
                    UbicacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MensajeroId = table.Column<int>(type: "int", nullable: false),
                    Latitud = table.Column<double>(type: "float", nullable: false),
                    Longitud = table.Column<double>(type: "float", nullable: false),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ubicaciones", x => x.UbicacionId);
                    table.ForeignKey(
                        name: "FK_Ubicaciones_Mensajeros_MensajeroId",
                        column: x => x.MensajeroId,
                        principalTable: "Mensajeros",
                        principalColumn: "MensajeroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ubicaciones_MensajeroId",
                table: "Ubicaciones",
                column: "MensajeroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ubicaciones");
        }
    }
}
