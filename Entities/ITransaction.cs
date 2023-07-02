using BankConsoleApp.Enums;

namespace BankConsoleApp
{
    internal interface ITransaction
    {
        string? AccountReceiverBalance { get; set; }
        string? AccountReceiverNumber { get; set; }
        string? AccountSenderBalance { get; set; }
        string AccountSenderNumber { get; set; }
        decimal Amount { get; set; }
        string? Note { get; set; }
        TransactType Type { get; set; }
        int TransactionId { get; set; }
    }
}