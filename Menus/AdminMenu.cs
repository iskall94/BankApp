using BankApp.Accounts;

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
                        Admin.AdminCreateUser(Password);
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
                        MainMenu.MainMenuStart();
                        break;

                    default:
                        break;
                }
            }
        }


    }
}
