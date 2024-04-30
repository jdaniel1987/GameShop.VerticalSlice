using FluentValidation;

namespace VerticalSlice.Features.GamesConsoles.Commands.UpdateGamesConsole;

public class UpdateGamesConsoleCommandValidator : AbstractValidator<UpdateGamesConsoleCommand>
{
    public UpdateGamesConsoleCommandValidator()
    {
        RuleFor(r => r.Name).NotEmpty();
        RuleFor(r => r.Manufacturer).NotEmpty();
        RuleFor(r => r.Price).GreaterThan(0);
    }
}
