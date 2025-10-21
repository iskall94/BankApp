using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankApp.Transactions
{
    internal class Loan : Transaction
    {
        public Loan(Guid transactionID, int toAccount, int fromAccount, decimal value, string transactionName, string personalNote) : base(transactionID, toAccount, fromAccount, value, transactionName, personalNote)
        {
            TransactionID = transactionID;
            ToAccount = toAccount;
            FromAccount = fromAccount;
            Value = value;
            TransactionName = transactionName;
            PersonalNote = personalNote;
        }
    }
}
