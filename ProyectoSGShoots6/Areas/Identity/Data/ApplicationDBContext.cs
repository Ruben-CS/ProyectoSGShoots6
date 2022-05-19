using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoSGShoots6.Areas.Identity.Data;

namespace ProyectoSGShoots6.Areas.Identity.Data;

public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserConfiguration());
    }
}

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(u => u.nombre).HasMaxLength(35).IsRequired();
        builder.Property(u => u.apellidoPaterno).HasMaxLength(50).IsRequired();
        builder.Property(u => u.apellidoMaterno).HasMaxLength(50).IsRequired();
        builder.Property(u => u.celular).HasMaxLength(8).IsRequired();
        builder.Property(u => u.carnet).HasMaxLength(9).IsRequired();
        builder.Property(u => u.estado).HasDefaultValue(true).IsRequired();
    }
}