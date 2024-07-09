using Microsoft.AspNetCore.Mvc.Rendering;

namespace My_Journal.Models.Reportes
{
    public class ReporteOfrendasViewModel
    {
        public int IdCatOfrenda { get; set; }
        public IEnumerable<SelectListItem> ListadoOfrendasCategorias { get; set; }

        public int IdDivisa { get; set; }
        public IEnumerable<SelectListItem> ListadoDivisa { get; set; }

        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
