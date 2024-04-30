using Carter.ModelBinding;
using Dapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;

namespace VerticalSlice.Features.GamesConsoles.Commands.UpdateGamesConsole;

public class UpdateGamesConsoleHandler : IRequestHandler<UpdateGamesConsoleCommand, IResult>
{
    private static string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VerticalSliceExample;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
    private readonly IValidator<UpdateGamesConsoleCommand> _validator;

    public UpdateGamesConsoleHandler(IValidator<UpdateGamesConsoleCommand> validator)
    {
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
        var db = new SqlConnection(_connectionString);
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
