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
            List<Transaction> TransactionHistory = new List<Transaction>();
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


            Transaction transx = paulina.CreateTransaction(fromAcc, toAcc, value, "Överförning till Gustav", TransactionType.Normal);

            transx.ExecuteTransaction(transx);

            paulina.ShowAllAccounts();

            paulinasKonto.GetTransactionHistory();




            //söka om ett lån

            BankAccount loanFromAdmin = Admin.bankaccount;
            AccountNumber LoanToAcc = gabrielsKonto.AccountNumber;


            try
            {
                Transaction loanTransx = gabriel.CreateLoan(LoanToAcc, loanFromAdmin, 800, gabrielsKonto.Balance, "bil lån", TransactionType.Loan);
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
