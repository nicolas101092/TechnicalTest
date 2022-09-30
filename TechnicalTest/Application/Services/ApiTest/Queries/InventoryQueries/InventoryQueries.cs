using Application.Services.ApiTest.DtoModels.Models.Inventory.Responses;
using Infrastructure.Persistence.Contexts.ApiTest.ContextInventory;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.ApiTest.Queries.InventoryQueries
{
    public class InventoryQueries : IInventoryQueries
    {
        #region Properties

        private readonly IBaseRepository<Inventory, InventoryContext> _inventoryRepository = null!;
        private readonly IMapper _mapper = null!;

        #endregion

        #region Constructor

        public InventoryQueries(IBaseRepository<Inventory, InventoryContext> inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository ?? throw new ArgumentNullException(nameof(inventoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion

        #region IInventoryQueries implementation

        public async Task<List<DtoGetListInventoriesResponse>?> GetListAsync()
        {
            var inventories = await _inventoryRepository.GetAsNoTracking().ToListAsync();
            return _mapper.Map<List<DtoGetListInventoriesResponse>>(inventories);
        }

        #endregion
    }
}
