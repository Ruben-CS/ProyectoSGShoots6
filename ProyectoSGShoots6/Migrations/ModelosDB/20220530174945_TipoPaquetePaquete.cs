using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoSGShoots6.Migrations.ModelosDB
{
    public partial class TipoPaquetePaquete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoPaqueteCodigo",
                table: "Paquetes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TipoPaquetes",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPaquetes", x => x.Codigo);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paquetes_TipoPaqueteCodigo",
                table: "Paquetes",
                column: "TipoPaqueteCodigo");

            migrationBuilder.AddForeignKey(
                name: "FK_Paquetes_TipoPaquetes_TipoPaqueteCodigo",
                table: "Paquetes",
                column: "TipoPaqueteCodigo",
                principalTable: "TipoPaquetes",
                principalColumn: "Codigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paquetes_TipoPaquetes_TipoPaqueteCodigo",
                table: "Paquetes");

            migrationBuilder.DropTable(
                name: "TipoPaquetes");

            migrationBuilder.DropIndex(
                name: "IX_Paquetes_TipoPaqueteCodigo",
                table: "Paquetes");

            migrationBuilder.DropColumn(
                name: "TipoPaqueteCodigo",
                table: "Paquetes");
        }
    }
}
