using DunderMifflinApi.Data;
using DunderMifflinApi.Features;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace DunderMifflinApi.Features.OrderDetail;

public class EndpointGroup : IEndpointGroup
{
    public void Map(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/orderdetails");

        group.MapGet("", async (DunderMifflinDbContext db) =>
            await db.Orderdetails.ToListAsync());

        group.MapGet("/{id:int}", async (int id, DunderMifflinDbContext db) =>
            await db.Orderdetails.FindAsync(id) is var od && od != null
                ? Results.Ok(od)
                : Results.NotFound());
    }
}
