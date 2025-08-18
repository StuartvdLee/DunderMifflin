using System.Text.Json.Serialization;
using DunderMifflinApi.Data;
using DunderMifflinApi.Features;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.MaxDepth = 256;
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddDbContext<DunderMifflinDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddEndpointGroups();

var app = builder.Build();

app.MapEndpointGroups();

app.Run();
