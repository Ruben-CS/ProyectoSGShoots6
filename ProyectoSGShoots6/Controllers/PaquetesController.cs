﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoSGShoots6.Data;
using ProyectoSGShoots6.Models;
using Microsoft.AspNetCore.Authorization;
namespace ProyectoSGShoots6.Controllers
{
    [Authorize]
    public class PaquetesController : Controller
    {
        private readonly ModelosDBContext _context;

        public PaquetesController(ModelosDBContext context)
        {
            _context = context;
        }

        // GET: Paquetes
        public async Task<IActionResult> Index()
        {
            var modelosDBContext = _context.Paquetes.Include(p => p.TipoPaqueteCodigoNavigation);

            var result = _context.Paquetes.Join(
                _context.Productos,
                paquete => paquete.Id,
                producto => producto.Id,
                (x, y) => new
                {
                    id = x.Id,
                    nombre = x.Nombre,
                    cobertura = x.Cobertura,
                    precio = x.PrecioBasePaquete,
                    idp = y.Id,
                    nombrep = y.Nombre
                }
            );
            return View(await modelosDBContext.ToListAsync());
        }

        // GET: Paquetes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Paquetes == null)
            {
                return NotFound();
            }

            var paquete = await _context.Paquetes
                .Include(p => p.TipoPaqueteCodigoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paquete == null)
            {
                return NotFound();
            }

            return View(paquete);
        }

        // GET: Paquetes/Create
        public IActionResult Create()
        {
            ViewData["TipoPaqueteCodigo"] = new SelectList(_context.TipoPaquetes, "Codigo", "Codigo");
            return View();
        }

        // POST: Paquetes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Cobertura,PrecioBasePaquete,TipoPaqueteCodigo")] Paquete paquete)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paquete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoPaqueteCodigo"] = new SelectList(_context.TipoPaquetes, "Codigo", "Codigo", paquete.TipoPaqueteCodigo);
            return View(paquete);
        }

        // GET: Paquetes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Paquetes == null)
            {
                return NotFound();
            }

            var paquete = await _context.Paquetes.FindAsync(id);
            if (paquete == null)
            {
                return NotFound();
            }
            ViewData["TipoPaqueteCodigo"] = new SelectList(_context.TipoPaquetes, "Codigo", "Codigo", paquete.TipoPaqueteCodigo);
            return View(paquete);
        }

        // POST: Paquetes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Cobertura,PrecioBasePaquete,TipoPaqueteCodigo")] Paquete paquete)
        {
            if (id != paquete.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paquete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaqueteExists(paquete.Id))
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
            ViewData["TipoPaqueteCodigo"] = new SelectList(_context.TipoPaquetes, "Codigo", "Codigo", paquete.TipoPaqueteCodigo);
            return View(paquete);
        }

        // GET: Paquetes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Paquetes == null)
            {
                return NotFound();
            }

            var paquete = await _context.Paquetes
                .Include(p => p.TipoPaqueteCodigoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paquete == null)
            {
                return NotFound();
            }

            return View(paquete);
        }

        // POST: Paquetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Paquetes == null)
            {
                return Problem("Entity set 'ModelosDBContext.Paquetes'  is null.");
            }
            var paquete = await _context.Paquetes.FindAsync(id);
            if (paquete != null)
            {
                _context.Paquetes.Remove(paquete);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaqueteExists(int id)
        {
          return (_context.Paquetes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
