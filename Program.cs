using BankApp.Accounts;
using BankApp.Enums;
using BankApp.Transactions;


namespace BankApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Admin admin = new Admin(Guid.NewGuid(), "admin", "Admin");


            //söka om ett lån

            BankAccount gabrielsKonto = new BankAccount("gabriels konto", AccountType.Normal, Currency.SEK, 25000);

            User gabriel = admin.CreateUser("lösenord", "Gabriel Kassarp", gabrielsKonto);


            BankAccount loanFromAdmin = Admin.bankaccount;
            AccountNumber LoanToAcc = gabrielsKonto.AccountNumber;


            try
            {
                Transaction loanTransx = gabriel.CreateLoan(LoanToAcc, loanFromAdmin, 80000, gabrielsKonto.Balance, "bil lån", TransactionType.Loan);
                loanTransx.ExecuteTransaction(loanTransx);

            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }



            gabrielsKonto.GetTransactionHistory();






        }
    }
}
