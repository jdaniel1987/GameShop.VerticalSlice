using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using CleanArchitecture.Domain.Entities;

namespace VerticalSlice.Application.Features.Queries.GetGamesForConsole;

public class GetGamesForConsoleRoute : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/GamesForConsole/{GamesConsoleId:int}", (int GamesConsoleId, IMediator mediator) =>
        {
            return mediator.Send(new GetGamesForConsoleQuery(GamesConsoleId));
        })
        .WithName(nameof(GetGamesForConsoleRoute))
        .WithTags(nameof(Game));
    }
}
