using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp
{
    internal class ModelData
    {
        public static List<Account> accountsList { get; set; } = new List<Account>();

        public static List<Transaction> transactionList { get; set; } = new List<Transaction>();

        public static List<User> usersList { get; set; } = new List<User>();

        public static Dictionary<long, string> LoginInfo { get; set; } = new Dictionary<long, string>();

        public static void BankData()
        {
            Registration.Register("James", "Aribo", "Urekka", "9090", AccountType.Savings, 20000);
            Registration.Register("Martha", "Glen", "Uriel", "7074", AccountType.Current, 10000);
        }      
    }
}
