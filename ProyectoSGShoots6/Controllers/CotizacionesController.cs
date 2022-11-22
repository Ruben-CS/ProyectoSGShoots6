using System;
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
    public class CotizacionesController : Controller
    {
        private readonly ModelosDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CotizacionesController(ModelosDBContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Cotizaciones
        public async Task<IActionResult> Index()
        {
            var modelosDBContext = _context.Cotizaciones.Include(c => c.PaqueteFkNavigation);
            return View(await modelosDBContext.ToListAsync());
        }

        // GET: Cotizaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cotizaciones == null)
            {
                return NotFound();
            }

            var cotizacione = await _context.Cotizaciones
                .Include(c => c.PaqueteFkNavigation)
                .FirstOrDefaultAsync(m => m.Idcotizacion == id);
            if (cotizacione == null)
            {
                return NotFound();
            }

            return View(cotizacione);
        }

        // GET: Cotizaciones/Create
        public IActionResult Create()
        {
            ViewData["PaqueteFk"] = new SelectList(_context.Paquetes, "Id", "Id");
            return View();
        }

        // POST: Cotizaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idcotizacion,FechaInicio,FechaFin,PrecioFinal,Ubicacion,Estado,PaqueteFk,NombreCotizacion")] Cotizacione cotizaciones)
        {
            if (ModelState.IsValid)
            {
                // var wwRootPath = _hostEnvironment.WebRootPath;
                //
                // string? fileName = Path.GetFileNameWithoutExtension(cotizaciones.ImageFile.FileName);
                //
                // var extension = Path.GetExtension(cotizaciones.ImageFile.FileName);
                //
                // cotizaciones.NombreCotizacion = fileName + DateTime.Now.ToString("yymssff") + extension;
                //
                // var path = Path.Combine(wwRootPath + "/img/" + fileName);
                // await using (var fileStream = new FileStream(path, FileMode.Create))
                // {
                //     await cotizaciones.ImageFile.CopyToAsync(fileStream);
                // }

                _context.Add(cotizaciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(cotizaciones);
        }

        // GET: Cotizaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cotizaciones == null)
            {
                return NotFound();
            }

            var cotizacione = await _context.Cotizaciones.FindAsync(id);
            if (cotizacione == null)
            {
                return NotFound();
            }
            ViewData["PaqueteFk"] = new SelectList(_context.Paquetes, "Id", "Id", cotizacione.PaqueteFk);
            return View(cotizacione);
        }

        // POST: Cotizaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idcotizacion,FechaInicio,FechaFin,PrecioFinal,Ubicacion,Estado,PaqueteFk,NombreCotizacion")] Cotizacione cotizacione)
        {
            if (id != cotizacione.Idcotizacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cotizacione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CotizacioneExists(cotizacione.Idcotizacion))
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
            ViewData["PaqueteFk"] = new SelectList(_context.Paquetes, "Id", "Id", cotizacione.PaqueteFk);
            return View(cotizacione);
        }

        // GET: Cotizaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cotizaciones == null)
            {
                return NotFound();
            }

            var cotizacione = await _context.Cotizaciones
                .Include(c => c.PaqueteFkNavigation)
                .FirstOrDefaultAsync(m => m.Idcotizacion == id);
            if (cotizacione == null)
            {
                return NotFound();
            }

            return View(cotizacione);
        }

        // POST: Cotizaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cotizaciones == null)
            {
                return Problem("Entity set 'ModelosDBContext.Cotizaciones'  is null.");
            }
            var cotizacione = await _context.Cotizaciones.FindAsync(id);
            if (cotizacione != null)
            {
                _context.Cotizaciones.Remove(cotizacione);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CotizacioneExists(int id)
        {
          return (_context.Cotizaciones?.Any(e => e.Idcotizacion == id)).GetValueOrDefault();
        }
    }
}
