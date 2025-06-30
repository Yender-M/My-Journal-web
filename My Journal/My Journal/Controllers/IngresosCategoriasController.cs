using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_Journal.Models.IngresosCategoria;

namespace My_Journal.Controllers
{
    public class IngresosCategoriasController : Controller
    {
        private readonly CbnIglesiaContext _context;

        public IngresosCategoriasController(CbnIglesiaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            try
            {
                MantIngresoCategoria mantIngresodaCat = new MantIngresoCategoria();
                var ingresocat = mantIngresodaCat.Getlistado();

                return View(ingresocat);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                ViewBag.ErrorMessage = $"Error al cargar el listado de ingresos categorias: {ex.Message}";
                return View(new List<IngresoCategoria>());
            }
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(IngresoCategoria ingresoCat)
        {
            if (ingresoCat == null)
            {
                return BadRequest(new { success = false, message = "El modelo recibido es inválido." });
            }

            try
            {
                var result = new MantIngresoCategoria().Editar(ingresoCat);
                if (!string.IsNullOrEmpty(result) && result != "OK")
                {
                    return BadRequest(new { success = false, message = result });
                }

                return Json(new { success = true, message = "Categoría actualizada exitosamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Error inesperado: " + ex.Message });
            }
        }


        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var categoria = await _context.IngresosCategorias
        //        .Include(c => c.Ingresos) // Solo si hay relación 1:N
        //        .FirstOrDefaultAsync(c => c.IdCatIngreso == id);

        //    if (categoria == null)
        //    {
        //        TempData["Error"] = "La categoría no fue encontrada.";
        //        return RedirectToAction(nameof(Index));
        //    }

        //    if (categoria.Ingresos != null && categoria.Ingresos.Any())
        //    {
        //        TempData["Error"] = "No se puede eliminar porque tiene ingresos asociados.";
        //        return RedirectToAction(nameof(Index));
        //    }

        //    _context.IngresosCategorias.Remove(categoria);
        //    await _context.SaveChangesAsync();

        //    TempData["Success"] = "Categoría eliminada exitosamente.";
        //    return RedirectToAction(nameof(Index));
        //}

    }
}
