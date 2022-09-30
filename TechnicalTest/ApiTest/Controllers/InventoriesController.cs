namespace ApiTest.Controllers
{
    public class InventoriesController : GenericController
    {
        #region Constructor

        /// <summary>
        /// Inventory controller constructor
        /// </summary>
        public InventoriesController()
        {
        }

        #endregion

        #region Actions

        /// <summary>
        /// Add a new inventory
        /// </summary>
        /// <returns>Returns an http status 201 with the requested resource</returns>
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            return Ok();
        }

        #endregion
    }
}
