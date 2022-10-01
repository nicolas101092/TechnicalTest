using Application.Services.ApiTest.DtoModels.Models.Item;
using Infrastructure.Persistence.Contexts.ApiTest.ContextInventory;

namespace Application.Services.ApiTest.Queries.ItemQueries
{
    public class ItemQueries : IItemQueries
    {
        #region Properties

        private readonly IBaseRepository<Item, InventoryContext> _itemRepository = null!;
        private readonly IMapper _mapper = null!;

        #endregion

        #region Constructor

        public ItemQueries(IBaseRepository<Item, InventoryContext> itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion

        #region IInventoryQueries implementation

        public async Task<List<DtoGetListItemsResponse>?> GetListAsync()
        {
            var items = await _itemRepository.GetAsNoTracking().ToListAsync();
            return _mapper.Map<List<DtoGetListItemsResponse>>(items);
        }

        public async Task<DtoGetItemResponse?> GetByIdAsync(int id)
        {
            var item = await _itemRepository.GetAsNoTracking(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<DtoGetItemResponse>(item);
        }

        #endregion
    }
}
