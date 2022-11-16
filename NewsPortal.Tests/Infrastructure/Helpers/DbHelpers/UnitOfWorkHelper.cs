using NewsPortal.DAL.Dto;
using NewsPortal.Model.Domain;
using Moq;
using Repositories.Implementations;
using Repositories.Interfaces;
using NewsPortal.Model;

namespace NewsPortal.Tests.Infrastructure.Helpers.DbHelpers
{
    public static class UnitOfWorkHelper
    {
        public static Mock<IUnitOfWork<WebApiContext>> GetMock()
        {
            var context = new DbContextHelper().WebApiContext;
            var mapper = MapperHelper.CreateMapper();
            var unitOfWork = new Mock<IUnitOfWork<WebApiContext>>();
            unitOfWork.Setup(x => x.GetRepository<User, IUserRepository>()).Returns(new UserRepository(context));
            unitOfWork.Setup(x => x.GetRepository<Group, IGroupRepository>()).Returns(new GroupRepository(context));
            unitOfWork.Setup(x => x.GetRepository<GroupPolicy, IGroupPolicyRepository>()).Returns(new GroupPolicyRepository(context));
            unitOfWork.Setup(x => x.GetRepository<UserGroup, IUserGroupRepository>()).Returns(new UserGroupRepository(context));
            unitOfWork.Setup(x => x.GetRepository<News, INewsRepository>()).Returns(new NewsRepository(context));
            unitOfWork.Setup(x => x.GetRepository<Comments, ICommentsRepository>()).Returns(new CommentsRepository(context));
            unitOfWork.Setup(x => x.SaveChanges()).Returns(() => { return context.SaveChanges(); });
            unitOfWork.Setup(x => x.SaveChangesAsync()).Returns(() => { return context.SaveChangesAsync(); });
            var scope = context.Database.BeginTransaction();
            var scopeAsync = context.Database.BeginTransactionAsync();

            unitOfWork.Setup(x => x.BeginTransaction(false)).Returns(scope);
            unitOfWork.Setup(x => x.BeginTransactionAsync(false)).Returns(scopeAsync);


            return unitOfWork;
        }
    }

}
