using Application.Services.ApiTest.DtoModels.Models.Item;

namespace Application.Services.ApiTest.DtoModels.Models.Inventory
{
    public class DtoGetInventoryResponse
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        #endregion

        #region Relations

        public List<DtoGetItemResponse>? Items { get; set; }

        #endregion
    }
}
