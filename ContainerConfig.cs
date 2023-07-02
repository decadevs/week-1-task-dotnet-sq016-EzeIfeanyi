using Autofac;
using BankConsoleApp.Repos;

namespace BankConsoleApp
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Account>().As<IAccount>();
            builder.RegisterType<User>().As<IUser>();
            builder.RegisterType<Transaction>().As<ITransaction>();
            builder.RegisterType<AccountRepository>().As<IAccountRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<Transaction>().As<ITransaction>();

            return builder.Build();
        }
    }
}
