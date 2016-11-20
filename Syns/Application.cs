using System;

namespace Syns
{
    public class Application
    {
        private readonly IAuthentication m_Authentication;
        private readonly ISynsStore m_SynsStore;
        private string m_LoggedUserName;
        private decimal m_SynsAllowance;

        public Application(IAuthentication authentication, ISynsStore synsStore)
        {
            m_Authentication = authentication;
            m_SynsStore = synsStore;
        }

        public void Login(string username, string password)
        {
            m_LoggedUserName = m_Authentication.Login(username, password);

            if (m_LoggedUserName == null)
            {
                throw new AuthenticationException();
            }
        }

        public decimal TodaySyns()
        {
            return m_SynsStore.GetTodaySyns(m_LoggedUserName);
        }

        public void SetSynsAllowance(decimal synsAllowance)
        {
            m_SynsAllowance = synsAllowance;
        }

        public decimal TodaySynsLeft()
        {
            var synsLeft = m_SynsAllowance - TodaySyns();

            return synsLeft > 0 ? synsLeft : 0;
        }
    }
}