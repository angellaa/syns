namespace Syns
{
    public interface IUserService
    {
        void Login(string username, string password);
        User GetLoggedUser();
        void RegisterUser(string username, string password);
        void SaveUser(User user);
    }
}