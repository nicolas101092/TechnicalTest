using Application.Services.ApiTest.DtoModels.Models.Item;

namespace Application.Services.ApiTest.Queries.ItemQueries
{
    public interface IItemQueries
    {
        Task<List<DtoGetListItemsResponse>?> GetListAsync();
        Task<DtoGetItemResponse?> GetByIdAsync(int id);
    }
}
