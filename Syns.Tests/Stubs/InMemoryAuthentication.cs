using System.Collections.Generic;
using System.Linq;

namespace Syns.Tests.Stubs
{
    public class InMemoryAuthentication : IAuthentication
    {
        public readonly Dictionary<string, string> users = new Dictionary<string, string>();

        public User Login(string username, string password)
        {
            if (users.Keys.Contains(username) && users[username] == password)
            {
                return new User(username);
            }

            return null;
        }

        public void AddUser(string username, string password)
        {
            users.Add(username, password);
        }
    }
}