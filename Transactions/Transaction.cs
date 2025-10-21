using BankApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Transactions
{
    internal class Transaction
    {

        private Guid TransactionID { get; set; }
        public AccountNumber ToAccount { get; set; } 
        public AccountNumber FromAccount { get; set; } 
        public decimal Value { get; set; }
        public string TransactionName { get; set; }
        public string PersonalNote { get; set; }
        //bool isRecurring?

        public Transaction(Guid transactionID, AccountNumber toAccount, AccountNumber fromAccount, decimal value, string transactionName, string personalNote)
        {
            TransactionID = Guid.NewGuid();
            ToAccount = toAccount;
            FromAccount = fromAccount;
            Value = value;
            TransactionName = transactionName;
            PersonalNote = personalNote;
        }

        public void CreateTransaction()
        {

        }

        public void ExecuteTransaction() //15 min delay
        {

        }

    }
}
