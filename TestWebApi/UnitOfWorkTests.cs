using NewsPortal.DAL.Dto;
using NewsPortal.Model.Domain;
using Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using TestWebApi.Infrastructure.Fixtures;
using Xunit;

namespace TestWebApi
{
    public class UnitOfWorkTests : IClassFixture<UnitOfWorkFixture>
    {
        
        private readonly UnitOfWorkFixture _unitOfWorkFixture;

        public UnitOfWorkTests(UnitOfWorkFixture unitOfWorkFixture)
        {
            _unitOfWorkFixture = unitOfWorkFixture;
        }

        [Trait("UnitOfWorkTests","UnderTesting")]
        [Fact]
        public void ItShould_unitOfWork_instance_not_null_and_created()
        {
            //Arrange
            var sut = _unitOfWorkFixture.Create();

            //Act 

            //Assert
            Assert.NotNull(sut);
        }
        [Trait("UnitOfWorkTests", "UnderTesting")]
        [Fact]
        public async Task ItShould_contains_usersAsync()
        {
            //Arrange
            const int expectedCount = 2;

            var sut = _unitOfWorkFixture.Create();
            var repo = sut.GetRepository<UserDto, User, IUserRepository>();
            var users = await repo.GetAsync();

            //Act 
            var actualCount = users.Count();


            //Assert
            Assert.Equal(expectedCount, actualCount);
        }
        [Trait("UnitOfWorkTests", "UnderTesting")]
        [Fact]
        public async Task ItShould_contains_groupsAsync()
        {
            //Arrange
            const int expectedCount = 4;

            var sut = _unitOfWorkFixture.Create();
            var repo = sut.GetRepository<GroupDto, Group, IGroupRepository>();
            var groups = await repo.GetAsync();

            //Act 
            var actualCount = groups.Count();


            //Assert
            Assert.Equal(expectedCount, actualCount);
        }
        [Trait("UnitOfWorkTests", "UnderTesting")]
        [Fact]
        public async Task ItShould_contains_newsAsync()
        {
            //Arrange
            const int expectedCount = 1;
            var sut = _unitOfWorkFixture.Create();
            var repo = sut.GetRepository<NewsDto, News, INewsRepository>();
            var news = await repo.GetAsync();
            //Act 
            var actualCount = news.Count();

            //Assert
            Assert.Equal(expectedCount, actualCount);
        }
        [Trait("UnitOfWorkTests", "UnderTesting")]
        [Fact]
        public async Task ItShould_contains_commentsAsync()
        {
            //Arrange
            const int expectedCount = 1;
            var sut = _unitOfWorkFixture.Create();
            var repo = sut.GetRepository<CommentsDto, Comments, ICommentsRepository>();
            var comments = await repo.GetAsync();
            //Act 
            var actualCount = comments.Count();

            //Assert
            Assert.Equal(expectedCount, actualCount);
        }
        [Trait("UnitOfWorkTests", "UnderTesting")]
        [Fact]
        public async Task ItShould_contains_groupPoliciesAsync()
        {
            //Arrange
            const int expectedCount = 4;
            var sut = _unitOfWorkFixture.Create();
            var repo = sut.GetRepository<GroupPolicyDto, GroupPolicy, IGroupPolicyRepository>();
            var groupPolicies = await repo.GetAsync();
            //Act 
            var actualCount = groupPolicies.Count();

            //Assert
            Assert.Equal(expectedCount, actualCount);
        }
    }
}
