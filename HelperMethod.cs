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