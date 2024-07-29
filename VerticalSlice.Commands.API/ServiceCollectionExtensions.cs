using Carter;
using VerticalSlice.Features.Games.Commands;
using VerticalSlice.Features.GamesConsoles.Commands;

namespace VerticalSlice.Commands.API;

public static class ServiceCollectionExtensions
{
    public static void AddApi(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddCarter();

        services.AddGamesConsolesCommands();
        services.AddGamesCommands();
    }
}
