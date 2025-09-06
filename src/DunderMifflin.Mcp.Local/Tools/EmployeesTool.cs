using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json.Serialization;
using DunderMifflin.Api.Data;
using DunderMifflin.Api.Models;
using Microsoft.EntityFrameworkCore;
using ModelContextProtocol.Server;

namespace DunderMifflin.Mcp.Local.Tools;

[McpServerToolType]
public static class EmployeesTool
{
    [McpServerTool(Name = "GetEmployees")]
    [Description("Gets a list of Dunder Mifflin employees.")]
    public static async Task <List<Employee>> GetEmployees(DunderMifflinDbContext dbContext)
    {
        // Debugger.Launch();
        Console.WriteLine($"GetEmployees was called");
        
        return await dbContext.Employees.ToListAsync();

        // var employees = new List<Employee>
        // {
        //     new Employee() { Employeeid = 1, Lastname = "van der Lee", Firstname = "Stuart" }
        // };
        //
        // return employees;
    }
}
