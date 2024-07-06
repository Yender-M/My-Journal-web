using My_Journal.Models.Miembros;

namespace My_Journal.Models.EgresosCategoria
{
    public class EgresoCategoria
    {
        public int IdCatEgreso { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }

        public int Estado { get; set; }

        public int? UsuarioCreacion { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public int? UsuarioModifica { get; set; }

        public DateTime? FechaModifica { get; set; }

        public virtual Usuario? UsuarioCreacionNavigation { get; set; }

        public EgresoCategoria egresoCategoria { get; internal set; }
    }
}
