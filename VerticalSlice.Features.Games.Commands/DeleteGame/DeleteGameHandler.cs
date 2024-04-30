using Dapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;

namespace VerticalSlice.Features.Games.Commands.DeleteGame;

public class DeleteGameHandler : IRequestHandler<DeleteGameCommand, IResult>
{
    private static string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VerticalSliceExample;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    public async Task<IResult> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
    {
        var sql = @"DELETE FROM [Games]       
                          WHERE [Id] = @id";
        var db = new SqlConnection(_connectionString);
        await db.QueryAsync(sql, new { id = request.GameId });

        return Results.Ok();
    }
}
