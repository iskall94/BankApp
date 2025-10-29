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
            "Transfer Money Between Account(s)",
            "Transfer to Account",
            "Apply for loan",
            "Add New Account(s)",
            "Edit Account(s)",
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

                        break;
                    case 1:

                        break;
                    case 2:

                        break;
                    case 3:
                        ApplyForLoan(currentUser);
                        break;
                    case 4:

                        break;
                    case 5:
                        break;
                    case 6:
                        MainMenu.MainMenuStart();
                        break;

                    default:
                        break;
                }
            }
        }


        public static void ApplyForLoan(User currentUser)
        {

            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("---Apply for loan---");


            Console.WriteLine("Please select the bank account to receive your loan:");
            List<AccountNumber> allAccountNumbers = currentUser.AccountNumbersList(currentUser);
            for (int i = 0; i < allAccountNumbers.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] - {allAccountNumbers[i]}");
            }
            AccountNumber selectedAccount;
            BankAccount currentUserBankAccount;

            while (true)
            {
                string input = Console.ReadLine() ?? "";

                if (int.TryParse(input, out int choice) && choice > 0 && choice <= allAccountNumbers.Count)
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

            Console.WriteLine("Please provide a short note describing the purpose of your loan:");
            string personalNote = Console.ReadLine() ?? "";

            try
            {
                Transaction loanTransx = currentUser.CreateLoan(selectedAccount, Admin.bankaccount, 80000, currentUserBankAccount.Balance, personalNote, TransactionType.Loan);
                loanTransx.ExecuteTransaction(loanTransx);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
