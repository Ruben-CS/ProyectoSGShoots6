using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoSGShoots6.Models;

public class TipoProducto
{
    [Key] public int Id { get; set; }
    [ForeignKey("idTipoProducto")] public ICollection<Productos>? Productos { get; set; }
    [Required] public string Nombre { get; set; }
}