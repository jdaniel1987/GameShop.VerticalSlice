using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Immutable;

namespace VerticalSlice.Features.GamesConsoles.Queries.GetGamesByName;

public class GetGamesByNameHandler : IRequestHandler<GetGamesByNameQuery, GetGamesByNameResponse>
{
    private readonly IConfiguration _configuration;

    public GetGamesByNameHandler(IConfiguration configuration)
    {
        _configuration = configuration;
    }
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
        using var db = new SqlConnection(_configuration.GetConnectionString("ReadDB"));
        var games = await db.QueryAsync<GetGamesByNameResponseItem>(
            sql, 
            new { gameName = $"%{request.GameName}%" });

        return new GetGamesByNameResponse(games.ToImmutableArray());
    }
}
