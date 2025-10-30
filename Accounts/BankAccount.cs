using BankApp.Enums;
using BankApp.Currencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Transactions;


namespace BankApp.Accounts
{
    internal class BankAccount
    {
      
        public BankAccount(string accountName, AccountType accountType, decimal balance)
        {
            AccountName = accountName;
            AccountType = accountType;
            Currency = Enums.CurrencyType.SEK;
            Balance = balance;
            Interest = 0;
            TransactionHistory = new List <Transaction>();
            AccountNumber = AccountNumber.Generate();
        }

        public static List<Transaction> TransactionHistory { get; set; }  = new List<Transaction>(); 



        public string AccountName { get; set; }
        public AccountType AccountType { get; set; }
        public CurrencyType Currency { get; set; }
        
        public AccountNumber AccountNumber { get; set; }
        public decimal Balance { get; set; } // Should be private

        public float Interest { get; set; } // Should be private

       

        public decimal Withdraw(decimal value)
        {
            Balance = Balance - value;

           return Balance;
        }

        public decimal Deposit(decimal value) 
        {

            Balance = Balance + value;
            return Balance ;
        }
        public  void AddTransaction(Transaction transaction)
        {
            TransactionHistory.Add(transaction);
        }


        public void GetTransactionHistory()
        {
            foreach (Transaction transaction in TransactionHistory)

            {
                Console.WriteLine(transaction);
            }


        }

        public void ChangeAccountCurrency(AccountNumber accountNumber, Enums.CurrencyType currency)
        {
            Console.WriteLine(accountNumber);
            var account = BankAccountDB.FindBankAccount(accountNumber);
            Console.WriteLine(account == null ? "account is null" : "account is ok");
            Console.WriteLine(account.ToString());
            
            decimal ExchangeRate = CurrencyManager.AccountCurrency[currency];

            account.Currency = currency;
            account.Balance = Balance * ExchangeRate;
            Console.WriteLine(account.ToString());
            Console.ReadKey();
        }

        


        //Implement in usermenu under user menu
        public void ChangeBankAccountName(AccountNumber accountNumber, string accountName)
        {
            var account = BankAccountDB.FindBankAccount(accountNumber);
            Console.WriteLine(accountNumber);

            if (account == null)
            {
                Console.WriteLine($"No account found with number {accountNumber}.");
                return;
            }

            Console.WriteLine($"Current account name: {account.AccountName}");
            Console.WriteLine($"Account number: {accountNumber}");
            Console.Write("Enter a new name for your bank account: ");
            string newName = Console.ReadLine();

            account.AccountName = newName;
           

            Console.WriteLine($" The name of your bankaccount ({accountNumber}) has been updated to: {newName}");

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
