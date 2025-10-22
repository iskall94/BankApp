using BankApp.Accounts;
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
        public string PersonalNote { get; set; }
        //bool isRecurring?

        public Transaction( AccountNumber toAccount, AccountNumber fromAccount, decimal value,  string personalNote)
        {
            TransactionID = Guid.NewGuid();
            ToAccount = toAccount;
            FromAccount = fromAccount;
            Value = value;
            PersonalNote = personalNote;
        }

         public Transaction CreateTransaction(AccountNumber toAccount, AccountNumber fromAccount, decimal value, string personalNote)
        {
            Transaction newTx = new Transaction(toAccount, fromAccount, value, personalNote);

            return newTx;
        }

        public BankAccount findAccount(AccountNumber accountNumber)
        {
            BankAccount bankAccount = null;

            bankAccount.AccountNumber.Equals(accountNumber);


            return bankAccount;
        }


        public void ExecuteTransaction(Transaction transaction) // 15 min delay
        {

            AccountNumber sender = transaction.FromAccount;
            AccountNumber reciever = transaction.ToAccount;

            //BankAccount senderAccount = //includes sender
            //BankAccount recieverAccount = //includes reciever

            //senderAccount.Withdraw(transaction.Value);
            //recieverAccount.Deposit(transaction.Value);


        }

    }
}
