using Application.Services.ApiTest.DtoModels.Models.Inventory;
using Infrastructure.Persistence.Contexts.ApiTest.ContextInventory;

namespace Application.Services.ApiTest.Queries.InventoryQueries
{
    public class InventoryQueries : IInventoryQueries
    {
        #region Properties

        private readonly IBaseRepository<Inventory, InventoryContext> _inventoryRepository = null!;
        private readonly ILogger<InventoryQueries> _logger = null!;
        private readonly IMapper _mapper = null!;

        #endregion

        #region Constructor

        public InventoryQueries(IBaseRepository<Inventory, InventoryContext> inventoryRepository,
                                ILogger<InventoryQueries> logger,
                                IMapper mapper)
        {
            _inventoryRepository = inventoryRepository ?? throw new ArgumentNullException(nameof(inventoryRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion

        #region IInventoryQueries implementation

        public async Task<List<DtoGetListInventoriesResponse>?> GetListAsync()
        {
            _logger.LogTrace($"InventoryQueries (GetListAsync) executed");
            var inventories = await _inventoryRepository.GetAsNoTracking().ToListAsync();
            return _mapper.Map<List<DtoGetListInventoriesResponse>>(inventories);
        }

        #endregion
    }
}
