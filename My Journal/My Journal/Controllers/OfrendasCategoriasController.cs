using Microsoft.AspNetCore.Mvc;
using My_Journal.Models.OfrendaCategoria;
namespace My_Journal.Controllers
{
    public class OfrendasCategoriasController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                MantOfrendaCategoria mantOfrendaCat = new MantOfrendaCategoria();
                var ofrendacat = mantOfrendaCat.Getlistado();

                return View(ofrendacat);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                ViewBag.ErrorMessage = $"Error al cargar el listado de ofrendas categorias: {ex.Message}";
                return View(new List<OfrendasCategoria>());
            }
        }

        // GET: OfrendasCat/Create
        public IActionResult Create()
        {
            try
            {
                var model = new OfrendasCategoria
                {
                    ofrendaCategoria = new OfrendasCategoria()
                };

                return View(model);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                return View(new OfrendasCategoria());
            }
        }

        [HttpPost]
        public ActionResult Create(List<string> Nombre, List<string> Descripcion)
        {
            try
            {
                // Validar que todas las listas tengan la misma longitud
                if (Nombre.Count == Descripcion.Count)
                {
                    // Crear una lista para almacenar las Ofrendas Categorias
                    var OfrendaCat = new List<OfrendasCategoria>();

                    // Iterar sobre las listas y crear objetos Ofrendas Categorias
                    for (int i = 0; i < Nombre.Count; i++)
                    {
                        var ofrendacat = new OfrendasCategoria
                        {
                            Nombre = Nombre[i],
                            Descripcion = Descripcion[i],
                        };
                        OfrendaCat.Add(ofrendacat);
                    }

                    // Insertar las Ofrendas Cat en la base de datos
                    MantOfrendaCategoria mantOfreCat = new MantOfrendaCategoria();
                    foreach (var ofrendacat in OfrendaCat)
                    {
                        mantOfreCat.Insertar(ofrendacat);
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

        //[HttpPost]
        //public IActionResult Editar([FromBody] OfrendasCategoria ofrendaCat)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(new { success = false, message = "Modelo no válido" });
        //    }

        //    try
        //    {
        //        MantOfrendaCategoria mant = new MantOfrendaCategoria();
        //        var resultado = mant.Editar(ofrendaCat);

        //        if (resultado == "OK")
        //        {
        //            return Json(new { success = true, message = "Categoría actualizada correctamente" });
        //        }
        //        else
        //        {
        //            return BadRequest(new { success = false, message = "Error al actualizar la categoría" });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { success = false, message = "Error interno del servidor" });
        //    }
        //}
        [HttpPost]
        public IActionResult Editar([FromBody] OfrendasCategoria OfrendaCat)
        {
            if (!ModelState.IsValid)
            {
                var errores = ModelState.Values
                    .SelectMany(v => v.Errors.Select(b => b.ErrorMessage))
                    .ToList();
                return BadRequest(new { success = false, message = "Modelo no válido", errores });
            }

            try
            {
                MantOfrendaCategoria mant = new MantOfrendaCategoria();
                var resultado = mant.Editar(OfrendaCat);

                if (string.IsNullOrEmpty(resultado) || resultado == "OK")
                {
                    return Json(new { success = true, message = "Categoría actualizada correctamente" });
                }
                else
                {
                    return BadRequest(new { success = false, message = resultado });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Error interno del servidor: " + ex.Message });
            }
        }

    }
}
