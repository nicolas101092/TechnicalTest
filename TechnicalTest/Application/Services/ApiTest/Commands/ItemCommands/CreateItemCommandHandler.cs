using Application.Services.ApiTest.Commands.InventoryCommands;
using Infrastructure.Persistence.Contexts.ApiTest.ContextInventory;

namespace Application.Services.ApiTest.Commands.ItemCommands
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, bool>
    {
        #region Properties

        private readonly IBaseRepository<Item, InventoryContext> _itemRepository = null!;
        private readonly IBaseRepository<Inventory, InventoryContext> _inventoryRepository = null!;
        private readonly IMapper _mapper = null!;

        #endregion

        #region Constructor

        public CreateItemCommandHandler(IBaseRepository<Item, InventoryContext> itemRepository, 
                                        IBaseRepository<Inventory, InventoryContext> inventoryRepository, 
                                        IMapper mapper)
        {
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
            _inventoryRepository = inventoryRepository ?? throw new ArgumentNullException(nameof(inventoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion

        #region IRequestHandler's implementation

        public async Task<bool> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            BadRequestExtension.ThrowIfFluentValidation(request, new CreateItemValidator());

            var idInventory = await _inventoryRepository.FindById(request.IdInventory);
            BadRequestExtension.ThrowIfNull(idInventory, "Inventory identifier does not exist");

            var response = await _itemRepository.Add(_mapper.Map<Item>(request));
            return response is not null;
        }

        #endregion
    }
}
