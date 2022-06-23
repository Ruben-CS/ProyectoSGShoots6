using System;
using System.Collections.Generic;

namespace ProyectoSGShoots6.Models
{
    public partial class UnidadMedida
    {
        public UnidadMedida()
        {
            DetalleProductoPersonalizados = new HashSet<DetalleProductoPersonalizado>();
            DetalleProductos = new HashSet<DetalleProducto>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<DetalleProductoPersonalizado> DetalleProductoPersonalizados { get; set; }
        public virtual ICollection<DetalleProducto> DetalleProductos { get; set; }
    }
}
