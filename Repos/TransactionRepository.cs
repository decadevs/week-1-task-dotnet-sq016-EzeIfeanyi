using Microsoft.EntityFrameworkCore;

namespace BankConsoleApp.Repos
{
    internal class TransactionRepository
    {
        private DbContext _db;
        private DbSet<ITransaction> _dbSet;
        public TransactionRepository(DbContext db)
        {
            _db = db;
            _dbSet = db.Set<ITransaction>();
        }

        public Transaction CreateUser()
        {
            return new();
        }

        public ITransaction? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        //public IEnumerable<ITransaction> GetAll()
        //{
        //    return _dbSet.OrderBy(item => item.Id).ToList();
        //}
        public void Add(ITransaction employee)
        {
            _dbSet.Add(employee);
        }

        //public void Remove(ITransaction item)
        //{
        //    _dbSet.Remove(item);
        //}

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
