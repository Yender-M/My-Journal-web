using System;
using System.Collections.Generic;

namespace My_Journal.Models.Divisa;

public partial class Divisa
{
    public int IdDivisa { get; set; }

    public string CodDivisa { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Simbolo { get; set; } = null!;
}
