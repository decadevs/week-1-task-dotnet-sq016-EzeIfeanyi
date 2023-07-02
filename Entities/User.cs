namespace BankConsoleApp
{
    public class User : IUser
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public IEnumerable<int> AccountId { get; set; }

        public User()
        {
            Id += 1;
            AccountId = new HashSet<int>();
        }
    }
}
