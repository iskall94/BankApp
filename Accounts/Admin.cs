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
            UserDB.AddUser(newUser);
            return newUser;

        }

        public static void FreezeBankAccount()
        {

        }

        public static void UpdateExchangeRates()
        {

        }



    }
}
