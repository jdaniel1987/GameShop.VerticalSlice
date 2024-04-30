using Carter;
using MediatR;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace VerticalSlice.Features.GamesConsoles.UpdateGamesConsole;

public class UpdateGamesConsoleRoute : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        // Carter will create this URL for the API project, so we can split each route for each command
        app.MapPut("api/UpdateGamesConsole", async (IMediator mediator, UpdateGamesConsoleCommand command) =>
        {
            return await mediator.Send(command);
        })
        .WithName(nameof(UpdateGamesConsoleRoute))
        .WithTags("GamesConsoles")
        .ProducesValidationProblem()
        .Produces(StatusCodes.Status200OK);
    }
}
