using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P04.Star_Enigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string encryptedMassage = Console.ReadLine();
                string decryptedMassage = DecryptingMassage(encryptedMassage);
                string pattern = @"[^\@\-\!\:\>]*?\@(?<planet>[A-Za-z]+)[^\@\-\!\:\>]*?\:(?<population>\d+)[^\@\-\!\:\>]*?\!(?<attackType>\w+)\![^\@\-\!\:\>]*?\-\>(?<soldiersCount>\d+)[^\@\-\!\:\>]*?";

                Match match = Regex.Match(decryptedMassage, pattern);
                if (match.Success)
                {
                    string planetName = match.Groups["planet"].Value;
                    int population = int.Parse(match.Groups["population"].Value);
                    string attackType = match.Groups["attackType"].Value;
                    int soldierCount =int.Parse(match.Groups["soldiersCount"].Value);

                    if (attackType == "A")
                    {
                        attackedPlanets.Add(planetName);
                    }
                    else if (attackType == "D")
                    {
                        destroyedPlanets.Add(planetName);
                    }
                };

            }
            attackedPlanets.Sort();
            destroyedPlanets.Sort();
            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (var planet in attackedPlanets)
            {
                Console.WriteLine($"-> {planet}");
            }
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (var planet in destroyedPlanets)
            {
                Console.WriteLine($"-> {planet}");
            }

        }

        public static string DecryptingMassage (string input)
        {
            string encryptedMassage = input;
            string decryptedMassage = string.Empty;
            string pattern = @"[star]";

            MatchCollection matches = Regex.Matches(encryptedMassage, pattern,RegexOptions.IgnoreCase);
            int decriptionKey = matches.Count;

            char[] encryptedMassageCr = encryptedMassage.ToCharArray();
            for (int i = 0; i < encryptedMassageCr.Length; i++)
            {
                int currenctChar = encryptedMassageCr[i] - decriptionKey;
                char currChar = (char)currenctChar;
                decryptedMassage += currChar;
            }


            return decryptedMassage;

        }
    }

}
