using BankApp.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Menus
{
    internal static class AdminMenu
    {
        private static string Password { get; set; } = "default";

        public static List<string> GetAdminOptions { get; set; } = new List<string>
        {
            "Create User?",
            "Freeze User?",
            "Unfreeze Password for User",
            "Lists of Accounts",
            "Change Currency Exchange Rate",
            "Exit To Main Menu..."
        };

        public static void AdminMenuStart()
        {
            Console.Clear();
            while (true)
            {
                Menu.MenuOptions = GetAdminOptions;
                string title = "---Admin Menu---";

                int menuChoice = Menu.Run(title);

                switch (menuChoice)
                {
                    case 0:
                        AdminMenu.AdminCreateUser();
                        break;
                    case 1:
                        
                        break;
                    case 2:
                        
                        break;
                    case 3:
                        UserDB.ShowAllUsers();
                        
                        break;
                    case 4:
                        break;
                    case 5:
                        
                        break;
                        default:
                        break;
                }
            }
        }

        public static void AdminCreateUser()
        {
            Console.Clear();
            Console.WriteLine("---User Creation Tool---");
            Console.WriteLine("Please enter a name for user:");
            string name = Console.ReadLine() ?? "";
            
            bool successful = false;
            string balanceInput;
            decimal decimalNumber = 0;

            while (!successful)
            {
                Console.WriteLine("Please enter a balance:");
                balanceInput = Console.ReadLine() ?? "";
                successful = decimal.TryParse(balanceInput, out decimalNumber);
                if (successful)
                {
                    Console.WriteLine("Balance successfully implemented.");
                }
                else
                {
                    Console.WriteLine("Could not parse the balance input. Please enter a valid input.");
                }
            }
            BankAccount bankAccount = new BankAccount("account", Enums.AccountType.Normal, Enums.Currency.SEK, decimalNumber);
             User  createdUser = Admin.CreateUser(Password, name, bankAccount);
            UserDB.AddUser(createdUser);   
            Console.WriteLine(createdUser.ToString());
            Console.ReadKey();
        }
    }
}
