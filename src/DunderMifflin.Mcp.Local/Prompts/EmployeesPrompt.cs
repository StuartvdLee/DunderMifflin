using System.ComponentModel;
using Microsoft.Extensions.AI;
using ModelContextProtocol.Server;

namespace DunderMifflin.Mcp.Local.Prompts;

[McpServerPromptType]
public class EmployeesPrompt
{
    [McpServerPrompt]
    [Description("Prompt to get a list of employees.")]
    public ChatMessage GetEmployees()
    {
        return new ChatMessage(ChatRole.User, "Get a list of all Dunder Mifflin employees");
    }
}
