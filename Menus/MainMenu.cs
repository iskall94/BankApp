using BankApp.Accounts;

namespace BankApp.Menus
{
    internal static class MainMenu
    {
        public static List<string> GetMainMenuOptions { get; set; } = new List<string>
        {
            "Login",
            "Login as Admin",
            "Exit the Bank App"
        };

        public static void MainMenuStart()
        {
            TransactionTimer.Start();
            while (true)
            {
                Menu.MenuOptions = GetMainMenuOptions;
                string title = AsciiTitle();
                Console.ResetColor();
                int menuChoice = Menu.Run(title);

                switch (menuChoice)
                {
                    case 0:
                        //UserMenu.UserMenuStart();
                        User.Login();
                        break;
                    case 1:
                        //AdminMenu.AdminMenuStart();
                        //EmailService.SendLoginCodeEmail();
                        Admin.AdminLogin();
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
 ________  ___  ___  ________  ________                         
|\   ____\|\  \|\  \|\   __  \|\   ____\                        
\ \  \___|\ \  \\\  \ \  \|\  \ \  \___|_                       
 \ \  \    \ \   __  \ \   __  \ \_____  \                      
  \ \  \____\ \  \ \  \ \  \ \  \|____|\  \                     
   \ \_______\ \__\ \__\ \__\ \__\____\_\  \                    
    \|_______|\|__|\|__|\|__|\|__|\_________\                   
                                 \|_________|                   
                                                                                 
 ________  ________  ________   ___  __            ________     
|\   __  \|\   __  \|\   ___  \|\  \|\  \         |\_____  \    
\ \  \|\ /\ \  \|\  \ \  \\ \  \ \  \/  /|_       \|____|\ /_   
 \ \   __  \ \   __  \ \  \\ \  \ \   ___  \            \|\  \  
  \ \  \|\  \ \  \ \  \ \  \\ \  \ \  \\ \  \          __\_\  \ 
   \ \_______\ \__\ \__\ \__\\ \__\ \__\\ \__\        |\_______\
    \|_______|\|__|\|__|\|__| \|__|\|__| \|__|        \|_______|
            ";
            return asciiTitle;
        }
    }
}
