using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoSGShoots6.Migrations
{
    public partial class BD_SgShoots : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paquete",
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
                    table.PrimaryKey("PK_Paquete", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cotizacion",
                columns: table => new
                {
                    IDCotizacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrecioFinal = table.Column<double>(type: "float", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    PaqueteFK = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotizacion", x => x.IDCotizacion);
                    table.ForeignKey(
                        name: "FK_Cotizacion_Paquete_PaqueteFK",
                        column: x => x.PaqueteFK,
                        principalTable: "Paquete",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PaqueteProductos",
                columns: table => new
                {
                    PaquetesID = table.Column<int>(type: "int", nullable: false),
                    ProductosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaqueteProductos", x => new { x.PaquetesID, x.ProductosId });
                    table.ForeignKey(
                        name: "FK_PaqueteProductos_Paquete_PaquetesID",
                        column: x => x.PaquetesID,
                        principalTable: "Paquete",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaqueteProductos_Productos_ProductosId",
                        column: x => x.ProductosId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CotizacionProductos",
                columns: table => new
                {
                    CotizacionesId = table.Column<int>(type: "int", nullable: false),
                    ProductosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CotizacionProductos", x => new { x.CotizacionesId, x.ProductosId });
                    table.ForeignKey(
                        name: "FK_CotizacionProductos_Cotizacion_CotizacionesId",
                        column: x => x.CotizacionesId,
                        principalTable: "Cotizacion",
                        principalColumn: "IDCotizacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CotizacionProductos_Productos_ProductosId",
                        column: x => x.ProductosId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cotizacion_PaqueteFK",
                table: "Cotizacion",
                column: "PaqueteFK");

            migrationBuilder.CreateIndex(
                name: "IX_CotizacionProductos_ProductosId",
                table: "CotizacionProductos",
                column: "ProductosId");

            migrationBuilder.CreateIndex(
                name: "IX_PaqueteProductos_ProductosId",
                table: "PaqueteProductos",
                column: "ProductosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CotizacionProductos");

            migrationBuilder.DropTable(
                name: "PaqueteProductos");

            migrationBuilder.DropTable(
                name: "Cotizacion");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Paquete");
        }
    }
}
