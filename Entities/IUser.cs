namespace BankConsoleApp
{
    internal interface IUser
    {
        IEnumerable<int> AccountId { get; set; }
        string FirstName { get; set; }
        int Id { get; set; }
        string LastName { get; set; }
        string Password { get; set; }
    }
}