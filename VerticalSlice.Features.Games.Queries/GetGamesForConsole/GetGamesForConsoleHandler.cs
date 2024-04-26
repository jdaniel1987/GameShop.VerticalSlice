using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using System.Collections.Immutable;

namespace VerticalSlice.Features.GamesConsoles.Queries.GetGamesForConsole;

public class GetGamesForConsoleHandler : IRequestHandler<GetGamesForConsoleQuery, GetGamesForConsoleResponse>
{
    private static string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VerticalSliceExample;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    public async Task<GetGamesForConsoleResponse> Handle(GetGamesForConsoleQuery request, CancellationToken cancellationToken)
    {
        string sql = @"SELECT [Id]
                              ,[Name]
                              ,[Publisher]
                              ,[Price]
                         FROM [dbo].[Games]
                        WHERE [GamesConsoleId] = @gamesConsoleId";
        using var db = new SqlConnection(_connectionString);
        var games = await db.QueryAsync<GetGamesForConsoleResponseItem>(
            sql,
            new { gamesConsoleId = request.GamesConsoleId });

        return new GetGamesForConsoleResponse(games.ToImmutableArray());
    }
}
