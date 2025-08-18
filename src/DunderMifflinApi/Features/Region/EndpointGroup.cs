using DunderMifflinApi.Data;
using DunderMifflinApi.Features;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace DunderMifflinApi.Features.Region;

public class EndpointGroup : IEndpointGroup
{
    public void Map(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/regions");

        group.MapGet("", async (DunderMifflinDbContext db) =>
            await db.Regions.ToListAsync());

        group.MapGet("/{id:int}", async (int id, DunderMifflinDbContext db) =>
            await db.Regions.FindAsync(id) is var r && r != null
                ? Results.Ok(r)
                : Results.NotFound());
    }
}
