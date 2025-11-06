using BankApp.Enums;
using BankApp.Menus;
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
            FirstTimeLogin = true;
            IsLocked = false;
        }

        public User(Guid userID, string password, string name, string? email, string? phone, string? residence, string? gender, List<BankAccount>? userBankAccounts = null)
        {
            UserID = Guid.NewGuid();
            Password = password;
            Name = name;
            Email = email;
            Phone = phone;
            Residence = residence;
            Gender = gender;
            UserBankAccounts = userBankAccounts;
            FirstTimeLogin = true;
            IsLocked = false;
        }

        private Guid UserID { get; set; }
        private string Password { get; set; }
        public string Name { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Residence { get; set; }

        public string? Gender { get; set; }

        public bool FirstTimeLogin { get; set; }

        public bool IsLocked { get; set; }
        public List<BankAccount>? UserBankAccounts { get; set; } = new List<BankAccount>();

        public static void Login()
        {
            int MAX_ATTEMPTS = 3;
            Console.Clear();
            int failedCount = 0;
            Console.WriteLine("---User Login---\n");
            Console.Write("Enter your name: ");
            string inputName = Console.ReadLine();
            Console.Write("Enter your password: ");
            string inputPassword = Console.ReadLine();

            bool userFound = false;
            foreach (User user in UserDB.allUsers)
            {
                if (inputName.ToLower() == user.Name.ToLower())
                {
                    userFound = true;

                    while (failedCount < MAX_ATTEMPTS)
                    {
                        if (user.IsLocked)
                        {
                            Console.WriteLine("Your account has been locked, please contact your administrator.");
                            Console.ReadKey();
                            return;
                        }
                        if (inputPassword != user.Password)
                        {
                            Console.WriteLine($"Wrong password, please try again. Attempts left: {3 - failedCount}");
                            failedCount++;
                            Console.Write("Enter your password: ");
                            inputPassword = Console.ReadLine();
                        }
                        else
                        {
                            if (user.FirstTimeLogin)
                            {
                                Console.WriteLine("Change password to new one.");
                                Console.WriteLine("Enter new password: ");
                                string newPassword = Console.ReadLine();

                                Console.WriteLine("Confirm new password: ");
                                string confirmNewPassword = Console.ReadLine();

                                while (newPassword != confirmNewPassword)
                                {
                                    Console.WriteLine("Password did not match, try again.");
                                    Console.WriteLine("Confirm password: ");
                                    confirmNewPassword = Console.ReadLine();
                                }

                                user.Password = newPassword;
                                user.FirstTimeLogin = false;
                                Console.WriteLine($"New password set: {newPassword}");
                            }

                            UserMenu.UserMenuStart(user);
                            break;
                        }
                    }
                    if (failedCount == MAX_ATTEMPTS)
                    {
                        user.IsLocked = true;
                        Console.WriteLine("Your account has been locked, please contact your administrator.");
                        EmailService.SendIssueCodeEmail(1, user, null, null);

                    }
                    return;

                }
            }

            if (!userFound)
            {
                Console.WriteLine("Name not found, please check your spelling and try again.");
            }

            Console.ReadKey();
        }

        public void ChangePassword(User user)
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

        public void EditUser(User user, string field, string value)
        {
            field = field.ToLower();

            switch (field)
            {

                case "name": user.Name = value; break;
                case "email": user.Email = value; break;
                case "phone": user.Phone = value; break;
                case "residence": user.Residence = value; break;
                case "gender": user.Gender = value; break;
                default: Console.WriteLine("Field not found. Try again."); break;

            }


        }

        public void ShowAllAccounts() // Remove?
        {
            foreach (BankAccount account in UserBankAccounts)
            {
                Console.WriteLine(account.ToString());
            }
        }

        public List<AccountNumber> AccountNumbersList(User currentUser)
        {
            return currentUser.UserBankAccounts.Select(a => a.AccountNumber).ToList();
        }

        public BankAccount FindAccount(AccountNumber accountNumber)
        {
            return UserBankAccounts.Find(a => a.AccountNumber == accountNumber);
        }

        public BankAccount CreateBankAccount(string accountName, AccountType accountType, decimal balance)
        {
            BankAccount account = new BankAccount(accountName, accountType, balance);
            if (accountType == AccountType.Savings)
            {
                account.Interest = 1.5f;
                account.LastInterestDate = DateTime.Now;
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
            Transaction.PendingTransactions.Add(newTx);
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

            try
            {
                From.Withdraw(value);
                To.Deposit(value);

                Console.WriteLine($" FROM {From}");
                Console.WriteLine($" TO {To}");

            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
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


