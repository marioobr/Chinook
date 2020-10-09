using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Chinook.Models
{
    public class DetalleFactura
    {
        [Key]
        public int DetFacturaId { get; set; }
        [Display(Name ="Factura")]
        public int FacturaId { get; set; }
        [ForeignKey("FacturaId")]
        public virtual Factura Facturas { get; set; }
        [Display(Name ="Cancion")]
        public int CancionId { get; set; }
        [ForeignKey("CancionId")]
        public virtual Cancion NombreCanc { get; set; }
        public float PrecioUnidad { get; set; }
        public int Cantidad { get; set; }

    }
}
