using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Journal.Models.Divisa;
using My_Journal.Models.Ofrenda;
using My_Journal.Models.OfrendaCategoria;

namespace My_Journal.Controllers
{
    public class OfrendasCreateController : Controller
    {
        // GET: Ofrendas/Create
        public IActionResult Index()
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

    }
}
