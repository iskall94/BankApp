using BankApp.Accounts;
using BankApp.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                        break;
                    case 1:

                        UserMenu.EditUserVisual(currentUser);
                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:
                        UserMenu.ChangeBankAccountVisual(currentUser);
                        
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
                Console.WriteLine(number + ". " +acc.AccountName);
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

    }
}
