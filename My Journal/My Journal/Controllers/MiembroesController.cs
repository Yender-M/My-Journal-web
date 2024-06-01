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
    public class MiembroesController : Controller
    {
        private readonly CbnIglesiaContext _context;

        public MiembroesController(CbnIglesiaContext context)
        {
            _context = context;
        }

        // GET: Miembroes
        public async Task<IActionResult> Index()
        {
            var cbnIglesiaContext = _context.Miembros.Include(m => m.UsuarioCreacionNavigation);
            return View(await cbnIglesiaContext.ToListAsync());
        }

        // GET: Miembroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miembro = await _context.Miembros
                .Include(m => m.UsuarioCreacionNavigation)
                .FirstOrDefaultAsync(m => m.IdMiembro == id);
            if (miembro == null)
            {
                return NotFound();
            }

            return View(miembro);
        }

        // GET: Miembroes/Create
        public IActionResult Create()
        {
            ViewData["UsuarioCreacion"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            return View();
        }

        // POST: Miembroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMiembro,Nombre,Apellido,Direccion,Telefono,FechaNacimiento,FechaBautismo,Estado,UsuarioCreacion,FechaCreacion,UsuarioModifica,FechaModifica")] Miembro miembro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(miembro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioCreacion"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", miembro.UsuarioCreacion);
            return View(miembro);
        }

        // GET: Miembroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miembro = await _context.Miembros.FindAsync(id);
            if (miembro == null)
            {
                return NotFound();
            }
            ViewData["UsuarioCreacion"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", miembro.UsuarioCreacion);
            return View(miembro);
        }

        // POST: Miembroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMiembro,Nombre,Apellido,Direccion,Telefono,FechaNacimiento,FechaBautismo,Estado,UsuarioCreacion,FechaCreacion,UsuarioModifica,FechaModifica")] Miembro miembro)
        {
            if (id != miembro.IdMiembro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(miembro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MiembroExists(miembro.IdMiembro))
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
            ViewData["UsuarioCreacion"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", miembro.UsuarioCreacion);
            return View(miembro);
        }

        // GET: Miembroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miembro = await _context.Miembros
                .Include(m => m.UsuarioCreacionNavigation)
                .FirstOrDefaultAsync(m => m.IdMiembro == id);
            if (miembro == null)
            {
                return NotFound();
            }

            return View(miembro);
        }

        // POST: Miembroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var miembro = await _context.Miembros.FindAsync(id);
            if (miembro != null)
            {
                _context.Miembros.Remove(miembro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MiembroExists(int id)
        {
            return _context.Miembros.Any(e => e.IdMiembro == id);
        }
    }
}
