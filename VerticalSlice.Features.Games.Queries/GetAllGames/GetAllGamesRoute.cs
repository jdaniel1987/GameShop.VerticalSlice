using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace VerticalSlice.Features.Games.Queries.GetAllGames;

public class GetAllGamesRoute : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/Games", (IMediator mediator) =>
        {
            return mediator.Send(new GetAllGamesQuery());
        })
        .WithName(nameof(GetAllGamesRoute))
        .WithTags("Games");
    }
}
