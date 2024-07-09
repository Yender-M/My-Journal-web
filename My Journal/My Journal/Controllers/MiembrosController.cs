using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Journal.Models.Divisa;
using My_Journal.Models.Miembros;
using My_Journal.Models.Ofrenda;
using My_Journal.Models.OfrendaCategoria;

namespace My_Journal.Controllers
{
    public class MiembrosController : Controller
    {
        public IActionResult Index(DateTime? startDate, DateTime? endDate)
        {
            try
            {
                // Leer las fechas desde los parámetros o desde las variables de sesión
                if (startDate.HasValue && endDate.HasValue)
                {
                    // Guardar las fechas en la sesión si se proporcionan
                    HttpContext.Session.SetString("startDate", startDate.Value.ToString("yyyy-MM-dd"));
                    HttpContext.Session.SetString("endDate", endDate.Value.ToString("yyyy-MM-dd"));
                }
                else
                {
                    var startDateString = HttpContext.Session.GetString("startDate");
                    var endDateString = HttpContext.Session.GetString("endDate");

                    if (!string.IsNullOrEmpty(startDateString))
                    {
                        startDate = DateTime.Parse(startDateString);
                    }
                    if (!string.IsNullOrEmpty(endDateString))
                    {
                        endDate = DateTime.Parse(endDateString);
                    }
                }

                // Si las fechas no están definidas, establecer un rango predeterminado (ej. último mes)
                if (!startDate.HasValue)
                {
                    startDate = DateTime.Now;
                }
                if (!endDate.HasValue)
                {
                    endDate = DateTime.Now;
                }

                // Lógica para obtener el listado de ofrendas según las fechas
                var desde = startDate.Value.ToString("yyyyMMdd");
                var hasta = endDate.Value.ToString("yyyyMMdd");

                MantMiembro mantDiezmo = new MantMiembro();
                var miembros = mantDiezmo.GetListadoMiembros(desde, hasta);

                // Pasar el listado de ofrendas y las fechas a la vista
                ViewBag.StartDate = startDate.Value.ToString("yyyy-MM-dd");
                ViewBag.EndDate = endDate.Value.ToString("yyyy-MM-dd");

                return View(miembros);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                ViewBag.ErrorMessage = $"Error al cargar el listado de ofrendas: {ex.Message}";
                return View(new List<Miembro>());
            }
        }

        [HttpPost]
        public IActionResult SetSessionDates(string startDate, string endDate)
        {
            try
            {
                // Guardar las fechas en formato string en las variables de sesión
                HttpContext.Session.SetString("startDate", startDate);
                HttpContext.Session.SetString("endDate", endDate);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // GET: Miembros/Create
        public IActionResult Create()
        {
            try
            {
                var model = new Miembro
                {
                    Miembros = new Miembro()
                };

                return View(model);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                return View(new Miembro());
            }
        }

        [HttpPost]
        public ActionResult Create(List<string> Nombre, List<string> Apellido, List<string> Direccion, List<string> Telefono, List<DateTime> FechaNacimiento, List<DateTime> FechaBautismo)
        {
            try
            {
                // Validar que todas las listas tengan la misma longitud
                if (Nombre.Count == Apellido.Count &&
                    Apellido.Count == Direccion.Count &&
                    Direccion.Count == Telefono.Count &&
                    Telefono.Count == FechaNacimiento.Count &&
                    FechaNacimiento.Count == FechaBautismo.Count)
                {
                    // Crear una lista para almacenar las Miembros
                    var miembros = new List<Miembro>();

                    // Iterar sobre las listas y crear objetos Miembros
                    for (int i = 0; i < Nombre.Count; i++)
                    {
                        var miembro = new Miembro
                        {
                            Nombre = Nombre[i],
                            Apellido = Apellido[i],
                            Direccion = Direccion[i],
                            Telefono = Telefono[i],
                            FechaNacimiento = FechaNacimiento[i],
                            FechaBautismo = FechaBautismo[i]
                        };
                        miembros.Add(miembro);
                    }

                    // Insertar los Miembros en la base de datos
                    MantMiembro mantMiembro = new MantMiembro();
                    foreach (var miembro in miembros)
                    {
                        mantMiembro.Insertar(miembro);
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

        // GET: Miembro/Edit que lo abre
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = new MantMiembro().GetMiembro(id.Value);

            
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // POST: Miembro/Edit que lo guarda
        public ActionResult Editar(Miembro miembro)
        {
            try
            {
                MantMiembro mant = new MantMiembro();
                var miembros = mant.Editar(miembro);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                return View(miembro);
            }
        }
    }
}
