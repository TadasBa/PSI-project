using Pantry.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pantry.Tests
{
    
    public class UtilitiesTests_Misc_SelectColor
    {
        //[Theory]
        [InlineData(2022, 12, 2, 2)]
        [InlineData(2022, 11, 30, 0)]
        [InlineData(2022, 11, 29, -1)]
        public void GetDaysLeft_ShouldReturnInt(int year, int month, int day, int expected)
        {
            
            int actual = SelectColor.GetDaysLeft(new DateTime(year, month, day));

            Assert.Equal(expected, actual);

        }

        //[Theory]
        [InlineData(2022,11,30, "#FF0000")]
        [InlineData(2022, 12, 2, "#FFA500")]
        [InlineData(2022, 12, 10, "#00FF00")]
        public void SetColor_ShouldReturnString(int year, int month, int day, string expeected)
        {

            string actual = SelectColor.SetColor(new DateTime(year, month, day));

            Assert.Equal(expeected, actual);
        }


    }
}
