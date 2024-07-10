using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Journal.Models.Divisa;
using My_Journal.Models.Reportes;
using My_Journal.Models.OfrendaCategoria;
namespace My_Journal.Controllers
{
    public class ReportController : Controller
    {
        // GET: ReportController
        public IActionResult Index(string report)
        {
            MantOfrendaCategoria mant = new MantOfrendaCategoria();
            var categorias = mant.Getlistado();
            var categoriasSelectList = new SelectList(categorias, "IdCatOfrenda", "Nombre");

            MantDivisa mantDivisa = new MantDivisa();
            var divisa = mantDivisa.Getlistado();
            var divisaSelectList = new SelectList(divisa, "IdDivisa", "CodDivisa");

            var viewModel = new ReporteOfrendasViewModel
            {
                ListadoOfrendasCategorias = categoriasSelectList,
                ListadoDivisa = divisaSelectList,
                StartDate = DateTime.Now.ToString("yyyy-MM-dd"),
                EndDate = DateTime.Now.ToString("yyyy-MM-dd")
            };

            ViewBag.UseLayout = true;

            return PartialView("~/Views/Reportes/" + report + ".cshtml", viewModel);
        }

        //public IActionResult Reporte(List<string> data, string rpt)
        //{
        //    // Ruta donde se encuentran los reportes
        //    string reportPath = @"C:\Users\MYender\Documents\REPORTES";

        //    // Validar que el parámetro 'rpt' no sea nulo o vacío
        //    if (string.IsNullOrEmpty(rpt))
        //    {
        //        return View("Error");
        //    }

        //    // Construir la ruta completa al archivo de reporte
        //    string reportFile = Path.Combine(reportPath, rpt);

        //    // Validar si el archivo de reporte existe
        //    if (!System.IO.File.Exists(reportFile))
        //    {
        //        return View("Error");
        //    }

        //    // Configurar ReportViewer
        //    var reportViewer = new ReportViewer
        //    {
        //        ProcessingMode = ProcessingMode.Local,
        //        SizeToReportContent = true,
        //        Width = System.Web.UI.WebControls.Unit.Percentage(100),
        //        Height = System.Web.UI.WebControls.Unit.Percentage(100)
        //    };

        //    reportViewer.LocalReport.ReportPath = reportFile;

        //    // Configurar los parámetros del reporte
        //    var reportParameters = new List<ReportParameter>();
        //    for (int i = 0; i < data.Count; i++)
        //    {
        //        reportParameters.Add(new ReportParameter($"param{i + 1}", data[i]));
        //    }
        //    reportViewer.LocalReport.SetParameters(reportParameters);

        //    reportViewer.LocalReport.Refresh();

        //    // Pasar el ReportViewer a la vista mediante ViewBag
        //    ViewBag.ReportViewer = reportViewer;
        //    ViewBag.ReportName = rpt;

        //    return View("~/Views/Shared/_Report.cshtml");
        //}





        //public ActionResult Reporte(List<string> data, string rpt = null)
        //{
        //    try
        //    {
        //        List<string> listaparametro = new List<string>();
        //        ReportViewer rptViewer = new ReportViewer
        //        {
        //            ProcessingMode = ProcessingMode.Remote,
        //            ShowReportBody = true,
        //            ShowToolBar = true,
        //            PageCountMode = 0,
        //            ShowPageNavigationControls = true,
        //            SizeToReportContent = false,
        //            ShowParameterPrompts = false,
        //            ZoomMode = ZoomMode.PageWidth,
        //            DocumentMapCollapsed = true,
        //            ShowZoomControl = true,
        //            ShowPrintButton = true
        //        };

        //        // Configuración de los parámetros del reporte
        //        var Params = rptViewer.ServerReport.GetParameters().ToList();
        //        if (Params.Count() == 1)
        //        {
        //            rptViewer.ServerReport.SetParameters(new ReportParameter(Params[0].Name, data[0], false));
        //        }
        //        else
        //        {
        //            for (int i = 0; i < data.Count(); i++)
        //            {
        //                rptViewer.ServerReport.SetParameters(new ReportParameter(Params[i].Name, data[i].ToString(), false));
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        return RedirectToAction("SendRespuesta", "Shared");
        //    }
        //    return PartialView("~/Views/Shared/_Report.cshtml");
        //}
    }
}
