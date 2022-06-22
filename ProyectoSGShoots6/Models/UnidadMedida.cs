using System.ComponentModel.DataAnnotations;

namespace ProyectoSGShoots6.Models;

public class UnidadMedida
{
    [Key] public int Id { get; set; }
    [Required] public string descripcion { get; set; }
}