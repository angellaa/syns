using System;

namespace Syns
{
    public class User : IEquatable<User>
    {
        private readonly string m_Username;

        public User(string username)
        {
            m_Username = username;
        }

        public bool Equals(User other)
        {
            if (other == null) return false;

            return m_Username == other.m_Username;
        }

        public override bool Equals(object obj)
        {
            return Equals((User) obj);
        }

        public override int GetHashCode()
        {
            return m_Username?.GetHashCode() ?? 0;
        }

        public override string ToString()
        {
            return $"User({m_Username})";
        }
    }
}