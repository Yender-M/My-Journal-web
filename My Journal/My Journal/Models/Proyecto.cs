using System;
using System.Collections.Generic;

namespace My_Journal;

public partial class Proyecto
{
    public int IdProyecto { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int Estado { get; set; }

    public int? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public virtual ICollection<EgresosVario> EgresosVarios { get; set; } = new List<EgresosVario>();

    public virtual ICollection<IngresosVario> IngresosVarios { get; set; } = new List<IngresosVario>();
}
