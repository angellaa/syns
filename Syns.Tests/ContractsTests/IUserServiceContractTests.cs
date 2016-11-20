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

        [Test]
        public void AddUserThatAlreadyExist()
        {
            IUserService userService = ServiceWithUser(Username, Password);

            Assert.Throws<UserServiceException>(() => userService.AddUser(Username, Password));
        }

        [Test]
        public void SaveUser()
        {
            IUserService userService = ServiceWithUser(Username, Password);

            userService.Login(Username, Password);

            var user = userService.GetLoggedUser();
            user.SynsAllowance = 15m;

            userService.Login(Username, Password);

            AssertUserAreEqual(user, userService.GetLoggedUser());
        }

        private void AssertUserAreEqual(User expected, User actual)
        {
            Assert.That(actual, Is.EqualTo(expected));
            Assert.That(actual.SynsAllowance, Is.EqualTo(expected.SynsAllowance));
        }

        private IUserService ServiceWithUser(string username, string password)
        {
            var authentication = CreateUserService();
            authentication.AddUser(username, password);

            return authentication;
        }

        private IUserService ServiceWithoutUser(string username)
        {
            var authentication = CreateUserService();
            authentication.AddUser("Different " + username, "irrelevant passowrd");

            return authentication;
        }

        private IUserService ServiceWithUserButDifferentPassword(string username, string password)
        {
            var authentication = CreateUserService();
            authentication.AddUser(username, "Different " + password);

            return authentication;
        }

        protected abstract IUserService CreateUserService();
    }
}