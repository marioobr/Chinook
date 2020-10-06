using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chinook.Models
{
    public class DetalleFactura
    {
        public int DetFacturaId { get; set; }
        public int FacturaId { get; set; }
        public int CancionId { get; set; }
        public float PrecioUnidad { get; set; }
        public int Cantidad { get; set; }

    }
}
