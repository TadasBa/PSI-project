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
        [Theory]
        [InlineData("admin@gmail.com")]
        [InlineData("admin@admin.lt")]
        public void CheckIfEmailCorrect_ShouldReturnTrue(string email)
        {
            RegisterCheck testClass = new RegisterCheck();
            Assert.True(testClass.CheckIfEmailCorrect(email));
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
        }

        /*[Theory]
        [InlineData("admin1")]
        public void CheckIfUserIsNotTaken_ShouldReturnTrue(string username)
        {
            RegisterCheck testClass = new RegisterCheck();
            Assert.True(testClass.CheckIfUserIsNotTaken(username));
        }

        [Theory]
        [InlineData("admin")]
        public void CheckIfUserIsNotTaken_ShouldReturnFalse(string username)
        {
            RegisterCheck testClass = new RegisterCheck();
            Assert.False(testClass.CheckIfUserIsNotTaken(username));
        }*/
    }
}
