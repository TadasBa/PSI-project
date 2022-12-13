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
    public class RecepieControllerTest : IDisposable
    {
        private DbContextOptions<ProductDBContext> dbContextOptions = new DbContextOptionsBuilder<ProductDBContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

        ProductDBContext context;
        RecepieController p_controller;

        public RecepieControllerTest()
        {
            context = new ProductDBContext(dbContextOptions);
            context.Database.EnsureCreated();
            p_controller = new RecepieController(context);

            context.Recepies.Add(new Recepie() { Title = "Kiausiniene1", Id = 1, Description = "Kaip pasidaryti kiausinius1", ImageSource = "http://nezinaulol1", Type = "Eggs" });
            context.Recepies.Add(new Recepie() { Title = "Kiausiniene2", Id = 2, Description = "Kaip pasidaryti kiausinius2", ImageSource = "http://nezinaulol2", Type = "Eggs" });
            context.Recepies.Add(new Recepie() { Title = "Kiausiniene3", Id = 3, Description = "Kaip pasidaryti kiausinius3", ImageSource = "http://nezinaulol3", Type = "Eggs" });
            context.Recepies.Add(new Recepie() { Title = "Kiausiniene4", Id = 4, Description = "Kaip pasidaryti kiausinius4", ImageSource = "http://nezinaulol4", Type = "Eggs" });
            context.SaveChanges();
        }

        [Fact]
        public async Task Get_Test()
        {
            var result = await p_controller.Get();
            var model = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsType<List<Recepie>>(model.Value);
            Assert.NotEmpty(data);
        }

        [Fact]
        public async Task GetById_Test()
        {
            var result = await p_controller.GetById(1);
            var model = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsType<Recepie>(model.Value);
            Assert.Equal(1, data.Id);
        }

        [Fact]
        public async Task CreateRecepie_Test()
        {
            Recepie recepie = new Recepie() { Title = "Kiausiniene1", Id = 0, Description = "Kaip pasidaryti kiausinius1", ImageSource = "http://nezinaulol1", Type = "Eggs" };
            var result = await p_controller.CreateRecepie(recepie);
            var model = Assert.IsType<CreatedAtActionResult>(result);
            var data = Assert.IsType<Recepie>(model.Value);
            Assert.Equal(5, data.Id);
        }

        [Fact]
        public async Task Update_Test()
        {
            var result = await p_controller.GetById(2);
            var model = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsType<Recepie>(model.Value);
            Assert.Equal(2, data.Id);
            data.Title = "NeKiausiniene";

            var result2 = await p_controller.Update(data.Id, data);
            Assert.IsType<OkObjectResult>(result);

            var result3 = await p_controller.GetById(data.Id);
            var model3 = Assert.IsType<OkObjectResult>(result3);
            var data3 = Assert.IsType<Recepie>(model.Value);
            Assert.Equal(data.Id, data3.Id);
            Assert.Equal(data.Title, data3.Title);
        }

        [Fact]
        public async Task Delete_Test()
        {
            var result = await p_controller.Delete(2);
            var model = Assert.IsType<OkResult>(result);
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}