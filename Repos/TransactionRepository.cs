using Microsoft.EntityFrameworkCore;

namespace BankConsoleApp.Repos
{
    internal class TransactionRepository
    {
        private DbContext _db;
        public TransactionRepository(DbContext db)
        {
            _db = db;
        }
    }
}
