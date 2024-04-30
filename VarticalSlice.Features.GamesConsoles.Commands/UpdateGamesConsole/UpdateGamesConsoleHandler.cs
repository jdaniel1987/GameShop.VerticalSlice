using Dapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;

namespace VerticalSlice.Features.GamesConsoles.UpdateGamesConsole;

public class UpdateGamesConsoleHandler : IRequestHandler<UpdateGamesConsoleCommand, IResult>
{
    private static string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VerticalSliceExample;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    public async Task<IResult> Handle(UpdateGamesConsoleCommand request, CancellationToken cancellationToken)
    {
        string sql = @"UPDATE [GamesConsoles]
                          SET
                              [Name] = @name,
                              [Manufacturer] = @manufacturer,
                              [Price] = @price
                        WHERE 
                              [Id] = @id";
        var db = new SqlConnection(_connectionString);
        await db.QueryAsync(sql, new
        {
            id = request.Id,
            name = request.Name,
            manufacturer = request.Manufacturer,
            price = request.Price,
        });

        return Results.Ok();
    }
}
