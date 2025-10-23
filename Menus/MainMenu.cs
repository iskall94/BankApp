using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Menus
{
    internal class MainMenu : Menu
    {
        public MainMenu() : base(GetMainMenuOptions())
        {

        }
        public static List<string> GetMainMenuOptions()
        {
            return new List<string>
            {
            "Logga in?",
            "Logga in som admin?",
            "Avsluta"
            };
        }

        public void MainMenuStart()
        {
            while (true)
            {
                string title = "MAIN MENU BANK APP";

                int menuChoice = Run(title);

                switch (menuChoice)
                {
                    case 0:
                        //Logga in?
                        break;
                    case 1:
                        //Logga in som admin?
                        break;
                    case 2:
                        //Avsluta?
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
