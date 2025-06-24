using Microsoft.AspNetCore.Mvc;
using My_Journal.Models.IngresosCategoria;

namespace My_Journal.Controllers
{
    public class IngresosCategoriasController : Controller
    {
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



        // GET: Ofrenda Cat/Edit que lo abre
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = new MantIngresoCategoria().GetOIngresoCategoria(id.Value);


            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // POST: Ofrenda Cat/Edit que lo guarda
        public ActionResult Editar(IngresoCategoria IngresoCat)
        {
            try
            {
                MantIngresoCategoria mant = new MantIngresoCategoria();
                var ingresoCat = mant.Editar(IngresoCat);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                return View(IngresoCat);
            }
        }
    }
}
