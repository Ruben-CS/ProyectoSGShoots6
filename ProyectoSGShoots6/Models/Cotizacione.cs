using System;
using System.Collections.Generic;

namespace ProyectoSGShoots6.Models
{
    public partial class Cotizacione
    {
        public Cotizacione()
        {
            DetalleProductoPersonalizados = new HashSet<DetalleProductoPersonalizado>();
        }

        public int Idcotizacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public double PrecioFinal { get; set; }
        public string Ubicacion { get; set; } = null!;
        public bool Estado { get; set; }
        public int? PaqueteFk { get; set; }

        public virtual Paquete? PaqueteFkNavigation { get; set; }
        public virtual ICollection<DetalleProductoPersonalizado> DetalleProductoPersonalizados { get; set; }
    }
}
