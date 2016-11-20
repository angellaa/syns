using NUnit.Framework;

namespace Syns.Tests.ContractTests
{
    public abstract class IUserContractTests
    {
        [Test]
        public void Success()
        {
            var username = "user@me.com";
            var password = "password";

            IUserService userService = ServiceWithUser(username, password);

            userService.Login(username, password);

            Assert.That(userService.GetLoggedUser(), Is.EqualTo(new User(username)));
        }

        [Test]
        public void UserDoesNotExist()
        {
            var username = "user@me.com";
            var password = "password";

            IUserService userService = ServiceWithoutUser(username);

            userService.Login(username, password);

            Assert.IsNull(userService.GetLoggedUser());
        }

        [Test]
        public void UserExistButPasswordIsWrong()
        {
            var username = "user@me.com";
            var password = "password";

            IUserService userService = ServiceWithUserButDifferentPassword(username, password);

            userService.Login(username, password);

            Assert.IsNull(userService.GetLoggedUser());
        }

        protected abstract IUserService ServiceWithUser(string username, string password);
        protected abstract IUserService ServiceWithoutUser(string username);
        protected abstract IUserService ServiceWithUserButDifferentPassword(string username, string password);
    }
}