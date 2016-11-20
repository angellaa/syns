namespace Syns
{
    public interface ISynsStore
    {
        decimal GetTodaySyns(User user);
        void SetTodaySyns(User user, decimal todaySyns);
    }
}