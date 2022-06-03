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
    [Migration("20220530182514_TipoPaquetePrecioIndividual")]
    partial class TipoPaquetePrecioIndividual
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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
#pragma warning restore 612, 618
        }
    }
}
