using Microsoft.AspNetCore.Mvc;
using My_Journal.Models.OfrendaCategoria;
using My_Journal;

[Route("OfrendasCategoriasCreate")]
public class OfrendasCategoriasCreateController : Controller
{
    private readonly CbnIglesiaContext _context;

    public OfrendasCategoriasCreateController(CbnIglesiaContext context)
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
    public async Task<IActionResult> Index(List<string> Nombre, List<string> Descripcion)
    {
        if (Nombre.Count != Descripcion.Count)
        {
            ModelState.AddModelError("", "Los nombres y descripciones no coinciden.");
            return View(new OfrendasCategoria());
        }

        try
        {
            for (int i = 0; i < Nombre.Count; i++)
            {
                var categoria = new OfrendasCategoria
                {
                    Nombre = Nombre[i],
                    Descripcion = Descripcion[i],
                };
                _context.OfrendasCategorias.Add(categoria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "OfrendasCategorias");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Error al guardar: {ex.Message}");
            return View(new OfrendasCategoria());
        }
    }
}
