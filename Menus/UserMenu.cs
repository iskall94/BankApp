using BankApp.Accounts;
using System;
using System.Collections.Generic;
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
            "Transfer Money Between Account(s)",
            "Transfer to Account",
            "Add New Account(s)",
            "Edit Account(s)",
            "Exit To Main Menu..."
        };

        public static void UserMenuStart(/*User currentUser*/)
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
                        
                        break;
                    case 4:

                        break;
                    case 5:
                        MainMenu.MainMenuStart();
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
