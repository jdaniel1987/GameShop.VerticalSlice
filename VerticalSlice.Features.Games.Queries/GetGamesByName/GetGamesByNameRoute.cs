using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace VerticalSlice.Features.GamesConsoles.Queries.GetGamesByName;

public class GetGamesByNameConsolesRoute : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/GamesByName/{GameName}", (string GameName, IMediator mediator) =>
        {
            return mediator.Send(new GetGamesByNameQuery(GameName));
        })
        .WithName(nameof(GetGamesByNameConsolesRoute));
    }
}
