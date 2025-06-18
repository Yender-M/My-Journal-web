using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Journal.Models.Diezmos;
using My_Journal.Models.Divisa;
using My_Journal.Models.Miembros;

namespace My_Journal.Controllers
{
    public class DiezmosCreateController : Controller
    {
        // GET: Diezmo/Create que abre el modal y carga los dropdown
        public IActionResult Index()
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

    }
}
