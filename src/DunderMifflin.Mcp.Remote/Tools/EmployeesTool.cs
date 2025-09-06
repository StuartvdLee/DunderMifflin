using System.ComponentModel;
using DunderMifflin.Api.Data;
using DunderMifflin.Api.Models;
using Microsoft.EntityFrameworkCore;
using ModelContextProtocol.Server;

namespace DunderMifflin.Mcp.Remote.Tools;

[McpServerToolType]
public static class EmployeesTool
{
    [McpServerTool(Name = "GetEmployees")]
    [Description(
        "Gets a list of Dunder Mifflin employees.")]
    public static async Task<List<Employee>> GetEmployees(DunderMifflinDbContext dbContext)
    {
        return await dbContext.Employees.AsQueryable().ToListAsync();
    }
}
