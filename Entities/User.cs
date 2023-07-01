namespace BankConsoleApp
{
    internal class User : IUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        // get the account AccountId instead
        public IEnumerable<int> AccountId { get; set; }

        public User()
        {
            Id += 1;
            AccountId = new HashSet<int>();
        }
    }
}
