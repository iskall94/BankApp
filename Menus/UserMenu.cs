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
            "Transfer to Account",
            "Apply for loan",
            "Add New Account(s)",
            "Edit Account(s)",
            "Edit User details",
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

                        EditUserVisual(currentUser);
                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:
                        ApplyForLoan(currentUser);

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
                    UserMenu.UserMenuStart(currentUser);
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
                UserMenu.UserMenuStart(currentUser);
                return;
            }

            currentUser.EditUser(currentUser, field, value);

            Console.WriteLine($"\n{field} updated successfully! Returning to Menu...");
            Thread.Sleep(1000);
            UserMenu.UserMenuStart(currentUser);
        }

        private static string? GetUserFieldValue(User user, string field)
        {
            return field switch
            {
                "Name" => user.Name,
                "Email" => user.Email,
                "Phone" => user.Phone,
                "Residence" => user.Residence,
                "Gender" => user.Gender,
                _ => ""
            };
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
    }
}






