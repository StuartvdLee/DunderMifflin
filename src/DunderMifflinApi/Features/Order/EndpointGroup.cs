using DunderMifflinApi.Data;
using DunderMifflinApi.Features;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace DunderMifflinApi.Features.Order;

public class EndpointGroup : IEndpointGroup
{
    public void Map(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/orders");

        group.MapGet("", async (DunderMifflinDbContext db) =>
            await db.Orders.ToListAsync());

        group.MapGet("/{id:int}", async (int id, DunderMifflinDbContext db) =>
            await db.Orders.FindAsync(id) is var o && o != null
                ? Results.Ok(o)
                : Results.NotFound());
    }
}
