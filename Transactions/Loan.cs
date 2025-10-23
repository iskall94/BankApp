using BankApp.Enums;

namespace BankApp.Transactions
{
    internal class Loan : Transaction
    {
        public decimal Interest { get; set; }
        public Loan(AccountNumber toAccount, AccountNumber fromAccount, decimal value, string transactionName, string personalNote, decimal interest) : base(toAccount, fromAccount, value, personalNote)
        {
            Interest = interest;
        }


    }
}
