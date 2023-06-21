using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp
{
    internal class Login
    {
        public static Account? LoginUser()
        {
            Account? account;

            long accountNumber;

            Console.Write("Enter Account Number: ");

            string number = Console.ReadLine();

            // string pass = SecretInput.GetSecret("password");

            string pass = SecretInput.GetSecret("Password");

            bool check = long.TryParse(number, out accountNumber);

            string password;

            if (check == true && number != null)
            {
                foreach (long num in ModelData.LoginInfo.Keys)
                {
                    Console.WriteLine(num);
                }
                //int accountIndex = accounts.FindIndex(acc => acc.AccountNumber == accountNumber);
                bool accCheck = ModelData.LoginInfo.TryGetValue(accountNumber, out password);

                if (accCheck &&  pass == password)
                {
                    Console.Clear();
                    Console.WriteLine("Successful Login");

                    account = ModelData.accountsList[ModelData.accountsList.FindIndex(acc => acc.AccountNumber == accountNumber)];
                }
                else
                {
                    Console.WriteLine($"Invalid User credentials {password}");

                    account = null;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid account number");
                account = null;
            }
            return account;
        }
    }
}
