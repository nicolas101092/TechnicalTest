using Application.Services.ApiTest.DtoModels.AutoMapper;
using Application.Services.ApiTest.DtoModels.AutoMapper.ApiTestContext;

namespace UnitTests.Application.ApiRRHH.AutoMapper
{
    public static class InventoryAutoMapper
    {
        public static IMapper GetIMapper()
        {
            MapperConfiguration configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddListProfiles(GerProfiles());
            });

            return new Mapper(configuration);
        }

        public static List<Profile> GerProfiles()
            => new()
            {
                new ApiTestAutorMapper(),
                new MapInventory(),
                new MapItem()
            };
    }
}
