using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoSGShoots6.Migrations.ModelosDB
{
    public partial class EDITED_PaqueteCotizacionLegit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cotizaciones_Paquetes_CotizacionFK",
                table: "Cotizaciones");

            migrationBuilder.RenameColumn(
                name: "CotizacionFK",
                table: "Cotizaciones",
                newName: "PaqueteFK");

            migrationBuilder.RenameIndex(
                name: "IX_Cotizaciones_CotizacionFK",
                table: "Cotizaciones",
                newName: "IX_Cotizaciones_PaqueteFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Cotizaciones_Paquetes_PaqueteFK",
                table: "Cotizaciones",
                column: "PaqueteFK",
                principalTable: "Paquetes",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cotizaciones_Paquetes_PaqueteFK",
                table: "Cotizaciones");

            migrationBuilder.RenameColumn(
                name: "PaqueteFK",
                table: "Cotizaciones",
                newName: "CotizacionFK");

            migrationBuilder.RenameIndex(
                name: "IX_Cotizaciones_PaqueteFK",
                table: "Cotizaciones",
                newName: "IX_Cotizaciones_CotizacionFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Cotizaciones_Paquetes_CotizacionFK",
                table: "Cotizaciones",
                column: "CotizacionFK",
                principalTable: "Paquetes",
                principalColumn: "ID");
        }
    }
}
