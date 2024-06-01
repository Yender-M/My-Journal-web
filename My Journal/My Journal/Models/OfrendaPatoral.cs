using System;
using System.Collections.Generic;

namespace My_Journal;

public partial class OfrendaPatoral
{
    public int IdOfrePasto { get; set; }

    public int? IdMiembro { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public double Cantidad { get; set; }

    public DateTime Fecha { get; set; }

    public int? Divisa { get; set; }

    public double? TasaCambio { get; set; }

    public int? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }
}
