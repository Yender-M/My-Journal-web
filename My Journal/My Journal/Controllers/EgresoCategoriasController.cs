using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_Journal.Models.EgresosCategoria;
using My_Journal.Models.IngresosCategoria;

namespace My_Journal.Controllers
{
    public class EgresoCategoriasController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                MantEgresoCategotia mantEgresodaCat = new MantEgresoCategotia();
                var egresocat = mantEgresodaCat.Getlistado();

                return View(egresocat);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                ViewBag.ErrorMessage = $"Error al cargar el listado de egresos categorias: {ex.Message}";
                return View(new List<EgresoCategoria>());
            }
        }

        // GET: OfrendasCat/Create
        public IActionResult Create()
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

        // GET: Ofrenda Cat/Edit que lo abre
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = new MantEgresoCategotia().GetEgresoCategoria(id.Value);


            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // POST: Ofrenda Cat/Edit que lo guarda
        public ActionResult Editar(EgresoCategoria EgresoCat)
        {
            try
            {
                MantEgresoCategotia mant = new MantEgresoCategotia();
                var egresoCat = mant.Editar(EgresoCat);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                return View(EgresoCat);
            }
        }

    }
}
