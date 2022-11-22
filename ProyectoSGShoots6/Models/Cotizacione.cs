using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace ProyectoSGShoots6.Models
{
    public partial class Cotizacione
    {
        private static readonly Random Rnd;

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
        [Required]
        public string? NombreCotizacion { get; set; } = null;

        public virtual Paquete? PaqueteFkNavigation { get; set; }
        public virtual ICollection<DetalleProductoPersonalizado> DetalleProductoPersonalizados { get; set; }

        [NotMapped]
        [DisplayName("Subir comprobante de pago")]
        public IFormFile ImageFile { get; set; }

    }
}
