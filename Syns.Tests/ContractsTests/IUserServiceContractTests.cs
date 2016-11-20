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
            IUserService userService = ServiceWithUser();

            Assert.IsTrue(userService.Login(Username, Password));
            Assert.That(userService.GetLoggedUser(), Is.EqualTo(new User(Username)));
        }

        [Test]
        public void Logout()
        {
            IUserService userService = ServiceWithUser();

            userService.Login(Username, Password);
            userService.Logout();

            Assert.IsNull(userService.GetLoggedUser());
        }

        [Test]
        public void LoginWhenUserDoesNotExist()
        {
            IUserService userService = CreateUserService();
            userService.RegisterUser("Different " + Username, "irrelevant passowrd");

            Assert.IsFalse(userService.Login(Username, Password));
            Assert.IsNull(userService.GetLoggedUser());
        }

        [Test]
        public void LoginWithWrongPassword()
        {
            IUserService userService = CreateUserService();
            userService.RegisterUser(Username, "Different " + Password);

            Assert.IsFalse(userService.Login(Username, Password));
            Assert.IsNull(userService.GetLoggedUser());
        }

        [Test]
        public void RegisterUserThatAlreadyExist()
        {
            IUserService userService = ServiceWithUser();

            Assert.Throws<UserServiceException>(() => userService.RegisterUser(Username, Password));
        }

        [Test]
        public void SaveUser()
        {
            // Arrange
            IUserService userService = ServiceWithUser();
            userService.Login(Username, Password);

            var user = userService.GetLoggedUser();
            user.SynsAllowance = 15m;
            
            // Act
            userService.SaveUser(user);
            
            // Assert
            AssertUserAreEqual(user, userService.GetLoggedUser());
        }

        [Test]
        public void FailedLoginPreserveCurrentLoggedUser()
        {
            IUserService userService = ServiceWithUser();
            userService.Login(Username, Password);

            userService.Login("Different " + Username, Password);

            Assert.That(userService.GetLoggedUser(), Is.EqualTo(new User(Username)));
        }

        private void AssertUserAreEqual(User expected, User actual)
        {
            Assert.That(actual, Is.EqualTo(expected));
            Assert.That(actual.SynsAllowance, Is.EqualTo(expected.SynsAllowance));
        }

        private IUserService ServiceWithUser()
        {
            var userService = CreateUserService();
            userService.RegisterUser(Username, Password);

            return userService;
        }

        protected abstract IUserService CreateUserService();
    }
}