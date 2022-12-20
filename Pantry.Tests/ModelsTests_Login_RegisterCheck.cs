using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pantry;
using Pantry.models.Login;
using Xunit;

namespace Pantry.Tests
{
    public class ModelsTests_Login_RegisterCheck
    {

        [Fact]
        public void CheckIfEmailCorrect_ShouldReturnTrue()
        {
            RegisterCheck registerCheck= new RegisterCheck();

            bool actual = registerCheck.CheckIfEmailCorrect("admin@gmail.com");
            
            bool expected = actual;

            Assert.Equal(expected, actual);
        
        }
/*        [Theory]
        [InlineData("admin@gmail.com")]
        [InlineData("admin@admin.lt")]
        public void CheckIfEmailCorrect_ShouldReturnTrue(string email)
        {
            RegisterCheck testClass = new RegisterCheck();
            bool actual = testClass.CheckIfEmailCorrect(email);
            bool expected = true;
            Assert.Equal(actual, expected);
        }

        [Theory]
        [InlineData("@gmail.com")]
        [InlineData("")]
        public void CheckIfEmailCorrect_ShouldReturnFalse(string email)
        {
            RegisterCheck testClass = new RegisterCheck();
            Assert.False(testClass.CheckIfEmailCorrect(email));
        }
        [Theory]
        [InlineData("admin@gmail.com", "admin", "1234")]
        public void CheckIfEntriesAreNotNull_ShouldReturnTrue(string email, string username, string password)
        {
            RegisterCheck testClass = new RegisterCheck();
            Assert.True(testClass.CheckIfEntriesAreNotNull(email, username, password));
        }

        [Fact]
        public void CheckIfEntriesAreNotNull_ShouldReturnFalse()
        {
            RegisterCheck testClass = new RegisterCheck();
            Assert.False(testClass.CheckIfEntriesAreNotNull(null, null, null));
            Assert.False(testClass.CheckIfEntriesAreNotNull("1", null, null));
            Assert.False(testClass.CheckIfEntriesAreNotNull(null, "1", null));
            Assert.False(testClass.CheckIfEntriesAreNotNull(null, null, "1"));
            Assert.False(testClass.CheckIfEntriesAreNotNull("1", "1", null));
            Assert.False(testClass.CheckIfEntriesAreNotNull(null, "1", "1"));
            Assert.False(testClass.CheckIfEntriesAreNotNull("1", null, "1"));
        }*/
    }
}
