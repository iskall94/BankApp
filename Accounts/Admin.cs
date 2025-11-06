using BankApp.Currencies;
using BankApp.Enums;
using BankApp.Menus;

namespace BankApp.Accounts
{
    internal class Admin : User
    {
        public static BankAccount bankaccount { get; set; } = new BankAccount("admins konto", AccountType.Normal, 10000000);
        public Admin(Guid userID, string password, string name) : base(userID, password, name)
        {

        }

        public static User CreateUser(string password, string name, BankAccount account)
        {
            List<BankAccount> userBankAccounts = new List<BankAccount>();
            userBankAccounts.Add(account);
            BankAccountDB.AddBankAccount(account);
            User newUser = new User(Guid.NewGuid(), password, name, userBankAccounts);
            UserDB.AddUser(newUser);
            return newUser;

        }
        public static User CreateUserwInfo(string password, string name, string email, string phone, string residence , string gender, BankAccount account)
        {
            List<BankAccount> userBankAccounts = new List<BankAccount>();
            userBankAccounts.Add(account);
            BankAccountDB.AddBankAccount(account);
            User newUser = new User(Guid.NewGuid(), password, name, email, phone, residence, gender, userBankAccounts);
            UserDB.AddUser(newUser);
            return newUser;

        }

        /// <summary>
        /// Add a list of all locked / unlocked users name, change to a menu
        /// </summary>
        public static void UnlockBankAccount()
        {
            Console.Clear();
            Console.CursorVisible = true;
            List<User> usersLockedList = UserDB.FindUserLocked();
            
            bool correctName = false;
            foreach (User user in usersLockedList)
            {
                while(!correctName)
                {
                    Console.WriteLine("Vänligen skriv in användarens namn:");
                    string userName = Console.ReadLine() ?? "";
                    if (userName == user.Name)
                    {
                        user.IsLocked = false;
                        correctName = true;
                        Console.WriteLine($"{user}'s account has been unlocked.");
                    } 
                    else
                    {
                        Console.WriteLine("Please insert a users name (Case Sensitive).");
                    }
                }
            }
        }

       
        public static void AdminLogin()
        {
            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("---Admin Login--- ");
            string logincode = EmailService.GetLastLoginCode();
            Console.WriteLine("Press esc key to return to main menu");
            Console.WriteLine("\nEnter your login code:");
            string code = "";
            
            while (true)
            {
                code = Console.ReadLine();

                if (code == logincode)
                {
                    Console.WriteLine("Login successful!");
                    AdminMenu.AdminMenuStart();
                    break; 
                }
                else
                {
                    Console.WriteLine("Invalid code. Please check your email and try again.");
                }
                    

                ConsoleKeyInfo escMenu = Console.ReadKey(true);
                if (escMenu.Key == ConsoleKey.Escape)
                {
                    MainMenu.MainMenuStart();
                }
            }
        }

        public static void UpdateExchangeRates()
        {
            Console.Clear();

            while (true)
            {
                Menu.MenuOptions = CurrencyManager.AccountCurrency.Keys.Select(key => key.ToString()).ToList();
                Menu.MenuOptions.Add("Back to Admin Menu");
                string title = "---Change Exchange Rate List---";

                int menuChoice = Menu.Run(title);

                Console.WriteLine("-------------------------------");

                Console.WriteLine("Current Currency values:");
                foreach (KeyValuePair<CurrencyType, decimal> ac in CurrencyManager.AccountCurrency)
                {
                    Console.WriteLine($"{ac.Key}: {ac.Value}");
                }

                Console.WriteLine("-------------------------------");

                switch (menuChoice)
                {
                    case 0:
                        Console.WriteLine("SEK is always 1,00, cannot be changed.");
                        Console.ReadKey();
                        break;
                    case 1:
                        CurrencyManager.ChangeCurrencyValue(CurrencyType.EUR);
                        break;
                    case 2:
                        CurrencyManager.ChangeCurrencyValue(CurrencyType.USD);
                        break;
                    case 3:
                        CurrencyManager.ChangeCurrencyValue(CurrencyType.GBP);
                        break;
                    case 4:
                        AdminMenu.AdminMenuStart();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
