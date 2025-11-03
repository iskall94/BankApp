using BankApp.Accounts;
using BankApp.Enums;
using BankApp.Transactions;

namespace BankApp.Menus
{
    internal static class UserMenu
    {
        public static List<string> GetUserOptions { get; set; } = new List<string>
        {
            "Check Accounts",
            "Edit User Info",
            "Transfer Money Between Account(s)",
            "Apply for loan",
            "Transfer to Account",
            "Add New Account(s)",
            "Change bankaccount name",
            "Exit To Main Menu..."
        };

        public static void UserMenuStart(User currentUser)
        {
            Console.Clear();
            while (true)
            {
                Menu.MenuOptions = GetUserOptions;
                string title = "---User Menu---";

                int menuChoice = Menu.Run(title);

                switch (menuChoice)
                {
                    case 0:
                        CheckAccountsVisual(currentUser);
                        break;
                    case 1:
                        EditUserVisual(currentUser);
                        break;
                    case 2:
                        HandleTransferVisual(currentUser);
                        break;
                    case 3:
                        TransactionVisual(currentUser);
                        break;
                    case 4:
                        CreateLoanVisual(currentUser);
                        break;
                    case 5:
                        CreateBankAccountVisual(currentUser);
                        break;
                    case 6:
                        ChangeBankAccountNameVisual(currentUser);
                        break;
                    case 7:
                        MainMenu.MainMenuStart();
                        break;
                    default:
                        break;
                }
            }
        }
        public static void CheckAccountsVisual(User currentUser)
        {
            Console.Clear();
            Console.CursorVisible = true;

            Console.WriteLine("\nEnter which account you would like to handle: ");
            AccountNumber chosenAccountNumber = ChooseAccountNumber(currentUser);

            BankAccount currentUserBankAccount;
            currentUserBankAccount = currentUser.FindAccount(chosenAccountNumber);

            List<string> accountOptions = new List<string>
            {
                "Deposit",
                "Withdraw",
                "Return to User Menu",
            };

            Menu.MenuOptions = accountOptions;


            Console.WriteLine($"Account: {currentUserBankAccount.AccountNumber} | Balance: {currentUserBankAccount.Balance:C}");
            Console.WriteLine("Do you want to deposit or withdraw money from account?");
            int menuChoice = Menu.Run();

            switch (menuChoice)
            {
                case 0:
                    DepositVisual(currentUser, currentUserBankAccount);
                    break;
                case 1:
                    WithdrawVisual(currentUser, currentUserBankAccount);
                    break;
                case 2:
                    UserMenuStart(currentUser);
                    return;
            }
        }

        public static void DepositVisual(User currentUser, BankAccount chosenAccountNumber)
        {
            Console.Clear();
            Console.WriteLine($"Depositing money to account: {chosenAccountNumber}");
            Console.Write("How much money would you like to deposit? ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                chosenAccountNumber.Deposit(amount);
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }

            Console.WriteLine($"New balance: {chosenAccountNumber.Balance:C}");
            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }

        public static void WithdrawVisual(User currentUser, BankAccount chosenAccountNumber)
        {
            Console.Clear();
            Console.WriteLine($"Withdrawing money from account: {chosenAccountNumber}");
            Console.Write("How much money would you like to withdraw? ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                chosenAccountNumber.Withdraw(amount);
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }

            Console.WriteLine($"New balance: {chosenAccountNumber.Balance:C}");
            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }
        public static void EditUserVisual(User currentUser)
        {
            Console.Clear();


            Console.WriteLine("Current User Information:\n");
            Console.WriteLine($"Name: {currentUser.Name}");
            Console.WriteLine($"Email: {currentUser.Email}");
            Console.WriteLine($"Phone: {currentUser.Phone}");
            Console.WriteLine($"Residence: {currentUser.Residence}");
            Console.WriteLine($"Gender: {currentUser.Gender}");
            Console.WriteLine("\n--------------------------\n");

            List<string> userData = new List<string>
    {
        "Name",
        "Email",
        "Phone",
        "Residence",
        "Gender",
        "Return to User Menu"
    };

            Menu.MenuOptions = userData;
            Console.WriteLine("Please select a data field to change:\n");

            int menuChoice = Menu.Run();

            string field = "";

            switch (menuChoice)
            {
                case 0:
                    field = "Name";
                    break;
                case 1:
                    field = "Email";
                    break;
                case 2:
                    field = "Phone";
                    break;
                case 3:
                    field = "Residence";
                    break;
                case 4:
                    field = "Gender";
                    break;
                case 5:
                    UserMenuStart(currentUser);
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }


            Console.Clear();
            Console.WriteLine($"Editing {field}");
            Console.WriteLine($"Current value: {GetUserFieldValue(currentUser, field)}\n");
            Console.Write($"Enter a new {field}: ");

            string? value = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("\nNo input provided. Returning to user menu...");
                Thread.Sleep(1000);
                UserMenuStart(currentUser);
                return;
            }

