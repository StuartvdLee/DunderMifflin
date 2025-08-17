using DunderMifflinApi.Data;
using Microsoft.EntityFrameworkCore;

namespace DunderMifflinApi.Features.Category;

public static class EndpointGroup
{
    public static IEndpointRouteBuilder MapToCategoryEndpointGroup(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/categories");
        
        group.MapGet("", async (DunderMifflinDbContext db) =>
            await db.Categories.ToListAsync());

        group.MapGet("/{id:int}", async (int id, DunderMifflinDbContext db) =>
            await db.Categories.FindAsync(id) is var c && c !=null
            ? Results.Ok(c)
            : Results.NotFound());

        return group;
    }
}