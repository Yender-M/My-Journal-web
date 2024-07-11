namespace My_Journal.Models.Ministerios
{
    public class Ministerios
    {
        public int IdMinisterio {  get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }

        public int? UsuarioCreacion { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public int? UsuarioModifica { get; set; }

        public DateTime? FechaModifica { get; set; }
    }

    public class MinisteriosViewModel
    {
        public Ministerios Ministerios { get; set; }
        public MinisteriosDetalle.MinisteriosDetalle  MinisteriosDetalle { get; set; }
        public Usuario.Usuario Usuario { get; set; }
    }
}