            currentUser.EditUser(currentUser, field, value);

            Console.WriteLine($"\n{field} updated successfully! Returning to Menu...");
            Thread.Sleep(1000);
            UserMenuStart(currentUser);
        }
        private static string? GetUserFieldValue(User currentUser, string field)
        {
            return field switch
            {
                "Name" => currentUser.Name,
                "Email" => currentUser.Email,
                "Phone" => currentUser.Phone,
                "Residence" => currentUser.Residence,
                "Gender" => currentUser.Gender,
                _ => ""
            };
        }
        public static void HandleTransferVisual(User currentUser)
        {
            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("---Transfer Money Between Account(s)---");
            List<AccountNumber> allAccountNumbers = currentUser.AccountNumbersList(currentUser);

            if (allAccountNumbers.Count < 2)
            {
                Console.WriteLine("You need at least two accounts to make a transfer between your own accounts");
                Console.ReadKey();
                UserMenuStart(currentUser);
                return;
            }
            Console.WriteLine("Choose the account you want to transfer money from:");
            AccountNumber fromAccount = ChooseAccountNumber(currentUser);
            Console.WriteLine("Choose the account you want to transfer money to: ");
            AccountNumber toAccount = ChooseAccountNumber(currentUser);

            decimal value = HelperMethod.HelperDecimal("Amount:");

            currentUser.HandleTransfer(toAccount, fromAccount, value);

            Console.ReadKey();

        }
        public static void TransactionVisual(User currentUser)
        {
            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("---Transfer to Account---");

            Console.WriteLine("Choose the account you want to transfer money from:");
            AccountNumber fromAccount = ChooseAccountNumber(currentUser);

            decimal value = HelperMethod.HelperDecimal("Amount:");
            Console.WriteLine("Personal note:");
            string personalNote = Console.ReadLine() ?? "";


            Console.WriteLine("Enter the account you want to transfer money to: ");
            string input = Console.ReadLine() ?? "";
            AccountNumber toAccount;

            BankAccount matchedAccount = BankAccountDB.BankAccounts.FirstOrDefault(a => a.AccountNumber.ToString() == input);
            while (true)
            {

                if (matchedAccount != null)
                {
                    toAccount = matchedAccount.AccountNumber;
                    break;
                }
                else
                {
                    Console.WriteLine("Could not find this account number, please try again");
                }

            }

            Transaction newTransaction = currentUser.CreateTransaction(toAccount, fromAccount, value, personalNote, TransactionType.Normal);
            newTransaction.ExecuteTransaction(newTransaction);

            Console.WriteLine("Your transaction was successful");

            Console.ReadKey();
        }

