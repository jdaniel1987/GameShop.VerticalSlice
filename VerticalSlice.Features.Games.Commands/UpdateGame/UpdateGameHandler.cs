using Carter.ModelBinding;
using Dapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace VerticalSlice.Features.Games.Commands.UpdateGame;

public class UpdateGameHandler : IRequestHandler<UpdateGameCommand, IResult>
{
    private readonly IConfiguration _configuration;
    private readonly IValidator<UpdateGameCommand> _validator;

    public UpdateGameHandler(
        IConfiguration configuration,
        IValidator<UpdateGameCommand> validator)
    {
        _configuration = configuration;
        _validator = validator;
    }

    public async Task<IResult> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return Results.ValidationProblem(validationResult.GetValidationProblems());
        }

        string sql = @"UPDATE [Games]
                          SET
                              [Name] = @name,
                              [Publisher] = @publisher,
                              [Price] = @price,
                              [GamesConsoleId] = @gamesConsoleId
                        WHERE 
                              [Id] = @id";
        var db = new SqlConnection(_configuration.GetConnectionString("WriteDB"));
        await db.QueryAsync(sql, new
        {
            id = request.Id,
            name = request.Name,
            publisher = request.Publisher,
            price = request.Price,
            gamesConsoleId = request.GamesConsoleId,
        });

        return Results.Ok();
    }
}
