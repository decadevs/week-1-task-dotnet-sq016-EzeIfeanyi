using Microsoft.EntityFrameworkCore;

namespace BankConsoleApp.Data
{
    internal class StorageAppDBContext : DbContext
    {
        public DbSet<IUser> Users => Set<IUser>();
        public DbSet<IAccount> Accounts => Set<IAccount>();
        public DbSet<ITransaction> Transactions => Set<ITransaction>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("ContosoBankAppData");
        }
    }
}
