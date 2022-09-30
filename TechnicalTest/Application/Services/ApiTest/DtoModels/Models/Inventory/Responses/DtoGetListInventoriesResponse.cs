namespace Application.Services.ApiTest.DtoModels.Models.Inventory.Responses
{
    public class DtoGetListInventoriesResponse
    {
        #region Properties

        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = null!;

        #endregion
    }
}
