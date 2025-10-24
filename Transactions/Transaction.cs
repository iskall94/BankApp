using BankApp.Accounts;
using BankApp.Enums;

namespace BankApp.Transactions
{
    internal class Transaction
    {

        private Guid TransactionID { get; set; }
        public AccountNumber ToAccount { get; set; }
        public AccountNumber FromAccount { get; set; }
        public TransactionType TransactionType { get; set; }
        public decimal Value { get; set; }
        public string PersonalNote { get; set; }
        //bool isRecurring?

        public Transaction(AccountNumber toAccount, AccountNumber fromAccount, decimal value, string personalNote, TransactionType transactionType)
        {
            TransactionID = Guid.NewGuid();
            ToAccount = toAccount;
            FromAccount = fromAccount;
            Value = value;
            PersonalNote = personalNote;
            TransactionType = transactionType;

        }


        public Transaction()
        {
        }



        public void ExecuteTransaction(Transaction transaction) // 15 min delay
        {
            AccountNumber sender = transaction.FromAccount;
            AccountNumber reciever = transaction.ToAccount;

            BankAccount senderAccount;

            if (transaction.TransactionType == TransactionType.Loan)
            {
                senderAccount = Admin.bankaccount;
            }
            else
            {
                senderAccount = BankAccountDB.FindBankAccount(sender);
            }
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
                   $"Personal note: {PersonalNote}%\n";

        }
    }
}

