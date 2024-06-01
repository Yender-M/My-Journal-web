using System;
using System.Collections.Generic;

namespace My_Journal;

public partial class Iglesium
{
    public int IdIglesia { get; set; }

    public string Nombres { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string? Telefono { get; set; }

    public byte[]? Logo { get; set; }

    public string Esquema { get; set; } = null!;

    public int? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }
}
