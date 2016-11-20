using NSubstitute;
using NUnit.Framework;

namespace Syns.Tests
{
    public class TodaySynsTests
    {
        [Test]
        public void TodaySyns()
        {
            // Arrange
            var username = "username@me.com";
            var password = "password";

            var authentication = Substitute.For<IAuthentication>();
            authentication
                .Login(username, password)
                .Returns(username);

            var todaySyns = 13.5m;

            var synsStore = Substitute.For<ISynsStore>();
            synsStore
                .GetTodaySyns(username)
                .Returns(todaySyns);

            // Act
            var application = new Application(authentication, synsStore);
            application.Login(username, password);

            // Assert
            Assert.That(application.TodaySyns, Is.EqualTo(todaySyns));

            authentication.Received(1).Login(username, password);
            synsStore.Received(1).GetTodaySyns(username);
        }

        [TestCase(25, 10.5, 14.5)]
        [TestCase(25, 25, 0)]
        [TestCase(25, 27, 0)]
        public void TodaySynsLeft(decimal synsAllowance, decimal todaySyns, decimal synsLeft)
        {
            // Arrange
            var username = "username@me.com";
            var password = "password";

            var authentication = Substitute.For<IAuthentication>();
            authentication
                .Login(username, password)
                .Returns(username);

            var synsStore = Substitute.For<ISynsStore>();
            synsStore
                .GetTodaySyns(username)
                .Returns(todaySyns);

            // Act
            var application = new Application(authentication, synsStore);
            application.Login(username, password);
            application.SetSynsAllowance(synsAllowance);

            // Assert
            Assert.That(application.TodaySynsLeft, Is.EqualTo(synsLeft));
        }
    }
}
