using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp
{
    internal class Account
    {
        public int Id { get; set; }

        private long _AccountNumber;
        public long AccountNumber { get; set; }
        public int AccountHolderId { get; set; }
        public AccountType Type { get; set; } = AccountType.Savings;
        public decimal AccountBalance { get; set; } = 0;

        private bool _AccountLogin;
        public bool AccountLogin { get; set; } = false;
        public List<int> TransactionIds { get; set; } = new List<int>();

        protected static long AccountNumberCounter = 8069438090;

        protected static int idCounter = 0;

        public Account()
        {
            AccountNumberCounter += 1;
            idCounter += 1;
            AccountNumber = AccountNumberCounter;
            Id = idCounter;
        }
    }

    public enum AccountType
    {
        Savings = 1,
        Current = 2
    }
}
