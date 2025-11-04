using BankApp.Menus;
using BankApp.Accounts;
using BankApp.Enums;

namespace BankApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            BankAccount One = new BankAccount("Goob", AccountType.Normal, 1000);
            BankAccount Two = new BankAccount("Gaba", AccountType.Normal, 1000);
            Admin.CreateUser("default", "Goob", One);
            Admin.CreateUser("default", "Gaba", Two);
            BankAccountDB.AddBankAccount(One);
            BankAccountDB.AddBankAccount(Two);
            MainMenu.MainMenuStart();






        }
    }
}
