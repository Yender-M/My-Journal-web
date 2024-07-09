namespace My_Journal.Models.MinisteriosDetalle
{
    public class MinisteriosDetalle
    {
        public int IdDetalle { get; set; }
        public int IdMinisterio { get; set; }
        public int IdUsuario { get; set; }
        public int Ver { get; set; }
        public int Crear { get; set; }
        public int Editar { get; set; }
        public int Anular { get; set; }
        public int? UsuarioCreacion { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public int? UsuarioModifica { get; set; }

        public DateTime? FechaModifica { get; set; }
    }
}
