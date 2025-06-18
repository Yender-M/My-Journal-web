using Microsoft.AspNetCore.Mvc;
using My_Journal.Models.Miembros;

namespace My_Journal.Controllers
{
    public class MiembrosCreateController : Controller
    {

        // GET: Miembros/Create
        public IActionResult Index()
        {
            try
            {
                var model = new Miembro
                {
                    Miembros = new Miembro()
                };

                return View(model);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                return View(new Miembro());
            }
        }

        [HttpPost]
        public ActionResult Create(List<string> Nombre, List<string> Apellido, List<string> Direccion, List<string> Telefono, List<DateTime> FechaNacimiento, List<DateTime> FechaBautismo)
        {
            try
            {
                // Validar que todas las listas tengan la misma longitud
                if (Nombre.Count == Apellido.Count &&
                    Apellido.Count == Direccion.Count &&
                    Direccion.Count == Telefono.Count &&
                    Telefono.Count == FechaNacimiento.Count &&
                    FechaNacimiento.Count == FechaBautismo.Count)
                {
                    // Crear una lista para almacenar las Miembros
                    var miembros = new List<Miembro>();

                    // Iterar sobre las listas y crear objetos Miembros
                    for (int i = 0; i < Nombre.Count; i++)
                    {
                        var miembro = new Miembro
                        {
                            Nombre = Nombre[i],
                            Apellido = Apellido[i],
                            Direccion = Direccion[i],
                            Telefono = Telefono[i],
                            FechaNacimiento = FechaNacimiento[i],
                            FechaBautismo = FechaBautismo[i]
                        };
                        miembros.Add(miembro);
                    }

                    // Insertar los Miembros en la base de datos
                    MantMiembro mantMiembro = new MantMiembro();
                    foreach (var miembro in miembros)
                    {
                        mantMiembro.Insertar(miembro);
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
                // Devolver la vista con los datos ingresados y el mensaje de error
                ModelState.AddModelError("", "Ocurrió un error al guardar los datos: " + ex.Message);
                return View();
            }
        }

    }
}
