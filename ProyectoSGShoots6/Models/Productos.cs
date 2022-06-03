using System.ComponentModel.DataAnnotations;
using Microsoft.CodeAnalysis.Options;

namespace ProyectoSGShoots6.Models;

public class Productos
{
    [Key] public int Id { get; set; }

    [Required(ErrorMessage = "Por favor ingrese un nombre")]
    public string Nombre { get; set; }

    [Required] [MaxLength(250)] public string Descripcion { get; set; }
    public bool Estado { get; set; }
    public ICollection<Paquete>? Paquetes { get; set; }
    public ICollection<Cotizacion> Cotizaciones { get; set; }
}