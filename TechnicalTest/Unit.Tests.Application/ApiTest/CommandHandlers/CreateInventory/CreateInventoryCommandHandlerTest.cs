using App.Utils.Extensions.Helpers.PersonalExceptions;
using Application.Services.ApiTest.Commands.InventoryCommands;
using Infrastructure.Persistence.Contexts.ApiTest.ContextInventory;
using Microsoft.Extensions.Logging;
using UnitTests.Application.ApiRRHH.AutoMapper;

namespace Unit.Tests.Application.ApiTest.CommandHandlers.CreateInventory
{
    public class CreateInventoryCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly InventoryContext _context;
        private readonly IBaseRepository<Inventory, InventoryContext> _inventoryRepository;
        private readonly IRequestHandler<CreateInventoryCommand, bool> _createInventoryCommandHandler;

        public CreateInventoryCommandHandlerTest()
        {
            _context = ContextConfig.LoadContextInMemory<InventoryContext>();
            ContextConfig.InitializeDb(_context);
            _mapper = InventoryAutoMapper.GetIMapper();
            _inventoryRepository = new BaseRepository<Inventory, InventoryContext>(_context);
            _createInventoryCommandHandler = new CreateInventoryCommandHandler(new BaseRepository<Inventory, InventoryContext>(_context),
                                                                               new Logger<CreateInventoryCommandHandler>(new LoggerFactory()),
                                                                               _mapper);
        }

        #region Test methods

        [Fact(DisplayName = "Added a record")]
        public async Task Add_1_record()
        {
            await _createInventoryCommandHandler.Handle(new CreateInventoryCommand
            {
                Name = "Inventory"
            }, CancellationToken.None);

            var result = await _inventoryRepository.GetAsNoTracking().FirstOrDefaultAsync();

            result.Should().NotBeNull();
            result?.Id.Should().Be(1);
            result?.Name.Should().Be("Inventory");
        }

        [Fact(DisplayName = "Not added by name minimun length validation")]
        public async Task Not_added_by_name_minimun_length_validation()
        {
            await Assert.ThrowsAsync<BadRequestException>(async () => await _createInventoryCommandHandler.Handle(new CreateInventoryCommand
            {
                Name = "I",
            }, CancellationToken.None));
        }

        [Fact(DisplayName = "Not added by name maximum length validation")]
        public async Task Not_added_by_name_maximum_length_validation()
        {
            await Assert.ThrowsAsync<BadRequestException>(async () => await _createInventoryCommandHandler.Handle(new CreateInventoryCommand
            {
                Name = "namenamenanamenamenanamenamenanamenamenanamenamenanamenamenanamenamenanamenamenanamenamenanamenamenanamenamena",
            }, CancellationToken.None));
        }

        #endregion
    }
}
