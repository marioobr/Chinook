using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chinook.Models
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cargo { get; set; }
        public int JefeDirecto { get; set; }
        public int Telefono { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


    }
}
