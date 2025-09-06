using DunderMifflin.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DunderMifflinDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services
    .AddMcpServer()
    .WithToolsFromAssembly();

var app = builder.Build();

app.MapMcp();

app.Run();
