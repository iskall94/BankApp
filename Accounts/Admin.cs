using BankApp.Enums;

namespace BankApp.Accounts
{
    internal class Admin : User
    {
        public static BankAccount bankaccount { get; set; } = new BankAccount("admins konto", AccountType.Normal, Currency.SEK, 10000000);
        public Admin(Guid userID, string password, string name) : base(userID, password, name)
        {

        }

        public static User CreateUser(string password, string name, BankAccount account)
        {
            List<BankAccount> userBankAccounts = new List<BankAccount>();
            userBankAccounts.Add(account);
            BankAccountDB.AddBankAccount(account);
            User newUser = new User(Guid.NewGuid(), password, name, userBankAccounts);
            newUser.AddUser(newUser);
            return newUser;

        }

        public static void AdminCreateUser(string password)
        {
            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("---User Creation Tool---");
            Console.WriteLine("Please enter a name for user:");
            string name = Console.ReadLine() ?? "";

            bool successful = false;
            string balanceInput;
            decimal decimalNumber = 0;

            while (!successful)
            {
                Console.WriteLine("Please enter a balance:");
                balanceInput = Console.ReadLine() ?? "";
                successful = decimal.TryParse(balanceInput, out decimalNumber);
                if (successful)
                {
                    Console.WriteLine("Balance successfully implemented.");
                }
                else
                {
                    Console.WriteLine("Could not parse the balance input. Please enter a valid input.");
                }
            }
            BankAccount bankAccount = new BankAccount("account", Enums.AccountType.Normal, Enums.Currency.SEK, decimalNumber);
            User createdUser = Admin.CreateUser(password, name, bankAccount);


            UserDB.AddUser(createdUser);
            Console.WriteLine(createdUser.ToString());
            Console.ReadKey();
        }

        public static void FreezeBankAccount()
        {

        }

        public static void UpdateExchangeRates()
        {

        }



    }
}
