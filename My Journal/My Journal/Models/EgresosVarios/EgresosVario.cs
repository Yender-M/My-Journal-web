namespace My_Journal.Models.EgresosVarios;

public partial class EgresosVario
{
    public int IdEgreVarios { get; set; }

    public int IdCatEgreso { get; set; }

    public int IdMinisterio { get; set; }

    public double Cantidad { get; set; }

    public int? Divisa { get; set; }

    public double? TasaCambio { get; set; }

    public string Descripcion { get; set; } = null!;

    public int? Estado { get; set; }

    public DateTime FechaEgreso { get; set; }

    public int? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public int? UsuarioAnula { get; set; }

    public DateTime? FechaAnula { get; set; }

    public virtual Usuario.Usuario? UsuarioCreacionNavigation { get; set; }
}


public class EgresosVariosViewModel
{
    public EgresosVario EgresosVario { get; set; }

    public Divisa.Divisa Divisa { get; set; }

    public EgresosCategoria.EgresoCategoria EgresoCategoria { get; set; }

    public Ministerios.Ministerios Ministerios { get; set; }

}
