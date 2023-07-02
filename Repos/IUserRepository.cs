namespace BankConsoleApp.Repos
{
    internal interface IUserRepository
    {
        void Add(IUser employee);
        User CreateUser();
        IEnumerable<IUser> GetAll();
        IUser? GetById(int id);
        void Remove(IUser item);
        void Save();
    }
}