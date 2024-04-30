using FluentValidation;

namespace VerticalSlice.Features.Games.Commands.AddGame;

public class AddGameCommandValidator : AbstractValidator<AddGameCommand>
{
    public AddGameCommandValidator()
    {
        RuleFor(r => r.Name).NotEmpty();
        RuleFor(r => r.Publisher).NotEmpty();
        RuleFor(r => r.Price).GreaterThan(0);
        RuleFor(r => r.GamesConsoleId).GreaterThan(0);
    }
}