        public static AccountNumber ChooseAccountNumber(User currentUser)
        {
            List<AccountNumber> allAccountNumbers = currentUser.AccountNumbersList(currentUser);
            for (int i = 0; i < allAccountNumbers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. - {allAccountNumbers[i]}");
            }
            AccountNumber selectedAccount;
            while (true)
            {
                string accountInput = Console.ReadLine() ?? "";
                if (int.TryParse(accountInput, out int choice) && choice > 0 && choice <= allAccountNumbers.Count)
                {
                    selectedAccount = allAccountNumbers[choice - 1];
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
            return selectedAccount;
        }
        public static void CreateLoanVisual(User currentUser)
        {
            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("---Apply for loan---");

            Console.WriteLine("Please select the bank account to receive your loan:");
            List<AccountNumber> allAccountNumbers = currentUser.AccountNumbersList(currentUser);
            for (int i = 0; i < allAccountNumbers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. - {allAccountNumbers[i]}");
            }
            AccountNumber selectedAccount;
            BankAccount currentUserBankAccount;

            while (true)
            {
                string accountInput = Console.ReadLine() ?? "";

                if (int.TryParse(accountInput, out int choice) && choice > 0 && choice <= allAccountNumbers.Count)
                {
                    selectedAccount = allAccountNumbers[choice - 1];
                    currentUserBankAccount = currentUser.FindAccount(selectedAccount);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }

            Console.Clear();
            Console.WriteLine("---Apply for loan---");

            Console.WriteLine($"Account: {selectedAccount}");
            Console.WriteLine($"Your current balance: {currentUserBankAccount.Balance}.");
            Console.WriteLine($"Please note that you can only borrow up to 5 times your current balance.");
            Console.WriteLine();
            decimal amountOfLoan = HelperMethod.HelperDecimal("Enter the desired loan amount:");


            Console.WriteLine("Please provide a short note describing the purpose of your loan:");
            string personalNote = Console.ReadLine() ?? "";

            Console.WriteLine("----------------");

            try
            {
                Transaction loanTransx = currentUser.CreateLoan(selectedAccount, Admin.bankaccount, amountOfLoan, currentUserBankAccount.Balance, personalNote, TransactionType.Loan);
                loanTransx.ExecuteTransaction(loanTransx);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.ReadKey();
        }
        public static void CreateBankAccountVisual(User currentUser)
        {
            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("---Add New Account(s)---");

            Console.WriteLine("Enter account name:");
            string accountName = Console.ReadLine() ?? "";
            decimal balance = HelperMethod.HelperDecimal("Enter balance: ");

            Console.WriteLine($"Choose account type: {string.Join(",", Enum.GetNames(typeof(AccountType)))}");
            string input = Console.ReadLine() ?? "";


            while (true)
            {
                if (Enum.TryParse(input, true, out AccountType accountType))
                {
                    currentUser.CreateBankAccount(accountName, accountType, balance);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
            Console.WriteLine("A new bank account has been successfully created!");
            Console.ReadKey();


        }
        public static void ChangeBankAccountVisual(User currentUser)
        {
            var accounts = currentUser.UserBankAccounts;
            if (accounts.Count == 0)
            {
                Console.WriteLine("You have no bank accounts.");
                Console.ReadKey();
                UserMenuStart(currentUser);
                return;
            }

            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("--- Select Account to Change Name ---\n");
            int number = 1;


            foreach (var acc in accounts)
            {
                Console.WriteLine(number + ". " + acc.AccountName);
                number++;
            }

            Console.WriteLine(number + ". Return to User Menu");
            Console.Write("\nType the number: ");
            string input = Console.ReadLine();

            number = 1;
            foreach (var acc in accounts)
            {
                if (input == number.ToString())
                {
                    BankAccount.ChangeBankAccountName(acc.AccountNumber);
                    break;
                }
                number++;
            }

            UserMenuStart(currentUser);
        }

        public static void ChangeBankAccountNameVisual(User currentUser)
        {
            var accounts = currentUser.UserBankAccounts;
            if (accounts.Count == 0)
            {
                Console.WriteLine("You have no bank accounts.");
                Console.ReadKey();
                UserMenuStart(currentUser);
                return;
            }

            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("--- Select Account to Change Name ---\n");
            int number = 1;


            foreach (var acc in accounts)
            {
                Console.WriteLine(number + ". " + acc.AccountName);
                number++;
            }

            Console.WriteLine(number + ". Return to User Menu");
            Console.Write("\nType the number: ");
            string input = Console.ReadLine();

            number = 1;
            foreach (var acc in accounts)
            {
                if (input == number.ToString())
                {
                    BankAccount.ChangeBankAccountName(acc.AccountNumber);
                    break;
                }
                number++;
            }

            UserMenuStart(currentUser);
        }


    }
}
