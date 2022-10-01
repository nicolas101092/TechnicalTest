using Infrastructure.Persistence.Contexts.ApiTest.ContextInventory;

namespace Application.Services.ApiTest.Commands.InventoryCommands
{
    public class CreateInventoryCommandHandler : IRequestHandler<CreateInventoryCommand, bool>
    {
        #region Properties

        private readonly IBaseRepository<Inventory, InventoryContext> _inventoryRepository = null!;
        private readonly IMapper _mapper = null!;

        #endregion

        #region Constructor

        public CreateInventoryCommandHandler(IBaseRepository<Inventory, InventoryContext> inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository ?? throw new ArgumentNullException(nameof(inventoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion

        #region IRequestHandler's implementation

        public async Task<bool> Handle(CreateInventoryCommand request, CancellationToken cancellationToken)
        {
            BadRequestExtension.ThrowIfFluentValidation(request, new CreateInventoryValidator());
            var response = await _inventoryRepository.Add(_mapper.Map<Inventory>(request));
            return response is not null;
        }

        #endregion
    }
}
