using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using My_Journal;

namespace My_Journal.Controllers
{
    public class DiezmosController : Controller
    {
        private readonly CbnIglesiaContext _context;

        public DiezmosController(CbnIglesiaContext context)
        {
            _context = context;
        }

        // GET: Diezmoes
        public async Task<IActionResult> Index()
        {
            var cbnIglesiaContext = _context.Diezmos.Include(d => d.UsuarioCreacionNavigation);
            return View(await cbnIglesiaContext.ToListAsync());
        }

        // GET: Diezmoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diezmo = await _context.Diezmos
                .Include(d => d.UsuarioCreacionNavigation)
                .FirstOrDefaultAsync(m => m.IdDiezmo == id);
            if (diezmo == null)
            {
                return NotFound();
            }

            return View(diezmo);
        }

        // GET: Diezmoes/Create
        public IActionResult Create()
        {
            ViewData["UsuarioCreacion"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            return View();
        }

        // POST: Diezmoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDiezmo,Cantidad,FechaDiezmo,Descripcion,Estado,UsuarioCreacion,FechaCreacion,UsuarioModifica,FechaModifica")] Diezmo diezmo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diezmo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioCreacion"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", diezmo.UsuarioCreacion);
            return View(diezmo);
        }

        // GET: Diezmoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diezmo = await _context.Diezmos.FindAsync(id);
            if (diezmo == null)
            {
                return NotFound();
            }
            ViewData["UsuarioCreacion"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", diezmo.UsuarioCreacion);
            return View(diezmo);
        }

        // POST: Diezmoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDiezmo,Cantidad,FechaDiezmo,Descripcion,Estado,UsuarioCreacion,FechaCreacion,UsuarioModifica,FechaModifica")] Diezmo diezmo)
        {
            if (id != diezmo.IdDiezmo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diezmo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiezmoExists(diezmo.IdDiezmo))
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
            ViewData["UsuarioCreacion"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", diezmo.UsuarioCreacion);
            return View(diezmo);
        }

        // GET: Diezmoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diezmo = await _context.Diezmos
                .Include(d => d.UsuarioCreacionNavigation)
                .FirstOrDefaultAsync(m => m.IdDiezmo == id);
            if (diezmo == null)
            {
                return NotFound();
            }

            return View(diezmo);
        }

        // POST: Diezmoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diezmo = await _context.Diezmos.FindAsync(id);
            if (diezmo != null)
            {
                _context.Diezmos.Remove(diezmo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiezmoExists(int id)
        {
            return _context.Diezmos.Any(e => e.IdDiezmo == id);
        }
    }
}
