using App.Utils.Extensions.Helpers.PersonalExceptions;
using App.Utils.Middlewares.Core.PersonalExceptions;
using Application.Services.ApiTest.Commands.InventoryCommands;
using Application.Services.ApiTest.Queries.ItemQueries;
using Infrastructure.Persistence.Contexts.ApiTest.ContextInventory;
using Microsoft.Extensions.Logging;
using UnitTests.Application.ApiRRHH.AutoMapper;

namespace Unit.Tests.Application.ApiTest.CommandHandlers.CreateInventory
{
    public class ItemQueriesTest
    {
        private readonly IMapper _mapper;
        private readonly InventoryContext _context;
        private readonly IBaseRepository<Item, InventoryContext> _itemRepository;
        private readonly IBaseRepository<Inventory, InventoryContext> _inventoryRepository;
        private readonly IItemQueries _itemQueries;

        public ItemQueriesTest()
        {
            _context = ContextConfig.LoadContextInMemory<InventoryContext>();
            ContextConfig.InitializeDb(_context);
            _mapper = InventoryAutoMapper.GetIMapper();
            _itemRepository = new BaseRepository<Item, InventoryContext>(_context);
            _inventoryRepository = new BaseRepository<Inventory, InventoryContext>(_context);
            _itemQueries = new ItemQueries(new BaseRepository<Item, InventoryContext>(_context),
                                           new Logger<ItemQueries>(new LoggerFactory()),
                                           _mapper);

            _inventoryRepository.AddListFromJsonFile(UrlDataJsonFilesContants.INVENTORY_GET_ITEM_BY_ID).Wait();
            _itemRepository.AddListFromJsonFile(UrlDataJsonFilesContants.ITEM_GET_ITEM_BY_ID).Wait();
        }

        #region Test methods

        [Fact(DisplayName = "Get by Id a record")]
        public async Task Get_by_Id_a_record()
        {
            var result = await _itemQueries.GetByIdAsync(1);

            result.Should().NotBeNull();
            result?.Id.Should().Be(1);
            result?.Name.Should().Be("Item");
        }

        [Fact(DisplayName = "Not obtained because id not found")]
        public async Task Not_obtained_because_id_not_found()
        {
            await Assert.ThrowsAsync<NotFoundException>(async () => await _itemQueries.GetByIdAsync(3));
        }

        #endregion
    }
}
