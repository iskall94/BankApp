using BankApp.Enums;
using BankApp.Currencies;
using BankApp.Transactions;

namespace BankApp.Accounts
{
    internal class BankAccount
    {
        public BankAccount(string accountName, AccountType accountType, decimal balance)
        {
            AccountName = accountName;
            AccountType = accountType;
            Currency = CurrencyType.SEK;
            Balance = balance;
            Interest = 0;
            TransactionHistory = new List <Transaction>();
            AccountNumber = AccountNumber.Generate();
        }

        public List<Transaction> TransactionHistory { get; set; }  = new List<Transaction>(); 



        public string AccountName { get; set; }
        public AccountType AccountType { get; set; }
        public CurrencyType Currency { get; set; }
        
        public AccountNumber AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public float Interest { get; set; }

        public DateTime? LastInterestDate { get; set; }



        public decimal Withdraw(decimal value)
        {
            if (value > Balance)
            {
                Console.WriteLine("You cannot withdraw more than the current balance.");
                return Balance;
            }
            Balance = Balance - value;

           return Balance;
        }

        public decimal Deposit(decimal value) 
        {

            Balance = Balance + value;
            return Balance;
        }
        public  void AddTransaction(Transaction transaction)
        {
            TransactionHistory.Add(transaction);
        }


        public void GetTransactionHistory()
        {
           
            if (TransactionHistory == null || TransactionHistory.Count == 0)
            {
                Console.WriteLine("There are no transactions to show.");
                return;
            }

            foreach (Transaction transaction in TransactionHistory)

            {
                Console.WriteLine(transaction);

            }

        }

        // Handle conversion from non-swedish to non-swedish currency -> Gabriel
        public void ChangeAccountCurrency(AccountNumber accountNumber, CurrencyType currency)
        {
            Console.WriteLine(accountNumber);
            var account = BankAccountDB.FindBankAccount(accountNumber);
            Console.WriteLine(account.ToString());
            
            decimal ExchangeRate = CurrencyManager.AccountCurrency[currency];

            account.Currency = currency;
            account.Balance = Balance * ExchangeRate;
            Console.WriteLine(account.ToString());
            Console.ReadKey();
        }



        // Move error handling into FindBankAccount()

        public static void ChangeBankAccountName(AccountNumber accountNumber)
        {
            var account = BankAccountDB.FindBankAccount(accountNumber);

            if (account == null)
            {
                Console.WriteLine($"No account found with number {accountNumber}.");
                return;
            }

            Console.WriteLine($"Current account name: {account.AccountName}");
            Console.Write("Enter a new name for your bank account: ");
            string newName = Console.ReadLine();

            account.AccountName = newName;

            Console.WriteLine($"The name of your bank account ({accountNumber}) has been updated to: {newName}");
        }
        public static string applyInterest(BankAccount account)
        {
            DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);

            DateOnly lastApplied = DateOnly.FromDateTime(account.LastInterestDate.Value);
            DateOnly nextEligibilityDate = lastApplied.AddYears(1);
            if (currentDate == nextEligibilityDate)
            {
                double rateFactor = 1.0 + (account.Interest / 100.0);
                decimal balanceBefore = account.Balance;
                account.Balance = account.Balance * (decimal)rateFactor;
                account.LastInterestDate = currentDate.ToDateTime(TimeOnly.MinValue);

                return $"Interest applied for Account {account.AccountNumber}. Balance changed from {balanceBefore:C} to {account.Balance:C}.";
            }
            else
            {
                return $"Account {account.AccountNumber} is not yet eligible for interest. Next eligibility: {nextEligibilityDate:yyyy-MM-dd}.";
            }
        }



        public override string ToString()
        {
            return $"Account: {AccountName}\n" +
                   $"Type: {AccountType}\n" +
                   $"Currency: {Currency}\n" +
                   $"Balance: {Balance}\n" +
                   $"Interest: {Interest}%\n" +
                   $"AccountNumber: {AccountNumber}\n";
        }

    }
}
