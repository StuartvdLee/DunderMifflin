using DunderMifflinApi.Data;
using Microsoft.EntityFrameworkCore;

namespace DunderMifflinApi.Features.Region;

public static class EndpointGroup
{
    public static IEndpointRouteBuilder MapToRegionEndpointGroup(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/regions");

        group.MapGet("", async (DunderMifflinDbContext db) =>
            await db.Regions.ToListAsync());

        group.MapGet("/{id:int}", async (int id, DunderMifflinDbContext db) =>
            await db.Regions.FindAsync(id) is var r && r != null
                ? Results.Ok(r)
                : Results.NotFound());

        return group;
    }
}
