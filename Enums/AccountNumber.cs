using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Enums
{
    using System;

    internal class AccountNumber
    {
        //creates a random instance
        private static readonly Random random = new Random();

        public string Value { get; }

        private AccountNumber(string value)
        {
            Value = value;
        }

        public static AccountNumber Generate()
        {
            // sets a number between 1- 9999 for each block
          
            string Block() => random.Next(0, 10000).ToString("D4");
            string accountNumber = $"5300 {Block()} {Block()} {Block()} {Block()}";


            return new AccountNumber(accountNumber);
        }


        //overides to string to return the randomizd value instead of converting to string
        public override string ToString()
        {
            return Value;
        }




    }
}
