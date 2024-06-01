using System;
using System.Collections.Generic;

namespace My_Journal.Models;

public partial class Permiso
{
    public int IdPermiso { get; set; }

    public string? NombrePermiso { get; set; }

    public bool? EsActivo { get; set; }

    public DateOnly? FechaRegistro { get; set; }
}
