using NUnit.Framework;

namespace Syns.Tests.ContractTests
{
    public abstract class ISynsStoreContractTests
    {
        [Test]
        public void TodaySyns()
        {
            var user = new User("user");
            var todaySyns = 12.5m;

            ISynsStore synsStore = SynsStore(user, todaySyns);

            Assert.That(synsStore.GetTodaySyns(user), Is.EqualTo(todaySyns));
        }


        protected abstract ISynsStore SynsStore(User use, decimal todaySyns);
    }
}