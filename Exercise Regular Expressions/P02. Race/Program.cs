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
                MatchCollection participtian = Regex.Matches(input, patternName);
                MatchCollection distance = Regex.Matches(input, patternDistance);

                    string name = new string(string.Join("", participtian));
                    string distanceTraveled = new string(string.Join("", distance));
                char[] ch = distanceTraveled.ToCharArray();
                    int distanceRan = 0;
                    for (int i = 0; i < ch.Length; i++)
                    {
                        distanceRan += ch[i]-48;
                    }

                    if (!participants.ContainsKey(name))
                    {
                        participants[name] = 0;
                    }
                    else
                    {
                        participants[name] += distanceRan;
                    }
                
            }

            var ordered = participants.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

        }
    }
}
