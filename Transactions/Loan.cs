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


    }
}
