namespace BankConsoleApp.Repos
{
    internal interface ITransactionRepository
    {
        void Add(ITransaction employee);
        Transaction CreateUser();
        IEnumerable<ITransaction> GetAll();
        ITransaction? GetById(int id);
        void Remove(ITransaction item);
        void Save();
    }
}