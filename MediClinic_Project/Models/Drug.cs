using System;
using System.Collections.Generic;

namespace MediClinic_Project.Models;

public partial class Drug
{
    public int DrugId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    public string? Dosage { get; set; }

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();

    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; } = new List<PurchaseOrderLine>();
}
