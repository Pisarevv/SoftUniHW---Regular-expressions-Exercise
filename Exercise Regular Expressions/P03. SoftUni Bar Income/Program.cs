using System;
using System.Text.RegularExpressions;

namespace P03._SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string pattern = @"\%(?<name>[A-Z]{1}[a-z]+)\%[^\%$|.]*?\<(?<product>\w+)\>[^\%$|.]*?\|(?<count>\d+)\|[^\%$|.]*?(?<price>\d+(\.\d+)?)\$";
            decimal finalPrice = 0m;

            string input = string.Empty;

            while((input = Console.ReadLine()) != "end of shift")
            {
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    string customerName = match.Groups["name"].Value;
                    string product = match.Groups["product"].Value;
                    int quantity = int.Parse(match.Groups["count"].Value);
                    decimal price = decimal.Parse(match.Groups["price"].Value);
                    decimal currentSpend = price * quantity;
                    finalPrice += currentSpend;
                    Console.WriteLine($"{customerName}: {product} - {currentSpend:F2}");
                }
            }
            Console.WriteLine($"Total income: {finalPrice:F2}");
        }

    }
}
