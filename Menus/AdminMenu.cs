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
            "Placeholder",
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

                        break;
                    case 3:
                        UserDB.ShowAllUsers();

                        break;
                    case 4:
                        Admin.UpdateExchangeRates();
                        break;
                    case 5:
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
            
            Console.ReadKey();
        }
    }
}
