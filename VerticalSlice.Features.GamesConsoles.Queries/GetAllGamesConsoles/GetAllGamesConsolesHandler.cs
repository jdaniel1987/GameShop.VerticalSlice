using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using System.Collections.Immutable;

namespace VerticalSlice.Application.Features.Queries.GetAllGamesConsoles;

public class GetAllGamesConsolesHandler : IRequestHandler<GetAllGamesConsolesQuery, GetAllGamesConsolesResponse>
{
    private static string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VerticalSliceExample;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
    
    public async Task<GetAllGamesConsolesResponse> Handle(GetAllGamesConsolesQuery request, CancellationToken cancellationToken)
    {
        string sql = @"SELECT [Id]
                              ,[Name]
                              ,[Manufacturer]
                              ,[Price]
                         FROM [dbo].[GamesConsoles]";
        using var db = new SqlConnection(_connectionString);
        var gamesConsoles = await db.QueryAsync<GetAllGamesConsolesResponseItem>(sql);

        return new GetAllGamesConsolesResponse(gamesConsoles.ToImmutableArray());
    }
}
