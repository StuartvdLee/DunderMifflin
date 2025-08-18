using Microsoft.AspNetCore.Routing;

namespace DunderMifflinApi.Features;

public interface IEndpointGroup
{
    void Map(IEndpointRouteBuilder endpoints);
}
