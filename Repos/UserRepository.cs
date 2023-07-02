using Microsoft.EntityFrameworkCore;

namespace BankConsoleApp.Repos
{
    internal class UserRepository
    {
        private DbContext _db;
        private DbSet<IUser> _dbSet;
        public UserRepository(DbContext db)
        {
            _db = db;
            _dbSet = db.Set<IUser>();
        }

        public User CreateUser()
        {
            return new ();
        }

        public IUser? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        //public IEnumerable<IUser> GetAll()
        //{
        //    return _dbSet.OrderBy(item => item.Id).ToList();
        //}
        public void Add(IUser employee)
        {
            _dbSet.Add(employee);
        }

        //public void Remove(IUser item)
        //{
        //    _dbSet.Remove(item);
        //}

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
