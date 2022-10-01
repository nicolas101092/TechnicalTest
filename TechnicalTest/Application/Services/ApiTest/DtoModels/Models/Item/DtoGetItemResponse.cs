namespace Application.Services.ApiTest.DtoModels.Models.Item
{
    public class DtoGetItemResponse
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
