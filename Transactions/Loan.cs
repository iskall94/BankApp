using BankApp.Enums;

namespace BankApp.Transactions
{
    internal class Loan : Transaction
    {
        public decimal Interest { get; set; }
        public Loan(AccountNumber toAccount, AccountNumber fromAccount, decimal value, string personalNote, decimal interest, TransactionType transactionType) : base(toAccount, fromAccount, value, personalNote, transactionType)
        {
            Interest = interest;
        }

        /// <summary>
        /// Calculates the total payment for a loan, including interest, over a specified number of years,
        /// and returns a formatted summary string.
        /// </summary>
        /// <param name="loanAmount">The amount of the loan.</param>
        /// <param name="interestRate">The annual interest rate (in percent) applied to the loan.</param>
        /// <param name="years">The duration of the loan in years.</param>
        /// <returns>A string showing the loan amount, interest rate, and total payment.</returns>
        public string CalculateLoan(decimal loanAmount, decimal interestRate, int years)
        {
            decimal totalInterest = loanAmount * (interestRate / 100) * years;
            decimal totalPayment = loanAmount + totalInterest;

            return "Your loan has been granted. \n" +
                   $"Loan Amount: {loanAmount} kr\n" +
                   $"Interest Rate: {interestRate}% per year\n" +
                   $"Total Payment: {totalPayment} kr\n";
        }
    }
}
