﻿using BankConsoleApp.Enums;

namespace BankConsoleApp
{
    internal class Transaction : ITransaction
    {
        private int _TransactionId;
        public int TransactionId { get; set; }

        readonly DateTime dateTime;
        public TransactType Type { get; set; }
        public string AccountSenderNumber { get; set; }
        public string? AccountReceiverNumber { get; set; }
        public string? AccountSenderBalance { get; set; }
        public string? AccountReceiverBalance { get; set; }
        public decimal Amount { get; set; }
        public string? Note { get; set; }

        public Transaction()
        {
            dateTime = DateTime.Now;
        }
    }
}
