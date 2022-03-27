using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P05._Nether_Realms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Demon> demons = new List<Demon>();
            string namePattern = @"(?<name>[A-Za-z]+)";
            string damagePattern = @"(?<digits>(\-|\+)*?\d+(\.\d+)*)|(?<operators>[\*\\]+)";
            string demonInput = Console.ReadLine();

            MatchCollection matches = Regex.Matches(demonInput, namePattern);

            foreach (Match match in matches)
            {
                string demonName = match.Groups["name"].Value;
            }

        }
    }

    public class Demon
    {
        public Demon(string name, double health, double damage)
        {
            this.Name = name;
            this.Health = health;
            this.DamagePoints = damage;
        }
        public string Name { get; set; }
        public double Health { get; set; }
        public double DamagePoints { get; set; }

    }
}
