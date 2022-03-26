using System;
using System.Text.RegularExpressions;

namespace P04.Star_Enigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string encryptedMassage = Console.ReadLine();
                string decryptedMassage = DecryptingMassage(encryptedMassage);
                string pattern = @"\@(?<planet>[A-Za-z]+).?\:(?<population>\d+).?\!(?<attackType>\w{1}).?\-\>(?<soldierCount>\d+)";

                Match match = Regex.Match(decryptedMassage, pattern);
               
                    string planetName = match.Groups["planet"].Value;
                    string population = match.Groups["population"].Value;
                    string attackType = match.Groups["attackType"].Value;
                    string soldierCount = match.Groups["soldierCount"].Value;
               

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
