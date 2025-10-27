using BankApp.Enums;
using BankApp.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

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
            FirstTimeLogin = true;
            IsLocked = false;
        }

        private Guid UserID { get; set; }
        private string Password { get; set; }
        public string Name { get; set; }

        public bool FirstTimeLogin { get; set; }

        public bool IsLocked { get; set; }
       

        public List<BankAccount>? UserBankAccounts { get; set; } = new List<BankAccount>();



        public static void Login()
        {
            Console.Clear();
            int failedCount = 0;
            Console.Write("Enter your name: ");
            string inputName = Console.ReadLine();
            Console.Write("Enter your password: ");
            string inputPassword = Console.ReadLine();
            foreach (User user in UserDB.allUsers)
            {
                while (failedCount != 2)
                {
                    if (inputName != user.Name)
                    {
                        Console.WriteLine("Name not found, please check your spelling and try again.");
                        Console.Write("Enter your name:");
                        inputName = Console.ReadLine();
                        Console.Write("Enter your password:");
                        inputPassword = Console.ReadLine();
                    }
                    else if (inputPassword != user.Password)
                    {
                        failedCount++;
                        Console.WriteLine($"Wrong password, please try again. Attempts left: {3 - failedCount}");
                        Console.Write("Enter your password: ");
                        inputPassword = Console.ReadLine();
                    }
                     else if (inputName.ToLower() == user.Name.ToLower() && inputPassword == user.Password)
                    {
                        if (user.IsLocked)
                        {
                            Console.WriteLine(" Your account has been locked, please contact your bank.");
                            break;
                        }
                        if (user.FirstTimeLogin)
                        {
                            Console.WriteLine("Change password to new one.");
                            Console.WriteLine("Enter new password:");
                            string newPassword = Console.ReadLine();

                            Console.WriteLine("Confirm new password.");
                            string confirmNewPassword = Console.ReadLine();

                            while (newPassword != confirmNewPassword)
                            {
                                Console.WriteLine("Password did not match, try again.");
                                Console.WriteLine("Confirm password: ");
                                confirmNewPassword = Console.ReadLine();
                            }

                            Console.WriteLine($" new password : {newPassword}");
                            user.Password = newPassword;
                            user.FirstTimeLogin = false;
                        }
                        break;
                    }
                }

                if (failedCount == 3)
                {
                    user.IsLocked = true;
                    Console.WriteLine(" Your account has been locked, please contact your bank.");
                    break;
                }
            }

                User confirmUser = UserDB.FindUserByName(inputName);
                Console.WriteLine(confirmUser.ToString());
             UserMenu.UserMenuStart(confirmUser);
        }

        public static void Logout()
        {
            
        }
        
        public void ChangePassword( User user)
        {
            Console.WriteLine("Change password.");
            Console.WriteLine("Enter current password: ");
            string confirmPassword = Console.ReadLine();

            
                if (confirmPassword == user.Password) 
                {
                    Console.WriteLine("Enter new password: ");
                    user.Password = Console.ReadLine();
                    Console.WriteLine("Your password has changed.");
                
                }

                else
                {
                    Console.WriteLine("Wrong password, please try again.");
                }

            
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
            $"Bank Accounts:\n{accountsInfo}";
                   
        }
    }
}
