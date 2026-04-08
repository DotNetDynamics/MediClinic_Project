using System;
using System.Collections.Generic;

namespace MediClinic_Project.Models;

public partial class PurchaseOrderHeader
{
    public int Poid { get; set; }

    public DateTime? Podate { get; set; }

    public int? SupplierId { get; set; }

    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; } = new List<PurchaseOrderLine>();

    public virtual Supplier? Supplier { get; set; }
}
