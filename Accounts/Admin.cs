using BankApp.Enums;

namespace BankApp.Accounts
{
    internal class Admin : User
    {
        public static BankAccount bankaccount { get; set; }
        public Admin(Guid userID, string password, string name) : base(userID, password, name)
        {
            bankaccount = new BankAccount("admins konto", AccountType.Normal, Currency.SEK, 10000000);

        }

        public User CreateUser(string password, string name, BankAccount account)
        {
            List<BankAccount> userBankAccounts = new List<BankAccount>();
            userBankAccounts.Add(account);
            BankAccountDB.AddBankAccount(account);
            User newUser = new User(Guid.NewGuid(), password, name, userBankAccounts);
            return newUser;

        }

        public void FreezeBankAccount()
        {

        }

        public void UpdateExchangeRates()
        {

        }



    }
}
