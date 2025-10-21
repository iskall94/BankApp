using BankApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Accounts
{
    internal class BankAccount
    {
        public BankAccount(string accountName, AccountType accountType, Currency currency, decimal balance, float interest, List<Transaction> transactionHistory)
        {
            AccountName = accountName;
            AccountType = accountType;
            Currency = currency;
            Balance = balance;
            Interest = interest;
            TransactionHistory = transactionHistory;
        }

        public string AccountName { get; set; }
        public AccountType AccountType { get; set; }
        public Currency Currency { get; set; }
        
        //AccountNumber
        private decimal Balance { get; set; }

        public float Interest { get; set; }

        private List<Transaction> TransactionHistory { get; set; } = new List<Transaction>

        public decimal Withdraw()
        {
            return 0;
        }

        public decimal Deposit() 
        {
            return 0; 
        }

        public void GetAccountHistory()
        {

        }

        public void ChangeCurrency()
        {

        }

    }
}
