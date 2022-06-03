using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoSGShoots6.Models;

public class TipoPaquete
{
    [Key] public int Codigo { get; set; }
    [Required] [MaxLength(30)] public string Nombre { get; set; }
    [Required][DefaultValue(true)]public bool Estado { get; set; }
    public int PrecioIndiviualID { get; set; }
    public PreciosIndividuales Precios { get; set; }
    public ICollection<Paquete> Paquetes { get; set; }
}