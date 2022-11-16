using AutoMapper;
using NewsPortal.WebApi;

namespace NewsPortal.Tests.Infrastructure.Helpers
{
    public class MapperHelper
    {
        public static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(x => x.AddMaps(typeof(Startup))));
        }
    }
}