using Application.Services.ApiTest.DtoModels.Models.Inventory.Requests;
using Application.Services.ApiTest.DtoModels.Models.Inventory.Responses;

namespace Application.Services.ApiTest.DtoModels.AutoMapper.ApiTestContext
{
    public class MapInventory : Profile
    {
        public MapInventory()
        {
            CreateMap<DtoCreateInventoryRequest, Inventory>();
            CreateMap<Inventory, DtoGetListInventoriesResponse>();
        }
    }
}