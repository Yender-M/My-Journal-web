using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Journal.Models.Divisa;
using My_Journal.Models.EgresosCategoria;
using My_Journal.Models.EgresosVarios;
using My_Journal.Models.Ministerios;

namespace My_Journal.Controllers
{
    public class EgresosVariosController : Controller
    {
        // GET: Egresos
        public IActionResult Index(DateTime? startDate, DateTime? endDate)
        {
            try
            {
                // Leer las fechas desde los parámetros o desde las variables de sesión
                if (startDate.HasValue && endDate.HasValue)
                {
                    // Guardar las fechas en la sesión si se proporcionan
                    HttpContext.Session.SetString("startDateeg", startDate.Value.ToString("yyyy-MM-dd"));
                    HttpContext.Session.SetString("endDateeg", endDate.Value.ToString("yyyy-MM-dd"));
                }
                else
                {
                    var startDateString = HttpContext.Session.GetString("startDateeg");
                    var endDateString = HttpContext.Session.GetString("endDateeg");

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

                MantEgresosVarios mantEgreso = new MantEgresosVarios();
                var Egresos = mantEgreso.GetListadoEgresosVarios(desde, hasta);

                // Pasar el listado de ofrendas y las fechas a la vista
                ViewBag.StartDate = startDate.Value.ToString("yyyy-MM-dd");
                ViewBag.EndDate = endDate.Value.ToString("yyyy-MM-dd");

                return View(Egresos);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                ViewBag.ErrorMessage = $"Error al cargar el listado de Egresos: {ex.Message}";
                return View(new List<EgresosVariosViewModel>());
            }
        }

        [HttpPost]
        public IActionResult SetSessionDates(string startDate, string endDate)
        {
            try
            {
                // Guardar las fechas en formato string en las variables de sesión
                HttpContext.Session.SetString("startDateeg", startDate);
                HttpContext.Session.SetString("endDateeg", endDate);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // GET: Egreso/Create que carga los dropdown
        public IActionResult Create()
        {
            try
            {
                MantEgresoCategotia mant = new MantEgresoCategotia();
                var categorias = mant.Getlistado();
                var categoriasSelectList = new SelectList(categorias, "IdCatEgreso", "Nombre");

                MantDivisa mantDivisa = new MantDivisa();
                var divisa = mantDivisa.Getlistado();
                var divisaSelectList = new SelectList(divisa, "IdDivisa", "CodDivisa");

                MantMinisterios mantMinisterio = new MantMinisterios();
                var ministerio = mantMinisterio.Getlistado();
                var ministerioSelectList = new SelectList(ministerio, "IdMinisterio", "Nombre");

                ViewBag.ListadoEgresosCategorias = categoriasSelectList;
                ViewBag.ListadoDivisa = divisaSelectList;
                ViewBag.ListadoMinisterio = ministerioSelectList;

                var model = new EgresosVariosViewModel
                {
                    EgresosVario = new EgresosVario()
                };

                return View(model);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                return View(new EgresosVariosViewModel());
            }
        }

        [HttpPost]
        public ActionResult Create(List<int> EgresosCategorias, List<int> Ministerios, List<string> Descripcion, List<decimal> Cantidad, List<int> Divisa, List<decimal> TasaCambio, List<DateTime> FechaEgreso)
        {
            try
            {
                // Validar que todas las listas tengan la misma longitud
                if (EgresosCategorias.Count == Ministerios.Count &&
                    Ministerios.Count == Descripcion.Count &&
                    Descripcion.Count == Cantidad.Count &&
                    Cantidad.Count == Divisa.Count &&
                    Divisa.Count == TasaCambio.Count &&
                    TasaCambio.Count == FechaEgreso.Count)
                {
                    // Crear una lista para almacenar las ofrendas
                    var egreso = new List<EgresosVario>();

                    // Iterar sobre las listas y crear objetos Ofrenda
                    for (int i = 0; i < EgresosCategorias.Count; i++)
                    {
                        var Egresos = new EgresosVario
                        {
                            IdCatEgreso = EgresosCategorias[i],
                            IdMinisterio = Ministerios[i],
                            Descripcion = Descripcion[i],
                            Cantidad = (double)Cantidad[i],
                            Divisa = Divisa[i],
                            TasaCambio = (double)TasaCambio[i],
                            FechaEgreso = FechaEgreso[i]
                        };
                        egreso.Add(Egresos);
                    }

                    // Insertar las ofrendas en la base de datos
                    MantEgresosVarios mantEgresosVarios = new MantEgresosVarios();
                    foreach (var Egresos in egreso)
                    {
                        mantEgresosVarios.Insertar(Egresos);
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
                MantEgresoCategotia mant = new MantEgresoCategotia();
                var categorias = mant.Getlistado();
                var categoriasSelectList = new SelectList(categorias, "IdCatEgreso", "Nombre");
                MantDivisa mantDivisa = new MantDivisa();
                var divisa = mantDivisa.Getlistado();
                var divisaSelectList = new SelectList(divisa, "IdDivisa", "CodDivisa");
                MantMinisterios mantMinisterio = new MantMinisterios();
                var ministerio = mantMinisterio.Getlistado();
                var ministerioSelectList = new SelectList(ministerio, "IdMinisterio", "Nombre");
                ViewBag.ListadoEgresosCategorias = categoriasSelectList;
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

            var viewModel = new MantEgresosVarios().GetEgresos(id.Value);

            MantEgresoCategotia mant = new MantEgresoCategotia();
            var categorias = mant.Getlistado();
            var categoriasSelectList = new SelectList(categorias, "IdCatEgreso", "Nombre", viewModel.EgresoCategoria.IdCatEgreso);

            MantDivisa mantDivisa = new MantDivisa();
            var divisa = mantDivisa.Getlistado();
            var divisaSelectList = new SelectList(divisa, "IdDivisa", "CodDivisa", viewModel.EgresosVario.Divisa);

            MantMinisterios mantMinisterio = new MantMinisterios();
            var ministerio = mantMinisterio.Getlistado();
            var ministerioSelectList = new SelectList(ministerio, "IdMinisterio", "Nombre", viewModel.Ministerios.IdMinisterio);

            ViewBag.ListadoEgresosCategorias = categoriasSelectList;
            ViewBag.ListadoDivisa = divisaSelectList;
            ViewBag.ListadoMinisterio = ministerioSelectList;

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // POST: Ofrendas/Edit/5
        public ActionResult Editar(EgresosVariosViewModel viewModel)
        {
            try
            {
                MantEgresosVarios mant = new MantEgresosVarios();
                var egreso = mant.Editar(viewModel);

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
                MantEgresosVarios mant = new MantEgresosVarios();
                mant.AnularEgreVarios(id); // Asegúrate de que este método cambia el estado a cero

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
