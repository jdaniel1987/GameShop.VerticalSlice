using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Immutable;

namespace VerticalSlice.Features.Games.Queries.GetAllGames;

public class GetAllGamesHandler(IConfiguration configuration) : IRequestHandler<GetAllGamesQuery, GetAllGamesResponse>
{

    private readonly IConfiguration _configuration = configuration;

    public async Task<GetAllGamesResponse> Handle(GetAllGamesQuery request, CancellationToken cancellationToken)
    {
        string sql = @"SELECT g.[Id]
                              ,g.[Name]
                              ,g.[Publisher]
                              ,g.[Price]
                              ,g.[GamesConsoleId]
                              ,c.[Name] AS GamesConsoleName
                         FROM [dbo].[Games] g
                         JOIN [dbo].[GamesConsoles] c on g.[GamesConsoleId] = c.[Id]";
        using var db = new SqlConnection(_configuration.GetConnectionString("ReadDB"));
        var games = await db.QueryAsync<GetAllGamesResponseItem>(sql);

        return new GetAllGamesResponse(games.ToImmutableArray());
    }
}
