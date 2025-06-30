using Microsoft.AspNetCore.Mvc;
using My_Journal.Models.Usuario;
using My_Journal;
[Route("UsuariosCreate")]
public class UsuariosCreateController : Controller
{
    private readonly CbnIglesiaContext _context;

    public UsuariosCreateController(CbnIglesiaContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View("Index"); // o simplemente View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(Usuario usuario)
    {
        if (ModelState.IsValid)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Usuarios");
        }
        return View(usuario);
    }
}
