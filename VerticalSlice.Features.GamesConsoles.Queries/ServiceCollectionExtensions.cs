using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace VerticalSlice.Features.GamesConsoles.Queries;

public static class ServiceCollectionExtensions
{
    public static void AddGamesConsolesQueries(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}
