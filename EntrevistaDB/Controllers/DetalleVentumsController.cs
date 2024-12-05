using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntrevistaDB.Models;

namespace EntrevistaDB.Controllers
{
    public class DetalleVentumsController : Controller
    {
        private readonly EntrevistaDbContext _context;

        public DetalleVentumsController(EntrevistaDbContext context)
        {
            _context = context;
        }

        // GET: DetalleVentums
        public async Task<IActionResult> Index()
        {
            var entrevistaDbContext = _context.DetalleVenta.Include(d => d.Pro).Include(d => d.Venta);
            return View(await entrevistaDbContext.ToListAsync());
        }

        // GET: DetalleVentums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleVentum = await _context.DetalleVenta
                .Include(d => d.Pro)
                .Include(d => d.Venta)
                .FirstOrDefaultAsync(m => m.DvId == id);
            if (detalleVentum == null)
            {
                return NotFound();
            }

            return View(detalleVentum);
        }

        // GET: DetalleVentums/Create
        public IActionResult Create()
        {
            ViewData["ProId"] = new SelectList(_context.Productos, "ProId", "ProId");
            ViewData["VentaId"] = new SelectList(_context.Ventas, "VentaId", "VentaId");
            return View();
        }

        // POST: DetalleVentums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DvId,VentaId,ProId,DvCantidad,DvPreciounitario,DvSubtotal")] DetalleVentum detalleVentum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleVentum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProId"] = new SelectList(_context.Productos, "ProId", "ProId", detalleVentum.ProId);
            ViewData["VentaId"] = new SelectList(_context.Ventas, "VentaId", "VentaId", detalleVentum.VentaId);
            return View(detalleVentum);
        }

        // GET: DetalleVentums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleVentum = await _context.DetalleVenta.FindAsync(id);
            if (detalleVentum == null)
            {
                return NotFound();
            }
            ViewData["ProId"] = new SelectList(_context.Productos, "ProId", "ProId", detalleVentum.ProId);
            ViewData["VentaId"] = new SelectList(_context.Ventas, "VentaId", "VentaId", detalleVentum.VentaId);
            return View(detalleVentum);
        }

        // POST: DetalleVentums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DvId,VentaId,ProId,DvCantidad,DvPreciounitario,DvSubtotal")] DetalleVentum detalleVentum)
        {
            if (id != detalleVentum.DvId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleVentum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleVentumExists(detalleVentum.DvId))
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
            ViewData["ProId"] = new SelectList(_context.Productos, "ProId", "ProId", detalleVentum.ProId);
            ViewData["VentaId"] = new SelectList(_context.Ventas, "VentaId", "VentaId", detalleVentum.VentaId);
            return View(detalleVentum);
        }

        // GET: DetalleVentums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleVentum = await _context.DetalleVenta
                .Include(d => d.Pro)
                .Include(d => d.Venta)
                .FirstOrDefaultAsync(m => m.DvId == id);
            if (detalleVentum == null)
            {
                return NotFound();
            }

            return View(detalleVentum);
        }

        // POST: DetalleVentums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleVentum = await _context.DetalleVenta.FindAsync(id);
            if (detalleVentum != null)
            {
                _context.DetalleVenta.Remove(detalleVentum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleVentumExists(int id)
        {
            return _context.DetalleVenta.Any(e => e.DvId == id);
        }
    }
}
