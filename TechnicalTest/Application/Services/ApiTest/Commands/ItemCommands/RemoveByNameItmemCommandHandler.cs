using Infrastructure.Persistence.Contexts.ApiTest.ContextInventory;

namespace Application.Services.ApiTest.Commands.ItemCommands
{
    public class RemoveByNameItmemCommandHandler : IRequestHandler<RemoveByNameItemCommand, bool>
    {
        #region Properties

        private readonly IBaseRepository<Item, InventoryContext> _itemRepository = null!;
        private readonly IMapper _mapper = null!;

        #endregion

        #region Constructor

        public RemoveByNameItmemCommandHandler(IBaseRepository<Item, InventoryContext> itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion

        #region IRequestHandler's implementation

        public async Task<bool> Handle(RemoveByNameItemCommand request, CancellationToken cancellationToken)
        {
            BadRequestExtension.ThrowIfFluentValidation(request, new RemoveByNameItemValidator());
            var item = await _itemRepository.Get(x => x.Name.ToLower() == request.Name.ToLower()).SingleOrDefaultAsync();

            NotFoundExtension.ThrowIfNull(item, request.Name);
            await _itemRepository.Remove(item);

            return true;
        }

        #endregion
    }
}
