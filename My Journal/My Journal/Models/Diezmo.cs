using My_Journal.Models.Divisa;
using My_Journal.Models.Miembros;
using System;
using System.Collections.Generic;

namespace My_Journal;

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

    public virtual Divisa? DivisaNavigation { get; set; }

    public virtual Miembro? IdMiembroNavigation { get; set; }

    public virtual Usuario? UsuarioCreacionNavigation { get; set; }
}
