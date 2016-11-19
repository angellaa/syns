namespace Syns
{
    public class Application
    {
        private readonly IAuthentication m_Authentication;
        private readonly ISynsStore m_SynsStore;
        private string m_LoggedUserName;

        public Application(IAuthentication authentication, ISynsStore synsStore)
        {
            m_Authentication = authentication;
            m_SynsStore = synsStore;
        }

        public void Login(string username, string password)
        {
            m_LoggedUserName = m_Authentication.Login(username, password);
        }

        public int TodaySyns()
        {
            return m_SynsStore.GetTodaySyns(m_LoggedUserName);
        }
    }
}