using System.ComponentModel;
using Microsoft.Extensions.AI;
using ModelContextProtocol.Server;

namespace DunderMifflin.Mcp.Local.Prompts;

[McpServerPromptType]
public class Prompts
{
    [McpServerPrompt]
    [Description("Prompt to get a list of Dunder Mifflin employees with a maximum limit.")]
    public ChatMessage ExamplePrompt([Description("Employee limit")] int limit)
    {
        return new ChatMessage(ChatRole.User, $"Get a list of {limit} Dunder Mifflin employees");
    }

    [McpServerPrompt]
    [Description("Prompt that serves as template")]
    public ChatMessage TemplatePrompt([Description("Employee limit")] int limit, [Description("Region")] string region)
    {
        return new ChatMessage(ChatRole.User, $"""
            Retrieve, assemble, and present a structured listing containing up to {limit} employees of the Dunder Mifflin {region} branch, together with a comprehensive overview of the customers currently assigned to each employee as part of their sales responsibilities.

            For every employee included in the result set, provide a detailed enumeration of the client organizations, businesses, or accounts that fall under their management or sales portfolio. Where applicable, also include information describing the sales activity associated with those customers, such as recent orders, ongoing sales relationships, notable deals, or any other relevant commercial interactions that demonstrate the employee’s involvement in selling Dunder Mifflin paper products and related office supplies.

            The resulting output should therefore give a clear and informative picture of which customers belong to which employees, as well as a high-level understanding of the sales activity and customer relationships maintained by those employees within the broader operational context of the {region} branch.

            Limit the total number of employees returned to {limit}, while still including the associated customer and sales details for each employee in the most complete and structured manner possible.
            """);
    }
}
