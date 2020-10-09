using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Chinook.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string Titulo { get; set; }
        [Display(Name ="Artista")]
        public int ArtistaId { get; set; }
        [ForeignKey("ArtistaId")]
        public virtual Artista Nombre { get; set; }
    }
}
