using DunderMifflinApi.Data;
using Microsoft.EntityFrameworkCore;

namespace DunderMifflinApi.Features.Order;

public static class EndpointGroup
{
    public static IEndpointRouteBuilder MapToOrderEndpointGroup(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/orders");

        group.MapGet("", async (DunderMifflinDbContext db) =>
            await db.Orders.ToListAsync());

        group.MapGet("/{id:int}", async (int id, DunderMifflinDbContext db) =>
            await db.Orders.FindAsync(id) is var o && o != null
                ? Results.Ok(o)
                : Results.NotFound());

        return group;
    }
}
