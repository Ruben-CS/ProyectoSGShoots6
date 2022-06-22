using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoSGShoots6.Models;

public class TipoProducto
{
    [Key] public int IdTipoProducto { get; set; }
    public ICollection<Productos>? Productos { get; set; }
    [Required] public string Nombre { get; set; }
}