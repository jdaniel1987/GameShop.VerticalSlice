using Dapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace VerticalSlice.Features.GamesConsoles.Commands.DeleteGamesConsole;

public class DeleteGamesConsoleHandler(IConfiguration configuration) : IRequestHandler<DeleteGamesConsoleCommand, IResult>
{
    private readonly IConfiguration _configuration = configuration;

    public async Task<IResult> Handle(DeleteGamesConsoleCommand request, CancellationToken cancellationToken)
    {
        var sql = @"DELETE FROM [GamesConsoles]       
                          WHERE [Id] = @id";
        var db = new SqlConnection(_configuration.GetConnectionString("WriteDB"));
        await db.QueryAsync(sql, new { id = request.GamesConsoleId });

        return Results.Ok();
    }
}
