using System;
using System.Collections.Generic;

namespace MediClinic_Project.Models;

public partial class PhysicianAdvice
{
    public int PhysicianAdviceId { get; set; }

    public int? ScheduleId { get; set; }

    public string? Advice { get; set; }

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();

    public virtual Schedule? Schedule { get; set; }
}
