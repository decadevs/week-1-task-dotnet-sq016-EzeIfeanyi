using BankConsoleApp.Repos;

namespace BankConsoleApp.Services
{
    public class AccountServices
    {
        private static int _accountId = 0;
        private static long _accNumber = 8169438090;
        private static IAccountRepository _accountRepo;
        public AccountServices(IAccountRepository accountRepo)
        {
            _accountRepo = accountRepo;
        }
        public static IUser CreateAccount(IUser user)
        {
            IAccount acc = _accountRepo.CreateUser();
            acc.AccountNumber = $"{++_accNumber}";
            acc.Id = ++_accountId;
            acc.Type = Enums.AccountType.Current;
            user.AccountId.Add(acc.Id);

            _accountRepo.Add(acc);
            _accountRepo.Save();
            return user;
        }

        public static void DisplayAccountStatement(IUser user)
        {
            // get and display all user accounts and transactions
        }

        public static void Logout(IUser user)
        {
            user = null;
            Application.Run();
        }

        public static IUser Transactions(IUser user)
        {
            Console.WriteLine("Transactions");
            Console.WriteLine();
            Console.WriteLine(@"1. Deposit        2. Withdraw");
            Console.WriteLine(@"3. Transfer");
            Console.WriteLine();
            Console.Write("Select Option: ");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    return TransactionService.DepositFund(user);

                case "2":
                    return TransactionService.WithDrawFund(user);

                case "3":
                    return TransactionService.Transfer(user);

                default:
                    throw new NotImplementedException("Invalid Option");
            }
        }
    }
}