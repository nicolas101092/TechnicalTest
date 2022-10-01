using Application.Services.ApiTest.Commands.InventoryCommands;
using Application.Services.ApiTest.Queries.InventoryQueries;

namespace ApiTest.Controllers
{
    public class InventoriesController : GenericController
    {
        #region Properties

        private readonly ISender _mediator = null!;
        private readonly IInventoryQueries _inventoryQueries = null!;

        #endregion

        #region Constructor

        /// <summary>
        /// Inventory controller constructor
        /// </summary>
        /// <param name="mediator">Sender's interface</param>
        /// <param name="inventoryQueries">IInventoryQueries interface</param>
        public InventoriesController(ISender mediator, IInventoryQueries inventoryQueries)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _inventoryQueries = inventoryQueries ?? throw new ArgumentNullException(nameof(inventoryQueries));
        }

        #endregion

        #region Actions

        /// <summary>
        /// Add a new inventory
        /// </summary>
        /// <returns>Returns an http status 200</returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateInventoryCommand request)
        {
            var commandResult = await _mediator.Send(request);
            return commandResult ? Ok() : BadRequest();
        }

        /// <summary>
        /// Returns a list of inventories
        /// </summary>
        /// <returns>Returns an http status 200 with the requested resource</returns>
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var queryResult = await _inventoryQueries.GetListAsync();
            return Ok(queryResult);
        }

        #endregion
    }
}
