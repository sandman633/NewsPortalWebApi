using DAL.Dto;
using Model;
using Model.Domain;
using Moq;
using Repositories.Implementations;
using Repositories.Interfaces;

namespace TestWebApi.Infrastructure.Helpers.DbHelpers
{
    public static class UnitOfWorkHelper
    {
        public static Mock<IUnitOfWork<WebApiContext>> GetMock()
        {
            var context = new DbContextHelper().WebApiContext;
            var unitOfWork = new Mock<IUnitOfWork<WebApiContext>>();
            unitOfWork.Setup(x => x.GetRepository<UserDto, User, IUserRepository>()).Returns(new UserRepository(context,MapperHelper.CreateMapper()));

            var scope = context.Database.BeginTransaction();
            var scopeAsync = context.Database.BeginTransactionAsync();

            unitOfWork.Setup(x => x.BeginTransaction(false)).Returns(scope);
            unitOfWork.Setup(x => x.BeginTransactionAsync(false)).Returns(scopeAsync);


            return unitOfWork;
        }
    }

}
