using BankApp.Accounts;

namespace BankApp.Menus
{
    internal static class AdminMenu
    {
        private static string Password { get; set; } = "default";

        public static List<string> GetAdminOptions { get; set; } = new List<string>
        {
            "Create User",
            "Unlock User",
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
                        AdminCreateUser();
                        break;
                    case 1:
                        Admin.UnlockBankAccount();
                        break;
                    case 2:
                        UserDB.ShowAllUsers();
                        break;
                    case 3:
                        Admin.UpdateExchangeRates();
                        break;
                    case 4:
                        MainMenu.MainMenuStart();
                        break;
                    default:
                        break;
                }
            }
        }

        public static void AdminCreateUser()
        {
            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("---User Creation Tool---\n");
            Console.WriteLine("Please enter a name for user:");
            string name = Console.ReadLine() ?? "";

            decimal decimalNumber = 0;

            while (true)
            {
                decimalNumber = HelperMethod.HelperDecimal("Please enter a balance:");
                if (decimalNumber < 0)
                {
                    Console.WriteLine("You cannot enter a negatve number.");
                    continue;
                }
                break;
            }
            BankAccount bankAccount = new BankAccount("account", Enums.AccountType.Normal, decimalNumber);
            Console.WriteLine("Has User provided additional info? \n" +
                "Y/N");
            string additionalUserChoice = Console.ReadLine();
            if (additionalUserChoice == "Y")
            {

                Console.WriteLine("Please enter user Email:");
                string email = Console.ReadLine();
                Console.WriteLine("Please enter user Phone number:");
                string phone = Console.ReadLine();
                Console.WriteLine("Please enter user Residence:");
                string residence = Console.ReadLine();
                Console.WriteLine("Please enter user Gender:");
                string gender = Console.ReadLine();

                User createdUserwInfo = Admin.CreateUserwInfo(Password, name, email, phone, residence, gender, bankAccount);
                Console.WriteLine(createdUserwInfo.ToString());
            }
            else
            {

                User createdUser = Admin.CreateUser(Password, name, bankAccount);
                Console.WriteLine(createdUser.ToString());
            }
            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }
    }
}
