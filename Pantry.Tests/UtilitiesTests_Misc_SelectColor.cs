using Pantry.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Pantry.Tests
{
    
    public class UtilitiesTests_Misc_SelectColor
    {
        [Theory]
        [InlineData(2022, 12, 5, 2)]
        [InlineData(2022, 12, 3, 0)]
        [InlineData(2022, 12, 2, -1)]
        public void GetDaysLeft_ShouldReturnInt(int year, int month, int day, int expected)
        {
            DateTime currentDate = new DateTime(2022, 12, 3);
            DateTime expiryDate = new DateTime(year, month, day);

            int actual = SelectColor.GetDaysLeft(expiryDate, currentDate); 

            Assert.Equal(expected, actual);

        }

        [Theory]
        [InlineData(2022, 11, 30, "#FF0000")]
        [InlineData(2022, 12, 4, "#FFA500")]
        [InlineData(2022, 12, 6, "#00FF00")]
        public void SetColor_ShouldReturnString(int year, int month, int day, string expeected)
        {
            DateTime expiryDate = new DateTime(year, month, day);
            DateTime currentDate = new DateTime(2022, 12, 1);
            string actual = SelectColor.SetColor(expiryDate, currentDate);

            Assert.Equal(expeected, actual);
        }
        [Theory]
        [InlineData(2022, 12, 3, "Days left: 2")]
        [InlineData(2022, 12, 1, "Product expired")]
        public void DisplayDaysLeft_ShouldReturnString(int year, int month, int day, string expeected)
        {
            DateTime expiryDate = new DateTime(year, month, day);
            DateTime currentDate = new DateTime(2022, 12, 1);

            string actual = SelectColor.DisplayDaysLeft(expiryDate,currentDate);

            Assert.Equal(expeected, actual);

        }
    }
}
