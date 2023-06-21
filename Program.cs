using BankConsoleApp;
using System.Security;

internal class Program
{
    private static void Main(string[] args)
    {
        string firstName = "";
        string lastName = "";
        string password = "";
        string pin = "";
        Account? currentUser = null;
        int index;

        ModelData.BankData();

        WelcomePage();

        void WelcomePage()
        {
            Console.Clear();
            Console.WriteLine("\n=============== Welcome To Contoso Bank ===============\n\n");

            Console.WriteLine("1. Sign-up\t\t\t\t 2. Login\n\n");

            Console.Write("Enter Option: ");

            string pick = Console.ReadLine();

            switch (pick)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("\n========== SignUp Form ==========\n\n");



                    while (firstName.Length == 0)
                    {
                        Console.Write("Enter firstname: ");
                        firstName = Console.ReadLine();
                        Console.WriteLine("\n");
                    }

                    while (lastName.Length == 0)
                    {
                        Console.Write("Enter lastname: ");
                        lastName = Console.ReadLine();
                        Console.WriteLine("\n");
                    }

                    while (password.Length == 0)
                    {
                        password = SecretInput.GetSecret("password");
                        Console.WriteLine("\n");
                    }

                    while (pin.Length == 0)
                    {
                        pin = SecretInput.GetSecret("pin");
                        Console.WriteLine("\n");
                    }

                    Console.Clear();

                    Console.WriteLine("========== Account Type ==========\n");
                    Console.WriteLine("1. Savings\t\t\t\t2. Current\n");
                    Console.Write("Enter type option: ");

                    string type = Console.ReadLine().Trim();

                    AccountType accountType = AccountType.Savings;

                    if (type == "1")
                    {
                        accountType = AccountType.Savings;
                    }
                    else if (type == "2")
                    {
                        accountType = AccountType.Current;
                    }
                    else
                    {
                        Console.WriteLine("Enter a valid account type");
                    }

                    decimal amount = 0;

                    currentUser = Registration.Register(firstName, lastName, password, pin, accountType, amount);

                    index = ModelData.accountsList.FindIndex(acc => acc.AccountNumber == currentUser.AccountNumber);
                    ModelData.accountsList[index] = currentUser;

                    currentUserActivities(currentUser);
                    
                    break;

                case "2":

                    userLogin();
                    break;

                default:

                    Console.WriteLine("Invalid option");
                    break;

            }
        }
        
        void userLogin()
        {
            currentUser = Login.LoginUser();

            if (currentUser == null)
            {
                Console.WriteLine("Invalid user credentials");

                Console.WriteLine("Proceed with user login: ");
                Console.WriteLine("1. Yes\t\t\t\t\t2.No\n");
                Console.Write("Choose option: ");
                var proceed = Console.ReadLine();

                switch (proceed)
                {
                    case "1":

                        userLogin();
                        break;

                    case "2":

                        WelcomePage();
                        break;

                    default:

                        Console.WriteLine("Invalid option");
                        break;
                }
            }
            else
            {
                currentUserActivities(currentUser);
                index = ModelData.accountsList.FindIndex(acc => acc.AccountNumber == currentUser.AccountNumber);
                ModelData.accountsList[index] = currentUser;
            }
        }
    }

    public static void currentUserActivities(Account account)
    {
        Console.Clear ();
        Console.WriteLine("1. Transaction\t\t\t\t\t2.Create New Account");
        Console.WriteLine("3. Logout\t\t\t\t\t4. Statement of Account\n");

        Console.Write("Enter Option: ");

        var pick = Console.ReadLine();

        switch(pick)
        {
            case "1":

                Console.Clear();
                Console.WriteLine("1. Deposit Fund\t\t\t\t\t2. WithDraw Fund\n");
                Console.WriteLine("3. Transfer Fund");

                Transaction transaction = new Transaction();

                var transactionOption = Console.ReadLine();

                if (transactionOption != null)
                {
                    if (transactionOption == "1")
                    {
                        Console.Write("Enter amount: ");

                        var amount = decimal.Parse(Console.ReadLine());

                        transaction.DepositFund(account, amount);

                        account.TransactionIds.Add(transaction.TransactionId);
                        
                    }
                    else if (transactionOption == "2")
                    {
                        Console.Write("Enter amount: ");

                        var amount = decimal.Parse(Console.ReadLine());

                        transaction.WithdrawFund(account, amount);

                        account.TransactionIds.Add(transaction.TransactionId);
                    }
                    else if (transactionOption == "3")
                    {
                        Console.Write("Enter the recipient account number: ");

                        long acc = long.Parse(Console.ReadLine());

                        Console.Write("Enter amount: ");

                        var amount = decimal.Parse(Console.ReadLine());

                        transaction.Transfer(account, acc, amount);

                        account.TransactionIds.Add(transaction.TransactionId);
                    }
                }

                break;

            case "2":

                Console.Clear();
                Console.WriteLine("Create Account");
                break;

            case "3":

                Console.Clear();
                Console.WriteLine("Logout");
                break;

            case "4":

                Console.Clear();
                Console.WriteLine("View statement of the current account");
                // List<Transaction> txList = new List<Transaction>();
                List<Account> accounts = new List<Account>();

                int userId = account.AccountHolderId;

                User user = ModelData.usersList.Find(u => u.Id == userId);

                accounts = ModelData.accountsList.FindAll(acc => acc.Id == user.Id);

                Console.WriteLine("Account Name\t\tAccount Number\t\tAccount Type\t\tAmount Balance\t\tNote");

                foreach (Account acc in accounts)
                {
                    foreach (int id in acc.TransactionIds)
                    {
                        Transaction tx = ModelData.transactionList.Find(t => t.TransactionId == id);

                        Console.WriteLine($"{user.FirstName} {user.LastName}\t\t{acc.AccountNumber}\t\t{acc.Type}\t\t\t{tx.NewBalance}\t\t{tx.note}");
                    }
                }

                Console.ReadLine();

                //user.AccountId.ForEach(id =>
                //{
                //    accounts.Add(ModelData.accountsList.Find(acc => acc.Id == id));
                //});

                //

                //foreach (Account acc in accounts)
                //{
                //    foreach (int id in acc.TransactionIds)
                //    {
                //        var tx = ModelData.transactionList.Find(tx => tx.TransactionId == id);

                //        Console.WriteLine();
                //    }
                //}

                break;

            default :

                Console.Clear();
                Console.WriteLine("Invalid option");
                break;
        }
    }
}
