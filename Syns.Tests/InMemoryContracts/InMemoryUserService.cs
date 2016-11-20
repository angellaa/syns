using System.Collections.Generic;
using System.Linq;

namespace Syns.Tests.InMemoryContracts
{
    public class InMemoryUserService : IUserService
    {
        public readonly Dictionary<string, string> users = new Dictionary<string, string>();
        private User m_LoggedUser;

        public void Login(string username, string password)
        {
            if (users.Keys.Contains(username) && users[username] == password)
            {
                m_LoggedUser = new User(username);
            }
            else
            {
               m_LoggedUser = null;
            }
        }

        public void AddUser(string username, string password)
        {
            users.Add(username, password);
        }

        public User GetLoggedUser()
        {
            return m_LoggedUser;
        }
    }
}