using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoSGShoots6.Migrations.ModelosDB
{
    public partial class ProductoCotizacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "detalleProductoPersonalizado",
                columns: table => new
                {
                    CotizacionesId = table.Column<int>(type: "int", nullable: false),
                    ProductosId = table.Column<int>(type: "int", nullable: false),
                    cantidadProducto = table.Column<int>(type:"int",nullable:false)
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
                name: "IX_detalleProductoPersonalizado_ProductosId",
                table: "detalleProductoPersonalizado",
                column: "ProductosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalleProductoPersonalizado");
        }
    }
}
