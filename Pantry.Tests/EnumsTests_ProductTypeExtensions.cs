using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pantry;
using Pantry.enums;
using Pantry.models;
using Xunit;

namespace Pantry.Tests
{
    public class EnumsTests_ProductTypeExtensions
    {

        [Fact]
         public void StringToEnum_ShouldReturnProductType()
         {
            ProductType expected = ProductType.NUTS_AND_SEEDS;

            ProductType actual = ProductTypeExtensions.StringToEnum("nuts and seeds");
           
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void StringToEnum_ShouldCatchException()
        {
            Assert.Throws<NullReferenceException>(() => ProductTypeExtensions.StringToEnum("string"));
        }

        [Fact]
        public void ToDescriptionString_ShouldReturnString()
        {
            string expected = "Baked goods";

            string actual = ProductTypeExtensions.ToDescriptionString(ProductType.BAKED_GOODS);
            
            Assert.Equal(expected, actual);
        }

    }
}
