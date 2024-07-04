using My_Journal.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Reporting.WebForms;
using System.Data;
using My_Journal.Models.Ofrenda;




namespace My_Journal.Controllers
{
    public class Report : Controller
    {
        private readonly CbnIglesiaContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public Report(CbnIglesiaContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
           _webHostEnvironment = webHostEnvironment;
        }


        public ActionResult Index()
        {
            var ofrendas = _context.Ofrendas.ToList();
            return View(ofrendas);
        }

        [HttpPost]
        public IActionResult PrintReport()
        {
            string renderFormat = "PDF";
            string extension = "pdf";
            string mimetype = "application/pdf";
            using var report = new LocalReport();
            var dt = new DataTable();
            dt = referOfrendas();

            report.DataSources.Add(item :new ReportDataSource("dsOfrenda", dt));







        }

        // Método para obtener los datos de ofrendas en forma de DataTable
        public DataTable referOfrendas()
        {
            var ofrendas = _context.Ofrendas.ToList();

            var dt = new DataTable();
            dt.Columns.Add("IdOfrenda", typeof(int));
            dt.Columns.Add("Cantidad", typeof(double));
            dt.Columns.Add("Descripcion", typeof(string));
            dt.Columns.Add("Divisa", typeof(int));
            dt.Columns.Add("TasaCambio", typeof(double));
            dt.Columns.Add("Fecha", typeof(DateTime));

            foreach (var ofrenda in ofrendas)
            {
                dt.Rows.Add(ofrenda.IdOfrenda, ofrenda.Cantidad, ofrenda.Descripcion, ofrenda.Divisa, ofrenda.TasaCambio, ofrenda.Fecha);
            }

            return dt;
        }



    }

      
       
        
 }

