using BackendAPI.Data;
using BackendAPI.Controllers;
using BackendAPI.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System;

namespace BackendAPI.Test
{
    public class UserControllerTest : IDisposable
    {
        private DbContextOptions<ProductDBContext> dbContextOptions = new DbContextOptionsBuilder<ProductDBContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

        ProductDBContext context;
        UserController controller;

        public UserControllerTest()
        {
            context = new ProductDBContext(dbContextOptions);
            context.Database.EnsureCreated();
            controller = new UserController(context);

            context.Users.Add(new User() { Email = "naujas@email.com", Id = 1, Name = "Naujokas1", Password = controller.HashCode("1password") });
            context.Users.Add(new User() { Email = "naujas1@email.com", Id = 2, Name = "Naujokas2", Password = controller.HashCode("2password") });
            context.Users.Add(new User() { Email = "naujas2@email.com", Id = 3, Name = "Naujokas3", Password = controller.HashCode("3password") });
            context.Users.Add(new User() { Email = "naujas4@email.com", Id = 4, Name = "Naujokas4", Password = controller.HashCode("4password") });

            context.SaveChanges();
        }

        [Fact]
        public async Task LogIn_Test()
        {
            User user = new User() { Email = "naujas@email.com", Id = 0, Name = "ikd", Password = "1password" };
            var result = await controller.LogIn(user);
            var model = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsType<User>(model.Value);
            Assert.Equal(1, data.Id);
            Assert.Equal(data.Email, user.Email);
        }

        [Fact]
        public async Task Register_Test()
        {
            User user = new User() { Email = "naujausias@email.com", Id = 0, Name = "ikd", Password = "naujaspass" };
            var result = await controller.Register(user);
            var model = Assert.IsType<CreatedAtActionResult>(result);
            var data = Assert.IsType<User>(model.Value);
            Assert.Equal(5, data.Id);
        }

        [Fact]
        public async Task Update_Test()
        {
            User user = new User() { Email = "naujas@email.com", Id = 0, Name = "ikd", Password = "1password" };
            var result = await controller.LogIn(user);
            var model = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsType<User>(model.Value);
            Assert.Equal(1, data.Id);
            data.Name = "NeKiausiniene";

            var result2 = await controller.Update(data.Id, data);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Delete_Test()
        {
            var result = await controller.Delete(2);
            var model = Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task HashCode_Test()
        {
            var result = controller.HashCode("password!=--..");
            Assert.Equal("cGFzc3dvcmQhPS0tLi4=", result);
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}