using NUnit.Framework;

namespace Syns.Tests.ContractTests
{
    public abstract class IUserServiceContractTests
    {
        private const string Username = "user";
        private const string Password = "password";

        [Test]
        public void SuccessfulLogin()
        {
            IUserService userService = ServiceWithUser(Username, Password);

            userService.Login(Username, Password);

            Assert.That(userService.GetLoggedUser(), Is.EqualTo(new User(Username)));
        }

        [Test]
        public void LoginWhenUserDoesNotExist()
        {
            IUserService userService = CreateUserService();
            userService.RegisterUser("Different " + Username, "irrelevant passowrd");

            userService.Login(Username, Password);

            Assert.IsNull(userService.GetLoggedUser());
        }

        [Test]
        public void LoginWithWrongPassword()
        {
            IUserService userService = CreateUserService();
            userService.RegisterUser(Username, "Different " + Password);

            userService.Login(Username, Password);

            Assert.IsNull(userService.GetLoggedUser());
        }

        [Test]
        public void RegisterUserThatAlreadyExist()
        {
            IUserService userService = ServiceWithUser(Username, Password);

            Assert.Throws<UserServiceException>(() => userService.RegisterUser(Username, Password));
        }

        [Test]
        public void SaveUser()
        {
            // Arrange
            IUserService userService = ServiceWithUser(Username, Password);
            userService.Login(Username, Password);

            var user = userService.GetLoggedUser();
            user.SynsAllowance = 15m;
            
            // Act
            userService.SaveUser(user);
            
            // Assert
            AssertUserAreEqual(user, userService.GetLoggedUser());
        }

        private void AssertUserAreEqual(User expected, User actual)
        {
            Assert.That(actual, Is.EqualTo(expected));
            Assert.That(actual.SynsAllowance, Is.EqualTo(expected.SynsAllowance));
        }

        private IUserService ServiceWithUser(string username, string password)
        {
            var userService = CreateUserService();
            userService.RegisterUser(username, password);

            return userService;
        }

        protected abstract IUserService CreateUserService();
    }
}