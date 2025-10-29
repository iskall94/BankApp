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
        public static Dictionary<CurrencyType, decimal> AccountCurrency { get; set; } = new Dictionary<CurrencyType, decimal>()
        {
            {CurrencyType.SEK, 1.00m},
            {CurrencyType.EUR, 0.09m},
            {CurrencyType.USD, 0.11m},
            {CurrencyType.GBP, 0.08m},
        };

        public static void ChangeCurrencyValue(CurrencyType keyUpdate)
        {
            decimal newValue;
            newValue = HelperMethod.HelperDecimal($"Please change the value of {keyUpdate}:");
            AccountCurrency[keyUpdate] = newValue;
        }
    }

        
}
