using System;
using System.Collections.Generic;

namespace EntrevistaDB.Models;

public partial class Venta
{
    public int VentaId { get; set; }

    public string? ClDni { get; set; }

    public DateOnly VentaFecha { get; set; }

    public decimal VentaImporteTotal { get; set; }

    public virtual Cliente? ClDniNavigation { get; set; }

    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();
}
