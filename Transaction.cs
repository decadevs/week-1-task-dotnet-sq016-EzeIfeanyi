using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp
{
    internal class Transaction
    {
        public int TransactionId { get; set; }

        public DateTime dateTime { get; set; }

        protected bool _hasDepositedOnce = false;

        public bool hasDepositedOnce
        {
            get { return _hasDepositedOnce; }
            set { _hasDepositedOnce = value;}
        }

        public Account AccountPaying { get; set; }

        public Account? AccountReceiving { get; set; }

        public decimal fund { get; set; }

        public decimal PreviousBalance { get; set; }

        public decimal NewBalance { get; set; }
        public string note { get; set; } = "";

        protected static int idCounter = 0;

        public Transaction()
        {
            //ModelData.BankData();
            idCounter++;
            TransactionId = idCounter;

            dateTime = DateTime.Now;
        }

        public void DepositFund(Account account, decimal fund)
        {
            string pin = SecretInput.GetSecret("pin");

            if (getUserPin(account.AccountHolderId) != pin)
            {
                Console.WriteLine("Wrong transaction PIN");
                return;
            }
            else
            {
                PreviousBalance = account.AccountBalance;
                account.AccountBalance += fund;
                NewBalance = account.AccountBalance + fund;

                // Update account transaction
                AccountPaying = account;
                this.fund = fund;

                account.TransactionIds.Add(this.TransactionId);
            }

            var index = ModelData.accountsList.FindIndex(a => a.Id == account.Id);

            if (index == -1)
            {
                ModelData.accountsList.Insert(0, account);
            }
            else
            {
                ModelData.accountsList.Insert(index, account);
            }

            Console.Clear();
            Console.WriteLine("\nAccount Updated Successfully");
            Console.WriteLine("Previous Balance: {0}", PreviousBalance);
            Console.WriteLine("Amount credited: {0}", fund);
            Console.WriteLine("Current Account Balance: {0}", NewBalance);
                                                
            Console.WriteLine("\n\n\npress any key to return to menu");
            Console.ReadLine();

            Program.currentUserActivities(account);
        }

        public void WithdrawFund(Account account, decimal fund)
        {
            string pin = SecretInput.GetSecret("pin").Trim();

            if (getUserPin(account.AccountHolderId).Trim() != pin)
            {
                Console.WriteLine("Wrong transaction PIN");

                Console.WriteLine("\n\n\npress any key to return to menu");
                Console.ReadLine();

                Program.currentUserActivities(account);
            }
            else
            {
                if (account.Type == AccountType.Savings && account.AccountBalance == 1000)
                {
                    Console.WriteLine("We cannot proceed with this transaction as your balance is at its minimum");

                    Console.WriteLine("\n\n\npress any key to return to menu");
                    Console.ReadLine();

                    Program.currentUserActivities(account);
                }
                else if (account.Type == AccountType.Savings && account.AccountBalance - fund < 1000)
                {
                    while (account.AccountBalance - fund < 1000)
                    {
                        Console.WriteLine("You cannot withdraw the minimum balance of 1000\nTry a lesser amount: ");
                        fund = decimal.Parse(Console.ReadLine());
                    }

                    PreviousBalance = account.AccountBalance;

                    account.AccountBalance -= fund;

                    // Update account transaction
                    AccountPaying = account;
                    this.fund = fund;

                    Console.WriteLine("we are here now 1");

                    Console.ReadLine();

                    account.TransactionIds.Add(this.TransactionId);

                    Console.Clear();
                    Console.WriteLine("\nAccount Updated Successfully");
                    Console.WriteLine("Previous Balance: {0}", PreviousBalance);
                    Console.WriteLine("Amount credited: {0}", fund);
                    Console.WriteLine("Current Account Balance: {0}", account.AccountBalance);

                    Console.WriteLine("\n\n\npress any key to return to menu");
                    Console.ReadLine();

                    Program.currentUserActivities(account);
                }
                else
                {
                    if (account.AccountBalance - fund < 0)
                    {
                        throw new Exception("Exceeded Withdrawal limit... Minimum balance is less than zero");

                        Console.WriteLine("\n\n\npress any key to return to menu");
                        Console.ReadLine();

                        Program.currentUserActivities(account);
                    }

                    PreviousBalance = account.AccountBalance;

                    account.AccountBalance -= fund;

                    // Update account transaction
                    AccountPaying = account;
                    this.fund = fund;

                    account.TransactionIds.Add(this.TransactionId);

                    Console.Clear();
                    Console.WriteLine("\nAccount Updated Successfully");
                    Console.WriteLine("Previous Balance: {0}", PreviousBalance);
                    Console.WriteLine("Amount credited: {0}", fund);
                    Console.WriteLine("Current Account Balance: {0}", account.AccountBalance);

                    Console.WriteLine("\n\n\npress any key to return to menu");
                    Console.ReadLine();

                    var index = ModelData.accountsList.FindIndex(a => a.Id == account.Id);

                    ModelData.accountsList.Insert(index, account);

                    Program.currentUserActivities(account);
                }
            }

        }

        public void Transfer(Account paying, long accReceiving, decimal fund)
        {
            int accIndex = ModelData.accountsList.FindIndex(acc => acc.AccountNumber == accReceiving);

            Account receiving = ModelData.accountsList[accIndex];

            string pin = SecretInput.GetSecret("pin");

            if (getUserPin(paying.AccountHolderId) != pin)
            {
                Console.WriteLine("Wrong transaction PIN");
            }
            else
            {
                paying.AccountBalance -= fund;
                receiving.AccountBalance += fund;

                // Update the history of the transaction
                PreviousBalance = paying.AccountBalance + fund;
                NewBalance = paying.AccountBalance - fund;
                this.fund = fund;

                AccountPaying = paying;
                AccountReceiving = receiving;

                // use a list instead to get the transaction Id and
                // save the transaction in a database.
                paying.TransactionIds.Add(this.TransactionId);
                receiving.TransactionIds.Add(this.TransactionId);

                Console.Clear();
                Console.WriteLine("\nAccount Updated Successfully");
                Console.WriteLine("Previous Balance: {0}", PreviousBalance);
                Console.WriteLine("Amount credited: {0}", fund);
                Console.WriteLine("Current Account Balance: {0}", NewBalance);
                Console.WriteLine("Beneficiary's Account Number: {0}", accReceiving);
                Console.WriteLine("Beneficiary's Account Balance: {0}", receiving);

                Console.WriteLine("\n\n\npress any key to return to menu");
                Console.ReadLine();

                Program.currentUserActivities(paying);
            }
        }
            
        private string getUserPin(int id)
        {
            var users = ModelData.usersList;

            int pinIndex = users.FindIndex(user => user.Id == id);

            if (pinIndex == -1)
            {
                Console.WriteLine("User does not exist");
                return "";
            }

            return users[pinIndex].Pin;
        }
    }
}
