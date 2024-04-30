using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace VerticalSlice.Features.Games.Queries;

public static class ServiceCollectionExtensions
{
    public static void AddGamesCommands(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}
