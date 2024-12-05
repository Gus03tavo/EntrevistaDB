using System;
using System.Collections.Generic;

namespace EntrevistaDB.Models;

public partial class Producto
{
    public string ProId { get; set; } = null!;

    public string ProNombre { get; set; } = null!;

    public int ProStock { get; set; }

    public decimal ProPrecio { get; set; }

    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();
}
