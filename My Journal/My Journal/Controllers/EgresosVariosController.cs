using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using My_Journal.Models;

namespace My_Journal.Controllers
{
    public class EgresosVariosController : Controller
    {
        private readonly CbnIglesiaContext _context;

        public EgresosVariosController(CbnIglesiaContext context)
        {
            _context = context;
        }

        // GET: EgresosVarios
        public async Task<IActionResult> Index()
        {
            var cbnIglesiaContext = _context.EgresosVarios.Include(e => e.IdProyectoNavigation).Include(e => e.UsuarioCreacionNavigation);
            return View(await cbnIglesiaContext.ToListAsync());
        }

        // GET: EgresosVarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var egresosVario = await _context.EgresosVarios
                .Include(e => e.IdProyectoNavigation)
                .Include(e => e.UsuarioCreacionNavigation)
                .FirstOrDefaultAsync(m => m.IdEgreVarios == id);
            if (egresosVario == null)
            {
                return NotFound();
            }

            return View(egresosVario);
        }

        // GET: EgresosVarios/Create
        public IActionResult Create()
        {
            ViewData["IdProyecto"] = new SelectList(_context.Proyectos, "IdProyecto", "IdProyecto");
            ViewData["UsuarioCreacion"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            return View();
        }

        // POST: EgresosVarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEgreVarios,Cantidad,Descripcion,Fecha,IdProyecto,UsuarioCreacion,FechaCreacion,UsuarioModifica,FechaModifica")] EgresosVario egresosVario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(egresosVario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProyecto"] = new SelectList(_context.Proyectos, "IdProyecto", "IdProyecto", egresosVario.IdProyecto);
            ViewData["UsuarioCreacion"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", egresosVario.UsuarioCreacion);
            return View(egresosVario);
        }

        // GET: EgresosVarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var egresosVario = await _context.EgresosVarios.FindAsync(id);
            if (egresosVario == null)
            {
                return NotFound();
            }
            ViewData["IdProyecto"] = new SelectList(_context.Proyectos, "IdProyecto", "IdProyecto", egresosVario.IdProyecto);
            ViewData["UsuarioCreacion"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", egresosVario.UsuarioCreacion);
            return View(egresosVario);
        }

        // POST: EgresosVarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEgreVarios,Cantidad,Descripcion,Fecha,IdProyecto,UsuarioCreacion,FechaCreacion,UsuarioModifica,FechaModifica")] EgresosVario egresosVario)
        {
            if (id != egresosVario.IdEgreVarios)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(egresosVario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EgresosVarioExists(egresosVario.IdEgreVarios))
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
            ViewData["IdProyecto"] = new SelectList(_context.Proyectos, "IdProyecto", "IdProyecto", egresosVario.IdProyecto);
            ViewData["UsuarioCreacion"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", egresosVario.UsuarioCreacion);
            return View(egresosVario);
        }

        // GET: EgresosVarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var egresosVario = await _context.EgresosVarios
                .Include(e => e.IdProyectoNavigation)
                .Include(e => e.UsuarioCreacionNavigation)
                .FirstOrDefaultAsync(m => m.IdEgreVarios == id);
            if (egresosVario == null)
            {
                return NotFound();
            }

            return View(egresosVario);
        }

        // POST: EgresosVarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var egresosVario = await _context.EgresosVarios.FindAsync(id);
            if (egresosVario != null)
            {
                _context.EgresosVarios.Remove(egresosVario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EgresosVarioExists(int id)
        {
            return _context.EgresosVarios.Any(e => e.IdEgreVarios == id);
        }
    }
}
