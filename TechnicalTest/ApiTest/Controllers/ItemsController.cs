using Application.Services.ApiTest.Commands.ItemCommands;
using Application.Services.ApiTest.Queries.ItemQueries;

namespace ApiTest.Controllers
{
    public class ItemsController : GenericController
    {
        #region Properties

        private readonly ISender _mediator = null!;
        private readonly IItemQueries _itemQueries = null!;

        #endregion

        #region Constructor

        /// <summary>
        /// Item controller constructor
        /// </summary>
        /// <param name="mediator">Sender's interface</param>
        /// <param name="itemQueries">ItemQueries interface</param>
        public ItemsController(ISender mediator, IItemQueries itemQueries)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _itemQueries = itemQueries ?? throw new ArgumentNullException(nameof(itemQueries));
        }

        #endregion

        #region Actions

        /// <summary>
        /// Add a new item
        /// </summary>
        /// <returns>Returns an http status 200</returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateItemCommand request)
        {
            var commandResult = await _mediator.Send(request);

            return commandResult ? Ok() : BadRequest();
        }

        /// <summary>
        /// Returns a list of items
        /// </summary>
        /// <returns>Returns an http status 200 with the requested resource</returns>
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var queryResult = await _itemQueries.GetListAsync();
            return Ok(queryResult);
        }

        /// <summary>
        /// Returns an item by id
        /// </summary>
        /// <returns>Returns an http status 200 with the requested resource</returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var queryResult = await _itemQueries.GetByIdAsync(id);
            return Ok(queryResult);
        }

        /// <summary>
        /// Add a new item
        /// </summary>
        /// <returns>Returns an http status 200</returns>
        [HttpDelete("name")]
        public async Task<IActionResult> RemoveByName(string name)
        {
            var commandResult = await _mediator.Send(new RemoveByNameItemCommand
            {
                Name = name
            });

            return commandResult ? NoContent() : BadRequest();
        }

        #endregion
    }
}
