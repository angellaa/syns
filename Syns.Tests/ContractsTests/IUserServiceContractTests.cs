using NUnit.Framework;

namespace Syns.Tests.ContractTests
{
    public abstract class IUserServiceContractTests
    {
        private const string Username = "user";
        private const string Password = "password";

        [Test]
        public void Success()
        {
            IUserService userService = ServiceWithUser(Username, Password);

            userService.Login(Username, Password);

            Assert.That(userService.GetLoggedUser(), Is.EqualTo(new User(Username)));
        }

        [Test]
        public void UserDoesNotExist()
        {
            IUserService userService = ServiceWithoutUser(Username);

            userService.Login(Username, Password);

            Assert.IsNull(userService.GetLoggedUser());
        }

        [Test]
        public void UserExistButPasswordIsWrong()
        {
            IUserService userService = ServiceWithUserButDifferentPassword(Username, Password);

            userService.Login(Username, Password);

            Assert.IsNull(userService.GetLoggedUser());
        }

        protected abstract IUserService ServiceWithUser(string username, string password);
        protected abstract IUserService ServiceWithoutUser(string username);
        protected abstract IUserService ServiceWithUserButDifferentPassword(string username, string password);
    }
}