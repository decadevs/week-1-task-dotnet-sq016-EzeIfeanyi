using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp
{
    internal class User
    {
        public int Id { get; set; } = 0;

        private string _FirstName;
        public string FirstName {  get; set; }

        private string _LastName;
        public string LastName { get; set; }

        private string _Private;
        public string Password { get; set; }

        private string _Pin;

        public string Pin { get; set; }
        
        // get the account AccountId instead
        public List<int> AccountId { get; set; } = new List<int>();

        public User()
        {
            Id += 1;
        }
    }
}
