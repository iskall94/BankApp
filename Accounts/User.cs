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

       
        

        public List<BankAccount>? UserBankAccounts { get; set; } = new List<BankAccount>();

        public void Login()
        {

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
                account.Balance = balance * (decimal)(1 + account.Interest / 100);
                Console.WriteLine(account.Balance);
            }
            UserBankAccounts?.Add(account);
            BankAccountDB.AddBankAccount(account);

            return account;


        }

        public Transaction CreateTransaction(AccountNumber toAccount, AccountNumber fromAccount, decimal value, string personalNote)
        {
            Transaction newTx = new Transaction(toAccount, fromAccount, value, personalNote);

            return newTx;
        }

        public Loan CreateLoan(AccountNumber toAccount, AccountNumber fromAdmin, decimal value, string transactionName, string personalNote)
        {


            //lånet blev godkänt och skapas här
            Loan newLoan = new Loan(toAccount, fromAdmin, value, transactionName, personalNote, 2.5m);
            return newLoan;
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
            $"Bank Accounts:\n{accountsInfo}";

        }
    }
}
