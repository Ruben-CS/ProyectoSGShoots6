using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoSGShoots6.Models;

public class Paquete
{
    [Key] public int ID { get; set; }
    [Required] public string Nombre { get; set; }
    [Required] public TimeSpan Cobertura { get; set; }
    [Required] public double PrecioBasePaquete { get; set; }
    public ICollection<Productos>? Productos { get; set; }
    [ForeignKey("PaqueteFK")]public ICollection<Cotizacion>? Cotizaciones { get; set; }
}