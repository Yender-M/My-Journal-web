using Microsoft.AspNetCore.Mvc;
using My_Journal.Models.EgresosCategoria;

namespace My_Journal.Controllers
{
    public class EgresosCategoriasCreateController : Controller
    {
        // GET: OfrendasCat/Create
        public IActionResult Index()
        {
            try
            {
                var model = new EgresoCategoria
                {
                    egresoCategoria = new EgresoCategoria()
                };

                return View(model);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                return View(new EgresoCategoria());
            }
        }

        [HttpPost]
        public ActionResult Create(List<string> Nombre, List<string> Descripcion)
        {
            try
            {
                // Validar que todas las listas tengan la misma longitud
                if (Nombre.Count == Descripcion.Count)
                {
                    // Crear una lista para almacenar las Ofrendas Categorias
                    var EgresoCat = new List<EgresoCategoria>();

                    // Iterar sobre las listas y crear objetos Ofrendas Categorias
                    for (int i = 0; i < Nombre.Count; i++)
                    {
                        var egresocat = new EgresoCategoria
                        {
                            Nombre = Nombre[i],
                            Descripcion = Descripcion[i],
                        };
                        EgresoCat.Add(egresocat);
                    }

                    // Insertar las Ofrendas Cat en la base de datos
                    MantEgresoCategotia mantegreCat = new MantEgresoCategotia();
                    foreach (var egresocat in EgresoCat)
                    {
                        mantegreCat.Insertar(egresocat);
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
}
