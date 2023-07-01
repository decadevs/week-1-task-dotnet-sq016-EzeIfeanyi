using Microsoft.EntityFrameworkCore;

namespace BankConsoleApp.Repos
{
    internal class UserRepository
    {
        private DbContext _db;
        public UserRepository(DbContext db)
        {
            _db = db;
        }
    }
}
