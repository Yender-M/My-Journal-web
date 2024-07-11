using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Journal.Models.Diezmos;
using My_Journal.Models.Divisa;
using My_Journal.Models.Miembros;
using My_Journal.Models.Ministerios;
using My_Journal.Models.MinisteriosDetalle;
using My_Journal.Models.Usuario;


namespace My_Journal.Controllers
{
    public class MinisteriosController : Controller
    {
        // GET: MinisteriosController
        public ActionResult Index()
        {
            try
            {

                MantMinisterios MantMinisterios = new MantMinisterios();
                var ministerios = MantMinisterios.GetListadoMinisterios();

                // Pasar el listado de Pagos y las fechas a la vista


                return View(ministerios);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                ViewBag.ErrorMessage = $"Error al cargar el listado de Ministerios: {ex.Message}";
                return View(new List<MinisteriosViewModel>());
            }
        }

        // GET: MinisteriosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MinisteriosController/Create
        public ActionResult Create()
        {
            try
            {

                MantUsuario mantUsuario = new MantUsuario();
                var usuarios = mantUsuario.GetListadoUsuarios();
                var usuarioSelectList = new SelectList(usuarios, "IdUsuario", "Nombres");

                ViewBag.usuarioSelectList = usuarioSelectList;

                var model = new MinisteriosViewModel
                {
                    Ministerios = new Ministerios()
                };

                return View(model);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                return View(new MinisteriosViewModel());
            }
        }

        // POST: MinisteriosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(List<String> Ministerio, List<String> Descripcion, List<int> Usuario, List<int> Ver, List<int> Crear, List<int> Editar, List<int> Anular)
        {
            try
            {

                // Crear una lista para almacenar los ministerios
                var ministerios = new List<Ministerios>();
                var ministeriosDetalles = new List<MinisteriosDetalle>();

                // Iterar sobre las listas y crear objetos ministerios
                for (int i = 0; i < Ministerio.Count; i++)
                {
                    var ministerio = new Ministerios
                    {
                        Nombre = Ministerio[i],
                        Descripcion = Descripcion[i],
                        Estado = 1,
                    };
                    ministerios.Add(ministerio);

                    var ministerioDetalle = new MinisteriosDetalle
                    {
                        IdMinisterio = ministerio.IdMinisterio,
                        IdUsuario = Usuario[i],
                        Ver = Ver[i],
                        Crear = Crear[i],
                        Editar = Editar[i],
                        Anular = Anular[i]
                    };
                    ministeriosDetalles.Add(ministerioDetalle);
                }

                // Insertar los ministerios en la base de datos
                MantMinisterios mantMinisterio = new MantMinisterios();
                foreach (var ministerio in ministerios)
                {
                    mantMinisterio.Insertar(ministerio);
                }

                MantMinisteriosDetalle mantministerioDetalle = new MantMinisteriosDetalle();

                foreach (var ministeriod in ministeriosDetalles)
                {
                    mantministerioDetalle.Insertar(ministeriod);
                }
            
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                // Cargar la lista de categorías para la vista en caso de error
                MantUsuario mantUsuario = new MantUsuario();
                var usuarios = mantUsuario.GetListadoUsuarios();
                var usuarioSelectList = new SelectList(usuarios, "IdUsuario", "Nombres");

                ViewBag.usuarioSelectList = usuarioSelectList;

                // Devolver la vista con los datos ingresados y el mensaje de error
                ModelState.AddModelError("", "Ocurrió un error al guardar los datos: " + ex.Message);
                return View();
            }
        }

        // GET: MinisteriosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MinisteriosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MinisteriosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MinisteriosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
