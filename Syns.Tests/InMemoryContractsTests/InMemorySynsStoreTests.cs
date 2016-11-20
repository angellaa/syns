using Syns.Tests.ContractTests;
using Syns.Tests.InMemoryContracts;

namespace Syns.Tests.InMemoryContractsTests
{
    public class InMemorySynsStoreTests : ISynsStoreContractTests
    {
        protected override ISynsStore SynsStore()
        {
            return new InMemorySynsStore();
        }
    }
}