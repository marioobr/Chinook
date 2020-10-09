using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Chinook.Models
{
    public class Cancion
    {
        public int CancionId { get; set; }
        public string Nombre { get; set; }
        [Display(Name = "Genero")]
        public int GeneroId { get; set; }
        [ForeignKey("GeneroId")]
        public virtual Genero NombreG { get; set; }
        [Display(Name = "Album")]
        public int AlbumId { get; set; }
        [ForeignKey("AlbumId")]
        public virtual Album NombreAlbum { get; set; }
    }
}
