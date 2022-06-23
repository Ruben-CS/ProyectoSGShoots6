using System;
using System.Collections.Generic;

namespace ProyectoSGShoots6.Models
{
    public partial class DetalleProducto
    {
        public int PaquetesId { get; set; }
        public int ProductosId { get; set; }
        public int? UnidadMedidaId { get; set; }

        public virtual Paquete Paquetes { get; set; } = null!;
        public virtual Producto Productos { get; set; } = null!;
        public virtual UnidadMedida? UnidadMedida { get; set; }
    }
}
