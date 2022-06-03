using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoSGShoots6.Migrations.ModelosDB
{
    public partial class BD_SgShootsV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cotizaciones_Paquetes_PaqueteFK",
                table: "Cotizaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_CotizacionProductos_Cotizaciones_CotizacionesId",
                table: "CotizacionProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_PaqueteProductos_Paquetes_PaquetesID",
                table: "PaqueteProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_Paquetes_TipoPaquetes_TipoPaqueteCodigo",
                table: "Paquetes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Paquetes",
                table: "Paquetes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cotizaciones",
                table: "Cotizaciones");

            migrationBuilder.RenameTable(
                name: "Paquetes",
                newName: "Paquete");

            migrationBuilder.RenameTable(
                name: "Cotizaciones",
                newName: "Cotizacion");

            migrationBuilder.RenameIndex(
                name: "IX_Paquetes_TipoPaqueteCodigo",
                table: "Paquete",
                newName: "IX_Paquete_TipoPaqueteCodigo");

            migrationBuilder.RenameIndex(
                name: "IX_Cotizaciones_PaqueteFK",
                table: "Cotizacion",
                newName: "IX_Cotizacion_PaqueteFK");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Paquete",
                table: "Paquete",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cotizacion",
                table: "Cotizacion",
                column: "IDCotizacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Cotizacion_Paquete_PaqueteFK",
                table: "Cotizacion",
                column: "PaqueteFK",
                principalTable: "Paquete",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CotizacionProductos_Cotizacion_CotizacionesId",
                table: "CotizacionProductos",
                column: "CotizacionesId",
                principalTable: "Cotizacion",
                principalColumn: "IDCotizacion",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Paquete_TipoPaquetes_TipoPaqueteCodigo",
                table: "Paquete",
                column: "TipoPaqueteCodigo",
                principalTable: "TipoPaquetes",
                principalColumn: "Codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_PaqueteProductos_Paquete_PaquetesID",
                table: "PaqueteProductos",
                column: "PaquetesID",
                principalTable: "Paquete",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cotizacion_Paquete_PaqueteFK",
                table: "Cotizacion");

            migrationBuilder.DropForeignKey(
                name: "FK_CotizacionProductos_Cotizacion_CotizacionesId",
                table: "CotizacionProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_Paquete_TipoPaquetes_TipoPaqueteCodigo",
                table: "Paquete");

            migrationBuilder.DropForeignKey(
                name: "FK_PaqueteProductos_Paquete_PaquetesID",
                table: "PaqueteProductos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Paquete",
                table: "Paquete");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cotizacion",
                table: "Cotizacion");

            migrationBuilder.RenameTable(
                name: "Paquete",
                newName: "Paquetes");

            migrationBuilder.RenameTable(
                name: "Cotizacion",
                newName: "Cotizaciones");

            migrationBuilder.RenameIndex(
                name: "IX_Paquete_TipoPaqueteCodigo",
                table: "Paquetes",
                newName: "IX_Paquetes_TipoPaqueteCodigo");

            migrationBuilder.RenameIndex(
                name: "IX_Cotizacion_PaqueteFK",
                table: "Cotizaciones",
                newName: "IX_Cotizaciones_PaqueteFK");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Paquetes",
                table: "Paquetes",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cotizaciones",
                table: "Cotizaciones",
                column: "IDCotizacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Cotizaciones_Paquetes_PaqueteFK",
                table: "Cotizaciones",
                column: "PaqueteFK",
                principalTable: "Paquetes",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CotizacionProductos_Cotizaciones_CotizacionesId",
                table: "CotizacionProductos",
                column: "CotizacionesId",
                principalTable: "Cotizaciones",
                principalColumn: "IDCotizacion",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaqueteProductos_Paquetes_PaquetesID",
                table: "PaqueteProductos",
                column: "PaquetesID",
                principalTable: "Paquetes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Paquetes_TipoPaquetes_TipoPaqueteCodigo",
                table: "Paquetes",
                column: "TipoPaqueteCodigo",
                principalTable: "TipoPaquetes",
                principalColumn: "Codigo");
        }
    }
}
