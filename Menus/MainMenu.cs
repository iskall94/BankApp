using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Menus
{
    internal static class MainMenu
    {
        public static List<string> GetMainMenuOptions { get; set; } = new List<string>
        {
            "Logga in?",
            "Logga in som admin?",
            "Avsluta"
        };

        public static void MainMenuStart()
        {
            while (true)
            {
                Menu.MenuOptions = GetMainMenuOptions;
                string title = AsciiTitle();
                Console.ResetColor();
                int menuChoice = Menu.Run(title);

                switch (menuChoice)
                {
                    case 0:
                        UserMenu.UserMenuStart();
                        //User.Login() Replace later!
                        break;
                    case 1:
                        AdminMenu.AdminMenuStart();
                        break;
                    case 2:
                        Console.WriteLine("Exiting the Bank App after 3 seconds...");
                        Thread.Sleep(3000);
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
        public static string AsciiTitle()
        {
            string asciiTitle = @"
PPPP   LL      AAA    CCCC EEEE  HH  HH   OOO   LL      DDDD   EEEE  RRRR   
P   P  LL     A   A  CC    EE    HH  HH  O   O  LL      D   D  EE    R   R  
PPPP   LL     AAAAA  CC    EEEE  HHHHHH  O   O  LL      D   D  EEEE  RRRR   
P      LL     A   A  CC    EE    HH  HH  O   O  LL      D   D  EE    R R    
P      LLLLLL A   A   CCCC EEEE  HH  HH   OOO   LLLLLL  DDDD   EEEE  R  RR  

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
