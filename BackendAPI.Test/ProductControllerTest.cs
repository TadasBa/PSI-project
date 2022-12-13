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
    public class ProductControllerTest : IDisposable
    {
        private DbContextOptions<ProductDBContext> dbContextOptions = new DbContextOptionsBuilder<ProductDBContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

        ProductDBContext context;
        ProductController controller;

        public ProductControllerTest()
        {
            context = new ProductDBContext(dbContextOptions);
            context.Database.EnsureCreated();

            context.Products.Add(new Product() { ProductName = "Milk1", Id = 1, UsrID = 0, ExpiryDate = System.DateTime.Today, ProductType = ProductType.DAIRY });
            context.Products.Add(new Product() { ProductName = "Milk2", Id = 2, UsrID = 2, ExpiryDate = System.DateTime.Today, ProductType = ProductType.DAIRY });
            context.Products.Add(new Product() { ProductName = "Milk3", Id = 3, UsrID = 0, ExpiryDate = System.DateTime.Today, ProductType = ProductType.DAIRY });
            context.Products.Add(new Product() { ProductName = "Milk4", Id = 4, UsrID = 2, ExpiryDate = System.DateTime.Today, ProductType = ProductType.DAIRY });
            context.SaveChanges();

            controller = new ProductController(context);
        }

        [Fact]
        public async Task Get_Test()
        {
            var result = await controller.Get();
            var model = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsType<List<Product>>(model.Value);
            Assert.NotEmpty(data);
        }

        [Fact]
        public async Task GetById_Test()
        {
            var result = await controller.GetById(1);
            var model = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsType<Product>(model.Value);
            Assert.Equal(1, data.Id);
        }

        [Fact]
        public async Task GetByUsrId_Test()
        {
            var result = await controller.GetByUsrId(0);
            var model = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsType<List<Product>>(model.Value);
            Assert.NotEmpty(data);
        }

        [Fact]
        public async Task CreateProduct_Test()
        {
            Product product = new Product() { ProductName = "Milk5", Id = 0, UsrID = 5, ExpiryDate = System.DateTime.Today, ProductType = ProductType.DAIRY };
            var result = await controller.CreateProduct(product);
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
            var result = await controller.GetById(2);
            var model = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsType<Product>(model.Value);
            Assert.Equal(2, data.Id);
            data.ProductName = "nepienas";

            var result2 = await controller.Update(data.Id, data);
            Assert.IsType<OkObjectResult>(result);

            var result3 = await controller.GetById(data.Id);
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
            var result = await controller.Delete(4);
            var model = Assert.IsType<OkResult>(result);
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}