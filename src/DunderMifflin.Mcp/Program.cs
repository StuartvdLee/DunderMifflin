using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using ModelContextProtocol.AspNetCore;
using ModelContextProtocol.Server;
using System;
using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole(o =>
{
    // Log everything to stderr so MCP clients receive logs
    o.LogToStandardErrorThreshold = LogLevel.Trace;
});

builder.Services.AddHttpClient("Api", http =>
    http.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]!));
builder.Services.AddTransient(sp =>
    sp.GetRequiredService<IHttpClientFactory>().CreateClient("Api"));

builder.Services
    .AddMcpServer()
    .WithHttpTransport()
    .WithToolsFromAssembly();

var app = builder.Build();

app.MapMcp("/mcp");

await app.RunAsync();

