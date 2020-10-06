using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chinook.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string Titulo { get; set; }
        public int ArtistaId { get; set; }
    }
}
