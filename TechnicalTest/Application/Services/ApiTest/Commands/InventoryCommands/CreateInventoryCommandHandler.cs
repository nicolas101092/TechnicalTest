using Infrastructure.Persistence.Contexts.ApiTest.ContextInventory;

namespace Application.Services.ApiTest.Commands.InventoryCommands
{
    public class CreateInventoryCommandHandler : IRequestHandler<CreateInventoryCommand, bool>
    {
        #region Properties

        private readonly IBaseRepository<Inventory, InventoryContext> _inventoryRepository = null!;
        private readonly ILogger<CreateInventoryCommandHandler> _logger = null!;
        private readonly IMapper _mapper = null!;

        #endregion

        #region Constructor

        public CreateInventoryCommandHandler(IBaseRepository<Inventory, InventoryContext> inventoryRepository, 
                                             ILogger<CreateInventoryCommandHandler> logger,
                                             IMapper mapper)
        {
            _inventoryRepository = inventoryRepository ?? throw new ArgumentNullException(nameof(inventoryRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion

        #region IRequestHandler's implementation

        public async Task<bool> Handle(CreateInventoryCommand request, CancellationToken cancellationToken)
        {
            _logger.LogTrace($"CreateInventoryCommandHandler executed");

            BadRequestExtension.ThrowIfFluentValidation(request, new CreateInventoryValidator());
            var response = await _inventoryRepository.Add(_mapper.Map<Inventory>(request));

            return response is not null;
        }

        #endregion
    }
}
