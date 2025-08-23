using System.ComponentModel;
using DunderMifflin.Api.Models;
using ModelContextProtocol.Server;
using System.Net.Http;
using System.Net.Http.Json;

namespace DunderMifflin.Mcp.Tools;

[McpServerToolType]
public static class EmployeesTools
{
    [McpServerTool(Name = "employees.list"), Description("List all employees")] 
    public static Task<List<Employee>?> ListEmployees(HttpClient http) =>
        http.GetFromJsonAsync<List<Employee>>("employees");

    [McpServerTool(Name = "employees.get"), Description("Get a single employee by id")]
    public static Task<Employee?> GetEmployee(
        [Description("Employee identifier")] int id,
        HttpClient http) =>
        http.GetFromJsonAsync<Employee>($"employees/{id}");
}
