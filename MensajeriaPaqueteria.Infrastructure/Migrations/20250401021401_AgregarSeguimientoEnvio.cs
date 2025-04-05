using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MensajeriaPaqueteria.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AgregarSeguimientoEnvio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Envios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirmaEntrega",
                table: "Envios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UbicacionActual",
                table: "Envios",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Envios");

            migrationBuilder.DropColumn(
                name: "FirmaEntrega",
                table: "Envios");

            migrationBuilder.DropColumn(
                name: "UbicacionActual",
                table: "Envios");
        }
    }
}
