using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using My_Journal.Models.Usuario;

namespace My_Journal.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly CbnIglesiaContext _context;

        public UsuariosController(CbnIglesiaContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,Nombres,Apellidos,Telefono,Direccion,Usuario1,Clave,Estado,UsuarioCreacion,FechaCreacion,UsuarioModifica,FechaModifica")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }
      [HttpPost]
public async Task<IActionResult> Edit([FromBody] Usuario usuario) // Ahora recibimos JSON
{
    if (!ModelState.IsValid)
    {
        return BadRequest(new { success = false, message = "Modelo no válido" });
    }

    try
    {
        _context.Update(usuario);
        await _context.SaveChangesAsync();
        return Json(new { success = true, message = "Usuario actualizado correctamente" }); // ✅ Respuesta para AJAX
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!UsuarioExists(usuario.IdUsuario))
        {
            return NotFound(new { success = false, message = "Usuario no encontrado" }); // ❌
        }
        else
        {
            return StatusCode(500, new { success = false, message = "Error de concurrencia" }); // ⚡️
        }
    }
}

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.IdUsuario == id);
        }
    }
}
