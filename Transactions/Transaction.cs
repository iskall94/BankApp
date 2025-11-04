using BankApp.Accounts;
using BankApp.Enums;
using BankApp.Currencies;

namespace BankApp.Transactions
{
    internal class Transaction
    {
        public List<Transaction> PendingTransactions { get; set; }
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

        public void ExecutePendingTransactions()
        {
            int isQuarter = DateTime.Now.Minute;


            if (isQuarter % 15 == 0)
            {
                foreach (Transaction tx in PendingTransactions)
                {
                    ExecuteTransaction(tx);

                }
                PendingTransactions.Clear();
            }
        }

        /// <summary>
        /// Executes a transaction between two accounts, handling special cases for loan transactions.
        /// Withdraws the amount from the sender account and deposits it to the receiver account,
        /// then records the transaction in both accounts.
        /// </summary>
        /// <param name="transaction">The transaction to execute, containing sender, receiver, amount, and type.</param>
        /// <remarks>
        /// If the transaction type is <see cref="TransactionType.Loan"/>, the funds are taken from the admin bank account
        /// instead of the sender's account.
        /// </remarks>
        public void ExecuteTransaction(Transaction transaction) // 15 min delay
        {
            if (transaction.Value  > 100000)
            {
                EmailService.SendIssueCodeEmail(3, null, null, transaction);
            }

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
            if (senderAccount.Currency != recieverAccount.Currency)
            {
                decimal senderToSEK = CurrencyManager.AccountCurrency[senderAccount.Currency];
                decimal receiverToSEK = CurrencyManager.AccountCurrency[recieverAccount.Currency];

                transaction.Value = transaction.Value * (senderToSEK / receiverToSEK);
            }

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

