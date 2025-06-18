using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Journal.Models.Divisa;
using My_Journal.Models.Pagos;
using My_Journal.Models.PagosCategoria;

namespace My_Journal.Controllers
{
    public class PagoesCreateController : Controller
    {
        // GET: Ofrendas/Create
        public IActionResult Index()
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

    }
}
