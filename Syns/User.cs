using System;

namespace Syns
{
    public class User : IEquatable<User>
    {
        public User(string username)
        {
            Username = username;
        }

        public string Username { get; }
        public decimal SynsAllowance { get; set; }

        public bool Equals(User other)
        {
            if (other == null) return false;

            return Username == other.Username;
        }

        public override bool Equals(object obj)
        {
            return Equals((User) obj);
        }

        public override int GetHashCode()
        {
            return Username?.GetHashCode() ?? 0;
        }

        public override string ToString()
        {
            return $"User({Username})";
        }
    }
}