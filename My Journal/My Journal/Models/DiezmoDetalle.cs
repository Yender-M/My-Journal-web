using System;
using System.Collections.Generic;
using My_Journal.Models.Divisa;

namespace My_Journal;

public partial class DiezmoDetalle
{
    public int IdDetDiezmo { get; set; }

    public int IdDiezmo { get; set; }

    public int? IdMiembro { get; set; }

    public string? Nombre { get; set; }

    public string? Alias { get; set; }

    public int? Divisa { get; set; }

    public double? TasaCambio { get; set; }

    public int? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public virtual Divisa? DivisaNavigation { get; set; }

    public virtual Diezmo IdDiezmoNavigation { get; set; } = null!;

    public virtual Miembro? IdMiembroNavigation { get; set; }

    public virtual Usuario? UsuarioCreacionNavigation { get; set; }
}
