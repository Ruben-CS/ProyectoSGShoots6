using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoSGShoots6.Areas.Identity.Data;

namespace ProyectoSGShoots6.Models;

public class Cotizacion
{
    [Key] [Column("IDCotizacion")] public int Id { get; set; }
    [Required] [DataType(DataType.Date)] public DateTime FechaInicio { get; set; }
    [Required] [DataType(DataType.Date)] public DateTime FechaFin { get; set; }
    [Required] public double PrecioFinal { get; set; }
    [Required] [MaxLength(255)] public string Ubicacion { get; set; }
    public ICollection<Productos> Productos { get; set; }
    [Required] public bool Estado { get; set; }
}