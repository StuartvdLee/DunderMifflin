var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddConsole();

builder.Services.AddHttpClient("Api", http =>
    http.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]!));
builder.Services.AddTransient(sp =>
    sp.GetRequiredService<IHttpClientFactory>().CreateClient("Api"));

builder.Services
    .AddMcpServer()
    .WithHttpTransport()
    .WithToolsFromAssembly();

var app = builder.Build();

app.MapMcp();

await app.RunAsync();