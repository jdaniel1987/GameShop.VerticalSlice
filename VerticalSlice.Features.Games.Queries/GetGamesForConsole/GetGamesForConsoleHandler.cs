using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Immutable;

namespace VerticalSlice.Features.GamesConsoles.Queries.GetGamesForConsole;

public class GetGamesForConsoleHandler : IRequestHandler<GetGamesForConsoleQuery, GetGamesForConsoleResponse>
{
    private readonly IConfiguration _configuration;

    public GetGamesForConsoleHandler(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<GetGamesForConsoleResponse> Handle(GetGamesForConsoleQuery request, CancellationToken cancellationToken)
    {
        string sql = @"SELECT [Id]
                              ,[Name]
                              ,[Publisher]
                              ,[Price]
                         FROM [dbo].[Games]
                        WHERE [GamesConsoleId] = @gamesConsoleId";
        using var db = new SqlConnection(_configuration.GetConnectionString("ReadDB"));
        var games = await db.QueryAsync<GetGamesForConsoleResponseItem>(
            sql,
            new { gamesConsoleId = request.GamesConsoleId });

        return new GetGamesForConsoleResponse(games.ToImmutableArray());
    }
}
