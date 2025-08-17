using DunderMifflinApi.Data;
using Microsoft.EntityFrameworkCore;

namespace DunderMifflinApi.Features.Shipper;

public static class EndpointGroup
{
    public static IEndpointRouteBuilder MapToShipperEndpointGroup(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/shippers");

        group.MapGet("", async (DunderMifflinDbContext db) =>
            await db.Shippers.ToListAsync());

        group.MapGet("/{id:int}", async (int id, DunderMifflinDbContext db) =>
            await db.Shippers.FindAsync(id) is var s && s != null
                ? Results.Ok(s)
                : Results.NotFound());

        return group;
    }
}
