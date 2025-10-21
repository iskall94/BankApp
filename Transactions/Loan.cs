using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using BankApp.Enums;

namespace BankApp.Transactions
{
    internal class Loan : Transaction
    {
        public Loan(Guid transactionID, AccountNumber toAccount, AccountNumber fromAccount, decimal value, string transactionName, string personalNote) : base(transactionID, toAccount, fromAccount, value, transactionName, personalNote)
        {
        }
    }
}
