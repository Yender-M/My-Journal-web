using System;
using System.Collections.Generic;

namespace My_Journal;

public partial class Role
{
    public int IdRol { get; set; }

    public string CodRol { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public bool Estado { get; set; }

    public int? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }
}
