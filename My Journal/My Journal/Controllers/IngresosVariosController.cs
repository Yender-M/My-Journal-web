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
    public class IngresosVariosController : Controller
    {
        private readonly CbnIglesiaContext _context;

        public IngresosVariosController(CbnIglesiaContext context)
        {
            _context = context;
        }

        // GET: IngresosVarios
        public async Task<IActionResult> Index()
        {
            var cbnIglesiaContext = _context.IngresosVarios.Include(i => i.IdProyectoNavigation).Include(i => i.UsuarioCreacionNavigation);
            return View(await cbnIglesiaContext.ToListAsync());
        }

        // GET: IngresosVarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingresosVario = await _context.IngresosVarios
                .Include(i => i.IdProyectoNavigation)
                .Include(i => i.UsuarioCreacionNavigation)
                .FirstOrDefaultAsync(m => m.IdIngreVarios == id);
            if (ingresosVario == null)
            {
                return NotFound();
            }

            return View(ingresosVario);
        }

        // GET: IngresosVarios/Create
        public IActionResult Create()
        {
            ViewData["IdProyecto"] = new SelectList(_context.Proyectos, "IdProyecto", "IdProyecto");
            ViewData["UsuarioCreacion"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            return View();
        }

        // POST: IngresosVarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdIngreVarios,Cantidad,Descripcion,Fecha,IdProyecto,UsuarioCreacion,FechaCreacion,UsuarioModifica,FechaModifica")] IngresosVario ingresosVario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingresosVario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProyecto"] = new SelectList(_context.Proyectos, "IdProyecto", "IdProyecto", ingresosVario.IdProyecto);
            ViewData["UsuarioCreacion"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", ingresosVario.UsuarioCreacion);
            return View(ingresosVario);
        }

        // GET: IngresosVarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingresosVario = await _context.IngresosVarios.FindAsync(id);
            if (ingresosVario == null)
            {
                return NotFound();
            }
            ViewData["IdProyecto"] = new SelectList(_context.Proyectos, "IdProyecto", "IdProyecto", ingresosVario.IdProyecto);
            ViewData["UsuarioCreacion"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", ingresosVario.UsuarioCreacion);
            return View(ingresosVario);
        }

        // POST: IngresosVarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdIngreVarios,Cantidad,Descripcion,Fecha,IdProyecto,UsuarioCreacion,FechaCreacion,UsuarioModifica,FechaModifica")] IngresosVario ingresosVario)
        {
            if (id != ingresosVario.IdIngreVarios)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingresosVario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngresosVarioExists(ingresosVario.IdIngreVarios))
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
            ViewData["IdProyecto"] = new SelectList(_context.Proyectos, "IdProyecto", "IdProyecto", ingresosVario.IdProyecto);
            ViewData["UsuarioCreacion"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", ingresosVario.UsuarioCreacion);
            return View(ingresosVario);
        }

        // GET: IngresosVarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingresosVario = await _context.IngresosVarios
                .Include(i => i.IdProyectoNavigation)
                .Include(i => i.UsuarioCreacionNavigation)
                .FirstOrDefaultAsync(m => m.IdIngreVarios == id);
            if (ingresosVario == null)
            {
                return NotFound();
            }

            return View(ingresosVario);
        }

        // POST: IngresosVarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingresosVario = await _context.IngresosVarios.FindAsync(id);
            if (ingresosVario != null)
            {
                _context.IngresosVarios.Remove(ingresosVario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngresosVarioExists(int id)
        {
            return _context.IngresosVarios.Any(e => e.IdIngreVarios == id);
        }
    }
}
