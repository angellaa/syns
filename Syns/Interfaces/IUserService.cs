namespace Syns
{
    public interface IUserService
    {
        bool Login(string username, string password);
        void Logout();
        User GetLoggedUser();
        void RegisterUser(string username, string password);
        void SaveUser(User user);
    }
}