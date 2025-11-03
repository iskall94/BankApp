using BankApp.Menus;
using BankApp.Accounts;
using BankApp.Enums;
using BankApp;
using Microsoft.Extensions.Configuration;

namespace BankApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Configures the json file at the start of program
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            
            EmailService.Initialize(configuration);

            List<BankAccount> userBankAccounts = new List<BankAccount>();
            User user = new User(Guid.NewGuid(), "default", "Gabriel Kassarp", userBankAccounts);
            UserDB.AddUser(user);
            MainMenu.MainMenuStart();

            // To test Login() Method


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
