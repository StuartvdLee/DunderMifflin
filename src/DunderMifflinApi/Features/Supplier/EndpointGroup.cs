using DunderMifflinApi.Data;
using DunderMifflinApi.Features;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace DunderMifflinApi.Features.Supplier;

public class EndpointGroup : IEndpointGroup
{
    public void Map(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/suppliers");

        group.MapGet("", async (DunderMifflinDbContext db) =>
            await db.Suppliers.ToListAsync());

        group.MapGet("/{id:int}", async (int id, DunderMifflinDbContext db) =>
            await db.Suppliers.FindAsync(id) is var s && s != null
                ? Results.Ok(s)
                : Results.NotFound());
    }
}
