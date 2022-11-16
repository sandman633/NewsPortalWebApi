using Microsoft.AspNetCore.Mvc;
using NewsPortal.DAL.Request.User;
using NewsPortal.DAL.Response;
using NewsPortal.Repositories.Infrastructure.Exceptions;
using NewsPortal.Tests.Infrastructure.Fixtures;
using NewsPortal.WebApi.Controllers;
using System;
using System.Collections.Generic;
using Xunit;

namespace NewsPortal.Tests.Controllers
{
    public class UserControllerTest : IClassFixture<UserControllerFixture>
    {
        UserControllerFixture _fixture;
        public UserControllerTest(UserControllerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void ItShould_create_userController_instance()
        {
            //Arrange
            UserController controller = _fixture.Create();

            //Act 

            //Assert
            Assert.NotNull(controller);
        }
        [Fact]
        public async void ItShould_return_exist_users_and_status_code_200()
        {
            //Arrange
            UserController controller = _fixture.Create();

            //Act 
            var response = ResponseHelper.GetResult(await controller.GetAsync());
            var ok = 200;

            //Assert
            Assert.NotNull(response.Data);
            Assert.Equal(ok, response.StatusCode);
        }
        [Fact]
        public async void ItShould_return_user_with_id_1()
        {
            //Arrange
            UserController controller = _fixture.Create();
            var userId = 1;

            //Act 
            var response = ResponseHelper.GetResult(await controller.GetByIdAsync(userId));

            var ok = 200;
            var id = 1;
            var userName = $"UserName {id}";

            //Assert
            Assert.Equal(ok, response.StatusCode);
            Assert.NotNull(response.Data);
            Assert.Equal(userName, response.Data.Name);
            Assert.Equal(id, response.Data.Id);
        }
        [Fact]
        public async void ItShould_delete_user_with_id_1()
        {
            //Arrange
            UserController controller = _fixture.Create();
            var userId = 1;

            //Act 
            var response = ResponseHelper.GetResult(await controller.DeleteAsync(userId));
            var ok = 200;

            //Assert
            Assert.Equal(ok, response.StatusCode);
        }
        [Fact]
        public async void ItShould_throws_exception_user_not_found()
        {
            //Arrange
            UserController controller = _fixture.Create();
            var userId = 3;

            //Act 

            //Assert
            Assert.ThrowsAsync<DataTransactionException>(()=> {return controller.GetByIdAsync(userId); });
        }

        [Fact]
        public async void ItShould_update_exist_user_1_change_only_name()
        {
            //Arrange
            UserController controller = _fixture.Create();
            var userId = 1;
            var newUserName = "NewUSerName1";
            var email = "Email@gmail.com";
            var userRequest = new UpdateUserRequest() { Id = userId,Name = newUserName};
            //Act 
            var response = ResponseHelper.GetResult(await controller.UpdateAsync(userRequest));
            //Assert
            Assert.Equal(userId, response.Data.Id);
            Assert.Equal(newUserName, response.Data.Name);
            Assert.Equal(email, response.Data.Email);
        }
        [Fact]
        public async void ItShould_create_newuser()
        {
            //Arrange
            UserController controller = _fixture.Create();
            var email = "newuser@gamil.com";
            var name = "newUser";
            var id = 3;
            var newUser = new NewUserRequest() { Age = 20, Email = email, Name = name, LastName = name, Password = "Passw0rd!" };
            //Act 
            var response = ResponseHelper.GetResult(await controller.CreateAsync(newUser));
            //Assert
            Assert.Equal(id, response.Data.Id);
            Assert.Equal(name, response.Data.Name);
            Assert.Equal(email, response.Data.Email);
        }
    }
    public class ResponseHelper
    {
        public static T GetResult<T>(ActionResult<T> result)
        {
            var okObject = Assert.IsType<OkObjectResult>(result.Result);
            return (T)okObject.Value;
        }
    }
}