using NSubstitute;
using NUnit.Framework;

namespace Syns.Tests
{
    public class ApplicationTodaySynsTests
    {
        [Test]
        public void TodaySyns()
        {
            // Arrange
            var user = new User("user");

            var userService = Substitute.For<IUserService>();
            userService
                .GetLoggedUser()
                .Returns(user);

            var todaySyns = 13.5m;

            var synsStore = Substitute.For<ISynsStore>();
            synsStore
                .GetTodaySyns(user)
                .Returns(todaySyns);

            // Act
            var application = new Application(userService, synsStore);

            // Assert
            Assert.That(application.TodaySyns, Is.EqualTo(todaySyns));

            userService.Received(1).GetLoggedUser();
            synsStore.Received(1).GetTodaySyns(user);
        }

        [TestCase(25, 10.5, 14.5)]
        [TestCase(25, 25, 0)]
        [TestCase(25, 27, 0)]
        public void TodaySynsLeft(decimal synsAllowance, decimal todaySyns, decimal synsLeft)
        {
            // Arrange
            var user = new User("user")
            {
                SynsAllowance = synsAllowance
            };

            var userService = Substitute.For<IUserService>();
            userService
                .GetLoggedUser()
                .Returns(user);

            var synsStore = Substitute.For<ISynsStore>();
            synsStore
                .GetTodaySyns(user)
                .Returns(todaySyns);

            // Act
            var application = new Application(userService, synsStore);

            // Assert
            Assert.That(application.TodaySynsLeft, Is.EqualTo(synsLeft));
        }
    }
}
