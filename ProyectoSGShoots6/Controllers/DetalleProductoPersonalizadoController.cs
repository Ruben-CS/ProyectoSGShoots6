using System;
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
    public class DetalleProductoPersonalizadoController : Controller
    {
        private readonly ModelosDbContext _context;

        public DetalleProductoPersonalizadoController(ModelosDbContext context)
        {
            _context = context;
        }

        // GET: DetalleProductoPersonalizado
        public async Task<IActionResult> Index()
        {
            var modelosDbContext = _context.DetalleProductoPersonalizados.Include(d => d.Cotizaciones).Include(d => d.Productos).Include(d => d.UnidadMedida);
            return View(await modelosDbContext.ToListAsync());
        }

        // GET: DetalleProductoPersonalizado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DetalleProductoPersonalizados == null)
            {
                return NotFound();
            }

            var detalleProductoPersonalizado = await _context.DetalleProductoPersonalizados
                .Include(d => d.Cotizaciones)
                .Include(d => d.Productos)
                .Include(d => d.UnidadMedida)
                .FirstOrDefaultAsync(m => m.CotizacionesId == id);
            if (detalleProductoPersonalizado == null)
            {
                return NotFound();
            }

            return View(detalleProductoPersonalizado);
        }

        // GET: DetalleProductoPersonalizado/Create
        public IActionResult Create()
        {
            ViewData["CotizacionesId"] = new SelectList(_context.Cotizaciones, "Idcotizacion", "Idcotizacion");
            ViewData["ProductosId"] = new SelectList(_context.Productos, "Id", "Id");
            ViewData["UnidadMedidaId"] = new SelectList(_context.UnidadMedidas, "Id", "Id");
            return View();
        }

        // POST: DetalleProductoPersonalizado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CotizacionesId,ProductosId,UnidadMedidaId")] DetalleProductoPersonalizado detalleProductoPersonalizado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleProductoPersonalizado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CotizacionesId"] = new SelectList(_context.Cotizaciones, "Idcotizacion", "Idcotizacion", detalleProductoPersonalizado.CotizacionesId);
            ViewData["ProductosId"] = new SelectList(_context.Productos, "Id", "Id", detalleProductoPersonalizado.ProductosId);
            ViewData["UnidadMedidaId"] = new SelectList(_context.UnidadMedidas, "Id", "Id", detalleProductoPersonalizado.UnidadMedidaId);
            return View(detalleProductoPersonalizado);
        }

        // GET: DetalleProductoPersonalizado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DetalleProductoPersonalizados == null)
            {
                return NotFound();
            }

            var detalleProductoPersonalizado = await _context.DetalleProductoPersonalizados.FindAsync(id);
            if (detalleProductoPersonalizado == null)
            {
                return NotFound();
            }
            ViewData["CotizacionesId"] = new SelectList(_context.Cotizaciones, "Idcotizacion", "Idcotizacion", detalleProductoPersonalizado.CotizacionesId);
            ViewData["ProductosId"] = new SelectList(_context.Productos, "Id", "Id", detalleProductoPersonalizado.ProductosId);
            ViewData["UnidadMedidaId"] = new SelectList(_context.UnidadMedidas, "Id", "Id", detalleProductoPersonalizado.UnidadMedidaId);
            return View(detalleProductoPersonalizado);
        }

        // POST: DetalleProductoPersonalizado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CotizacionesId,ProductosId,UnidadMedidaId")] DetalleProductoPersonalizado detalleProductoPersonalizado)
        {
            if (id != detalleProductoPersonalizado.CotizacionesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleProductoPersonalizado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleProductoPersonalizadoExists(detalleProductoPersonalizado.CotizacionesId))
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
            ViewData["CotizacionesId"] = new SelectList(_context.Cotizaciones, "Idcotizacion", "Idcotizacion", detalleProductoPersonalizado.CotizacionesId);
            ViewData["ProductosId"] = new SelectList(_context.Productos, "Id", "Id", detalleProductoPersonalizado.ProductosId);
            ViewData["UnidadMedidaId"] = new SelectList(_context.UnidadMedidas, "Id", "Id", detalleProductoPersonalizado.UnidadMedidaId);
            return View(detalleProductoPersonalizado);
        }

        // GET: DetalleProductoPersonalizado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DetalleProductoPersonalizados == null)
            {
                return NotFound();
            }

            var detalleProductoPersonalizado = await _context.DetalleProductoPersonalizados
                .Include(d => d.Cotizaciones)
                .Include(d => d.Productos)
                .Include(d => d.UnidadMedida)
                .FirstOrDefaultAsync(m => m.CotizacionesId == id);
            if (detalleProductoPersonalizado == null)
            {
                return NotFound();
            }

            return View(detalleProductoPersonalizado);
        }

        // POST: DetalleProductoPersonalizado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DetalleProductoPersonalizados == null)
            {
                return Problem("Entity set 'ModelosDbContext.DetalleProductoPersonalizados'  is null.");
            }
            var detalleProductoPersonalizado = await _context.DetalleProductoPersonalizados.FindAsync(id);
            if (detalleProductoPersonalizado != null)
            {
                _context.DetalleProductoPersonalizados.Remove(detalleProductoPersonalizado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleProductoPersonalizadoExists(int id)
        {
          return (_context.DetalleProductoPersonalizados?.Any(e => e.CotizacionesId == id)).GetValueOrDefault();
        }
    }
}
