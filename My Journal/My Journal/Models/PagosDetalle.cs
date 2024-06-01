using System;
using System.Collections.Generic;
using My_Journal.Models.Divisa;

namespace My_Journal;

public partial class PagosDetalle
{
    public int IdDetalle { get; set; }

    public int IdPago { get; set; }

    public int IdCategoria { get; set; }

    public double Cantidad { get; set; }

    public int? Divisa { get; set; }

    public double? TasaCambio { get; set; }

    public int? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public virtual Divisa? DivisaNavigation { get; set; }

    public virtual PagosCategoria IdCategoriaNavigation { get; set; } = null!;

    public virtual Pago IdPagoNavigation { get; set; } = null!;

    public virtual Usuario? UsuarioCreacionNavigation { get; set; }
}
