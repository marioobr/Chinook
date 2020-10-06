using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Chinook.Models;

namespace Chinook.Data
{
    public class ChinookContext : DbContext
    {
        public ChinookContext (DbContextOptions<ChinookContext> options)
            : base(options)
        {
        }

        public DbSet<Chinook.Models.Cliente> Cliente { get; set; }

        public DbSet<Chinook.Models.Empleado> Empleado { get; set; }

        public DbSet<Chinook.Models.Album> Album { get; set; }

        public DbSet<Chinook.Models.Artista> Artista { get; set; }

        public DbSet<Chinook.Models.Cancion> Cancion { get; set; }

        public DbSet<Chinook.Models.Genero> Genero { get; set; }

        public DbSet<Chinook.Models.Factura> Factura { get; set; }

        public DbSet<Chinook.Models.DetalleFactura> DetalleFactura { get; set; }
    }
}
