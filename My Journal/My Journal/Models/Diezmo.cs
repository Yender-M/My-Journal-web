using System;
using System.Collections.Generic;

namespace My_Journal;

public partial class Diezmo
{
    public int IdDiezmo { get; set; }

    public double Cantidad { get; set; }

    public DateTime FechaDiezmo { get; set; }

    public string? Descripcion { get; set; }

    public int Estado { get; set; }

    public int? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public virtual ICollection<DiezmoDetalle> DiezmoDetalles { get; set; } = new List<DiezmoDetalle>();

    public virtual Usuario? UsuarioCreacionNavigation { get; set; }
}
