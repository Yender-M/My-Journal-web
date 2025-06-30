using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_Journal.Models.Usuario;
using System.Linq;
using System.Threading.Tasks;

namespace My_Journal.Controllers
{
    public class UsuariosEditController : Controller
    {
        private readonly CbnIglesiaContext _context;

        public UsuariosEditController(CbnIglesiaContext context)
        {
            _context = context;
        }

        // GET: /UsuariosEdit-1002
        [HttpGet("/UsuariosEdit-{id:int}")]
        public async Task<IActionResult> Index(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: /UsuariosEdit-1002
        [HttpPost("/UsuariosEdit-{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int id, Usuario usuario)
        {
            if (id != usuario.IdUsuario)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(usuario);

            try
            {
                _context.Update(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Usuarios");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Usuarios.Any(e => e.IdUsuario == usuario.IdUsuario))
                    return NotFound();
                else
                    throw;
            }
        }
    }
}
