using System;
using System.Collections.Generic;

namespace DataAccess.DataModels;

public partial class StaffMaster
{
    public int Sid { get; set; }

    public string? Fname { get; set; }

    public string? Address { get; set; }

    public string? Mobile { get; set; }

    public int? Age { get; set; }

    public string? Dob { get; set; }

    public int? Salary { get; set; }
}
