using DunderMifflinApi.Data;
using DunderMifflinApi.Features.Category;
using DunderMifflinApi.Features.Customer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DunderMifflinDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapToCategoryEndpointGroup();
app.MapToCustomerEndpointGroup();

app.Run();