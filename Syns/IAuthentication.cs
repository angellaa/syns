namespace Syns
{
    public interface IAuthentication
    {
        User Login(string username, string password);
    }
}