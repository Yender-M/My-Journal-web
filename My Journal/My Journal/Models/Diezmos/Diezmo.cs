namespace My_Journal.Models.Diezmos;

public partial class Diezmo
{
    public int IdDiezmo { get; set; }

    public int? IdMiembro { get; set; }

    public double Cantidad { get; set; }

    public int? Divisa { get; set; }

    public double? TasaCambio { get; set; }

    public DateTime FechaDiezmo { get; set; }

    public string? Descripcion { get; set; }

    public string? Alias { get; set; }

    public int Estado { get; set; }

    public int? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public int? UsuarioAnula { get; set; }

    public DateTime? FechaAnulacion { get; set; }

    public virtual Usuario? UsuarioCreacionNavigation { get; set; }
}

public class DiezmoViewModel
{
    public Diezmo Diezmo { get; set; }

    public Divisa.Divisa Divisa { get; set; }

    public Miembros.Miembro Miembro { get; set; }
}