using Carter.ModelBinding;
using Dapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using VerticalSlice.Features.Games.Commands.AddGame.Notification;

namespace VerticalSlice.Features.Games.Commands.AddGame;

public class AddGameHandler : IRequestHandler<AddGameCommand, IResult>
{
    private static string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VerticalSliceExample;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
    private readonly IPublisher _mediatorPublisher;
    private readonly IValidator<AddGameCommand> _validator;

    public AddGameHandler(
        IPublisher publisher,
        IValidator<AddGameCommand> validator)
    {
        _mediatorPublisher = publisher;
        _validator = validator;
    }

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

        var db = new SqlConnection(_connectionString);
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
