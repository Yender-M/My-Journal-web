using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_Journal.Models.EgresosCategoria;

namespace My_Journal.Controllers
{
    public class EgresosCategoriasController : Controller
    {
        private readonly CbnIglesiaContext _context;

        public EgresosCategoriasController(CbnIglesiaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            try
            {
                MantEgresoCategotia mantEgresodaCat = new MantEgresoCategotia();
                var egresocat = mantEgresodaCat.Getlistado();

                return View(egresocat);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                ViewBag.ErrorMessage = $"Error al cargar el listado de egresos categorias: {ex.Message}";
                return View(new List<EgresoCategoria>());
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EgresoCategoria egresoCat)
        {
            if (egresoCat == null)
            {
                return BadRequest(new { success = false, message = "La categoría enviada es inválida." });
            }

            try
            {
                // Asegúrate de que esta clase y método sean válidos
                MantEgresoCategotia mant = new MantEgresoCategotia();
                var resultado = await Task.Run(() => mant.Editar(egresoCat));

                if (string.IsNullOrEmpty(resultado) || resultado.Equals("OK", StringComparison.OrdinalIgnoreCase))
                {
                    return Json(new { success = true, message = "Categoría de egreso actualizada correctamente." });
                }
                else
                {
                    return BadRequest(new { success = false, message = resultado });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error inesperado al procesar la solicitud.",
                    details = ex.Message
                });
            }
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoria = await _context.EgresosCategorias.FindAsync(id);
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

            _context.EgresosCategorias.Remove(categoria);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Categoria eliminada exitosamente.";
            return RedirectToAction(nameof(Index));
        }





    }
}
