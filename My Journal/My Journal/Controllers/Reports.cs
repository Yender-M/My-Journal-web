using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using My_Journal.Models.Ofrenda;
using AspNetCore.Reporting;
using System;
using My_Journal;

public class ReportsController : Controller
{
    private readonly CbnIglesiaContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ReportsController(CbnIglesiaContext context, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
    }

    // Método para recopilar y mostrar los datos en la vista
    public IActionResult Index(DateTime? startDate, DateTime? endDate)
    {
        var ofrendas = _context.Ofrendas.AsQueryable();

        if (startDate.HasValue)
        {
            ofrendas = ofrendas.Where(o => o.Fecha >= startDate.Value);
        }

        if (endDate.HasValue)
        {
            ofrendas = ofrendas.Where(o => o.Fecha <= endDate.Value);
        }

        var ofrendasList = ofrendas.ToList();
        var totalCantidad = ofrendasList.Sum(o => o.Cantidad);

        ViewBag.TotalCantidad = totalCantidad;
        ViewBag.StartDate = startDate;
        ViewBag.EndDate = endDate;

        return View(ofrendasList.ToList());
    }

    // Método para generar el reporte en PDF y previsualizar en el navegador
    [HttpPost]
    public IActionResult PrintReport(DateTime? startDate, DateTime? endDate)
    {
        string mimetype = "application/pdf";
        int extension = 1;
        var path = $"{_webHostEnvironment.WebRootPath}\\Reports\\rptOfrenda.rdlc";
        var dt = referOfrendas(startDate, endDate);

        LocalReport report = new LocalReport(path);
        report.AddDataSource("dsOfrenda", dt);

        var result = report.Execute(RenderType.Pdf, extension, new Dictionary<string, string>(), mimetype);

        // Convertir el resultado a MemoryStream
        var stream = new MemoryStream(result.MainStream);

        return new FileStreamResult(stream, mimetype);
    }

    // Método para obtener los datos de ofrendas en forma de DataTable
    public DataTable referOfrendas(DateTime? startDate, DateTime? endDate)
    {
        var ofrendas = _context.Ofrendas.AsQueryable();

        if (startDate.HasValue)
        {
            ofrendas = ofrendas.Where(o => o.Fecha >= startDate.Value);
        }

        if (endDate.HasValue)
        {
            ofrendas = ofrendas.Where(o => o.Fecha <= endDate.Value);
        }

        var ofrendasList = ofrendas.ToList();

        var dataTable = new DataTable();
        dataTable.Columns.Add("IdOfrenda", typeof(int));
        dataTable.Columns.Add("Cantidad", typeof(double));
        dataTable.Columns.Add("Descripcion", typeof(string));
        dataTable.Columns.Add("Divisa", typeof(int));
        dataTable.Columns.Add("TasaCambio", typeof(double));
        dataTable.Columns.Add("Fecha", typeof(DateTime));

        foreach (var ofrenda in ofrendasList)
        {
            dataTable.Rows.Add(ofrenda.IdOfrenda, ofrenda.Cantidad, ofrenda.Descripcion, ofrenda.Divisa, ofrenda.TasaCambio, ofrenda.Fecha);
        }

        return dataTable;
    }
}
