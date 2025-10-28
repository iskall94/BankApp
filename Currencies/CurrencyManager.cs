using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Enums;

namespace BankApp.Currencies
{
    internal static class CurrencyManager
    {
        public static Dictionary<Enums.CurrencyType, decimal> AccountCurrency { get; set; } = new Dictionary<Enums.CurrencyType, decimal>()
        {
            {CurrencyType.SEK, 1.00m},
            {CurrencyType.EUR, 0.09m},
            {CurrencyType.USD, 0.11m},
            {CurrencyType.GBP, 0.08m},
        };

        public static void ChangeCurrencyValue(int selectedIndex)
        {

        }
    }

        
}
