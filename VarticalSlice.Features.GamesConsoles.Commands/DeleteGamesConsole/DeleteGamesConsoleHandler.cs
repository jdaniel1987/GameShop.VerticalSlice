using Dapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;

namespace VerticalSlice.Features.GamesConsoles.DeleteGamesConsole;

public class DeleteGamesConsoleHandler : IRequestHandler<DeleteGamesConsoleCommand, IResult>
{
    private static string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VerticalSliceExample;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    public async Task<IResult> Handle(DeleteGamesConsoleCommand request, CancellationToken cancellationToken)
    {
        var sql = @"DELETE FROM [GamesConsoles]       
                          WHERE [Id] = @id";
        var db = new SqlConnection(_connectionString);
        await db.QueryAsync(sql, new { id = request.GamesConsoleId });

        return Results.Ok();
    }
}
