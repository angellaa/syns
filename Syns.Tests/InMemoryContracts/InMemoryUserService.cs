using System.Collections.Generic;
using System.Linq;

namespace Syns.Tests.InMemoryContracts
{
    public class InMemoryUserService : IUserService
    {
        private readonly Dictionary<string, UserWithPassword> savedUsers = new Dictionary<string, UserWithPassword>();
        private string m_LoggedUserName;

        public void Login(string username, string password)
        {
            if (UserExists(username) && savedUsers[username].Password == password)
            {
                m_LoggedUserName = username;
            }
            else
            {
                m_LoggedUserName = null;
            }
        }

        public void AddUser(string username, string password)
        {
            if (UserExists(username))
            {
                throw new UserServiceException($"The user {username} already exist.");    
            }

            var userWithPassword = new UserWithPassword
                                   {
                                       User = new User(username),
                                       Password = password
                                   };

            savedUsers.Add(username, userWithPassword);
        }

        public User GetLoggedUser()
        {
            if (m_LoggedUserName == null)
            {
                return null;
            }

            return CloneUser(savedUsers[m_LoggedUserName].User);
        }

        public void SaveUser(User user)
        {
            if (UserExists(user.Username))
            {
                savedUsers[user.Username].User = user;
            }            
        }

        private bool UserExists(string username)
        {
            return savedUsers.Keys.Contains(username);
        }

        private static User CloneUser(User user)
        {
            return new User(user.Username)
            {
                SynsAllowance = user.SynsAllowance
            };
        }

        private class UserWithPassword
        {
            public User User { get; set; }
            public string Password { get; set; }
        }
    }
}