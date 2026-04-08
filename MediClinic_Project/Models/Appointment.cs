using System;
using System.Collections.Generic;

namespace MediClinic_Project.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int? PatientId { get; set; }

    public int? PhysicianId { get; set; }

    public DateTime? AppointmentDateTime { get; set; }

    public string? Criticality { get; set; }

    public string? Reason { get; set; }

    public string? Notes { get; set; }

    public string? ScheduleStatus { get; set; }

    public virtual Patient? Patient { get; set; }

    public virtual Physician? Physician { get; set; }

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
