using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp
{
    internal static class Registration
    {
        public static Account Register(string firsttname, string lastname, string password, string pin, AccountType type, decimal amount)
        {

            User user = new User()
            {
                FirstName = firsttname,
                LastName = lastname,
                Password = password,
                Pin = pin
            };

            ModelData.usersList.Add(user);

            Account account = new Account();

            if (type == AccountType.Savings)
            {
                account.Type = AccountType.Savings;
            }
            else
            {
                account.Type = AccountType.Current;
            }

            account.AccountHolderId = account.Id;
            user.AccountId.Add(account.Id);
                        
            ModelData.accountsList.Add(account);
            ModelData.LoginInfo.Add(account.AccountNumber, user.Password);

            Transaction transaction = new Transaction();

            if (transaction.hasDepositedOnce ==  false)
            {
                while (amount < 1000)
                {
                    Console.Write("Enter Initial deposit amount: ");
                    var amountCheck = decimal.TryParse(Console.ReadLine(), out amount);

                    if (amountCheck == true)
                    {
                        if (amount >= 1000)
                        {
                            transaction.DepositFund(account, amount);
                        }
                        else
                        {
                            Console.WriteLine($"Amount \"{amount}\" should be a minimum of 1000 for first deposit\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input amount");
                    }
                }
            }
            else
            {
                transaction.DepositFund(account, amount);
            }
            ModelData.transactionList.Add(transaction);

            return account;
        }
    }
}
