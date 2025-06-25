using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Journal.Models.Divisa;
using My_Journal.Models.Ofrenda;
using My_Journal.Models.OfrendaCategoria;

namespace My_Journal.Controllers
{
    public class OfrendasController : Controller
    {
        // GET: Ofrendas
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

                MantOfrenda mantOfrenda = new MantOfrenda();
                var ofrendas = mantOfrenda.GetListadoOfrendas(desde, hasta);

                // Pasar el listado de ofrendas y las fechas a la vista
                ViewBag.StartDate = startDate.Value.ToString("yyyy-MM-dd");
                ViewBag.EndDate = endDate.Value.ToString("yyyy-MM-dd");

                return View(ofrendas);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                ViewBag.ErrorMessage = $"Error al cargar el listado de ofrendas: {ex.Message}";
                return View(new List<OfrendaViewModel>());
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

        // GET: Ofrendas/Create
        public IActionResult Create()
        {
            try
            {
                MantOfrendaCategoria mant = new MantOfrendaCategoria();
                var categorias = mant.Getlistado();
                var categoriasSelectList = new SelectList(categorias, "IdCatOfrenda", "Nombre");

                MantDivisa mantDivisa = new MantDivisa();
                var divisa = mantDivisa.Getlistado();
                var divisaSelectList = new SelectList(divisa, "IdDivisa", "CodDivisa");

                ViewBag.ListadoOfrendasCategorias = categoriasSelectList;
                ViewBag.ListadoDivisa = divisaSelectList;

                var model = new OfrendaViewModel
                {
                    Ofrenda = new Ofrenda()
                };

                return View(model);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                return View(new OfrendaViewModel());
            }
        }

        [HttpPost]
        public ActionResult Create(List<int> OfrendaCategoria, List<string> Descripcion, List<decimal> Cantidad, List<int> Divisa, List<decimal> TasaCambio, List<DateTime> Fecha)
        {
            try
            {
                // Validar que todas las listas tengan la misma longitud
                if (OfrendaCategoria.Count == Descripcion.Count &&
                    Descripcion.Count == Cantidad.Count &&
                    Cantidad.Count == Divisa.Count &&
                    Divisa.Count == TasaCambio.Count &&
                    TasaCambio.Count == Fecha.Count)
                {
                    // Crear una lista para almacenar las ofrendas
                    var ofrendas = new List<Ofrenda>();

                    // Iterar sobre las listas y crear objetos Ofrenda
                    for (int i = 0; i < OfrendaCategoria.Count; i++)
                    {
                        var ofrenda = new Ofrenda
                        {
                            IdCatOfrenda = OfrendaCategoria[i],
                            Descripcion = Descripcion[i],
                            Cantidad = (double)Cantidad[i],
                            Divisa = Divisa[i],
                            TasaCambio = (double)TasaCambio[i],
                            Fecha = Fecha[i]
                        };
                        ofrendas.Add(ofrenda);
                    }

                    // Insertar las ofrendas en la base de datos
                    MantOfrenda mantOfrenda = new MantOfrenda();
                    foreach (var ofrenda in ofrendas)
                    {
                        mantOfrenda.Insertar(ofrenda);
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
                MantOfrendaCategoria mantCategoria = new MantOfrendaCategoria();
                var categorias = mantCategoria.Getlistado();
                var categoriasSelectList = new SelectList(categorias, "IdCatOfrenda", "Nombre");
                ViewBag.ListadoOfrendasCategorias = categoriasSelectList;

                // Devolver la vista con los datos ingresados y el mensaje de error
                ModelState.AddModelError("", "Ocurrió un error al guardar los datos: " + ex.Message);
                return View();
            }
        }

        // GET: Ofrendas/Edit/5
        [HttpPost]
        public IActionResult Edit([FromBody] OfrendaViewModel viewModel)
        {
            try
            {
                MantOfrenda mant = new MantOfrenda();
                var ofrendaEditada = mant.Editar(viewModel);

                return Json(new { success = true, message = "Ofrenda actualizada correctamente" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }


        public ActionResult Anular(int id)
        {
            try
            {
                MantOfrenda mant = new MantOfrenda();
                mant.AnularOfrenda(id); // Asegúrate de que este método cambia el estado a cero

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