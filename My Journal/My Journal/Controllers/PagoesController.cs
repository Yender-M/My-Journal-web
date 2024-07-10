using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Journal.Models.Divisa;
using My_Journal.Models.Pagos;
using My_Journal.Models.PagosCategoria;

namespace My_Journal.Controllers
{
    public class PagoesController : Controller
    {
        // GET: Pagos
        public IActionResult Index(DateTime? startDate, DateTime? endDate)
        {
            try
            {
                // Leer las fechas desde los parámetros o desde las variables de sesión
                if (startDate.HasValue && endDate.HasValue)
                {
                    // Guardar las fechas en la sesión si se proporcionan
                    HttpContext.Session.SetString("startDatepa", startDate.Value.ToString("yyyy-MM-dd"));
                    HttpContext.Session.SetString("endDatepa", endDate.Value.ToString("yyyy-MM-dd"));
                }
                else
                {
                    var startDateString = HttpContext.Session.GetString("startDatepa");
                    var endDateString = HttpContext.Session.GetString("endDatepa");

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

                // Lógica para obtener el listado de Ppagos según las fechas
                var desde = startDate.Value.ToString("yyyyMMdd");
                var hasta = endDate.Value.ToString("yyyyMMdd");

                MantPago MantPago = new MantPago();
                var pago = MantPago.GetListadoPagos(desde, hasta);

                // Pasar el listado de Pagos y las fechas a la vista
                ViewBag.StartDate = startDate.Value.ToString("yyyy-MM-dd");
                ViewBag.EndDate = endDate.Value.ToString("yyyy-MM-dd");

                return View(pago);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                ViewBag.ErrorMessage = $"Error al cargar el listado de Pagos: {ex.Message}";
                return View(new List<PagosViewModel>());
            }
        }

        [HttpPost]
        public IActionResult SetSessionDates(string startDate, string endDate)
        {
            try
            {
                // Guardar las fechas en formato string en las variables de sesión
                HttpContext.Session.SetString("startDatepa", startDate);
                HttpContext.Session.SetString("endDatepa", endDate);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // GET: Ofrendas/Create
        public IActionResult Create()
        {
            try
            {
                MantPagosCategoria mant = new MantPagosCategoria();
                var categorias = mant.Getlistado();
                var categoriasSelectList = new SelectList(categorias, "IdCategoria", "Nombre");

                MantDivisa mantDivisa = new MantDivisa();
                var divisa = mantDivisa.Getlistado();
                var divisaSelectList = new SelectList(divisa, "IdDivisa", "CodDivisa");

                ViewBag.ListadoPagosCategorias = categoriasSelectList;
                ViewBag.ListadoDivisa = divisaSelectList;

                var model = new PagosViewModel
                {
                    Pagos = new Pago()
                };

                return View(model);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                return View(new PagosViewModel());
            }
        }

        [HttpPost]
        public ActionResult Create(List<int> PagoCategoria, List<string> Descripcion, List<decimal> Cantidad, List<int> Divisa, List<decimal> TasaCambio, List<DateTime> FechaPago)
        {
            try
            {
                // Validar que todas las listas tengan la misma longitud
                if (PagoCategoria.Count == Descripcion.Count &&
                    Descripcion.Count == Cantidad.Count &&
                    Cantidad.Count == Divisa.Count &&
                    Divisa.Count == TasaCambio.Count &&
                    TasaCambio.Count == FechaPago.Count)
                {
                    // Crear una lista para almacenar las ofrendas
                    var pagos = new List<Pago>();

                    // Iterar sobre las listas y crear objetos Ofrenda
                    for (int i = 0; i < PagoCategoria.Count; i++)
                    {
                        var pago = new Pago
                        {
                            IdCategoria = PagoCategoria[i],
                            Descripcion = Descripcion[i],
                            Cantidad = (double)Cantidad[i],
                            Divisa = Divisa[i],
                            TasaCambio = (double)TasaCambio[i],
                            FechaPago = FechaPago[i]
                        };
                        pagos.Add(pago);
                    }

                    // Insertar los Pagos en la base de datos
                    MantPago mantPagos = new MantPago();
                    foreach (var pago in pagos)
                    {
                        mantPagos.Insertar(pago);
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
                MantPagosCategoria mant = new MantPagosCategoria();
                var categorias = mant.Getlistado();
                var categoriasSelectList = new SelectList(categorias, "IdCategoria", "Nombre");
                MantDivisa mantDivisa = new MantDivisa();
                var divisa = mantDivisa.Getlistado();
                var divisaSelectList = new SelectList(divisa, "IdDivisa", "CodDivisa");
                ViewBag.ListadoPagosCategorias = categoriasSelectList;
                ViewBag.ListadoDivisa = divisaSelectList;

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

            var viewModel = new MantPago().GetPago(id.Value);

            MantPagosCategoria mant = new MantPagosCategoria();
            var categorias = mant.Getlistado();
            var categoriasSelectList = new SelectList(categorias, "IdCategoria", "Nombre", viewModel.Pagos.IdCategoria);
            MantDivisa mantDivisa = new MantDivisa();
            var divisa = mantDivisa.Getlistado();
            var divisaSelectList = new SelectList(divisa, "IdDivisa", "CodDivisa", viewModel.Pagos.Divisa);
            ViewBag.ListadoPagosCategorias = categoriasSelectList;
            ViewBag.ListadoDivisa = divisaSelectList;

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // POST: Ofrendas/Edit/5
        public ActionResult Editar(PagosViewModel viewModel)
        {
            try
            {
                MantPago mant = new MantPago();
                var pago = mant.Editar(viewModel);

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
                MantPago mant = new MantPago();
                mant.AnularPago(id); // Asegúrate de que este método cambia el estado a cero

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
