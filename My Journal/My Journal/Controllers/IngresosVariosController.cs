using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Journal.Models.Divisa;
using My_Journal.Models.IngresosCategoria;
using My_Journal.Models.IngresosVarios;
using My_Journal.Models.Ministerios;

namespace My_Journal.Controllers
{
    public class IngresosVariosController : Controller
    {
        // GET: Ingresos
        public IActionResult Index(DateTime? startDate, DateTime? endDate)
        {
            try
            {
                // Leer las fechas desde los parámetros o desde las variables de sesión
                if (startDate.HasValue && endDate.HasValue)
                {
                    // Guardar las fechas en la sesión si se proporcionan
                    HttpContext.Session.SetString("startDateing", startDate.Value.ToString("yyyy-MM-dd"));
                    HttpContext.Session.SetString("endDateing", endDate.Value.ToString("yyyy-MM-dd"));
                }
                else
                {
                    var startDateString = HttpContext.Session.GetString("startDateing");
                    var endDateString = HttpContext.Session.GetString("endDateing");

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

                MantIngresosVarios mantIngreso = new MantIngresosVarios();
                var Ingresos = mantIngreso.GetListadoIngresosVarios(desde, hasta);

                // Pasar el listado de ofrendas y las fechas a la vista
                ViewBag.StartDate = startDate.Value.ToString("yyyy-MM-dd");
                ViewBag.EndDate = endDate.Value.ToString("yyyy-MM-dd");

                return View(Ingresos);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                ViewBag.ErrorMessage = $"Error al cargar el listado de Ingresos: {ex.Message}";
                return View(new List<IngresosVariosViewModel>());
            }
        }

        [HttpPost]
        public IActionResult SetSessionDates(string startDate, string endDate)
        {
            try
            {
                // Guardar las fechas en formato string en las variables de sesión
                HttpContext.Session.SetString("startDateing", startDate);
                HttpContext.Session.SetString("endDateing", endDate);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // GET: Ingreso/Create que carga los dropdown
        public IActionResult Create()
        {
            try
            {
                MantIngresoCategoria mant = new MantIngresoCategoria();
                var categorias = mant.Getlistado();
                var categoriasSelectList = new SelectList(categorias, "IdCatIngreso", "Nombre");

                MantDivisa mantDivisa = new MantDivisa();
                var divisa = mantDivisa.Getlistado();
                var divisaSelectList = new SelectList(divisa, "IdDivisa", "CodDivisa");

                MantMinisterios mantMinisterio = new MantMinisterios();
                var ministerio = mantMinisterio.Getlistado();
                var ministerioSelectList = new SelectList(ministerio, "IdMinisterio", "Nombre");

                ViewBag.ListadoIngresosCategorias = categoriasSelectList;
                ViewBag.ListadoDivisa = divisaSelectList;
                ViewBag.ListadoMinisterio = ministerioSelectList;

                var model = new IngresosVariosViewModel
                {
                    IngresosVario = new IngresosVario()
                };

                return View(model);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                return View(new IngresosVariosViewModel());
            }
        }

        [HttpPost]
        public ActionResult Create(List<int> IngresosCategorias, List<int> Ministerios, List<string> Descripcion, List<decimal> Cantidad, List<int> Divisa, List<decimal> TasaCambio, List<DateTime> FechaIngreso)
        {
            try
            {
                // Validar que todas las listas tengan la misma longitud
                if (IngresosCategorias.Count == Ministerios.Count &&
                    Ministerios.Count == Descripcion.Count &&
                    Descripcion.Count == Cantidad.Count &&
                    Cantidad.Count == Divisa.Count &&
                    Divisa.Count == TasaCambio.Count &&
                    TasaCambio.Count == FechaIngreso.Count)
                {
                    // Crear una lista para almacenar las ofrendas
                    var ingreso = new List<IngresosVario>();

                    // Iterar sobre las listas y crear objetos Ofrenda
                    for (int i = 0; i < IngresosCategorias.Count; i++)
                    {
                        var Ingresos = new IngresosVario
                        {
                            IdCatIngreso = IngresosCategorias[i],
                            IdMinisterio = Ministerios[i],
                            Descripcion = Descripcion[i],
                            Cantidad = (double)Cantidad[i],
                            Divisa = Divisa[i],
                            TasaCambio = (double)TasaCambio[i],
                            FechaIngreso = FechaIngreso[i]
                        };
                        ingreso.Add(Ingresos);
                    }

                    // Insertar las ofrendas en la base de datos
                    MantIngresosVarios mantIngresosVarios = new MantIngresosVarios();
                    foreach (var Ingresos in ingreso)
                    {
                        mantIngresosVarios.Insertar(Ingresos);
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
                // Cargar la lista de categorías para la vista en caso de error
                MantIngresoCategoria mant = new MantIngresoCategoria();
                var categorias = mant.Getlistado();
                var categoriasSelectList = new SelectList(categorias, "IdCatIngreso", "Nombre");
                MantDivisa mantDivisa = new MantDivisa();
                var divisa = mantDivisa.Getlistado();
                var divisaSelectList = new SelectList(divisa, "IdDivisa", "CodDivisa");
                MantMinisterios mantMinisterio = new MantMinisterios();
                var ministerio = mantMinisterio.Getlistado();
                var ministerioSelectList = new SelectList(ministerio, "IdMinisterio", "Nombre");
                ViewBag.ListadoIngresosCategorias = categoriasSelectList;
                ViewBag.ListadoDivisa = divisaSelectList;
                ViewBag.ListadoMinisterio = ministerioSelectList;

                // Devolver la vista con los datos ingresados y el mensaje de error
                ModelState.AddModelError("", "Ocurrió un error al guardar los datos: " + ex.Message);
                return View();
            }
        }

        // GET: Ofrendas/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = new MantIngresosVarios().GetIngresos(id.Value);

            MantIngresoCategoria mant = new MantIngresoCategoria();
            var categorias = mant.Getlistado();
            var categoriasSelectList = new SelectList(categorias, "IdCatIngreso", "Nombre", viewModel.IngresoCategoria.IdCatIngreso);

            MantDivisa mantDivisa = new MantDivisa();
            var divisa = mantDivisa.Getlistado();
            var divisaSelectList = new SelectList(divisa, "IdDivisa", "CodDivisa", viewModel.IngresosVario.Divisa);

            MantMinisterios mantMinisterio = new MantMinisterios();
            var ministerio = mantMinisterio.Getlistado();
            var ministerioSelectList = new SelectList(ministerio, "IdMinisterio", "Nombre", viewModel.Ministerios.IdMinisterio);

            ViewBag.ListadoIngresosCategorias = categoriasSelectList;
            ViewBag.ListadoDivisa = divisaSelectList;
            ViewBag.ListadoMinisterio = ministerioSelectList;

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // POST: Ofrendas/Edit/5
        public ActionResult Editar(IngresosVariosViewModel viewModel)
        {
            try
            {
                MantIngresosVarios mant = new MantIngresosVarios();
                var ingreso = mant.Editar(viewModel);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                return View(viewModel);
            }
        }

        public ActionResult Anular(int id)
        {
            try
            {
                MantIngresosVarios mant = new MantIngresosVarios();
                mant.AnularIngreVarios(id); // Asegúrate de que este método cambia el estado a cero

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                return Json(new { success = false, error = ex.Message });
            }
        }
    }
}
