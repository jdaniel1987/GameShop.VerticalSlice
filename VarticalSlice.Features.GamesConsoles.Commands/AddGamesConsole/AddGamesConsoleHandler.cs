using Carter.ModelBinding;
using Dapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace VerticalSlice.Features.GamesConsoles.Commands.AddGamesConsole;

public class AddGamesConsoleHandler : IRequestHandler<AddGamesConsoleCommand, IResult>
{
    private readonly IConfiguration _configuration;
    private readonly IValidator<AddGamesConsoleCommand> _validator;

    public AddGamesConsoleHandler(
        IConfiguration configuration,
        IValidator<AddGamesConsoleCommand> validator)
    {
        _configuration = configuration;
        _validator = validator;
    }

    public async Task<IResult> Handle(AddGamesConsoleCommand request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return Results.ValidationProblem(validationResult.GetValidationProblems());
        }

        var sql = @"INSERT INTO [GamesConsoles] ([Name], [Manufacturer], [Price])
                         OUTPUT INSERTED.Id
                         VALUES (@name, @manufacturer, @price);";

        var db = new SqlConnection(_configuration.GetConnectionString("WriteDB"));
        var id = await db.QuerySingleAsync<int>(
            sql,
            new
            {
                name = request.Name,
                manufacturer = request.Manufacturer,
                price = request.Price,
            });

        return Results.Created($"api/GamesConsole/{id}", null);
    }
}
