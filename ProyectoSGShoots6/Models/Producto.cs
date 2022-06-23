using System;
using System.Collections.Generic;

namespace ProyectoSGShoots6.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetalleProductoPersonalizados = new HashSet<DetalleProductoPersonalizado>();
            DetalleProductos = new HashSet<DetalleProducto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public bool Estado { get; set; }
        public int? TipoProductoIdTipoProducto { get; set; }

        public virtual TipoProducto? TipoProductoIdTipoProductoNavigation { get; set; }
        public virtual ICollection<DetalleProductoPersonalizado> DetalleProductoPersonalizados { get; set; }
        public virtual ICollection<DetalleProducto> DetalleProductos { get; set; }
    }
}
