using NewsPortal.DAL.Dto;
using NewsPortal.Model.Domain;
using Moq;
using Repositories.Implementations;
using Repositories.Interfaces;
using NewsPortal.Model;

namespace TestWebApi.Infrastructure.Helpers.DbHelpers
{
    public static class UnitOfWorkHelper
    {
        public static Mock<IUnitOfWork<WebApiContext>> GetMock(bool consistency)
        {
            var context = new DbContextHelper(consistency).WebApiContext;
            var mapper = MapperHelper.CreateMapper();
            var unitOfWork = new Mock<IUnitOfWork<WebApiContext>>();
            unitOfWork.Setup(x => x.GetRepository<UserDto, User, IUserRepository>()).Returns(new UserRepository(context, mapper));
            unitOfWork.Setup(x => x.GetRepository<GroupDto, Group, IGroupRepository>()).Returns(new GroupRepository(context, mapper));
            unitOfWork.Setup(x => x.GetRepository<GroupPolicyDto, GroupPolicy, IGroupPolicyRepository>()).Returns(new GroupPolicyRepository(context, mapper));
            unitOfWork.Setup(x => x.GetRepository<UserGroupDto, UserGroup, IUserGroupRepository>()).Returns(new UserGroupRepository(context, mapper));
            unitOfWork.Setup(x => x.GetRepository<NewsDto, News, INewsRepository>()).Returns(new NewsRepository(context, mapper));
            unitOfWork.Setup(x => x.GetRepository<CommentsDto, Comments, ICommentsRepository>()).Returns(new CommentsRepository(context, mapper));

            var scope = context.Database.BeginTransaction();
            var scopeAsync = context.Database.BeginTransactionAsync();

            unitOfWork.Setup(x => x.BeginTransaction(false)).Returns(scope);
            unitOfWork.Setup(x => x.BeginTransactionAsync(false)).Returns(scopeAsync);


            return unitOfWork;
        }
    }

}
