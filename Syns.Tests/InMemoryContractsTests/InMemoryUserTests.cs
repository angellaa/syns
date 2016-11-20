using Syns.Tests.ContractTests;
using Syns.Tests.InMemoryContracts;

namespace Syns.Tests.InMemoryContractsTests
{
    public class InMemoryUserTests : IUserContractTests
    {
        protected override IUserService ServiceWithUser(string username, string password)
        {
            var authentication = new InMemoryUserService();
            authentication.AddUser(username, password);

            return authentication;
        }

        protected override IUserService ServiceWithoutUser(string username)
        {
            var authentication = new InMemoryUserService();
            authentication.AddUser("Different " + username, "irrelevant passowrd");

            return authentication;
        }

        protected override IUserService ServiceWithUserButDifferentPassword(string username, string password)
        {
            var authentication = new InMemoryUserService();
            authentication.AddUser(username, "Different " + password);

            return authentication;
        }
    }
}