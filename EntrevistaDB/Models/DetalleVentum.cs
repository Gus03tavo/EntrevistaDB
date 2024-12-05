using System;
using System.Collections.Generic;

namespace EntrevistaDB.Models;

public partial class DetalleVentum
{
    public int DvId { get; set; }

    public int? VentaId { get; set; }

    public string? ProId { get; set; }

    public int DvCantidad { get; set; }

    public decimal DvPreciounitario { get; set; }

    public decimal DvSubtotal { get; set; }

    public virtual Producto? Pro { get; set; }

    public virtual Venta? Venta { get; set; }
}
