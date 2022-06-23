using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProyectoSGShoots6.Models;

namespace ProyectoSGShoots6.Data
{
    public partial class ModelosDbContext : DbContext
    {
        public ModelosDbContext()
        {
        }

        public ModelosDbContext(DbContextOptions<ModelosDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<Cotizacione> Cotizaciones { get; set; } = null!;
        public virtual DbSet<DetalleProducto> DetalleProductos { get; set; } = null!;
        public virtual DbSet<DetalleProductoPersonalizado> DetalleProductoPersonalizados { get; set; } = null!;
        public virtual DbSet<Paquete> Paquetes { get; set; } = null!;
        public virtual DbSet<PreciosIndividuale> PreciosIndividuales { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<TipoPaquete> TipoPaquetes { get; set; } = null!;
        public virtual DbSet<TipoProducto> TipoProductos { get; set; } = null!;
        public virtual DbSet<UnidadMedida> UnidadMedidas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:ruben-server.database.windows.net,1433;Initial Catalog=BD_SgShoots;Persist Security Info=False;User ID=ruben_f;Password=Ilpcgamailp19;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.ApellidoMaterno)
                    .HasMaxLength(50)
                    .HasColumnName("apellidoMaterno");

                entity.Property(e => e.ApellidoPaterno)
                    .HasMaxLength(50)
                    .HasColumnName("apellidoPaterno");

                entity.Property(e => e.Carnet)
                    .HasMaxLength(9)
                    .HasColumnName("carnet");

                entity.Property(e => e.Celular)
                    .HasMaxLength(8)
                    .HasColumnName("celular");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasDefaultValueSql("(CONVERT([bit],(1)))");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(35)
                    .HasColumnName("nombre");

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Cotizacione>(entity =>
            {
                entity.HasKey(e => e.Idcotizacion);

                entity.HasIndex(e => e.PaqueteFk, "IX_Cotizaciones_PaqueteFK");

                entity.Property(e => e.Idcotizacion).HasColumnName("IDCotizacion");

                entity.Property(e => e.PaqueteFk).HasColumnName("PaqueteFK");

                entity.Property(e => e.Ubicacion).HasMaxLength(255);

                entity.HasOne(d => d.PaqueteFkNavigation)
                    .WithMany(p => p.Cotizaciones)
                    .HasForeignKey(d => d.PaqueteFk);
            });

            modelBuilder.Entity<DetalleProducto>(entity =>
            {
                entity.HasKey(e => new { e.PaquetesId, e.ProductosId })
                    .HasName("PK_PaqueteProductos");

                entity.ToTable("DetalleProducto");

                entity.HasIndex(e => e.ProductosId, "IX_PaqueteProductos_ProductosId");

                entity.Property(e => e.PaquetesId).HasColumnName("PaquetesID");

                entity.Property(e => e.UnidadMedidaId).HasColumnName("UnidadMedidaID");

                entity.HasOne(d => d.Paquetes)
                    .WithMany(p => p.DetalleProductos)
                    .HasForeignKey(d => d.PaquetesId)
                    .HasConstraintName("FK_PaqueteProductos_Paquetes_PaquetesID");

                entity.HasOne(d => d.Productos)
                    .WithMany(p => p.DetalleProductos)
                    .HasForeignKey(d => d.ProductosId)
                    .HasConstraintName("FK_PaqueteProductos_Productos_ProductosId");

                entity.HasOne(d => d.UnidadMedida)
                    .WithMany(p => p.DetalleProductos)
                    .HasForeignKey(d => d.UnidadMedidaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("UnidadMedidas_fk");
            });

            modelBuilder.Entity<DetalleProductoPersonalizado>(entity =>
            {
                entity.HasKey(e => new { e.CotizacionesId, e.ProductosId })
                    .HasName("PK_CotizacionProductos");

                entity.ToTable("DetalleProductoPersonalizado");

                entity.HasIndex(e => e.ProductosId, "IX_CotizacionProductos_ProductosId");

                entity.Property(e => e.UnidadMedidaId).HasColumnName("UnidadMedida_ID");

                entity.HasOne(d => d.Cotizaciones)
                    .WithMany(p => p.DetalleProductoPersonalizados)
                    .HasForeignKey(d => d.CotizacionesId)
                    .HasConstraintName("FK_CotizacionProductos_Cotizaciones_CotizacionesId");

                entity.HasOne(d => d.Productos)
                    .WithMany(p => p.DetalleProductoPersonalizados)
                    .HasForeignKey(d => d.ProductosId)
                    .HasConstraintName("FK_CotizacionProductos_Productos_ProductosId");

                entity.HasOne(d => d.UnidadMedida)
                    .WithMany(p => p.DetalleProductoPersonalizados)
                    .HasForeignKey(d => d.UnidadMedidaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("DetalleProductoPersonalizado_UnidadMedidas__fk");
            });

            modelBuilder.Entity<Paquete>(entity =>
            {
                entity.HasIndex(e => e.TipoPaqueteCodigo, "IX_Paquetes_TipoPaqueteCodigo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.TipoPaqueteCodigoNavigation)
                    .WithMany(p => p.Paquetes)
                    .HasForeignKey(d => d.TipoPaqueteCodigo);
            });

            modelBuilder.Entity<PreciosIndividuale>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasIndex(e => e.TipoProductoIdTipoProducto, "IX_Productos_TipoProductoIdTipoProducto");

                entity.Property(e => e.Descripcion).HasMaxLength(250);

                entity.HasOne(d => d.TipoProductoIdTipoProductoNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.TipoProductoIdTipoProducto);
            });

            modelBuilder.Entity<TipoPaquete>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.HasIndex(e => e.PreciosId, "IX_TipoPaquetes_PreciosId");

                entity.Property(e => e.Nombre).HasMaxLength(30);

                entity.HasOne(d => d.Precios)
                    .WithMany(p => p.TipoPaquetes)
                    .HasForeignKey(d => d.PreciosId);
            });

            modelBuilder.Entity<TipoProducto>(entity =>
            {
                entity.HasKey(e => e.IdTipoProducto);
            });

            modelBuilder.Entity<UnidadMedida>(entity =>
            {
                entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
