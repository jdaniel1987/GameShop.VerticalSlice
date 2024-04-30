using Carter;
using MediatR;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace VerticalSlice.Features.Games.Commands.AddGame;

public class AddGameRoute : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        // Carter will create this URL for the API project, so we can split each route for each command
        app.MapPost("api/AddGame", async (IMediator mediator, AddGameCommand command) =>
        {
            return await mediator.Send(command);
        })
        .WithName(nameof(AddGameRoute))
        .WithTags("Games")
        .ProducesValidationProblem()
        .Produces(StatusCodes.Status201Created);
    }
}
