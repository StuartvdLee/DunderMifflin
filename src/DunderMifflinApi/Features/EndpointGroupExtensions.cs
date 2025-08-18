using System.Reflection;

namespace DunderMifflinApi.Features;

public static class EndpointGroupExtensions
{
    public static IServiceCollection AddEndpointGroups(this IServiceCollection services)
    {
        var endpointGroupType = typeof(IEndpointGroup);
        var assembly = Assembly.GetExecutingAssembly();

        foreach (var type in assembly.GetTypes().Where(t => !t.IsAbstract && !t.IsInterface && endpointGroupType.IsAssignableFrom(t)))
        {
            services.AddSingleton(endpointGroupType, type);
        }

        return services;
    }

    public static WebApplication MapEndpointGroups(this WebApplication app)
    {
        var groups = app.Services.GetServices<IEndpointGroup>();
        foreach (var group in groups)
        {
            group.Map(app);
        }

        return app;
    }
}
