using BankApp.Menus;

namespace BankApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            MainMenu.MainMenuStart();



            //// --------- kod som behövs i menyn när allterativet 'sök lån' finns -----------
            ///
            //try
            //{
            //    Transaction loanTransx = gabriel.CreateLoan(LoanToAcc, loanFromAdmin, 80000, gabrielsKonto.Balance, "bil lån", TransactionType.Loan);
            //    loanTransx.ExecuteTransaction(loanTransx);

            //}
            //catch (InvalidOperationException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}


        }
    }
}
