using System;
using System.Collections.Generic;

namespace MediClinic_Project.Models;

public partial class Physician
{
    public int PhysicianId { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Specialization { get; set; }

    public string? Summary { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<DrugRequest> DrugRequests { get; set; } = new List<DrugRequest>();
}
