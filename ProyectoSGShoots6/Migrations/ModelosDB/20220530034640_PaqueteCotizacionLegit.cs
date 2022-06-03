using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoSGShoots6.Migrations.ModelosDB
{
    public partial class PaqueteCotizacionLegit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paquetes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cobertura = table.Column<TimeSpan>(type: "time", nullable: false),
                    PrecioBasePaquete = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paquetes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cotizaciones",
                columns: table => new
                {
                    IDCotizacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrecioFinal = table.Column<double>(type: "float", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    CotizacionFK = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotizaciones", x => x.IDCotizacion);
                    table.ForeignKey(
                        name: "FK_Cotizaciones_Paquetes_CotizacionFK",
                        column: x => x.CotizacionFK,
                        principalTable: "Paquetes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_CotizacionFK",
                table: "Cotizaciones",
                column: "CotizacionFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cotizaciones");

            migrationBuilder.DropTable(
                name: "Paquetes");
        }
    }
}
