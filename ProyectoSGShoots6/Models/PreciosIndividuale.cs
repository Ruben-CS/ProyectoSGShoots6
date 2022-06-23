using System;
using System.Collections.Generic;

namespace ProyectoSGShoots6.Models
{
    public partial class PreciosIndividuale
    {
        public PreciosIndividuale()
        {
            TipoPaquetes = new HashSet<TipoPaquete>();
        }

        public int Id { get; set; }
        public double PrecioFoto { get; set; }
        public double? PrecioVideoPorSegudo { get; set; }
        public bool Estado { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<TipoPaquete> TipoPaquetes { get; set; }
    }
}
