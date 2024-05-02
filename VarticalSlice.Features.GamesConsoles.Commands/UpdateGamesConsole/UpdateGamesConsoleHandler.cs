using Carter.ModelBinding;
using Dapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace VerticalSlice.Features.GamesConsoles.Commands.UpdateGamesConsole;

public class UpdateGamesConsoleHandler : IRequestHandler<UpdateGamesConsoleCommand, IResult>
{

    private readonly IConfiguration _configuration; 
    private readonly IValidator<UpdateGamesConsoleCommand> _validator;

    public UpdateGamesConsoleHandler(
        IConfiguration configuration,
        IValidator<UpdateGamesConsoleCommand> validator)
    {
        _configuration = configuration;
        _validator = validator;
    }

    public async Task<IResult> Handle(UpdateGamesConsoleCommand request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return Results.ValidationProblem(validationResult.GetValidationProblems());
        }

        string sql = @"UPDATE [GamesConsoles]
                          SET
                              [Name] = @name,
                              [Manufacturer] = @manufacturer,
                              [Price] = @price
                        WHERE 
                              [Id] = @id";
        var db = new SqlConnection(_configuration.GetConnectionString("WriteDB"));
        await db.QueryAsync(sql, new
        {
            id = request.Id,
            name = request.Name,
            manufacturer = request.Manufacturer,
            price = request.Price,
        });

        return Results.Ok();
    }
}
