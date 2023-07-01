using BankConsoleApp.Enums;

namespace BankConsoleApp
{
    internal class Account : IAccount
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public AccountType Type { get; set; }
        public decimal Balance { get; set; }
        public string Address { get; set; }
        public IEnumerable<int> TransactionId { get; set; }

        public string DisplayAccountStatement()
        {
            return "";
        }


        public Account()
        {

        }
    }
}
