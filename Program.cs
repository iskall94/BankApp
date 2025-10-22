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

            BankAccount bankAccount = new BankAccount("konto", AccountType.Normal, Currency.SEK, 40000, 2.00f, accountHistory);

            Admin admin = new Admin(Guid.NewGuid(), "admin", "Admin");

            User aldor = admin.CreateUser("lösenord", "Aldor", bankAccount);

            Console.WriteLine(aldor);
            
        }
    }
}
