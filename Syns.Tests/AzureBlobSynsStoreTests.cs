using Syns;
using Syns.Tests.ContractTests;

namespace AzureBlobSynsStore.Tests
{
    public class AzureBlobSynsStoreTests : ISynsStoreContractTests
    {
        protected override ISynsStore SynsStore()
        {
            return new AzureBlobSynsStore();
        }
    }
}
