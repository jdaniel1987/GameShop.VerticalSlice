using MediatR;
using Microsoft.Extensions.Logging;

namespace VerticalSlice.Features.Games.Commands.AddGame.Notification;

public class AddGameNotificationEventHandler(ILogger<AddGameNotificationEventHandler> logger) : INotificationHandler<AddGameNotification>
{
    private readonly ILogger<AddGameNotificationEventHandler> _logger = logger;

    public async Task Handle(AddGameNotification notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"{notification.ReleaseDate.ToString("dd-MM-yyyy HH:mm")} - New Game from {notification.Publisher}");
        _logger.LogInformation($"Product {notification.Name} with price {notification.Price}€");

        await Task.Delay(1000, cancellationToken);
    }
}
