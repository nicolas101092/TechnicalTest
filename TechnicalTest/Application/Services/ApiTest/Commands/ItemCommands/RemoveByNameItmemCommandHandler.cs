using Domain.ApiTest.Events;
using Infrastructure.Persistence.Contexts.ApiTest.ContextInventory;

namespace Application.Services.ApiTest.Commands.ItemCommands
{
    public class RemoveByNameItmemCommandHandler : IRequestHandler<RemoveByNameItemCommand, bool>
    {
        #region Properties

        private readonly IBaseRepository<Item, InventoryContext> _itemRepository = null!;
        private readonly ILogger<RemoveByNameItmemCommandHandler> _logger = null!;

        #endregion

        #region Constructor

        public RemoveByNameItmemCommandHandler(IBaseRepository<Item, InventoryContext> itemRepository, 
                                               ILogger<RemoveByNameItmemCommandHandler> logger)
        {
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        #endregion

        #region IRequestHandler's implementation

        public async Task<bool> Handle(RemoveByNameItemCommand request, CancellationToken cancellationToken)
        {
            _logger.LogTrace($"RemoveByNameItmemCommandHandler executed");
            BadRequestExtension.ThrowIfFluentValidation(request, new RemoveByNameItemValidator());
            var item = await _itemRepository.Get(x => x.Name.ToLower() == request.Name.ToLower()).SingleOrDefaultAsync();

            NotFoundExtension.ThrowIfNull(item, request.Name);

            item.DomainEvents.Add(new ItemRemovedDomainEvent(item));
            await _itemRepository.SaveChanges();

            await _itemRepository.Remove(item);

            return true;
        }

        #endregion
    }
}
