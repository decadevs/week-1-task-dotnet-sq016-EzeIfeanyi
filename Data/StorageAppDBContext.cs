using Microsoft.EntityFrameworkCore;

namespace BankConsoleApp.Data
{
    internal class StorageAppDBContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Account> Accounts => Set<Account>();
        public DbSet<Transaction> Transactions => Set<Transaction>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("ContosoBankAppData");
        }
    }
}
