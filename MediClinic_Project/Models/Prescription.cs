using System;
using System.Collections.Generic;

namespace MediClinic_Project.Models;

public partial class Prescription
{
    public int PrescriptionId { get; set; }

    public int? PhysicianAdviceId { get; set; }

    public int? DrugId { get; set; }

    public string? Prescription1 { get; set; }

    public virtual Drug? Drug { get; set; }

    public virtual PhysicianAdvice? PhysicianAdvice { get; set; }
}
