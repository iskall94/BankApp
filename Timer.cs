using BankApp.Transactions;

namespace BankApp
{
    internal static class TransactionTimer
    {
        private static Timer _transactionTimer;
        private static Timer _loanTimer;


        public static void Start()
        {

            _transactionTimer = new Timer(Tick, null, 0, 60_000);

        }

        private static void Tick(object? state)
        {
            Transaction.ExecutePendingTransactions();
        }


    }
}
