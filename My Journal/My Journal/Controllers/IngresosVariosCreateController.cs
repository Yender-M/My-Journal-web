using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Journal.Models.Divisa;
using My_Journal.Models.IngresosCategoria;
using My_Journal.Models.IngresosVarios;
using My_Journal.Models.Ministerios;

namespace My_Journal.Controllers
{
    public class IngresosVariosCreateController : Controller
    {
        // GET: Ingreso/Create que carga los dropdown
        public IActionResult Index()
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

    }
}
