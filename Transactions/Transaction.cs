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



        public void ExecuteTransaction(Transaction transaction) // 15 min delay
        {

            AccountNumber sender = transaction.FromAccount;
            AccountNumber reciever = transaction.ToAccount;



            BankAccount senderAccount = BankAccountDB.FindBankAccount(sender);
            BankAccount recieverAccount = BankAccountDB.FindBankAccount(reciever);


            senderAccount.Withdraw(transaction.Value);
            recieverAccount.Deposit(transaction.Value);

            Console.WriteLine(senderAccount.Balance);
            Console.WriteLine(recieverAccount.Balance);


        }

    }
}
