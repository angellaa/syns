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
    }
}
