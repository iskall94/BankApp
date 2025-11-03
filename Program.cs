using BankApp.Accounts;
using BankApp.Menus;

namespace BankApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<BankAccount> userBankAccounts = new List<BankAccount>();
            User user = new User(Guid.NewGuid(), "default", "Gabriel Kassarp", userBankAccounts);
      
            UserDB.AddUser(user);
            user.IsLocked = true;
            MainMenu.MainMenuStart();

            // To test Login() Method


            //User.Login();

            // -----------------------

            // To test ChangeAccountCurrency

            
            //BankAccountDB.AddBankAccount(test);
            //AccountNumber accountNumber = test.AccountNumber;
            //Console.WriteLine(accountNumber);
            //test.ChangeAccountCurrency(accountNumber, CurrencyType.USD);
        }
    }
}
