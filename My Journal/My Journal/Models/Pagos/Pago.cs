namespace My_Journal.Models.Pagos;

public partial class Pago
{
    public int IdPago { get; set; }

    public int IdCategoria { get; set; }

    public double? Cantidad { get; set; }

    public int Divisa { get; set; }

    public double? TasaCambio { get; set; }

    public string? Descripcion { get; set; }

    public DateTime FechaPago { get; set; }

    public int? Estado { get; set; }

    public int? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public int? UsuarioAnula { get; set; }

    public DateTime? FechaAnulacion { get; set; }

    public virtual Usuario.Usuario? UsuarioCreacionNavigation { get; set; }
}

public class PagosViewModel
{
    public Pago Pagos { get; set; }

    public PagosCategoria.PagosCategoria PagosCategoria { get; set; }

    public Divisa.Divisa Divisa { get; set; }
}
