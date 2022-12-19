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
    public class ControllerTests : IDisposable
    {
        private DbContextOptions<ProductDBContext> dbContextOptions = new DbContextOptionsBuilder<ProductDBContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

        ProductDBContext context;
        ProductController p_controller;
        RecepieController r_controller;
        UserController u_controller;

        public ControllerTests()
        {
            context = new ProductDBContext(dbContextOptions);
            context.Database.EnsureCreated();

            p_controller = new ProductController(context);
            r_controller = new RecepieController(context);
            u_controller = new UserController(context);

            context.Products.Add(new Product() { ProductName = "Milk1", Id = 1, UsrID = 0, ExpiryDate = System.DateTime.Today, ProductType = ProductType.DAIRY });
            context.Products.Add(new Product() { ProductName = "Milk2", Id = 2, UsrID = 2, ExpiryDate = System.DateTime.Today, ProductType = ProductType.DAIRY });
            context.Products.Add(new Product() { ProductName = "Milk3", Id = 3, UsrID = 0, ExpiryDate = System.DateTime.Today, ProductType = ProductType.DAIRY });
            context.Products.Add(new Product() { ProductName = "Milk4", Id = 4, UsrID = 2, ExpiryDate = System.DateTime.Today, ProductType = ProductType.DAIRY });

            context.Recepies.Add(new Recepie() { Title = "Kiausiniene1", Id = 1, Description = "Kaip pasidaryti kiausinius1", ImageSource = "http://nezinaulol1", Type = "Eggs" });
            context.Recepies.Add(new Recepie() { Title = "Kiausiniene2", Id = 2, Description = "Kaip pasidaryti kiausinius2", ImageSource = "http://nezinaulol2", Type = "Eggs" });
            context.Recepies.Add(new Recepie() { Title = "Kiausiniene3", Id = 3, Description = "Kaip pasidaryti kiausinius3", ImageSource = "http://nezinaulol3", Type = "Eggs" });
            context.Recepies.Add(new Recepie() { Title = "Kiausiniene4", Id = 4, Description = "Kaip pasidaryti kiausinius4", ImageSource = "http://nezinaulol4", Type = "Eggs" });

            context.Users.Add(new User() { Email = "naujas@email.com", Id = 1, Name = "Naujokas1", Password = u_controller.HashCode("1password") });
            context.Users.Add(new User() { Email = "naujas1@email.com", Id = 2, Name = "Naujokas2", Password = u_controller.HashCode("2password") });
            context.Users.Add(new User() { Email = "naujas2@email.com", Id = 3, Name = "Naujokas3", Password = u_controller.HashCode("3password") });
            context.Users.Add(new User() { Email = "naujas4@email.com", Id = 4, Name = "Naujokas4", Password = u_controller.HashCode("4password") });
            context.SaveChanges();
        }

        [Fact]
        public async Task Get_Test()
        {
            var result = await p_controller.Get();
            var model = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsType<List<Product>>(model.Value);
            Assert.NotEmpty(data);
        }

        [Fact]
        public async Task GetById_Test()
        {
            var result = await p_controller.GetById(1);
            var model = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsType<Product>(model.Value);
            Assert.Equal(1, data.Id);
        }

        [Fact]
        public async Task GetByUsrId_Test()
        {
            var result = await p_controller.GetByUsrId(0);
            var model = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsType<List<Product>>(model.Value);
            Assert.NotEmpty(data);
        }

        [Fact]
        public async Task CreateProduct_Test()
        {
            Product product = new Product() { ProductName = "Milk5", Id = 0, UsrID = 5, ExpiryDate = System.DateTime.Today, ProductType = ProductType.DAIRY };
            var result = await p_controller.CreateProduct(product);
            var model = Assert.IsType<CreatedAtActionResult>(result);
            var data = Assert.IsType<Product>(model.Value);
            Assert.Equal(product.ProductName, data.ProductName);
            Assert.Equal(product.UsrID, data.UsrID);
            Assert.Equal(product.ExpiryDate, data.ExpiryDate);
            Assert.Equal(product.ProductType, data.ProductType);
            Assert.Equal(5, data.Id);
        }

        [Fact]
        public async Task Update_Test()
        {
            var result = await p_controller.GetById(2);
            var model = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsType<Product>(model.Value);
            Assert.Equal(2, data.Id);
            data.ProductName = "nepienas";

            var result2 = await p_controller.Update(data.Id, data);
            Assert.IsType<OkObjectResult>(result);

            var result3 = await p_controller.GetById(data.Id);
            var model3 = Assert.IsType<OkObjectResult>(result3);
            var data3 = Assert.IsType<Product>(model.Value);
            Assert.Equal(data.Id, data3.Id);

            Assert.Equal(data3.ProductName, data.ProductName);
            Assert.Equal(data3.UsrID, data.UsrID);
            Assert.Equal(data3.ExpiryDate, data.ExpiryDate);
            Assert.Equal(data3.ProductType, data.ProductType);
            Assert.Equal(data3.Id, data.Id);
        }

        [Fact]
        public async Task Delete_Test()
        {
            var result = await p_controller.Delete(4);
            var model = Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Get_Recepie_Test()
        {
            var result = await r_controller.Get();
            var model = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsType<List<Recepie>>(model.Value);
            Assert.NotEmpty(data);
        }

        [Fact]
        public async Task GetById_Recepie_Test()
        {
            var result = await r_controller.GetById(1);
            var model = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsType<Recepie>(model.Value);
            Assert.Equal(1, data.Id);
        }

        [Fact]
        public async Task CreateRecepie_Test()
        {
            Recepie recepie = new Recepie() { Title = "Kiausiniene1", Id = 0, Description = "Kaip pasidaryti kiausinius1", ImageSource = "http://nezinaulol1", Type = "Eggs" };
            var result = await r_controller.CreateRecepie(recepie);
            var model = Assert.IsType<CreatedAtActionResult>(result);
            var data = Assert.IsType<Recepie>(model.Value);
            Assert.Equal(5, data.Id);
        }

        [Fact]
        public async Task Update_Recepie_Test()
        {
            var result = await r_controller.GetById(2);
            var model = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsType<Recepie>(model.Value);
            Assert.Equal(2, data.Id);
            data.Title = "NeKiausiniene";

            var result2 = await r_controller.Update(data.Id, data);
            Assert.IsType<OkObjectResult>(result);

            var result3 = await r_controller.GetById(data.Id);
            var model3 = Assert.IsType<OkObjectResult>(result3);
            var data3 = Assert.IsType<Recepie>(model.Value);
            Assert.Equal(data.Id, data3.Id);
            Assert.Equal(data.Title, data3.Title);
        }

        [Fact]
        public async Task Delete_Recepie_Test()
        {
            var result = await r_controller.Delete(2);
            var model = Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task LogIn_Test()
        {
            User user = new User() { Email = "naujas@email.com", Id = 0, Name = "ikd", Password = "1password" };
            var result = await u_controller.LogIn(user);
            var model = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsType<User>(model.Value);
            Assert.Equal(1, data.Id);
            Assert.Equal(data.Email, user.Email);
        }

        [Fact]
        public async Task Register_Test()
        {
            User user = new User() { Email = "naujausias@email.com", Id = 0, Name = "ikd", Password = "naujaspass" };
            var result = await u_controller.Register(user);
            var model = Assert.IsType<CreatedAtActionResult>(result);
            var data = Assert.IsType<User>(model.Value);
            Assert.Equal(5, data.Id);
        }

        [Fact]
        public async Task Update_User_Test()
        {
            User user = new User() { Email = "naujas@email.com", Id = 0, Name = "ikd", Password = "1password" };
            var result = await u_controller.LogIn(user);
            var model = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsType<User>(model.Value);
            Assert.Equal(1, data.Id);
            data.Name = "NeKiausiniene";

            var result2 = await u_controller.Update(data.Id, data);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Delete_User_Test()
        {
            var result = await u_controller.Delete(2);
            var model = Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task HashCode_Test()
        {
            var result = u_controller.HashCode("password!=--..");
            Assert.Equal("cGFzc3dvcmQhPS0tLi4=", result);
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}