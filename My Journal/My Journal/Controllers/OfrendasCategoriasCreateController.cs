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
        try
        {
            var model = new OfrendasCategoria
            {
                ofrendaCategoria = new OfrendasCategoria()
            };

            return View(model);
        }
        catch (Exception ex)
        {
            // Manejar la excepción según sea necesario
            return View(new OfrendasCategoria());
        }
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(List<string> Nombre, List<string> Descripcion)
    {
        try
        {
            // Validar que todas las listas tengan la misma longitud
            if (Nombre.Count == Descripcion.Count)
            {
                // Crear una lista para almacenar las Ofrendas Categorias
                var OfrendaCat = new List<OfrendasCategoria>();

                // Iterar sobre las listas y crear objetos Ofrendas Categorias
                for (int i = 0; i < Nombre.Count; i++)
                {
                    var ofrendacat = new OfrendasCategoria
                    {
                        Nombre = Nombre[i],
                        Descripcion = Descripcion[i],
                    };
                    OfrendaCat.Add(ofrendacat);
                }

                // Insertar las Ofrendas Cat en la base de datos
                MantOfrendaCategoria mantOfreCat = new MantOfrendaCategoria();
                foreach (var ofrendacat in OfrendaCat)
                {
                    mantOfreCat.Insertar(ofrendacat);
                }

                // Redirigir a la acción Index después de la inserción
                return RedirectToAction("Index");
            }
            else
            {
                throw new InvalidOperationException("Las listas proporcionadas tienen diferentes longitudes.");
            }
        }
        catch (Exception ex)
        {
            // Manejar la excepción según sea necesario
            // Devolver la vista con los datos ingresados y el mensaje de error
            ModelState.AddModelError("", "Ocurrió un error al guardar los datos: " + ex.Message);
            return View();
        }
    }
}
