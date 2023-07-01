using Microsoft.EntityFrameworkCore;

namespace BankConsoleApp.Repos
{
    internal class AccountRepository
    {
        private DbContext _db;
        public AccountRepository(DbContext db)
        {
            _db = db;
        }
    }
}
