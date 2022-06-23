﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoSGShoots6.Data;
using ProyectoSGShoots6.Models;

namespace ProyectoSGShoots6.Controllers
{
    public class DetalleProductosController : Controller
    {
        private readonly ModelosDbContext _context;

        public DetalleProductosController(ModelosDbContext context)
        {
            _context = context;
        }

        // GET: DetalleProductos
        public async Task<IActionResult> Index()
        {
            var modelosDbContext = _context.DetalleProductos.Include(d => d.Paquetes).Include(d => d.Productos).Include(d => d.UnidadMedida);
            return View(await modelosDbContext.ToListAsync());
        }

        // GET: DetalleProductos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DetalleProductos == null)
            {
                return NotFound();
            }

            var detalleProducto = await _context.DetalleProductos
                .Include(d => d.Paquetes)
                .Include(d => d.Productos)
                .Include(d => d.UnidadMedida)
                .FirstOrDefaultAsync(m => m.PaquetesId == id);
            if (detalleProducto == null)
            {
                return NotFound();
            }

            return View(detalleProducto);
        }

        // GET: DetalleProductos/Create
        public IActionResult Create()
        {
            ViewData["PaquetesId"] = new SelectList(_context.Paquetes, "Id", "Id");
            ViewData["ProductosId"] = new SelectList(_context.Productos, "Id", "Id");
            ViewData["UnidadMedidaId"] = new SelectList(_context.UnidadMedidas, "Id", "Id");
            return View();
        }

        // POST: DetalleProductos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaquetesId,ProductosId,UnidadMedidaId")] DetalleProducto detalleProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaquetesId"] = new SelectList(_context.Paquetes, "Id", "Id", detalleProducto.PaquetesId);
            ViewData["ProductosId"] = new SelectList(_context.Productos, "Id", "Id", detalleProducto.ProductosId);
            ViewData["UnidadMedidaId"] = new SelectList(_context.UnidadMedidas, "Id", "Id", detalleProducto.UnidadMedidaId);
            return View(detalleProducto);
        }

        // GET: DetalleProductos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DetalleProductos == null)
            {
                return NotFound();
            }

            var detalleProducto = await _context.DetalleProductos.FindAsync(id);
            if (detalleProducto == null)
            {
                return NotFound();
            }
            ViewData["PaquetesId"] = new SelectList(_context.Paquetes, "Id", "Id", detalleProducto.PaquetesId);
            ViewData["ProductosId"] = new SelectList(_context.Productos, "Id", "Id", detalleProducto.ProductosId);
            ViewData["UnidadMedidaId"] = new SelectList(_context.UnidadMedidas, "Id", "Id", detalleProducto.UnidadMedidaId);
            return View(detalleProducto);
        }

        // POST: DetalleProductos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaquetesId,ProductosId,UnidadMedidaId")] DetalleProducto detalleProducto)
        {
            if (id != detalleProducto.PaquetesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleProductoExists(detalleProducto.PaquetesId))
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
            ViewData["PaquetesId"] = new SelectList(_context.Paquetes, "Id", "Id", detalleProducto.PaquetesId);
            ViewData["ProductosId"] = new SelectList(_context.Productos, "Id", "Id", detalleProducto.ProductosId);
            ViewData["UnidadMedidaId"] = new SelectList(_context.UnidadMedidas, "Id", "Id", detalleProducto.UnidadMedidaId);
            return View(detalleProducto);
        }

        // GET: DetalleProductos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DetalleProductos == null)
            {
                return NotFound();
            }

            var detalleProducto = await _context.DetalleProductos
                .Include(d => d.Paquetes)
                .Include(d => d.Productos)
                .Include(d => d.UnidadMedida)
                .FirstOrDefaultAsync(m => m.PaquetesId == id);
            if (detalleProducto == null)
            {
                return NotFound();
            }

            return View(detalleProducto);
        }

        // POST: DetalleProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DetalleProductos == null)
            {
                return Problem("Entity set 'ModelosDbContext.DetalleProductos'  is null.");
            }
            var detalleProducto = await _context.DetalleProductos.FindAsync(id);
            if (detalleProducto != null)
            {
                _context.DetalleProductos.Remove(detalleProducto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleProductoExists(int id)
        {
          return (_context.DetalleProductos?.Any(e => e.PaquetesId == id)).GetValueOrDefault();
        }
    }
}
