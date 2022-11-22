using System;
using System.Collections.Generic;

namespace ProyectoSGShoots6.Models
{
    public partial class TipoPaquete
    {
        public TipoPaquete()
        {
            Paquetes = new HashSet<Paquete>();
        }

        public int Codigo { get; set; }
        public string Nombre { get; set; } = null!;
        public bool Estado { get; set; }
        public int PreciosId { get; set; }

        public virtual PreciosIndividuale Precios { get; set; } = null!;
        public virtual ICollection<Paquete> Paquetes { get; set; }
    }
}
