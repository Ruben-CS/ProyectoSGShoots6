using System;
using System.Collections.Generic;

namespace ProyectoSGShoots6.Models
{
    public partial class Paquete
    {
        public Paquete()
        {
            Cotizaciones = new HashSet<Cotizacione>();
            DetalleProductos = new HashSet<DetalleProducto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Cobertura { get; set; } = null!;
        public double PrecioBasePaquete { get; set; }
        public int? TipoPaqueteCodigo { get; set; }

        public virtual TipoPaquete? TipoPaqueteCodigoNavigation { get; set; }
        public virtual ICollection<Cotizacione> Cotizaciones { get; set; }
        public virtual ICollection<DetalleProducto> DetalleProductos { get; set; }
    }
}
