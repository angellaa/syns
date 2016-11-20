using System.Collections.Generic;
using System.Linq;

namespace Syns.Tests.InMemoryContracts
{
    public class InMemoryUserService : IUserService
    {
        private readonly Dictionary<string, UserWithPassword> users = new Dictionary<string, UserWithPassword>();
        private User m_LoggedUser;

        public void Login(string username, string password)
        {
            if (UserExists(username) && users[username].Password == password)
            {
                m_LoggedUser = users[username].User;
            }
            else
            {
               m_LoggedUser = null;
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

            users.Add(username, userWithPassword);
        }

        public User GetLoggedUser()
        {
            return m_LoggedUser;
        }

        public void SaveUser(User user)
        {
            if (UserExists(user.Username))
            {
                users[user.Username].User = user;
            }            
        }

        private bool UserExists(string username)
        {
            return users.Keys.Contains(username);
        }

        private class UserWithPassword
        {
            public User User { get; set; }
            public string Password { get; set; }
        }
    }
}