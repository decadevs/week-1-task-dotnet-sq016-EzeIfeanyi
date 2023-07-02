namespace BankConsoleApp
{
    public static class UserInformation
    {
        public static ValueTuple<string, string, string, string> GetUserInformation()
        {
            Console.Write("First Name: ");
            string FName = Console.ReadLine() ?? "John";
            Console.Write("First Name: ");
            string LName = Console.ReadLine() ?? "Doe";
            Console.Write("First Name: ");
            string Email = Console.ReadLine() ?? "JohnDoe@gmail.com";
            Console.Write("First Name: ");
            string Password = Console.ReadLine() ?? "12345";

            return (FName, LName, Email, Password);

        }

        //public static bool ValidateUserInfo(string Fname, string Lname, string Email)
        //{
        //    return true;
        //}
    }
}
