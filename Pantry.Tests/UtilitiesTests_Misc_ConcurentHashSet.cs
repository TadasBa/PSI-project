using Pantry.models;
using Pantry.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pantry.Tests
{
    public class UtilitiesTests_Misc_ConcurentHashSet
    {
        [Fact]
        public void Add_ShouldReturnTrueIfItemAdded()
        {

            Product p = new Product("morka", ProductType.VEGETABLES, new DateTime(2022, 12, 12), 1);
            ConcurrentHashSet<Product> ProductList = new ConcurrentHashSet<Product>();
            ProductList.Add(p);

            Assert.True(ProductList.Count == 1);
        }

        [Fact]
        public void Count_ShouldReturnTrueIfListContainsNumberOfItems()
        {

            Product a = new Product("morka", ProductType.VEGETABLES, new DateTime(2022, 12, 12), 1);
            Product b = new Product("morka", ProductType.VEGETABLES, new DateTime(2022, 12, 12), 1);
            Product c = new Product("morka", ProductType.VEGETABLES, new DateTime(2022, 12, 12), 1);
            ConcurrentHashSet<Product> ProductList = new ConcurrentHashSet<Product>();
            ProductList.Add(a);
            ProductList.Add(b);
            ProductList.Add(c);
            int actual = ProductList.Count;

            Assert.True(actual == 3);
        }

        [Fact]
        public void Clear_ShouldReturnTrueIfListIsEmpty()
        {

            Product p = new Product("morka", ProductType.VEGETABLES, new DateTime(2022, 12, 12), 1);
            ConcurrentHashSet<Product> ProductList = new ConcurrentHashSet<Product>();
            ProductList.Add(p);
            ProductList.Clear();

            Assert.True(ProductList.Count == 0);
        }

        [Fact]
        public void Contains_ShouldReturnTrueIfListContainsItem()
        {

            Product p = new Product("morka", ProductType.VEGETABLES, new DateTime(2022, 12, 12), 1);
            ConcurrentHashSet<Product> ProductList = new ConcurrentHashSet<Product>();
            ProductList.Add(p);
            bool actual = ProductList.Contains(p);

            Assert.True(actual);
        }

        [Fact]
        public void Remove_ShouldReturnTrueIfItemRemoved()
        {

            Product p = new Product("morka", ProductType.VEGETABLES, new DateTime(2022, 12, 12), 1);
            ConcurrentHashSet<Product> ProductList = new ConcurrentHashSet<Product>();
            ProductList.Add(p);
            ProductList.Remove(p);

            Assert.True(ProductList.Count == 0);
        }

    }
}

