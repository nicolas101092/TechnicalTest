namespace Application.Services.ApiTest.DtoModels.Models.Inventory.Requests
{
    public class DtoCreateInventoryRequest : IRequest<bool>
    {
        #region Properties

        [MaxLength(100)]
        public string Name { get; set; } = null!;

        #endregion
    }
}
