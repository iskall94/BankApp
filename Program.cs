using BankApp.Accounts;
using BankApp.Enums;
using BankApp.Menus;
using System.Transactions;

namespace BankApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Transaction> accountHistory = new List<Transaction>();
            List<BankAccount> bankAccounts = new List<BankAccount>();


            Admin admin = new Admin(Guid.NewGuid(), "admin", "Admin");
            BankAccount paulinasKonto = new BankAccount("paulinas konto", AccountType.Normal, Currency.SEK, 25000);
            //User paulina = admin.CreateUser("lösenordet", "Paulina Porsmyr", paulinasKonto);

            //BankAccount resekonto = paulina.CreateBankAccount("Paulinas Resekonto", AccountType.Savings, Currency.SEK, 20000);

            AccountNumber fromacc = paulinasKonto.AccountNumber;
            //AccountNumber toAcc = resekonto.AccountNumber;

            decimal value = 10000;

            //paulina.HandleTransfer(toAcc, fromacc, value);

            MainMenu mainMenu = new MainMenu();
            mainMenu.MainMenuStart();
            




            

          


            



        }
    }
}
