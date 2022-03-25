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
               
            }
            
        }
    }
}
