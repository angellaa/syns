namespace Syns
{
    public interface IUserService
    {
        void Login(string username, string password);
        User GetLoggedUser();
    }
}