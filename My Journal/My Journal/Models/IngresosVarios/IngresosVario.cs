namespace My_Journal.Models.IngresosVarios;

public partial class IngresosVario
{
    public int IdIngreVarios { get; set; }

    public int IdCatIngreso { get; set; }

    public int IdMinisterio { get; set; }

    public double Cantidad { get; set; }

    public int? Divisa { get; set; }

    public double? TasaCambio { get; set; }

    public string Descripcion { get; set; } = null!;

    public int? Estado { get; set; }

    public DateTime FechaIngreso { get; set; }

    public int? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public int? UsuarioAnula { get; set; }

    public DateTime? FechaAnula { get; set; }
    
    public virtual Usuario.Usuario? UsuarioCreacionNavigation { get; set; }
}

public class IngresosVariosViewModel
{
    public IngresosVario IngresosVario { get; set; }

    public Divisa.Divisa Divisa { get; set; }

    public IngresosCategoria.IngresoCategoria IngresoCategoria { get; set; }

    public Ministerios.Ministerios Ministerios { get; set; }

}
