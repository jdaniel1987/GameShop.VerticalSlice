using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using VerticalSlice.Features.Games.Commands.AddGame;
using VerticalSlice.Features.Games.Commands.UpdateGame;

namespace VerticalSlice.Features.Games.Queries;

public static class ServiceCollectionExtensions
{
    public static void AddGamesCommands(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddTransient<IValidator<AddGameCommand>, AddGameCommandValidator>();
        services.AddTransient<IValidator<UpdateGameCommand>, UpdateGameCommandValidator>();
    }
}
