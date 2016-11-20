
namespace Syns
{
    public class Application
    {
        private readonly IAuthentication m_Authentication;
        private readonly ISynsStore m_SynsStore;
        private User m_LoggedUser;

        public Application(IAuthentication authentication, ISynsStore synsStore)
        {
            m_Authentication = authentication;
            m_SynsStore = synsStore;
        }

        public void Login(string username, string password)
        {
            m_LoggedUser = m_Authentication.Login(username, password);

            if (m_LoggedUser == null)
            {
                throw new AuthenticationException();
            }
        }

        public decimal TodaySyns()
        {
            return m_SynsStore.GetTodaySyns(m_LoggedUser);
        }

        public decimal TodaySynsLeft()
        {
            var synsLeft = m_LoggedUser.SynsAllowance - TodaySyns();

            return synsLeft > 0 ? synsLeft : 0;
        }
    }
}