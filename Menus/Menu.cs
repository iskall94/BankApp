using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Menus
{
    internal class Menu
    {
        public List<string> MenuOptions { get; set; } = new List<string>();
        public int MenuIndex { get; set; }

        public Menu(List<string> menuOptions)
        {
            MenuOptions = menuOptions;
            MenuIndex = 0;
        }

        /// <summary>
        /// The core part of the menu, where it lets user choose an option in a list depending on its selected index.
        /// </summary>
        /// <param name="headerText">An optional title/header text for the menu</param>
        /// <returns>Returns an int (index of a list)</returns>
        public int Run(string headerText = "")
        {
            int menuOptionsCount = MenuOptions.Count;
            while (true)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine(headerText);
                DisplayMenu();
                ConsoleKeyInfo keyPress = Console.ReadKey(true);

                switch (keyPress.Key)
                {
                    case (ConsoleKey.UpArrow):
                        MenuIndex--;
                        if (MenuIndex < 0)
                        {
                            MenuIndex = 0;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        MenuIndex++;
                        if (MenuIndex > menuOptionsCount - 1)
                        {
                            MenuIndex = menuOptionsCount - 1;
                        }
                        break;
                    case ConsoleKey.Enter:
                        return MenuIndex;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// DisplayMenu basically prints out the menu, colors the text black/white, background white/black based on index selected.
        /// </summary>
        public void DisplayMenu()
        {
            for (int i = 0; i < MenuOptions.Count; i++)
            {
                string currentMenuOption = MenuOptions[i];

                if (i == MenuIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine($">{currentMenuOption}<");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine($" {currentMenuOption} ");
                }

                // A simple check to prevent the Console Terminal from messing up its colours.
                Console.ResetColor();
            }
        }
    }
}
