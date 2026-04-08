using System;
using System.Collections.Generic;

namespace MediClinic_Project.Models;

public partial class DrugRequest
{
    public int DrugRequestId { get; set; }

    public int? PhysicianId { get; set; }

    public string? DrugInfo { get; set; }

    public DateTime? RequestDate { get; set; }

    public string? RequestStatus { get; set; }

    public virtual Physician? Physician { get; set; }
}
