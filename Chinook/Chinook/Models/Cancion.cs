using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chinook.Models
{
    public class Cancion
    {
        public int CancionId { get; set; }
        public string Nombre { get; set; }
        public int GeneroId { get; set; }
        public int AlbumId { get; set; }

    }
}
