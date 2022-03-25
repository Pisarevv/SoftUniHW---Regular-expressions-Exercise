using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P01.Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<furnitureType>[A-Za-z]+)<<(?<price>\d+(.\d.?))!(?<quantity>\d+\b)";

            string input = string.Empty;
            decimal finalPrice = 0m;
            List<string> boughtFurniture = new List<string>();
            while ((input = Console.ReadLine()) != "Purchase")
            {
               Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    string furnitureType = match.Groups["furnitureType"].Value;
                    string price = match.Groups["price"].Value;
                    string quantity = match.Groups["quantity"].Value;
                    boughtFurniture.Add(furnitureType);
                    finalPrice += decimal.Parse(price) * int.Parse(quantity);
                }
            }

            Console.WriteLine("Bought furniture:");
            foreach (var item in boughtFurniture)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Total money spend: {finalPrice:F2}");
        }
    }
}
