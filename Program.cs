using BankApp.Accounts;
using BankApp.Enums;
using BankApp.Menus;
using BankApp.Transactions;

namespace BankApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<BankAccount> userBankAccounts = new List<BankAccount>();
            User user = new User(Guid.NewGuid(), "lösenordet", "Paulina Porsmyr", userBankAccounts);
            UserDB.AddUser(user);
            
            User.LogIn();
        }
            //MainMenu.MainMenuStart();
    }
}
