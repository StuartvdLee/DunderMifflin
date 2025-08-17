using System;
using System.Collections.Generic;

namespace DunderMifflinApi.Models;

public partial class Employeestatus
{
    public int Statusid { get; set; }

    public string Statuscode { get; set; } = null!;

    public string Statusname { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
