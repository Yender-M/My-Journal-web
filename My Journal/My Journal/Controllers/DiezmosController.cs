using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using My_Journal.Models.Diezmos;
using My_Journal.Models.Divisa;
using My_Journal.Models.Miembros;
using My_Journal.Models.Ofrenda;
using My_Journal.Models.OfrendaCategoria;

namespace My_Journal.Controllers
{
    public class DiezmosController : Controller
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

                MantDiezmo mantDiezmo = new MantDiezmo();
                var diezmo = mantDiezmo.GetListadoDiezmo(desde, hasta);

                // Pasar el listado de ofrendas y las fechas a la vista
                ViewBag.StartDate = startDate.Value.ToString("yyyy-MM-dd");
                ViewBag.EndDate = endDate.Value.ToString("yyyy-MM-dd");

                return View(diezmo);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                ViewBag.ErrorMessage = $"Error al cargar el listado de ofrendas: {ex.Message}";
                return View(new List<DiezmoViewModel>());
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

        // GET: Diezmo/Create que abre el modal y carga los dropdown
        public IActionResult Create()
        {
            try
            {
                MantMiembro mant = new MantMiembro();
                var miembros = mant.Getlistado();
                var miembrosSelectList = new SelectList(miembros, "IdMiembro", "Nombre");

                MantDivisa mantDivisa = new MantDivisa();
                var divisa = mantDivisa.Getlistado();
                var divisaSelectList = new SelectList(divisa, "IdDivisa", "CodDivisa");

                ViewBag.ListadoMiembro = miembrosSelectList;
                ViewBag.ListadoDivisa = divisaSelectList;

                var model = new DiezmoViewModel
                {
                    Miembro = new Miembro()
                };

                return View(model);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                return View(new DiezmoViewModel());
            }
        }

        [HttpPost]
        public ActionResult Create(List<int> Miembro, List<string> Alias, List<string> Descripcion, List<decimal> Cantidad, List<int> Divisa, List<decimal> TasaCambio, List<DateTime> FechaDiezmo)
        {
            try
            {
                // Validar que todas las listas tengan la misma longitud
                if (Miembro.Count == Alias.Count && 
                    Alias.Count == Descripcion.Count &&
                    Descripcion.Count == Cantidad.Count &&
                    Cantidad.Count == Divisa.Count &&
                    Divisa.Count == TasaCambio.Count &&
                    TasaCambio.Count == FechaDiezmo.Count)
                {
                    // Crear una lista para almacenar los Diezmos
                    var diezmos = new List<Diezmo>();

                    // Iterar sobre las listas y crear objetos Diezmos
                    for (int i = 0; i < Miembro.Count; i++)
                    {
                        var diezmo = new Diezmo
                        {
                            IdMiembro = Miembro[i],
                            Alias = Alias[i],
                            Descripcion = Descripcion[i],
                            Cantidad = (double)Cantidad[i],
                            Divisa = Divisa[i],
                            TasaCambio = (double)TasaCambio[i],
                            FechaDiezmo = FechaDiezmo[i]
                        };
                        diezmos.Add(diezmo);
                    }

                    // Insertar los Diezmos en la base de datos
                    MantDiezmo mantDiezmo = new MantDiezmo();
                    foreach (var diezmo in diezmos)
                    {
                        mantDiezmo.Insertar(diezmo);
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
                MantMiembro mant = new MantMiembro();
                var miembros = mant.Getlistado();
                var miembrosSelectList = new SelectList(miembros, "IdMiembro", "Nombre");

                MantDivisa mantDivisa = new MantDivisa();
                var divisa = mantDivisa.Getlistado();
                var divisaSelectList = new SelectList(divisa, "IdDivisa", "CodDivisa");

                ViewBag.ListadoMiembro = miembrosSelectList;
                ViewBag.ListadoDivisa = divisaSelectList;

                // Devolver la vista con los datos ingresados y el mensaje de error
                ModelState.AddModelError("", "Ocurrió un error al guardar los datos: " + ex.Message);
                return View();
            }
        }

        // GET: Ofrendas/Edit que carga los datos
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = new MantDiezmo().GetDiezmo(id.Value);

            MantMiembro mant = new MantMiembro();
            var miembros = mant.Getlistado();
            var miembrosSelectList = new SelectList(miembros, "IdMiembro", "Nombre");

            MantDivisa mantDivisa = new MantDivisa();
            var divisa = mantDivisa.Getlistado();
            var divisaSelectList = new SelectList(divisa, "IdDivisa", "CodDivisa");

            ViewBag.ListadoMiembro = miembrosSelectList;
            ViewBag.ListadoDivisa = divisaSelectList;

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // POST: Ofrendas/Edit que guarda los datos
        public ActionResult Editar(DiezmoViewModel viewModel)
        {
            try
            {
                MantDiezmo mant = new MantDiezmo();
                var diezmo = mant.Editar(viewModel);

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
                MantDiezmo mant = new MantDiezmo();
                mant.AnularDiezmo(id); // Asegúrate de que este método cambia el estado a cero

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
