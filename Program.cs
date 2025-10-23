using BankApp.Accounts;
using BankApp.Enums;
using BankApp.Transactions;


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
            BankAccount gabrielsKonto = new BankAccount("gabriels konto", AccountType.Normal, Currency.SEK, 25000);
            User paulina = admin.CreateUser("lösenordet", "Paulina Porsmyr", paulinasKonto);
            User gabriel = admin.CreateUser("lösenord", "Gabriel Kassarp", gabrielsKonto);

            BankAccount resekonto = paulina.CreateBankAccount("Paulinas Resekonto", AccountType.Savings, Currency.SEK, 20000);


            AccountNumber fromAcc = paulinasKonto.AccountNumber;
            AccountNumber toAcc = gabrielsKonto.AccountNumber;



            decimal value = 10000;


           Transaction transx =  paulina.CreateTransaction(fromAcc, toAcc, value, "Överförning till Gustav");

            transx.ExecuteTransaction(transx);

            paulina.ShowAllAccounts();


      




            

          


            



        }
    }
}
