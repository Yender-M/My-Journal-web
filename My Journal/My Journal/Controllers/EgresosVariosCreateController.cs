using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Journal.Models.Divisa;
using My_Journal.Models.EgresosCategoria;
using My_Journal.Models.EgresosVarios;
using My_Journal.Models.Ministerios;

namespace My_Journal.Controllers
{
    public class EgresosVariosCreateController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                MantEgresoCategotia mant = new MantEgresoCategotia();
                var categorias = mant.Getlistado();
                var categoriasSelectList = new SelectList(categorias, "IdCatEgreso", "Nombre");

                MantDivisa mantDivisa = new MantDivisa();
                var divisa = mantDivisa.Getlistado();
                var divisaSelectList = new SelectList(divisa, "IdDivisa", "CodDivisa");

                MantMinisterios mantMinisterio = new MantMinisterios();
                var ministerio = mantMinisterio.Getlistado();
                var ministerioSelectList = new SelectList(ministerio, "IdMinisterio", "Nombre");

                ViewBag.ListadoEgresosCategorias = categoriasSelectList;
                ViewBag.ListadoDivisa = divisaSelectList;
                ViewBag.ListadoMinisterio = ministerioSelectList;

                var model = new EgresosVariosViewModel
                {
                    EgresosVario = new EgresosVario()
                };

                return View(model);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                return View(new EgresosVariosViewModel());
            }
        }

    }
}
