using Microsoft.AspNetCore.Mvc;
using My_Journal.Models.IngresosCategoria;

namespace My_Journal.Controllers
{
    public class IngresosCategoriasController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                MantIngresoCategoria mantIngresodaCat = new MantIngresoCategoria();
                var ingresocat = mantIngresodaCat.Getlistado();

                return View(ingresocat);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                ViewBag.ErrorMessage = $"Error al cargar el listado de ingresos categorias: {ex.Message}";
                return View(new List<IngresoCategoria>());
            }
        }

        // GET: OfrendasCat/Create
        public IActionResult Create()
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
                // Validar que todas las listas tengan la misma longitud
                if (Nombre.Count == Descripcion.Count)
                {
                    // Crear una lista para almacenar las Ofrendas Categorias
                    var IngresoCat = new List<IngresoCategoria>();

                    // Iterar sobre las listas y crear objetos Ofrendas Categorias
                    for (int i = 0; i < Nombre.Count; i++)
                    {
                        var ingresocat = new IngresoCategoria
                        {
                            Nombre = Nombre[i],
                            Descripcion = Descripcion[i],
                        };
                        IngresoCat.Add(ingresocat);
                    }

                    // Insertar las Ofrendas Cat en la base de datos
                    MantIngresoCategoria mantIngreCat = new MantIngresoCategoria();
                    foreach (var ingresocat in IngresoCat)
                    {
                        mantIngreCat.Insertar(ingresocat);
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

            var viewModel = new MantIngresoCategoria().GetOIngresoCategoria(id.Value);


            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // POST: Ofrenda Cat/Edit que lo guarda
        public ActionResult Editar(IngresoCategoria IngresoCat)
        {
            try
            {
                MantIngresoCategoria mant = new MantIngresoCategoria();
                var ingresoCat = mant.Editar(IngresoCat);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                return View(IngresoCat);
            }
        }
    }
}
