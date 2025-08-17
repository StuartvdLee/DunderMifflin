using DunderMifflinApi.Data;
using Microsoft.EntityFrameworkCore;

namespace DunderMifflinApi.Features.EmployeeStatus;

public static class EndpointGroup
{
    public static IEndpointRouteBuilder MapToEmployeeStatusEndpointGroup(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/employeestatuses");

        group.MapGet("", async (DunderMifflinDbContext db) =>
            await db.Employeestatuses.ToListAsync());

        group.MapGet("/{id:int}", async (int id, DunderMifflinDbContext db) =>
            await db.Employeestatuses.FindAsync(id) is var es && es != null
                ? Results.Ok(es)
                : Results.NotFound());

        return group;
    }
}
