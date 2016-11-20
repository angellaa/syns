using NUnit.Framework;

namespace Syns.Tests.ContractTests
{
    public abstract class IAuthenticationContractTests
    {
        [Test]
        public void Success()
        {
            var username = "user@me.com";
            var password = "password";

            IAuthentication authentication = AuthenticationWithUser(username, password);

            var loggedUser = authentication.Login(username, password);

            Assert.That(loggedUser, Is.EqualTo(username));
        }

        [Test]
        public void UserDoesNotExist()
        {
            var username = "user@me.com";
            var password = "password";

            IAuthentication authentication = AuthenticationWithoutUser(username);

            var loggedUser = authentication.Login(username, password);

            Assert.IsNull(loggedUser);
        }

        [Test]
        public void UserExistButPasswordIsWrong()
        {
            var username = "user@me.com";
            var password = "password";

            IAuthentication authentication = AuthenticationWithUserButDifferentPassword(username, password);

            var loggedUser = authentication.Login(username, password);

            Assert.IsNull(loggedUser);
        }

        protected abstract IAuthentication AuthenticationWithUser(string username, string password);
        protected abstract IAuthentication AuthenticationWithoutUser(string username);
        protected abstract IAuthentication AuthenticationWithUserButDifferentPassword(string username, string password);
    }
}