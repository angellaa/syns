using Syns.Tests.ContractTests;
using Syns.Tests.InMemoryContracts;

namespace Syns.Tests.InMemoryContractsTests
{
    public class InMemoryAuthenticationTests : IAuthenticationContractTests
    {
        protected override IAuthentication AuthenticationWithUser(string username, string password)
        {
            var authentication = new InMemoryAuthentication();
            authentication.AddUser(username, password);

            return authentication;
        }

        protected override IAuthentication AuthenticationWithoutUser(string username)
        {
            var authentication = new InMemoryAuthentication();
            authentication.AddUser("Different " + username, "irrelevant passowrd");

            return authentication;
        }

        protected override IAuthentication AuthenticationWithUserButDifferentPassword(string username, string password)
        {
            var authentication = new InMemoryAuthentication();
            authentication.AddUser(username, "Different " + password);

            return authentication;
        }
    }
}