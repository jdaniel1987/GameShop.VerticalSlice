using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using VerticalSlice.Features.GamesConsoles.Commands.AddGamesConsole;
using VerticalSlice.Features.GamesConsoles.Commands.UpdateGamesConsole;

namespace VerticalSlice.Features.GamesConsoles.Commands;

public static class ServiceCollectionExtensions
{
    public static void AddGamesConsolesCommands(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddTransient<IValidator<AddGamesConsoleCommand>, AddGamesConsoleCommandValidator>();
        services.AddTransient<IValidator<UpdateGamesConsoleCommand>, UpdateGamesConsoleCommandValidator>();
    }
}
