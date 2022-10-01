using Application.Services.ApiTest.Commands.InventoryCommands;
using Application.Services.ApiTest.DtoModels.Models.Inventory;

namespace Application.Services.ApiTest.DtoModels.AutoMapper.ApiTestContext
{
    public class MapInventory : Profile
    {
        public MapInventory()
        {
            CreateMap<CreateInventoryCommand, Inventory>();
            CreateMap<Inventory, DtoGetListInventoriesResponse>();
        }
    }
}