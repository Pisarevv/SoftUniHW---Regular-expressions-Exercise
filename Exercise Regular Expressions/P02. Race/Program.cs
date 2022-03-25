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
            List<string> winners = new List<string>();
            string patternName = @"(?<name>[A-Za-z]+)";
            string patternDistance = @"(?<distance>\d+)";

            string[] inputParticiptians = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < inputParticiptians.Length; i++)
            {
                participants[inputParticiptians[i]] = 0;
            }
            
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

                    if (participants.ContainsKey(name))
                    {
                    participants[name] += distanceRan;
                    }                                     
                    
                    
                
            }

            //var ordered = participants.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            //winners = ordered.Select(x => x.Key).ToList();
            //winners.Reverse();




            //Console.WriteLine($"1st place: {winners[0]}");
            //Console.WriteLine($"2nd place: {winners[1]}");
            //Console.WriteLine($"3rd place: {winners[2]}");
            participants = participants.OrderByDescending(kvp => kvp.Value).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            Console.WriteLine($"1st place: {participants.Keys.ElementAt(0)}");
            Console.WriteLine($"2nd place: {participants.Keys.ElementAt(1)}");
            Console.WriteLine($"3rd place: {participants.Keys.ElementAt(2)}");


        }
    }
}
