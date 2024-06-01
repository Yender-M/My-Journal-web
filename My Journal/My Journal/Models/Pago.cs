using System;
using System.Collections.Generic;

namespace My_Journal;

public partial class Pago
{
    public int IdPago { get; set; }

    public string? Descripcion { get; set; }

    public DateTime Fecha { get; set; }

    public int? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public virtual ICollection<PagosDetalle> PagosDetalles { get; set; } = new List<PagosDetalle>();

    public virtual Usuario? UsuarioCreacionNavigation { get; set; }

    public double Cantidad { get; set; }
}
