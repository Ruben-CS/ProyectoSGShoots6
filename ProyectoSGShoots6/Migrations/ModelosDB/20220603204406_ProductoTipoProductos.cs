using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoSGShoots6.Migrations.ModelosDB
{
    public partial class ProductoTipoProductos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idTipoProducto",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TipoProductos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProductos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_idTipoProducto",
                table: "Productos",
                column: "idTipoProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_TipoProductos_idTipoProducto",
                table: "Productos",
                column: "idTipoProducto",
                principalTable: "TipoProductos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_TipoProductos_idTipoProducto",
                table: "Productos");

            migrationBuilder.DropTable(
                name: "TipoProductos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_idTipoProducto",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "idTipoProducto",
                table: "Productos");
        }
    }
}
