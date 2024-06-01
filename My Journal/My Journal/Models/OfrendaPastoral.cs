using System;
using System.Collections.Generic;

namespace My_Journal.Models;

public partial class OfrendaPastoral
{
    public int IdOfrendaPastoral { get; set; }

    public int? Cantidad { get; set; }

    public string? Nombre { get; set; }

    public DateOnly? FechaOfrendaPastoral { get; set; }

    //public virtual ICollection<TotalEgreso> TotalEgresos { get; set; } = new List<TotalEgreso>();
}
