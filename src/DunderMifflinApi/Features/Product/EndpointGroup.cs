using DunderMifflinApi.Data;
using Microsoft.EntityFrameworkCore;

namespace DunderMifflinApi.Features.Product;

public static class EndpointGroup
{
    public static IEndpointRouteBuilder MapToProductEndpointGroup(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/products");

        group.MapGet("", async (DunderMifflinDbContext db) =>
            await db.Products.ToListAsync());

        group.MapGet("/{id:int}", async (int id, DunderMifflinDbContext db) =>
            await db.Products.FindAsync(id) is var p && p != null
                ? Results.Ok(p)
                : Results.NotFound());

        return group;
    }
}
