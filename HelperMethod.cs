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
    internal static class HelperMethod
    {
        public static decimal HelperDecimal(string inputText)
        {
            Console.CursorVisible = true;
            string inputValue;
            while (true)
            {
                Console.WriteLine(inputText);
                inputValue = Console.ReadLine() ?? "";
                if (decimal.TryParse(inputValue, out decimal number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Could not parse the decimal. Please enter a valid input.");
                }
            }
        }
    }
}