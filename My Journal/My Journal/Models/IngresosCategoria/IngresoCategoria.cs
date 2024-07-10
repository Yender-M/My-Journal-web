using My_Journal.Models.EgresosCategoria;

namespace My_Journal.Models.IngresosCategoria
{
    public class IngresoCategoria
    {
        public int IdCatIngreso { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }

        public int Estado { get; set; }

        public int? UsuarioCreacion { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public int? UsuarioModifica { get; set; }

        public DateTime? FechaModifica { get; set; }

        public virtual Usuario? UsuarioCreacionNavigation { get; set; }

        public IngresoCategoria ingresoCategoria { get; internal set; }
    }
}
