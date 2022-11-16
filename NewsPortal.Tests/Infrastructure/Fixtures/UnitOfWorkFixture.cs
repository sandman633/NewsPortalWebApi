using NewsPortal.Model;
using Repositories.Interfaces;
using NewsPortal.Tests.Infrastructure.Helpers.DbHelpers;

namespace NewsPortal.Tests.Infrastructure.Fixtures
{
    public class UnitOfWorkFixture
    {
        public IUnitOfWork<WebApiContext> Create()
        {
            var mock = UnitOfWorkHelper.GetMock();

            return mock.Object;
        }
    }
}
