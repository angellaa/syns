using System;
using NUnit.Framework;
using Syns.Tests.Stubs;

namespace Syns.Tests
{
    public class AuthenticationTests
    {
        [Test]
        public void Success()
        {
            var username = "user@me.com";
            var password = "password";

            var authentication = new InMemoryAuthentication();
            authentication.WithUser(username, password);

            var loggedUser = authentication.Login(username, password);

            Assert.That(loggedUser, Is.EqualTo(username));
        }

        [Test]
        public void UserDoesNotExist()
        {
            var username = "user@me.com";
            var password = "password";

            var authentication = new InMemoryAuthentication();
            authentication.WithoutUser(username);

            var loggedUser = authentication.Login(username, password);

            Assert.IsNull(loggedUser);
        }

        [Test]
        public void UserExistButPassowordIsWrong()
        {
            var username = "user@me.com";
            var password = "password";

            var authentication = new InMemoryAuthentication();
            authentication.WithUserButDifferentPassword(username, password);

            var loggedUser = authentication.Login(username, password);

            Assert.IsNull(loggedUser);
        }
    }
}