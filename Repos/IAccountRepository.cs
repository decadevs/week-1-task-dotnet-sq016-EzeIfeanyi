namespace BankConsoleApp.Repos
{
    public interface IAccountRepository
    {
        void Add(IAccount employee);
        Account CreateUser();
        IEnumerable<IAccount> GetAll();
        IAccount? GetById(int id);
        void Remove(IAccount item);
        void Save();
    }
}