using BankApp.Menus;
using BankApp.Accounts;
using BankApp.Enums;

namespace BankApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainMenu.MainMenuStart();
            
            // To test Login() Method

            //List<BankAccount> userBankAccounts = new List<BankAccount>();
            //User user = new User(Guid.NewGuid(), "default", "Gabriel Kassarp", userBankAccounts);
            //UserDB.AddUser(user);

            //User.Login();

            // -----------------------

            // To test ChangeAccountCurrency

            //BankAccount test = new BankAccount("test", AccountType.Normal, 100000m);
            //BankAccountDB.AddBankAccount(test);
            //AccountNumber accountNumber = test.AccountNumber;
            //Console.WriteLine(accountNumber);
            //test.ChangeAccountCurrency(accountNumber, CurrencyType.USD);
        }
    }
}
