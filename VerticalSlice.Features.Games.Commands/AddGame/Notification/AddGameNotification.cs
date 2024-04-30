using MediatR;

namespace VerticalSlice.Features.Games.Commands.AddGame.Notification;

public record AddGameNotification(
    string Name,
    string Publisher,
    double Price,
    DateTimeOffset ReleaseDate) : INotification;
