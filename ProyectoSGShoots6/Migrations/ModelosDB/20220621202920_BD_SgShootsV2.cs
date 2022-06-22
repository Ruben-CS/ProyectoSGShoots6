using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoSGShoots6.Migrations.ModelosDB
{
    public partial class BD_SgShootsV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PreciosIndividuales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrecioFoto = table.Column<double>(type: "float", nullable: false),
                    PrecioVideoPorSegudo = table.Column<double>(type: "float", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreciosIndividuales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoProductos",
                columns: table => new
                {
                    IdTipoProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProductos", x => x.IdTipoProducto);
                });

            migrationBuilder.CreateTable(
                name: "TipoPaquetes",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    PrecioIndiviualID = table.Column<int>(type: "int", nullable: false),
                    PreciosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPaquetes", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_TipoPaquetes_PreciosIndividuales_PreciosId",
                        column: x => x.PreciosId,
                        principalTable: "PreciosIndividuales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    TipoProductoIdTipoProducto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_TipoProductos_TipoProductoIdTipoProducto",
                        column: x => x.TipoProductoIdTipoProducto,
                        principalTable: "TipoProductos",
                        principalColumn: "IdTipoProducto");
                });

            migrationBuilder.CreateTable(
                name: "Paquetes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cobertura = table.Column<TimeSpan>(type: "time", nullable: false),
                    PrecioBasePaquete = table.Column<double>(type: "float", nullable: false),
                    TipoPaqueteCodigo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paquetes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Paquetes_TipoPaquetes_TipoPaqueteCodigo",
                        column: x => x.TipoPaqueteCodigo,
                        principalTable: "TipoPaquetes",
                        principalColumn: "Codigo");
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
                    PaqueteFK = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotizaciones", x => x.IDCotizacion);
                    table.ForeignKey(
                        name: "FK_Cotizaciones_Paquetes_PaqueteFK",
                        column: x => x.PaqueteFK,
                        principalTable: "Paquetes",
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
                        name: "FK_PaqueteProductos_Paquetes_PaquetesID",
                        column: x => x.PaquetesID,
                        principalTable: "Paquetes",
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
                        name: "FK_CotizacionProductos_Cotizaciones_CotizacionesId",
                        column: x => x.CotizacionesId,
                        principalTable: "Cotizaciones",
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
                name: "IX_Cotizaciones_PaqueteFK",
                table: "Cotizaciones",
                column: "PaqueteFK");

            migrationBuilder.CreateIndex(
                name: "IX_CotizacionProductos_ProductosId",
                table: "CotizacionProductos",
                column: "ProductosId");

            migrationBuilder.CreateIndex(
                name: "IX_PaqueteProductos_ProductosId",
                table: "PaqueteProductos",
                column: "ProductosId");

            migrationBuilder.CreateIndex(
                name: "IX_Paquetes_TipoPaqueteCodigo",
                table: "Paquetes",
                column: "TipoPaqueteCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_TipoProductoIdTipoProducto",
                table: "Productos",
                column: "TipoProductoIdTipoProducto");

            migrationBuilder.CreateIndex(
                name: "IX_TipoPaquetes_PreciosId",
                table: "TipoPaquetes",
                column: "PreciosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CotizacionProductos");

            migrationBuilder.DropTable(
                name: "PaqueteProductos");

            migrationBuilder.DropTable(
                name: "Cotizaciones");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Paquetes");

            migrationBuilder.DropTable(
                name: "TipoProductos");

            migrationBuilder.DropTable(
                name: "TipoPaquetes");

            migrationBuilder.DropTable(
                name: "PreciosIndividuales");
        }
    }
}
