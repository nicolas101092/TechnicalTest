using Application.Services.ApiTest.Commands.ItemCommands;
using Application.Services.ApiTest.DtoModels.Models.Item;

namespace Application.Services.ApiTest.DtoModels.AutoMapper.ApiTestContext
{
    public class MapItem : Profile
    {
        public MapItem()
        {
            CreateMap<CreateItemCommand, Item>();
            CreateMap<Item, DtoGetItemResponse>();
            CreateMap<Item, DtoGetListItemsResponse>();
        }
    }
}
