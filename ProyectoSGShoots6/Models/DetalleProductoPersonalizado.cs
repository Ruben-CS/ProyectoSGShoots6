using System;
using System.Collections.Generic;

namespace ProyectoSGShoots6.Models
{
    public partial class DetalleProductoPersonalizado
    {
        public int CotizacionesId { get; set; }
        public int ProductosId { get; set; }
        public int? UnidadMedidaId { get; set; }

        public virtual Cotizacione Cotizaciones { get; set; } = null!;
        public virtual Producto Productos { get; set; } = null!;
        public virtual UnidadMedida? UnidadMedida { get; set; }
    }
}
