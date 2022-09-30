using Domain.Common.Constants;

namespace Infrastructure.Common.Configuration
{
    [Route($"{ConstantsStartup.BASEPATH_GENERIC_CONTROLLER}/[controller]")]
    [ApiController]
    public class GenericController : Controller
    {
    }
}