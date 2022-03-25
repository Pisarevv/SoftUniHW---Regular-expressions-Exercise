using System;

namespace P01.Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<furnitureType>[A-Za-z]+)<<(?<price>\d+(.\d.?))!(?<quantity>\d+\b)";
        }
    }
}
