using Application.Services.ApiTest.DtoModels.Models.Item;
using Infrastructure.Persistence.Contexts.ApiTest.ContextInventory;

namespace Application.Services.ApiTest.Queries.ItemQueries
{
    public class ItemQueries : IItemQueries
    {
        #region Properties

        private readonly IBaseRepository<Item, InventoryContext> _itemRepository = null!;
        private readonly ILogger<ItemQueries> _logger = null!;
        private readonly IMapper _mapper = null!;

        #endregion

        #region Constructor

        public ItemQueries(IBaseRepository<Item, InventoryContext> itemRepository,
                           ILogger<ItemQueries> logger, 
                           IMapper mapper)
        {
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion

        #region IInventoryQueries implementation

        public async Task<List<DtoGetListItemsResponse>?> GetListAsync()
        {
            _logger.LogTrace($"ItemQueries (GetListAsync) executed");
            var items = await _itemRepository.GetAsNoTracking().ToListAsync();
            return _mapper.Map<List<DtoGetListItemsResponse>>(items);
        }

        public async Task<DtoGetItemResponse?> GetByIdAsync(int id)
        {
            _logger.LogTrace($"ItemQueries (GetByIdAsync {id}) executed");
            var item = await _itemRepository.GetAsNoTracking(x => x.Id == id).FirstOrDefaultAsync();
            NotFoundExtension.ThrowIfNull(item, id);

            return _mapper.Map<DtoGetItemResponse>(item);
        }

        #endregion
    }
}
