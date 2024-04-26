using Carter;
using VerticalSlice.Features.Games.Queries;
using VerticalSlice.Features.GamesConsoles.Queries;

namespace VerticalSlice.API;

public static class ServiceCollectionExtensions
{
    public static void AddApi(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddCarter();

        services.AddGamesConsolesQueries();
        services.AddGamesQueries();
    }
}
