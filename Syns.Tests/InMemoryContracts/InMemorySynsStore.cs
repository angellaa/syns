using System.Collections.Generic;

namespace Syns.Tests.InMemoryContracts
{
    public class InMemorySynsStore : ISynsStore
    {
        private readonly Dictionary<User, decimal> todaySyns = new Dictionary<User, decimal>();

        public decimal GetTodaySyns(User user)
        {
            return todaySyns[user];
        }

        public void SetTodaySyns(User user, decimal syns)
        {
            todaySyns[user] = syns;
        }
    }
}