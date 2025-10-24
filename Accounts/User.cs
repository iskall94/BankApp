using BankApp.Accounts;
using BankApp.Enums;
using BankApp.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankApp.Accounts
{
    internal class User
    {
        public User(Guid userID, string password, string name, List<BankAccount>? userBankAccounts = null)
        {
            UserID = Guid.NewGuid();
            Password = password;
            Name = name;
            UserBankAccounts = userBankAccounts;
        }

        private Guid UserID { get; set; }
        private string Password { get; set; }
        public string Name { get; set; }

        public static List<User> AllUsers { get; set; } = new List<User>();

        public void AddUser(User user)
        {
            AllUsers.Add(user);
        }

     

        public List<BankAccount>? UserBankAccounts { get; set; } = new List<BankAccount>();



        public static bool LogIn()
        {
            foreach (User user in AllUsers)
            {
                Console.WriteLine(user.ToString());
            }

            int failedCount = 0;

            while (failedCount < 3)
            {
                Console.Write("Enter your name: ");
                string inputName = Console.ReadLine();

                Console.Write("Enter your password: ");
                string inputPassword = Console.ReadLine();

              

                foreach (User user in AllUsers)
                {
                    if (inputName == user.Name && inputPassword == user.Password)
                    {
                        Console.WriteLine("Login succeeded!");
                        return true; 
                    }
                }

                failedCount++;
                Console.WriteLine($"Try again. Attempts left: {3 - failedCount}");
            }

            Console.WriteLine("You have been locked out of your account, please contact your bank.");
            return false; 
        }
                
        

        

        public void Logout()
        {

        }
        
        public void ResetPassword()
        {

        }

        public void GetBalanceForAll()
        {

        }

        public void ShowAllAccounts()
        {
            foreach (BankAccount account in UserBankAccounts)
            {
                Console.WriteLine(account.ToString());
            }
        }

        public BankAccount FindAccount(AccountNumber accountNumber)
        {
            BankAccount foundAccount = UserBankAccounts.Find(a => a.AccountNumber == accountNumber);

            return foundAccount;
        }

   
        public BankAccount CreateBankAccount(string accountName, AccountType accountType, Currency currency, decimal balance)
        {
            BankAccount account = new BankAccount(accountName, accountType, currency, balance);
            if (accountType == AccountType.Savings)
            {
                account.Interest = 1.5f;
                Console.WriteLine(account.Balance);
                account.Balance = balance * (decimal)(1 + account.Interest/100);
                Console.WriteLine(account.Balance);
            }
            UserBankAccounts?.Add(account);
            BankAccountDB.AddBankAccount(account);

            return account;
           
       
        }

        public  Transaction CreateTransaction(AccountNumber toAccount, AccountNumber fromAccount, decimal value, string personalNote)
        {
            Transaction newTx = new Transaction(toAccount, fromAccount, value, personalNote);

            return newTx;
        }




        public void HandleTransfer( AccountNumber to , AccountNumber from, decimal value)
        {
            BankAccount From = FindAccount(from);
            BankAccount To = FindAccount(to);
            From.Withdraw(value);
            To.Deposit(value);

            Console.WriteLine($" FROM {From}");
            Console.WriteLine($" TO {To}");

        }

       

        public void EditBankAccount()
        {

        }

        public override string ToString()
        {
            string accountsInfo = string.Join("\n---\n", UserBankAccounts.Select(acc => acc.ToString()));

            return $"User: {Name}\n" +
                   $"Password: {Password}\n" +
                   "\n---\n" +
            $"Bank Accounts:\n{UserBankAccounts}";
                   
        }
    }
}


