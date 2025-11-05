using BankApp.Menus;
using BankApp.Accounts;
using BankApp.Enums;

namespace BankApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount test = new BankAccount("test", AccountType.Normal, 100000m);
            //string accountNum = test.AccountNumber.ToString();
            //Console.WriteLine(accountNum);
            //Console.WriteLine(accountNum.GetType());


            BankAccountDB.AddBankAccount(test);
            AccountNumber accountNumber = test.AccountNumber;
            //Console.WriteLine(accountNumber);
            test.ChangeAccountCurrency(accountNumber, CurrencyType.USD);

            List<BankAccount> userBankAccounts = new List<BankAccount>();
            userBankAccounts.Add(test);
            User user = new User(Guid.NewGuid(), "default", "Gabriel Kassarp", userBankAccounts);

            UserDB.AddUser(user);
            user.IsLocked = false;
            MainMenu.MainMenuStart();

            // To test Login() Method


            //User.Login();

            // -----------------------

            // To test ChangeAccountCurrency


        }
    }
}
