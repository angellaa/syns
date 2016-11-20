using System;

namespace Syns
{
    public class UserServiceException : Exception
    {
        public UserServiceException() {}
        public UserServiceException(string message) : base(message) {}
        public UserServiceException(string message, Exception ex) : base(message, ex) { }
    }
}