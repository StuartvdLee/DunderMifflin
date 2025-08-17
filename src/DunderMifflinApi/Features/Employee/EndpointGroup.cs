using DunderMifflinApi.Data;
using Microsoft.EntityFrameworkCore;

namespace DunderMifflinApi.Features.Employee;

public static class EndpointGroup
{
    public static IEndpointRouteBuilder MapToEmployeeEndpointGroup(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/employees");

        group.MapGet("", async (DunderMifflinDbContext db) =>
            await db.Employees.ToListAsync());

        group.MapGet("/{id:int}", async (int id, DunderMifflinDbContext db) =>
            await db.Employees.FindAsync(id) is var e && e != null
                ? Results.Ok(e)
                : Results.NotFound());

        return group;
    }
}
