using Application.Services.ApiTest.DtoModels.Models.Inventory.Requests;
using Infrastructure.Persistence.Contexts.ApiTest.ContextInventory;

namespace Application.Services.ApiTest.Commands.InventoryCommands
{
    public class CreateInventoryCommandHandler : IRequestHandler<DtoCreateInventoryRequest, bool>
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

        public async Task<bool> Handle(DtoCreateInventoryRequest request, CancellationToken cancellationToken)
        {
            var response = await _inventoryRepository.Add(_mapper.Map<Inventory>(request));
            return response is not null;
        }

        #endregion
    }
}
