using Syns.Tests.ContractTests;
using Syns.Tests.InMemoryContracts;

namespace Syns.Tests.InMemoryContractsTests
{
    public class InMemoryUserServiceTests : IUserServiceContractTests
    {
        protected override IUserService CreateUserService()
        {
            return new InMemoryUserService();
        }
    }
}