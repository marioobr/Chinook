﻿using System;
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
    public class DetalleFacturasController : Controller
    {
        private readonly ChinookContext _context;

        public DetalleFacturasController(ChinookContext context)
        {
            _context = context;
        }

        // GET: DetalleFacturas
        public async Task<IActionResult> Index(int? pageNumber)
        {
            var chinookContext = _context.DetalleFactura.Include(d => d.Facturas).Include(d => d.NombreCanc);

            int pageSize = 5;
            return View(await PaginatedList<DetalleFactura>.CreateAsync(chinookContext.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: DetalleFacturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleFactura = await _context.DetalleFactura
                .Include(d => d.Facturas)
                .Include(d => d.NombreCanc)
                .FirstOrDefaultAsync(m => m.DetFacturaId == id);
            if (detalleFactura == null)
            {
                return NotFound();
            }

            return View(detalleFactura);
        }

        // GET: DetalleFacturas/Create
        public IActionResult Create()
        {
            ViewData["FacturaId"] = new SelectList(_context.Factura, "FacturaId", "FacturaId");
            ViewData["CancionId"] = new SelectList(_context.Cancion, "CancionId", "Nombre");
            return View();
        }

        // POST: DetalleFacturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DetFacturaId,FacturaId,CancionId,PrecioUnidad,Cantidad")] DetalleFactura detalleFactura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleFactura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FacturaId"] = new SelectList(_context.Factura, "FacturaId", "FacturaId", detalleFactura.FacturaId);
            ViewData["CancionId"] = new SelectList(_context.Cancion, "CancionId", "Nombre", detalleFactura.CancionId);
            return View(detalleFactura);
        }

        // GET: DetalleFacturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleFactura = await _context.DetalleFactura.FindAsync(id);
            if (detalleFactura == null)
            {
                return NotFound();
            }
            ViewData["FacturaId"] = new SelectList(_context.Factura, "FacturaId", "FacturaId", detalleFactura.FacturaId);
            ViewData["CancionId"] = new SelectList(_context.Cancion, "CancionId", "Nombre", detalleFactura.CancionId);
            return View(detalleFactura);
        }

        // POST: DetalleFacturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DetFacturaId,FacturaId,CancionId,PrecioUnidad,Cantidad")] DetalleFactura detalleFactura)
        {
            if (id != detalleFactura.DetFacturaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleFactura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleFacturaExists(detalleFactura.DetFacturaId))
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
            ViewData["FacturaId"] = new SelectList(_context.Factura, "FacturaId", "FacturaId", detalleFactura.FacturaId);
            ViewData["CancionId"] = new SelectList(_context.Cancion, "CancionId", "Nombre", detalleFactura.CancionId);
            return View(detalleFactura);
        }

        // GET: DetalleFacturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleFactura = await _context.DetalleFactura
                .Include(d => d.Facturas)
                .Include(d => d.NombreCanc)
                .FirstOrDefaultAsync(m => m.DetFacturaId == id);
            if (detalleFactura == null)
            {
                return NotFound();
            }

            return View(detalleFactura);
        }

        // POST: DetalleFacturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleFactura = await _context.DetalleFactura.FindAsync(id);
            _context.DetalleFactura.Remove(detalleFactura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleFacturaExists(int id)
        {
            return _context.DetalleFactura.Any(e => e.DetFacturaId == id);
        }
    }
}
