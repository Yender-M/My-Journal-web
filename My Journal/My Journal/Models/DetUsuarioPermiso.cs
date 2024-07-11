using System;
using System.Collections.Generic;

namespace My_Journal.Models;

public partial class DetUsuarioPermiso
{
    public int IdUsuario { get; set; }

    public int IdPermiso { get; set; }

    public virtual Permiso IdPermisoNavigation { get; set; } = null!;

    public virtual Usuario.Usuario IdUsuarioNavigation { get; set; } = null!;
}
