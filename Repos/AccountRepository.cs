using Microsoft.EntityFrameworkCore;

namespace BankConsoleApp.Repos
{
    internal class AccountRepository
    {
        private DbContext _db;
        private DbSet<IAccount> _dbSet;
        public AccountRepository(DbContext db)
        {
            _db = db;
            _dbSet = db.Set<IAccount>();
        }

        public Account CreateUser()
        {
            return new();
        }

        public IAccount? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        //public IEnumerable<IAccount> GetAll()
        //{
        //    return _dbSet.OrderBy(item => item.Id).ToList();
        //}
        public void Add(IAccount employee)
        {
            _dbSet.Add(employee);
        }

        //public void Remove(IAccount item)
        //{
        //    _dbSet.Remove(item);
        //}

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
