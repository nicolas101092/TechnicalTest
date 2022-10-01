using Application.Services.ApiTest.DtoModels.Models.Inventory;

namespace Application.Services.ApiTest.DtoModels.Models.Item
{
    public class DtoGetListItemsResponse
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime ExpirationDate { get; set; }

        #region Relation properties

        public int IdInventory { get; set; }

        #endregion

        #endregion
    }
}
