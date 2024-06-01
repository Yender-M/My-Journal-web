using System;
using System.Collections.Generic;

namespace My_Journal;

public partial class IngresosVario
{
    public int IdIngreVarios { get; set; }

    public double Cantidad { get; set; }

    public string Descripcion { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public int? IdProyecto { get; set; }

    public int? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public virtual Proyecto? IdProyectoNavigation { get; set; }

    public virtual ICollection<IngresosVariosDetalle> IngresosVariosDetalles { get; set; } = new List<IngresosVariosDetalle>();

    public virtual Usuario? UsuarioCreacionNavigation { get; set; }
}
