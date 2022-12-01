using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pantry;
using Pantry.converters;
using Xunit;

namespace Pantry.Tests
{
    public class ConverterersTests_DateTimeToString
    {
        //[Theory]
        [InlineData(2022, 12, 1, "2022-12-01")]
        [InlineData(12, 2, 1, "0012-02-01")]
        public void ConvertDataTimeToString_ShouldReturnString(int year, int month, int day, String expected)
        {
            // Arrange

            // Act
            DateTimeToString testClass = new DateTimeToString();

            //String actual = testClass.ConvertDateTimeToString(new DateTime(year, month, day));
            // Assert

            //Assert.Equal(expected, actual);
        }

        //[Fact]
        public void ConvertEmptyDataTimeToString_ShouldReturnString()
        {
            // Arrange
            String expected = "0001-01-01";

            // Act
            DateTimeToString testClass = new DateTimeToString();

            //String actual1 = testClass.ConvertDateTimeToString(new DateTime());
            // Assert

            //Assert.Equal(expected, actual1);
        }

        //[Fact]
        public void ConvertDataTimeToString_ShouldCatchException()
        {
            DateTimeToString testClass = new DateTimeToString();

            //Assert.Throws<ArgumentOutOfRangeException>(() => testClass.ConvertDateTimeToString(new DateTime(0, 0, 0)));
        }


        //[Theory]
        [InlineData(2022, 12, 01, "2022-12-01")]
        [InlineData(1, 1, 1, "0001-01-01")]
        public void ConvertStringToDateTime_ShouldReturnDateTime(int year, int month, int day, String givenString)
        {
            // Arrange
            DateTime expected = new DateTime(year, month, day);

            // Act
            DateTimeToString testClass = new DateTimeToString();

            //DateTime actual = testClass.ConvertStringToDateTime(givenString);
            

            // Assert
            //Assert.Equal(expected, actual);
        }

        //[Fact]
        public void ConvertEmptyStringToDateTime_ShouldReturnDateTime()
        {
            // Arrange
            DateTime expected = new DateTime(0001, 01, 01);

            // Act
            DateTimeToString testClass = new DateTimeToString();

            //DateTime actual = testClass.ConvertStringToDateTime(null);

            // Assert
            //Assert.Equal(expected, actual);
        }

        //[Fact]
        public void ConvertStringToDataTime_ShouldCatchException()
        {
            DateTimeToString testClass = new DateTimeToString();

            //Assert.Throws<NullReferenceException>(() => testClass.ConvertStringToDateTime("string"));
        }

    }
}