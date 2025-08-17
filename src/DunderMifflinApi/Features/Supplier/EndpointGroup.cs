using DunderMifflinApi.Data;
using Microsoft.EntityFrameworkCore;

namespace DunderMifflinApi.Features.Supplier;

public static class EndpointGroup
{
    public static IEndpointRouteBuilder MapToSupplierEndpointGroup(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/suppliers");

        group.MapGet("", async (DunderMifflinDbContext db) =>
            await db.Suppliers.ToListAsync());

        group.MapGet("/{id:int}", async (int id, DunderMifflinDbContext db) =>
            await db.Suppliers.FindAsync(id) is var s && s != null
                ? Results.Ok(s)
                : Results.NotFound());

        return group;
    }
}
