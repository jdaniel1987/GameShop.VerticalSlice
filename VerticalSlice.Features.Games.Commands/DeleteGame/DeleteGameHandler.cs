using Dapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace VerticalSlice.Features.Games.Commands.DeleteGame;

public class DeleteGameHandler : IRequestHandler<DeleteGameCommand, IResult>
{
    private readonly IConfiguration _configuration;

    public DeleteGameHandler(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<IResult> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
    {
        var sql = @"DELETE FROM [Games]       
                          WHERE [Id] = @id";
        var db = new SqlConnection(_configuration.GetConnectionString("WriteDB"));
        await db.QueryAsync(sql, new { id = request.GameId });

        return Results.Ok();
    }
}
