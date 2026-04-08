using System;
using System.Collections.Generic;

namespace MediClinic_Project.Models;

public partial class Chemist
{
    public int ChemistId { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Summary { get; set; }
}
