using System.ComponentModel.DataAnnotations;

namespace ProyectoSGShoots6.Models;

public class PreciosIndividuales
{
    [Key]
    public int Id { get; set; }

    [Required]
    public double PrecioFoto { get; set; }

    public double? PrecioVideoPorSegudo { get; set; }

    public bool Estado { get; set; }
}