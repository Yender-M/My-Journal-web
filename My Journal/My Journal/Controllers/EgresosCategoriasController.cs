using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_Journal.Models.EgresosCategoria;
using My_Journal.Models.IngresosCategoria;

namespace My_Journal.Controllers
{
    public class EgresosCategoriasController : Controller
    {
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


        // GET: Ofrenda Cat/Edit que lo abre
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = new MantEgresoCategotia().GetEgresoCategoria(id.Value);


            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // POST: Ofrenda Cat/Edit que lo guarda
        public ActionResult Editar(EgresoCategoria EgresoCat)
        {
            try
            {
                MantEgresoCategotia mant = new MantEgresoCategotia();
                var egresoCat = mant.Editar(EgresoCat);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                return View(EgresoCat);
            }
        }

    }
}
