using BankApp.Enums;
using BankApp.Transactions;

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
            BankAccount account = new BankAccount(accountName, accountType, balance);
            if (accountType == AccountType.Savings)
            {
                account.Interest = 1.5f;
                Console.WriteLine(account.Balance);
                account.Balance = balance * (decimal)(1 + account.Interest / 100);
                Console.WriteLine(account.Balance);
            }
            UserBankAccounts?.Add(account);
            BankAccountDB.AddBankAccount(account);

            return account;


        }

        public Transaction CreateTransaction(AccountNumber toAccount, AccountNumber fromAccount, decimal value, string personalNote, TransactionType transactionType)
        {
            Transaction newTx = new Transaction(toAccount, fromAccount, value, personalNote, transactionType);

            return newTx;
        }

        /// <summary>
        /// Creates a new loan for a specified account if the loan amount is within allowed limits.
        /// </summary>
        /// <param name="toAccount">The account that will receive the loan.</param>
        /// <param name="admin">The bank admin account providing the loan funds.</param>
        /// <param name="valueOfLoan">The requested loan amount.</param>
        /// <param name="accountBalance">The current balance of the account to check against loan limit.</param>
        /// <param name="personalNote">A personal note or purpose for the loan.</param>
        /// <param name="transactionType">The type of transaction for the loan.</param>
        /// <returns>A Loan object representing the created loan.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the requested loan exceeds 5× the account balance.
        /// </exception>
        public Loan CreateLoan(AccountNumber toAccount, BankAccount admin, decimal valueOfLoan, decimal accountBalance, string personalNote, TransactionType transactionType)
        {
            decimal interestRate = 2m; // TODO: hårdkodad interest kanske bör ändras?
            int years = 3;

            if (valueOfLoan > accountBalance * 5)
            {
                throw new InvalidOperationException("This loan cannot be granted: the amount exceeds 5× your current balance.");
            }
            else
            {
                Loan newLoan = new Loan(toAccount, admin.AccountNumber, valueOfLoan, personalNote, interestRate, transactionType);
                Console.WriteLine(newLoan.CalculateLoan(valueOfLoan, interestRate, years));
                return newLoan;
            }
        }


        public void HandleTransfer(AccountNumber to, AccountNumber from, decimal value)
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


