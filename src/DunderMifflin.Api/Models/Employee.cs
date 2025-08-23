using System;
using System.Collections.Generic;

namespace DunderMifflin.Api.Models;

public partial class Employee
{
    public int Employeeid { get; set; }

    public string Lastname { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string? Middlename { get; set; }

    public string? Title { get; set; }

    public string? Titleofcourtesy { get; set; }

    public DateOnly? Birthdate { get; set; }

    public DateOnly? Hiredate { get; set; }

    public DateOnly? Terminationdate { get; set; }

    public DateOnly? Rehiredate { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Region { get; set; }

    public string? Postalcode { get; set; }

    public string? Country { get; set; }

    public string? Homephone { get; set; }

    public string? Extension { get; set; }

    public string? Notes { get; set; }

    public int? Reportsto { get; set; }

    public string? Photopath { get; set; }

    public string? Statuscode { get; set; }

    public virtual ICollection<Employee> InverseReportstoNavigation { get; set; } = new List<Employee>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Employee? ReportstoNavigation { get; set; }

    public virtual Employeestatus? StatuscodeNavigation { get; set; }
}
