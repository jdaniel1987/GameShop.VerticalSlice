using FluentValidation;

namespace VerticalSlice.Features.GamesConsoles.Commands.AddGamesConsole;

public class AddGamesConsoleCommandValidator : AbstractValidator<AddGamesConsoleCommand>
{
    public AddGamesConsoleCommandValidator()
    {
        RuleFor(r => r.Name).NotEmpty();
        RuleFor(r => r.Manufacturer).NotEmpty();
        RuleFor(r => r.Price).GreaterThan(0);
    }
}
