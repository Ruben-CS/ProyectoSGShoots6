using Microsoft.EntityFrameworkCore;
using ProyectoSGShoots6.Models;

namespace ProyectoSGShoots6.Data;

public class ModelosDBContext : DbContext
{
    public ModelosDBContext(DbContextOptions<ModelosDBContext> options) : base(options)
    {
        
    }
    public DbSet<Paquete> Paquetes { get; set; }
    public DbSet<Cotizacion> Cotizaciones { get; set; }
    public DbSet<TipoPaquete> TipoPaquetes { get; set; }
    public DbSet<TipoProducto> TipoProductos { get; set; }
    public DbSet<UnidadMedida> UnidadMedidas { get; set; }
    
}
