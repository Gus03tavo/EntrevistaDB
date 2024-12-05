using System;
using System.Collections.Generic;

namespace EntrevistaDB.Models;

public partial class Cliente
{
    public string ClDni { get; set; } = null!;

    public string ClNombres { get; set; } = null!;

    public string ClApellidos { get; set; } = null!;

    public string? ClCorreo { get; set; }

    public string? ClCelular { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
