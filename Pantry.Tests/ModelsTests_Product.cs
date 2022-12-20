using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pantry;
using Pantry.models;
using Xunit;

namespace Pantry.Tests
{
    public class ModelsTests_Product
    {
        [Theory]
        [InlineData(2000, 1, 2, 2000, 1, 1)]
        public void CompareTo_ShouldReturnFirstValueIsGreater(int year1, int month1, int day1, int year2, int month2, int day2)
        {
            Product product1 = new Product("bread", ProductType.BAKED_GOODS, new DateTime(year1, month1, day1), 1);
            Product product2 = new Product("bread", ProductType.BAKED_GOODS, new DateTime(year2, month2, day2), 1);

            int expected = 1;   // if value1 > value2 returns 1, if value1 < value2 returns -1, if value1 == value2 returns 0  
            int actual = product1.CompareTo(product2);

            Assert.Equal(expected, actual);

        }

        [Theory]
        [InlineData(2000, 1, 1, 2000, 1, 2)]
        public void CompareTo_ShouldReturnFirstValueIsLess(int year1, int month1, int day1, int year2, int month2, int day2)
        {
            Product product1 = new Product("bread", ProductType.BAKED_GOODS, new DateTime(year1, month1, day1), 1);
            Product product2 = new Product("bread", ProductType.BAKED_GOODS, new DateTime(year2, month2, day2), 1);

            int expected = -1;   // if value1 > value2 returns 1, if value1 < value2 returns -1, if value1 == value2 returns 0  
            int actual = product1.CompareTo(product2);

            Assert.Equal(expected, actual);

        }

        [Theory]
        [InlineData(2000, 1, 1, 2000, 1, 1)]
        public void CompareTo_ShouldReturnFirstValueIsEqual(int year1, int month1, int day1, int year2, int month2, int day2)
        {
            Product product1 = new Product("bread", ProductType.BAKED_GOODS, new DateTime(year1, month1, day1), 1);
            Product product2 = new Product("bread", ProductType.BAKED_GOODS, new DateTime(year2, month2, day2), 1);

            int expected = 0;   // if value1 > value2 returns 1, if value1 < value2 returns -1, if value1 == value2 returns 0  
            int actual = product1.CompareTo(product2);

            Assert.Equal(expected, actual);

        }

    }
}
