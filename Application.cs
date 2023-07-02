using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp
{
    public static class Application
    {
        private static IUser user;
        public static void Run()
        {
            user = BankAppInterfaceWelcomePage();
            BankAppInterfaceCustomerPage(user);
        }

        public static IUser BankAppInterfaceWelcomePage()
        {
            Console.WriteLine("Welcome to GiGi Bank");
            Console.WriteLine();
            Console.WriteLine(@"1. Login         2. Register");
            Console.WriteLine();
            Console.WriteLine("Select an Option: Login or Register?");

            var option = Console.ReadLine();

            switch(option)
            {
                case "1":
                    return BankService.LoginUser();

                case "2":
                    return BankService.RegisterUser();

                default:
                    throw new Exception("Invalid Option");
            }
        }

        public static void BankAppInterfaceCustomerPage(IUser user)
        {
            Console.WriteLine("Customer Page");
            Console.WriteLine();
            Console.WriteLine(@"1. Bank Transactions     2. Create New Account");
            Console.WriteLine();
            Console.WriteLine(@"3. Account Statement     4. Logout");
            Console.WriteLine();

            var option = Console.ReadLine();

            switch(option)
            {
                case "1":
                    user = AccountServices.Transactions();
                    break;

                case "2":
                    user = AccountServices.CreateAccount();
                    break;

                case "3":
                    AccountServices.DisplayAccountStatement();
                    break;

                case "4":
                    AccountServices.Logout();
                    break;

                default:
                    throw new Exception("Invalid Option");
            }
        }
    }
}
