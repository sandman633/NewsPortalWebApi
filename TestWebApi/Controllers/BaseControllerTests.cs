using AutoMapper;
using Microsoft.Extensions.Logging;
using TestWebApi.Infrastructure.Helpers;

namespace TestWebApi.Controllers
{
    public class BaseControllerTests<T>
    {
        protected readonly IMapper _mapper;
        protected readonly ILogger<T> _logger;
        public BaseControllerTests()
        {
            _mapper = MapperHelper.CreateMapper();
            _logger = LoggerHelper.GetLogger<T>();
        }
    }
}