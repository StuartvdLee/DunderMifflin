using System.Text.Json.Serialization;
using DunderMifflinApi.Data;
using DunderMifflinApi.Features.Category;
using DunderMifflinApi.Features.Customer;
using DunderMifflinApi.Features.Employee;
using DunderMifflinApi.Features.EmployeeStatus;
using DunderMifflinApi.Features.Order;
using DunderMifflinApi.Features.OrderDetail;
using DunderMifflinApi.Features.Product;
using DunderMifflinApi.Features.Region;
using DunderMifflinApi.Features.Shipper;
using DunderMifflinApi.Features.Supplier;
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

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapToCategoryEndpointGroup();
app.MapToCustomerEndpointGroup();
app.MapToEmployeeEndpointGroup();
app.MapToEmployeeStatusEndpointGroup();
app.MapToOrderEndpointGroup();
app.MapToOrderDetailEndpointGroup();
app.MapToProductEndpointGroup();
app.MapToRegionEndpointGroup();
app.MapToShipperEndpointGroup();
app.MapToSupplierEndpointGroup();

app.Run();
