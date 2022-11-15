using NewsPortal.Model;
using Repositories.Interfaces;
using TestWebApi.Infrastructure.Helpers.DbHelpers;

namespace TestWebApi.Infrastructure.Fixtures
{
    public class UnitOfWorkFixture
    {

        public IUnitOfWork<WebApiContext> Create(bool consistency=true)
        {
            var mock = UnitOfWorkHelper.GetMock(consistency);

            return mock.Object;
        }

    }
}
