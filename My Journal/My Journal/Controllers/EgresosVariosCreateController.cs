using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Journal.Models.Divisa;
using My_Journal.Models.EgresosCategoria;
using My_Journal.Models.EgresosVarios;
using My_Journal.Models.Ministerios;

namespace My_Journal.Controllers
{
    public class EgresosVariosCreateController : Controller
    {
        public IActionResult Index()
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
        public ActionResult Index(List<int> EgresosCategorias, List<int> Ministerios, List<string> Descripcion, List<decimal> Cantidad, List<int> Divisa, List<decimal> TasaCambio, List<DateTime> FechaEgreso)
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

    }
}
