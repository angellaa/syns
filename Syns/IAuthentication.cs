namespace Syns
{
    public interface IAuthentication
    {
        string Login(string username, string password);
    }
}