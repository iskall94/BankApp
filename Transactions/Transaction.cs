using BankApp.Accounts;
using BankApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankApp.Transactions
{
    internal class Transaction
    {
        public List<Transaction> PendingTransactions { get; set; }
        private Guid TransactionID { get; set; }
        public AccountNumber ToAccount { get; set; }
        public AccountNumber FromAccount { get; set; }
        public decimal Value { get; set; }
        public string PersonalNote { get; set; }
        //bool isRecurring?

        public Transaction(AccountNumber toAccount, AccountNumber fromAccount, decimal value, string personalNote)
        {
            TransactionID = Guid.NewGuid();
            ToAccount = toAccount;
            FromAccount = fromAccount;
            Value = value;
            PersonalNote = personalNote;
        }


        public Transaction()
        {
        }

   
        public void ExecutePendingTransactions()
        {
            int isQuarter = DateTime.Now.Minute;
           

            if ( isQuarter % 15 == 0 )
            {
                foreach (Transaction tx in PendingTransactions)
                {
                    ExecuteTransaction(tx);
                    
                }
                PendingTransactions.Clear();
            }


        public void ExecuteTransaction(Transaction transaction) // 15 min delay
        {
          
            AccountNumber sender = transaction.FromAccount;
            AccountNumber reciever = transaction.ToAccount;

        

            BankAccount senderAccount = BankAccountDB.FindBankAccount(sender);
            BankAccount recieverAccount = BankAccountDB.FindBankAccount(reciever);


            senderAccount.Withdraw(transaction.Value);
            recieverAccount.Deposit(transaction.Value);

            senderAccount.AddTransaction(transaction);
            recieverAccount.AddTransaction(transaction);

            Console.WriteLine(senderAccount.Balance);
            Console.WriteLine(recieverAccount.Balance);


        }
        public override string ToString()
        {
            return $"TransactionID: {TransactionID}\n" +
                   $"To account: {ToAccount}\n" +
                   $"From account: {FromAccount}\n" +
                   $"Value: {Value}\n" +
                   $"Personal note: {PersonalNote}%\n" ;
               
        }
    }
}

