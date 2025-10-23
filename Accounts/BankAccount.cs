using BankApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankApp.Accounts
{
    internal class BankAccount
    {
      
        public BankAccount(string accountName, AccountType accountType, Currency currency, decimal balance)
        {
            AccountName = accountName;
            AccountType = accountType;
            Currency = currency;
            Balance = balance;
            Interest = 0;
            TransactionHistory = new List <Transaction>();
            AccountNumber = AccountNumber.Generate();
        }

        public static List<Transaction> TransactionHistory { get; set; }  = new List<Transaction>(); 



        public string AccountName { get; set; }
        public AccountType AccountType { get; set; }
        public Currency Currency { get; set; }
        
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
        public static void AddTransaction(Transaction transaction)
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

        public void ChangeCurrency()
        {

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
