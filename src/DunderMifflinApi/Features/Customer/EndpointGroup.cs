using DunderMifflinApi.Data;
using Microsoft.EntityFrameworkCore;

namespace DunderMifflinApi.Features.Customer;

public static class EndpointGroup
{
    public static IEndpointRouteBuilder MapToCustomerEndpointGroup(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/customers");

        group.MapGet("", async (DunderMifflinDbContext db) =>
            await db.Customers.ToListAsync());
        
        group.MapGet("/{id:int}", async (int id, DunderMifflinDbContext db) =>
            await db.Customers.FindAsync(id) is var c && c !=null
                ? Results.Ok(c)
                : Results.NotFound());

        return group;
    }
}