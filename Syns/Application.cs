namespace Syns
{
    public class Application
    {
        private readonly IUserService m_UserService;
        private readonly ISynsStore m_SynsStore;

        public Application(IUserService userService, ISynsStore synsStore)
        {
            m_UserService = userService;
            m_SynsStore = synsStore;
        }

        public decimal TodaySyns()
        {
            return m_SynsStore.GetTodaySyns(LoggedUser());
        }

        public decimal TodaySynsLeft()
        {
            var synsLeft = LoggedUser().SynsAllowance - TodaySyns();

            return synsLeft > 0 ? synsLeft : 0;
        }

        private User LoggedUser()
        {
            return m_UserService.GetLoggedUser();
        }

        public void AddSyns(decimal syns)
        {
            var loggedUser = LoggedUser();
            var newSyns = TodaySyns() + syns;

            m_SynsStore.SetTodaySyns(loggedUser, newSyns);
        }
    }
}