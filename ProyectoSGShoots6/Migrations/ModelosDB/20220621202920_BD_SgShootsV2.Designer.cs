﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoSGShoots6.Data;

#nullable disable

namespace ProyectoSGShoots6.Migrations.ModelosDB
{
    [DbContext(typeof(ModelosDBContext))]
    [Migration("20220621202920_BD_SgShootsV2")]
    partial class BD_SgShootsV2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CotizacionProductos", b =>
                {
                    b.Property<int>("CotizacionesId")
                        .HasColumnType("int");

                    b.Property<int>("ProductosId")
                        .HasColumnType("int");

                    b.HasKey("CotizacionesId", "ProductosId");

                    b.HasIndex("ProductosId");

                    b.ToTable("CotizacionProductos");
                });

            modelBuilder.Entity("PaqueteProductos", b =>
                {
                    b.Property<int>("PaquetesID")
                        .HasColumnType("int");

                    b.Property<int>("ProductosId")
                        .HasColumnType("int");

                    b.HasKey("PaquetesID", "ProductosId");

                    b.HasIndex("ProductosId");

                    b.ToTable("PaqueteProductos");
                });

            modelBuilder.Entity("ProyectoSGShoots6.Models.Cotizacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDCotizacion");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PaqueteFK")
                        .HasColumnType("int");

                    b.Property<double>("PrecioFinal")
                        .HasColumnType("float");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("PaqueteFK");

                    b.ToTable("Cotizaciones");
                });

            modelBuilder.Entity("ProyectoSGShoots6.Models.Paquete", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<TimeSpan>("Cobertura")
                        .HasColumnType("time");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PrecioBasePaquete")
                        .HasColumnType("float");

                    b.Property<int?>("TipoPaqueteCodigo")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TipoPaqueteCodigo");

                    b.ToTable("Paquetes");
                });

            modelBuilder.Entity("ProyectoSGShoots6.Models.PreciosIndividuales", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<double>("PrecioFoto")
                        .HasColumnType("float");

                    b.Property<double?>("PrecioVideoPorSegudo")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("PreciosIndividuales");
                });

            modelBuilder.Entity("ProyectoSGShoots6.Models.Productos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TipoProductoIdTipoProducto")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoProductoIdTipoProducto");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("ProyectoSGShoots6.Models.TipoPaquete", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"), 1L, 1);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("PrecioIndiviualID")
                        .HasColumnType("int");

                    b.Property<int>("PreciosId")
                        .HasColumnType("int");

                    b.HasKey("Codigo");

                    b.HasIndex("PreciosId");

                    b.ToTable("TipoPaquetes");
                });

            modelBuilder.Entity("ProyectoSGShoots6.Models.TipoProducto", b =>
                {
                    b.Property<int>("IdTipoProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoProducto"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTipoProducto");

                    b.ToTable("TipoProductos");
                });

            modelBuilder.Entity("CotizacionProductos", b =>
                {
                    b.HasOne("ProyectoSGShoots6.Models.Cotizacion", null)
                        .WithMany()
                        .HasForeignKey("CotizacionesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoSGShoots6.Models.Productos", null)
                        .WithMany()
                        .HasForeignKey("ProductosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PaqueteProductos", b =>
                {
                    b.HasOne("ProyectoSGShoots6.Models.Paquete", null)
                        .WithMany()
                        .HasForeignKey("PaquetesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoSGShoots6.Models.Productos", null)
                        .WithMany()
                        .HasForeignKey("ProductosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProyectoSGShoots6.Models.Cotizacion", b =>
                {
                    b.HasOne("ProyectoSGShoots6.Models.Paquete", null)
                        .WithMany("Cotizaciones")
                        .HasForeignKey("PaqueteFK");
                });

            modelBuilder.Entity("ProyectoSGShoots6.Models.Paquete", b =>
                {
                    b.HasOne("ProyectoSGShoots6.Models.TipoPaquete", null)
                        .WithMany("Paquetes")
                        .HasForeignKey("TipoPaqueteCodigo");
                });

            modelBuilder.Entity("ProyectoSGShoots6.Models.Productos", b =>
                {
                    b.HasOne("ProyectoSGShoots6.Models.TipoProducto", null)
                        .WithMany("Productos")
                        .HasForeignKey("TipoProductoIdTipoProducto");
                });

            modelBuilder.Entity("ProyectoSGShoots6.Models.TipoPaquete", b =>
                {
                    b.HasOne("ProyectoSGShoots6.Models.PreciosIndividuales", "Precios")
                        .WithMany()
                        .HasForeignKey("PreciosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Precios");
                });

            modelBuilder.Entity("ProyectoSGShoots6.Models.Paquete", b =>
                {
                    b.Navigation("Cotizaciones");
                });

            modelBuilder.Entity("ProyectoSGShoots6.Models.TipoPaquete", b =>
                {
                    b.Navigation("Paquetes");
                });

            modelBuilder.Entity("ProyectoSGShoots6.Models.TipoProducto", b =>
                {
                    b.Navigation("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}