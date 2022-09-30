using Application.Services.ApiTest.DtoModels.Models.Inventory.Responses;

namespace Application.Services.ApiTest.Queries.InventoryQueries
{
    public interface IInventoryQueries
    {
        Task<List<DtoGetListInventoriesResponse>?> GetListAsync();
    }
}
