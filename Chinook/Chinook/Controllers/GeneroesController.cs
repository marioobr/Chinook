using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chinook.Data;
using Chinook.Models;

namespace Chinook.Controllers
{
    public class GeneroesController : Controller
    {
        private readonly ChinookContext _context;

        public GeneroesController(ChinookContext context)
        {
            _context = context;
        }

        // GET: Generoes
        public async Task<IActionResult> Index(string CadenaBusq,
            string sortOrder,
            string currentFilter,
            int? pageNumber)

        {
            //Paginación
            ViewData["CurrentSort"] = sortOrder;
            //Ordenar
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : " ";

            if (CadenaBusq != null)
            {
                pageNumber = 1;
            }
            else
            {
                CadenaBusq = currentFilter;
            }
            ViewData["CurrentFilter"] = CadenaBusq;

            //Busqueda
            var generos = from c in _context.Genero
                            select c;

            if (!String.IsNullOrEmpty(CadenaBusq))
            {
                generos = generos.Where(p => p.Nombre.Contains(CadenaBusq));
            }


            switch (sortOrder)
            {
                case "name_desc":
                    generos = generos.OrderByDescending(o => o.Nombre);
                    break;

                default:
                    generos = generos.OrderBy(p => p.Nombre);
                    break;
            }

            int pageSize = 5;
            //return View(await PaginatedList<Pelicula>.CreateAsync(peliculas.AsNoTracking(), pageNumber ?? 1, pageSize));
            return View(await PaginatedList<Genero>.CreateAsync(generos.AsNoTracking(), pageNumber ?? 1, pageSize));
        }




        // GET: Generoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genero = await _context.Genero
                .FirstOrDefaultAsync(m => m.GeneroId == id);
            if (genero == null)
            {
                return NotFound();
            }

            return View(genero);
        }

        // GET: Generoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Generoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GeneroId,Nombre")] Genero genero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(genero);
        }

        // GET: Generoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genero = await _context.Genero.FindAsync(id);
            if (genero == null)
            {
                return NotFound();
            }
            return View(genero);
        }

        // POST: Generoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GeneroId,Nombre")] Genero genero)
        {
            if (id != genero.GeneroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeneroExists(genero.GeneroId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(genero);
        }

        // GET: Generoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genero = await _context.Genero
                .FirstOrDefaultAsync(m => m.GeneroId == id);
            if (genero == null)
            {
                return NotFound();
            }

            return View(genero);
        }

        // POST: Generoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genero = await _context.Genero.FindAsync(id);
            _context.Genero.Remove(genero);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GeneroExists(int id)
        {
            return _context.Genero.Any(e => e.GeneroId == id);
        }
    }
}
