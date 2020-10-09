using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Chinook.Models
{
    public class Factura
    {
        public int FacturaId { get; set; }
        [Display(Name ="Cliente")]
        public int ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public virtual Cliente NombresCli { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaFactura { get; set; }
        public float Total { get; set; }

    }
}
