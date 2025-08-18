using DunderMifflinApi.Data;
using DunderMifflinApi.Features;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace DunderMifflinApi.Features.Employee;

public class EndpointGroup : IEndpointGroup
{
    public void Map(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/employees");

        group.MapGet("", async (DunderMifflinDbContext db) =>
            await db.Employees.ToListAsync());

        group.MapGet("/{id:int}", async (int id, DunderMifflinDbContext db) =>
            await db.Employees.FindAsync(id) is var e && e != null
                ? Results.Ok(e)
                : Results.NotFound());
    }
}
