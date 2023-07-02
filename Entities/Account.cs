using BankConsoleApp.Enums;

namespace BankConsoleApp
{
    public class Account : IAccount
    {
        public int Id { get; set; }
        public string? AccountNumber { get; set; }
        public AccountType Type { get; set; } = AccountType.Savings;
        public decimal Balance { get; set; }
        public IEnumerable<int>? TransactionId { get; set; }

        //public Account()
        //{

        //}
        public string DisplayAccountStatement()
        {
            return "";
        }
    }
}
