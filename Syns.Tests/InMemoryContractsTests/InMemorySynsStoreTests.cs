using Syns.Tests.ContractTests;
using Syns.Tests.InMemoryContracts;

namespace Syns.Tests.InMemoryContractsTests
{
    public class InMemorySynsStoreTests : ISynsStoreContractTests
    {
        protected override ISynsStore SynsStore(User user, decimal todaySyns)
        {
            var synsStore = new InMemorySynsStore();
            synsStore.SetTodaySyns(user, todaySyns);

            return synsStore;
        }
    }
}