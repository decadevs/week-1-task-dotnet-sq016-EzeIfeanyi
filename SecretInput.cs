using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp
{
    internal static class SecretInput
    {
        public static string GetSecret(string secret)
        {
            Console.Write("Enter your {0}: ", secret);

            List<char> pass = new List<char>();

            ConsoleKeyInfo key;

            do
            {

                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Write("");
                }
                else if (key.Key != ConsoleKey.Backspace)
                {
                    pass.Add(key.KeyChar);
                    Console.Write("*");
                }
                else
                {
                    pass.RemoveAt(pass.Count() - 1);
                    Console.Write("\b \b");
                }
            }
            while (key.Key != ConsoleKey.Enter);

            var passArray = pass.ToArray();

            var result = new string(passArray).Trim();

            return result;
        }
    }
}
