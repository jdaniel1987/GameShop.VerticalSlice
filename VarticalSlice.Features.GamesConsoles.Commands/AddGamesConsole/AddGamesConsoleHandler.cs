using Dapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;

namespace VerticalSlice.Features.GamesConsoles.AddGamesConsole;

public class AddGamesConsoleHandler : IRequestHandler<AddGamesConsoleCommand, IResult>
{
    private static string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VerticalSliceExample;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    public async Task<IResult> Handle(AddGamesConsoleCommand request, CancellationToken cancellationToken)
    {
        var sql = @"INSERT INTO [GamesConsoles] ([Name], [Manufacturer], [Price])
                         OUTPUT INSERTED.Id
                         VALUES (@name, @manufacturer, @price);";

        var db = new SqlConnection(_connectionString);
        var id = await db.QuerySingleAsync<int>(
            sql,
            new
            {
                name = request.Name,
                manufacturer = request.Manufacturer,
                price = request.Price,
            });

        return Results.Created($"api/GamesConsole/{id}", null);
    }
}
