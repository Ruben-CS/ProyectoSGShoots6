using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoSGShoots6.Migrations.ModelosDB
{
    public partial class PaqueteProducto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "detalleProducto",
                columns: table => new
                {
                    PaquetesID = table.Column<int>(type: "int", nullable: false),
                    ProductosId = table.Column<int>(type: "int", nullable: false),
                    CantidadProducto = table.Column<int>(type:"int",nullable:false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalleProducto", x => new { x.PaquetesID, x.ProductosId });
                    table.ForeignKey(
                        name: "FK_detalleProducto_Paquetes_PaquetesID",
                        column: x => x.PaquetesID,
                        principalTable: "Paquetes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalleProducto_Productos_ProductosId",
                        column: x => x.ProductosId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaqueteProductos_ProductosId",
                table: "detalleProducto",
                column: "ProductosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalleProducto");

            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
