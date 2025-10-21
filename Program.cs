using BankApp.Enums;

namespace BankApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var TEST = AccountNumber.Generate();

            Console.WriteLine(TEST);
        }
    }
}
