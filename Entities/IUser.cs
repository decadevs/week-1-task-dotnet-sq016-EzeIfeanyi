namespace BankConsoleApp
{
    public interface IUser
    {
        int Id { get; set; }
        string? FirstName { get; set; }
        string? LastName { get; set; }
        string? Email { get; set; }
        string? Password { get; set; }
        IEnumerable<int> AccountId { get; set; }
    }
}