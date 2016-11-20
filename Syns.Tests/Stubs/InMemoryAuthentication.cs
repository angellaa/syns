using System.Collections.Generic;
using System.Linq;

namespace Syns.Tests.Stubs
{
    public class InMemoryAuthentication : IAuthentication
    {
        public readonly Dictionary<string, string> users = new Dictionary<string, string>();

        public string Login(string username, string password)
        {
            if (users.Keys.Contains(username) && users[username] == password)
            {
                return username;
            }

            return null;
        }

        public void AddUser(string username, string password)
        {
            users.Add(username, password);
        }
    }
}