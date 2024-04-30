using Carter;
using MediatR;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace VerticalSlice.Features.GamesConsoles.Commands.DeleteGamesConsole;

public class DeleteGamesConsoleRoute : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        // Carter will create this URL for the API project, so we can split each route for each command
        app.MapDelete("api/DeleteGamesConsole/{GamesConsoleId:int}", async (int GamesConsoleId, IMediator mediator) =>
        {
            return await mediator.Send(new DeleteGamesConsoleCommand(GamesConsoleId));
        })
        .WithName(nameof(DeleteGamesConsoleRoute))
        .WithTags("GamesConsoles")
        .ProducesValidationProblem()
        .Produces(StatusCodes.Status204NoContent);
    }
}
