using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace P02._Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,int> participants = new Dictionary<string,int>();

            string patternName = @"(?<name>[A-Za-z]+)";
            string patternDistance = @"(?<distance>\d+)";

            string participtians = Console.ReadLine();
            string input = string.Empty;

            while((input = Console.ReadLine()) != "end of race")
            {
                Match participtian = Regex.Match(input, patternName);
                Match distance = Regex.Match(input, patternDistance);
                if (participtian.Success && distance.Success)
                {
                    string name = participtian.Groups["name"].Value;
                    string distanceTraveled = distance.Groups["distance"].Value;

                    if (participants.ContainsKey(name))
                    {
                        participants[participtian.Value]
                    }
                }
            }

        }
    }
}
