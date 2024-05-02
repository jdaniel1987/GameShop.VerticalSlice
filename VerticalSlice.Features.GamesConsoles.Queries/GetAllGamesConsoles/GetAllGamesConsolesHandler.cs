using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Immutable;

namespace VerticalSlice.Application.Features.Queries.GetAllGamesConsoles;

public class GetAllGamesConsolesHandler : IRequestHandler<GetAllGamesConsolesQuery, GetAllGamesConsolesResponse>
{
    private readonly IConfiguration _configuration;

    public GetAllGamesConsolesHandler(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<GetAllGamesConsolesResponse> Handle(GetAllGamesConsolesQuery request, CancellationToken cancellationToken)
    {
        string sql = @"SELECT [Id]
                              ,[Name]
                              ,[Manufacturer]
                              ,[Price]
                         FROM [dbo].[GamesConsoles]";
        using var db = new SqlConnection(_configuration.GetConnectionString("ReadDB"));
        var gamesConsoles = await db.QueryAsync<GetAllGamesConsolesResponseItem>(sql);

        return new GetAllGamesConsolesResponse(gamesConsoles.ToImmutableArray());
    }
}
