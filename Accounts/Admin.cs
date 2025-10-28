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

        public static void FreezeBankAccount()
        {

        }

        public static void UpdateExchangeRates()
        {
            //Console.WriteLine("Choose currency: ");
            //foreach(CurrencyType c in CurrencyManager.AccountCurrency.Keys)
            //{
            //    Console.WriteLine(c);
            //}

            Console.Clear();
            while (true)
            {
                Menu.MenuOptions = CurrencyManager.AccountCurrency.Keys.Select(key => key.ToString()).ToList();
                Menu.MenuOptions.Add("Back to Admin Menu");
                string title = "---Change Exchange Rate List---";

                int menuChoice = Menu.Run(title);

                switch (menuChoice)
                {
                    case 0:
                        //Console.WriteLine($"Please change the value of {CurrencyType.SEK}: ");
                        //Console.ReadLine();
                        //CurrencyManager.AccountCurrency[CurrencyType.SEK] = 
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
                        AdminMenu.AdminMenuStart();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
