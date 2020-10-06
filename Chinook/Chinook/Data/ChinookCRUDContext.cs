using Chinook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chinook.Data
{
    public class ChinookCRUDContext:DbContext
    {
        public ChinookCRUDContext(DbContextOptions<ChinookCRUDContext> options):base(options)
        {

        }

        public DbSet<Album> Album { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<Cancion> Cancion { get; set; }
        public DbSet<Artista> Artista { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Factura> Factura { get; set; }
        public DbSet<DetalleFactura> DetalleFactura { get; set; }
        public DbSet<Empleado> Empleado { get; set; }

    }
}
