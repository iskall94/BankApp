using BankApp.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Menus
{

    internal class AdminMenu : Menu
    {
        public AdminMenu() : base (GetAdminOptions()) { }
        public static List<string> GetAdminOptions()
        {
            return new List<string>
            {
            "Create User?",
            "Freeze User?",
            "Unfreeze Password for User",
            "Exit To Main Menu..."
            };
        }
        public void AdminMenuStart()
        {
            Console.Clear();
            while (true)
            {
                string title = "---Admin Menu---";

                int menuChoice = Run(title);

                switch (menuChoice)
                {
                    case 0:
                        
                        break;
                    case 1:
                        //Logga in som admin?
                        break;
                    case 2:
                        //Avsluta?
                        break;
                    case 3:
                        //
                        break;
                    default:
                        break;
                }
            }
        }

        public void AdminCreateUser()
        {
            Console.Clear();
            Console.WriteLine("---User Creation Tool---");
            Console.WriteLine("Please enter a name for user:");
            string name = Console.ReadLine() ?? "";
            Console.WriteLine("Please enter a password for user");
            string password = Console.ReadLine() ?? "";

            BankAccount bankAccount = new BankAccount(name, );
        }
    }
}
