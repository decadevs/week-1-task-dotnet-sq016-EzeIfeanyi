using BankConsoleApp.Enums;

namespace BankConsoleApp
{
    public interface IAccount
    {
        string? AccountNumber { get; set; }
        decimal Balance { get; set; }
        int Id { get; set; }
        IEnumerable<int>? TransactionId { get; set; }
        AccountType Type { get; set; }

        string DisplayAccountStatement();
    }
}