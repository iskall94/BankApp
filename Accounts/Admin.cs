using BankApp.Enums;

namespace BankApp.Accounts
{
    internal class Admin : User
    {
        public static BankAccount bankaccount { get; set; } = new BankAccount("admins konto", AccountType.Normal, 10000000);
        public Admin(Guid userID, string password, string name) : base(userID, password, name)
        {

        }

        public static User CreateUser(string password, string name, BankAccount account)
        {
            List<BankAccount> userBankAccounts = new List<BankAccount>();
            userBankAccounts.Add(account);
            BankAccountDB.AddBankAccount(account);
            User newUser = new User(Guid.NewGuid(), password, name, userBankAccounts);
            UserDB.AddUser(newUser);
            return newUser;

        }

        public void ChangeBankAccountType(AccountNumber accountNumber, Enums.AccountType AccountType)
        {
            Console.WriteLine(accountNumber);
            var account = BankAccountDB.FindBankAccount(accountNumber);
            Console.WriteLine(accountNumber.ToString(), AccountType);

            foreach (AccountType type in Enum.GetValues(typeof(AccountType)))
            {
                Console.WriteLine($"\n{type}");
                Console.WriteLine("Enter a new type for your bank account (one of the above): ");
                string newType = Console.ReadLine();
                Enum.TryParse(newType, out AccountType);


                Console.WriteLine($" The type of your bankaccount ({accountNumber}) has been updated to: {AccountType}");

            }


        }

        public static void FreezeBankAccount()
        {

        }

        public static void UpdateExchangeRates()
        {

        }



    }
}
