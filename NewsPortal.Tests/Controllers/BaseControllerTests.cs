using AutoMapper;
using Microsoft.Extensions.Logging;
using NewsPortal.Tests.Infrastructure.Helpers;

namespace NewsPortal.Tests.Controllers
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