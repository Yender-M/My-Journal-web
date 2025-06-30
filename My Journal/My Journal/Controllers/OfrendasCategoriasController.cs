using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_Journal.Models.OfrendaCategoria;
using System.Text.Json;
namespace My_Journal.Controllers
{
    public class OfrendasCategoriasController : Controller
    {
        private readonly CbnIglesiaContext _context;

        public OfrendasCategoriasController(CbnIglesiaContext context)
        {
            _context = context;
        }
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
        [ValidateAntiForgeryToken]
        public IActionResult Editar(OfrendasCategoria OfrenfaCat)
        {
            try
            {
                MantOfrendaCategoria mant = new MantOfrendaCategoria();
                var result = mant.Editar(OfrenfaCat);

                // You could return JSON for more flexibility
                return Json(new { success = true, message = "Categoría editada con éxito" });
            }
            catch (Exception ex)
            {
                // Log the error as needed
                return Json(new { success = false, message = "Error al editar la categoría", error = ex.Message });
            }
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoria = await _context.OfrendasCategorias.FindAsync(id);
            if (categoria == null)
            {
                TempData["Error"] = "La categoria no fue encontrada.";
                return RedirectToAction(nameof(Index));
            }

            // Check for related ofrendas
            bool hasOfrendas = await _context.Ofrendas.AnyAsync(o => o.IdCatOfrenda == id);
            if (hasOfrendas)
            {
                TempData["Error"] = "No se puede eliminar esta categoria porque tiene ofrendas asociadas.";
                return RedirectToAction(nameof(Index));
            }

            _context.OfrendasCategorias.Remove(categoria);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Categoria eliminada exitosamente.";
            return RedirectToAction(nameof(Index));
        }


    }
}
