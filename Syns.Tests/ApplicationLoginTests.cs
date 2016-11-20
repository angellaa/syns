using NSubstitute;
using NUnit.Framework;

namespace Syns.Tests
{
    public class ApplicationLoginTests
    {
        [Test]
        public void LoginFail()
        {
            var username = "username@me.com";
            var password = "password";

            var authentication = Substitute.For<IAuthentication>();
            authentication
                .Login(username, password)
                .Returns((User)null);

            var synsStore = Substitute.For<ISynsStore>();

            var application = new Application(authentication, synsStore);

            Assert.Throws<AuthenticationException>(() => application.Login(username, password));
            authentication.Received(1).Login(username, password);
        }
    }
}