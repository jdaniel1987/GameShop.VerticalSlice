using FluentValidation;

namespace VerticalSlice.Features.Games.Commands.UpdateGame;

public class UpdateGameCommandValidator : AbstractValidator<UpdateGameCommand>
{
    public UpdateGameCommandValidator()
    {
        RuleFor(r => r.Name).NotEmpty();
        RuleFor(r => r.Publisher).NotEmpty();
        RuleFor(r => r.Price).GreaterThan(0);
    }
}
