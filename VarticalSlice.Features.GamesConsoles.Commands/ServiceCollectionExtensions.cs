using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace VerticalSlice.Features.GamesConsoles.Commands;

public static class ServiceCollectionExtensions
{
    public static void AddGamesConsolesCommands(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}
