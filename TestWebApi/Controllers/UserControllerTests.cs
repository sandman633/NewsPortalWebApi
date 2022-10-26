using AutoFixture;
using AutoMapper;
using BL.Services.Implementations;
using DAL.Request.User;
using Microsoft.Extensions.Logging;
using Moq;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestWebApi.Infrastructure.Helpers;
using WebApi.SocialNetWorkAdministration.Controllers;
using WebApi.SocialNetWorkAdministration.Mappings;
using Xunit;

namespace TestWebApi.Controllers
{
    public class UserControllerTests : BaseControllerTests<UserController>
    {
        public UserControllerTests() : base() { }
        
        [Fact]
        public async Task GET_ShouldCreateNewUserAndReturnUserAsync()
        {
            //Arrange
            //var mock = new Mock<IUserRepository>();
            //var userService = new UserService(mock.Object);
            //var controller = new UserController(userService, _mapper, _logger);
            //var userRequest = new Fixture().Create<NewUserRequest>();
            ////Act 
            //var result = await controller.CreateAsync(userRequest,new CancellationToken());

            ////Assert
            //Assert.NotNull(result);
            //Assert.NotNull(result);
        }

    }
}
