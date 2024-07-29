using Carter.ModelBinding;
using Dapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using VerticalSlice.Features.Games.Commands.AddGame.Notification;

namespace VerticalSlice.Features.Games.Commands.AddGame;

public class AddGameHandler(
    IConfiguration configuration,
    IPublisher publisher,
    IValidator<AddGameCommand> validator) : IRequestHandler<AddGameCommand, IResult>
{
    private readonly IConfiguration _configuration = configuration;
    private readonly IPublisher _mediatorPublisher = publisher;
    private readonly IValidator<AddGameCommand> _validator = validator;

    public async Task<IResult> Handle(AddGameCommand request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return Results.ValidationProblem(validationResult.GetValidationProblems());
        }

        var createdId = await AddGameToDB(request);
        await NotifyGameCreation(request);

        return Results.Created($"api/Games/{createdId}", null);
    }

    private async Task NotifyGameCreation(AddGameCommand command)
    {
        var notification = new AddGameNotification(command.Name, command.Publisher, command.Price, DateTimeOffset.UtcNow);
        await _mediatorPublisher.Publish(notification);
    }

    private async Task<int> AddGameToDB(AddGameCommand command)
    {
        var sql = @"INSERT INTO [Games] ([Name], [Publisher], [Price], [GamesConsoleId])
                         OUTPUT INSERTED.Id
                         VALUES (@name, @publisher, @price, @gamesConsoleId);";

        var db = new SqlConnection(_configuration.GetConnectionString("WriteDB"));
        return await db.QuerySingleAsync<int>(
            sql, 
            new
            {
                name = command.Name,
                publisher = command.Publisher,
                price = command.Price,
                gamesConsoleId = command.GamesConsoleId,
            });
    }
}
