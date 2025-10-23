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
                string title = AsciiTitle();

                int menuChoice = Run(title);

                switch (menuChoice)
                {
                    case 0:
                        //Logga in?
                        break;
                    case 1:
                        AdminMenu adminMenu = new AdminMenu();
                        adminMenu.AdminMenuStart();
                        break;
                    case 2:
                        //Avsluta?
                        break;
                    default:
                        break;
                }
            }
        }
        public static string AsciiTitle()
        {
            string asciiTitle = @"
PPPP   LL      AAA    CCCC  EEEE  HH  HH   OOO   LL      DDDD   EEEE  RRRR   
P   P  LL     A   A  CC    EE    HH  HH  O   O  LL      D   D  EE    R   R  
PPPP   LL     AAAAA  CC    EEEE  HHHHHH  O   O  LL      D   D  EEEE  RRRR   
P      LL     A   A  CC    EE    HH  HH  O   O  LL      D   D  EE    R R    
P      LLLLLL A   A   CCCC EEEE  HH  HH   OOO   LLLLLL DDDD   EEEE  R  RR  

NN  NN   AAA   MM  MM EEEE 
NNN NN  A   A  MMM MM EE   
NN NNN  AAAAA  MM M M EEEE 
NN  NN  A   A  MM   M EE   
NN  NN  A   A  MM   M EEEE
            ";
            Console.ForegroundColor = ConsoleColor.Green;
            return asciiTitle;
        }
    }
}
