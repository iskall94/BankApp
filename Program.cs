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
            // MainMenu.MainMenuStart();

            BankAccount test = new BankAccount("test", AccountType.Normal, 100000m);
            BankAccountDB.AddBankAccount(test);
            AccountNumber accountNumber = test.AccountNumber;
            Console.WriteLine(accountNumber);
            test.ChangeAccountCurrency(accountNumber, CurrencyType.USD);
        }
    }
}
