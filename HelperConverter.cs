using BankApp;
using BankApp.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BankApp
{
    internal static class HelperConverter
    {
        public static decimal HelperDecimal(string inputText, string inputValue)
        {
            Console.CursorVisible = true;
            bool helper = false;
            decimal number = 0;
            while (!helper)
            {
                Console.WriteLine(inputText);
                inputValue = Console.ReadLine() ?? "";
                helper = decimal.TryParse(inputValue, out number);
                if (!helper)
                {
                    Console.WriteLine("Could not parse the decimal. Please enter a valid input.");
                    break;
                }
            }
            return number;
        }
    }
}