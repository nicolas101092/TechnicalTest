using Domain.ApiTest.Events;

namespace Application.Services.ApiTest.DomainEventHandlers
{
    public class ItemRemovedDomainEventHandler : INotificationHandler<ItemRemovedDomainEvent>
    {
        private readonly ILogger<ItemRemovedDomainEventHandler> _logger;

        public ItemRemovedDomainEventHandler(ILogger<ItemRemovedDomainEventHandler> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Handle(ItemRemovedDomainEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Item {notification.Item.Name} has been removed");
        }
    }
}
