using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using System.Collections.Immutable;

namespace VerticalSlice.Features.GamesConsoles.Queries.GetGamesByName;

public class GetGamesByNameHandler : IRequestHandler<GetGamesByNameQuery, GetGamesByNameResponse>
{
    private static string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VerticalSliceExample;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    public async Task<GetGamesByNameResponse> Handle(GetGamesByNameQuery request, CancellationToken cancellationToken)
    {
        string sql = @"SELECT g.[Id]
                              ,g.[Name]
                              ,g.[Publisher]
                              ,g.[Price]
                              ,g.[GamesConsoleId]
                              ,c.[Name] AS GamesConsoleName
                         FROM [dbo].[Games] g
                         JOIN [dbo].[GamesConsoles] c on g.[GamesConsoleId] = c.[Id]
                        WHERE g.[Name] LIKE @gameName";
        using var db = new SqlConnection(_connectionString);
        var games = await db.QueryAsync<GetGamesByNameResponseItem>(
            sql, 
            new { gameName = $"%{request.GameName}%" });

        return new GetGamesByNameResponse(games.ToImmutableArray());
    }
}
