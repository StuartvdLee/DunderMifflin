using DunderMifflinApi.Data;
using Microsoft.EntityFrameworkCore;

namespace DunderMifflinApi.Features.OrderDetail;

public static class EndpointGroup
{
    public static IEndpointRouteBuilder MapToOrderDetailEndpointGroup(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/orderdetails");

        group.MapGet("", async (DunderMifflinDbContext db) =>
            await db.Orderdetails.ToListAsync());

        group.MapGet("/{id:int}", async (int id, DunderMifflinDbContext db) =>
            await db.Orderdetails.FindAsync(id) is var od && od != null
                ? Results.Ok(od)
                : Results.NotFound());

        return group;
    }
}
