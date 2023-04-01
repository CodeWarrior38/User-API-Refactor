using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tests.User.Api.Controllers;
using Tests.User.Api.Models;
using Tests.User.Api.Services;

namespace Tests.User.Api.Test
{
    public class UserControllerTests
    {
        private readonly UserController _controller;
        private readonly IUserService _db;

        public UserControllerTests( IUserService db)
        {            
            _controller = new UserController(db);
            _db = db;
        }

        [Fact]
        public async Task Should_Return_User_When_Valid_Id_Passed()
        {
            CreateUserDto user = new CreateUserDto
            {
                FirstName = "Test",
                LastName = "User",
                DateOfBirth = new DateTime(1977, 03, 17)
            };

            var savedUser = await _db.CreateAsync(user);            

            IActionResult result = await _controller.Get(savedUser.Id);
            OkObjectResult ok = result as OkObjectResult;           

            Assert.NotNull(ok);
            Assert.Equal(200, ok.StatusCode);            
        }

        [Fact]
        public async Task Should_Return_Valid_When_User_Created()
        {
            CreateUserDto userToCreate = new CreateUserDto()
            {
                FirstName = "Test",
                LastName = "User",
                DateOfBirth = new DateTime(1977,03,17)
            };

            IActionResult result = await _controller.Create(userToCreate);

            OkResult ok = result as OkResult;

            Assert.NotNull(ok);
            Assert.Equal(200, ok.StatusCode);
        }

        [Fact]
        public async Task Should_Return_Valid_When_User_Updated()
        {
            CreateUserDto user = new CreateUserDto
            {
                FirstName = "Test",
                LastName = "User",
                DateOfBirth = new DateTime(1977, 03, 17)
            };

            var addedUser = await _db.CreateAsync(user);

            UpdateUserDto updateUser = new UpdateUserDto()
            {
                FirstName = "Updated",
                LastName = "User",
                DateOfBirth = new DateTime(1977, 03, 17)
            };

            IActionResult result = await _controller.Update(addedUser.Id, updateUser);

            OkResult ok = result as OkResult;

            Assert.NotNull(ok);
            Assert.Equal(200, ok.StatusCode);
        }

        [Fact]
        public async Task Should_Return_Valid_When_User_Removed()
        {
            CreateUserDto user = new CreateUserDto
            {
                FirstName = "Test",
                LastName = "User",
                DateOfBirth = new DateTime(1977, 03, 17)
            };

            var addedUser = await _db.CreateAsync(user);

            IActionResult result = await _controller.Delete(addedUser.Id);

            OkResult ok = result as OkResult;

            Assert.NotNull(ok);
            Assert.Equal(200, ok.StatusCode);
        }
    }
}