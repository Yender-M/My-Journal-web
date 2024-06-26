namespace My_Journal.Models.Miembros;

public partial class Miembro
{
    public int IdMiembro { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Apellido { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public DateTime FechaNacimiento { get; set; }

    public DateTime FechaBautismo { get; set; }

    public int Estado { get; set; }

    public int? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public virtual ICollection<EgresosVariosDetalle> EgresosVariosDetalles { get; set; } = new List<EgresosVariosDetalle>();

    public virtual ICollection<IngresosVariosDetalle> IngresosVariosDetalles { get; set; } = new List<IngresosVariosDetalle>();

    public virtual ICollection<Diezmo> Diezmos { get; set; } = new List<Diezmo>();

    public virtual Usuario? UsuarioCreacionNavigation { get; set; }
    public Miembro Miembros { get; internal set; }

}

