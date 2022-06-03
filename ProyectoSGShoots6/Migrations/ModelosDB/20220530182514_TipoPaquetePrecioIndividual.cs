using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoSGShoots6.Migrations.ModelosDB
{
    public partial class TipoPaquetePrecioIndividual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrecioIndiviualID",
                table: "TipoPaquetes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PreciosId",
                table: "TipoPaquetes",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_TipoPaquetes_PreciosId",
                table: "TipoPaquetes",
                column: "PreciosId");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoPaquetes_PreciosIndividuales_PreciosId",
                table: "TipoPaquetes",
                column: "PreciosId",
                principalTable: "PreciosIndividuales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoPaquetes_PreciosIndividuales_PreciosId",
                table: "TipoPaquetes");

            migrationBuilder.DropTable(
                name: "PreciosIndividuales");

            migrationBuilder.DropIndex(
                name: "IX_TipoPaquetes_PreciosId",
                table: "TipoPaquetes");

            migrationBuilder.DropColumn(
                name: "PrecioIndiviualID",
                table: "TipoPaquetes");

            migrationBuilder.DropColumn(
                name: "PreciosId",
                table: "TipoPaquetes");
        }
    }
}
