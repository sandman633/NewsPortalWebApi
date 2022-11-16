using NewsPortal.BusinessLogic.Services.Implementations;
using NewsPortal.Tests.Controllers;
using NewsPortal.Tests.Infrastructure.Helpers;
using NewsPortal.Tests.Infrastructure.Helpers.DbHelpers;
using NewsPortal.WebApi.Controllers;

namespace NewsPortal.Tests.Infrastructure.Fixtures
{
    public class UserControllerFixture : BaseControllerTests<UserController>
    {
        public UserController Create()
        {
            var userService = new UserService(UnitOfWorkHelper.GetMock().Object);
            return new UserController(userService,_mapper,_logger);
        }
    }
}
