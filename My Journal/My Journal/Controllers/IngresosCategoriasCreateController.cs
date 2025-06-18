using Microsoft.AspNetCore.Mvc;
using My_Journal.Models.IngresosCategoria;

namespace My_Journal.Controllers
{
    public class IngresosCategoriasCreateController : Controller
    {
        // GET: IngresoCategoriasCreate/Create
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var model = new IngresoCategoria
                {
                    ingresoCategoria = new IngresoCategoria()
                };

                return View(model);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                return View(new IngresoCategoria());
            }
        }
        [HttpPost]
        public ActionResult Create(List<string> Nombre, List<string> Descripcion)
        {
            try
            {
                if (Nombre.Count == Descripcion.Count)
                {
                    var ingresoCategorias = new List<IngresoCategoria>();

                    for (int i = 0; i < Nombre.Count; i++)
                    {
                        ingresoCategorias.Add(new IngresoCategoria
                        {
                            Nombre = Nombre[i],
                            Descripcion = Descripcion[i],
                        });
                    }

                    MantIngresoCategoria mantIngreCat = new MantIngresoCategoria();
                    foreach (var ingresoCat in ingresoCategorias)
                    {
                        mantIngreCat.Insertar(ingresoCat);
                    }

                    return RedirectToAction("Index", "IngresosCategorias");
                }
                else
                {
                    throw new InvalidOperationException("Las listas proporcionadas tienen diferentes longitudes.");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al guardar los datos: " + ex.Message);
                return View();
            }
        }
    }
}
