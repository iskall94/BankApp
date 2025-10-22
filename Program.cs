using BankApp.Accounts;
using BankApp.Enums;
using System.Transactions;

namespace BankApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Transaction> accountHistory = new List<Transaction>();
            List<BankAccount> bankAccounts = new List<BankAccount>();

            

            BankAccount bankAccount = new BankAccount("konto", AccountType.Normal, Currency.SEK, 40000);

            Admin admin = new Admin(Guid.NewGuid(), "admin", "Admin");

            User aldor = admin.CreateUser("lösenord", "Aldor", bankAccount);
           
            aldor.CreateBankAccount("Aldors Sparkonto", AccountType.Savings, Currency.SEK, 100000);
            Console.WriteLine(aldor);

            



        }
    }
}
