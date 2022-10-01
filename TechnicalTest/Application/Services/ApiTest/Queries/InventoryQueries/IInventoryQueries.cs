using Application.Services.ApiTest.DtoModels.Models.Inventory;

namespace Application.Services.ApiTest.Queries.InventoryQueries
{
    public interface IInventoryQueries
    {
        Task<List<DtoGetListInventoriesResponse>?> GetListAsync();
    }
}
