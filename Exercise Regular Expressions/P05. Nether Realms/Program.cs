using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace P05._Nether_Realms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Demon> demons = new List<Demon>();
            string namePatternForHealth = @"([^0-9\+\-\*\/\.\ \,])";
            string operatorPattern = @"(?<operators>[\*\/])";
            string damagePattern = @"(?<digits>(\-|\+|)*?\d+(\.\d+)*)";
            string[] demonInput = Console.ReadLine().Split(",",StringSplitOptions.RemoveEmptyEntries);
            

            

            for (int i = 0; i < demonInput.Length; i++)
            {
                string currentDeamon = demonInput[i].Trim();
                if (currentDeamon.Contains(','))
                {
                    int indexOfSplitter = currentDeamon.IndexOf(',');
                    currentDeamon = currentDeamon.Remove(indexOfSplitter);
                   

                }
                string demonName = string.Empty;
                double health = 0;
                double damagePoints = 0;


                MatchCollection matches = Regex.Matches(currentDeamon, namePatternForHealth);

                foreach (Match match in matches)
                {
                    string currentCh = match.Value;
                    demonName += currentCh;
                }

                char[] currName = demonName.ToCharArray();
                for (int j = 0; j < currName.Length; j++)
                {
                    health += currName[j];
                }

                MatchCollection damageMatches = Regex.Matches(currentDeamon, damagePattern);
                MatchCollection operatorMatches = Regex.Matches(currentDeamon, operatorPattern);
                foreach (Match match in damageMatches)
                {
                    string currentNumber = match.Value;
                    if (currentNumber.Contains("-"))
                    {
                        int indexOfDash = currentNumber.IndexOf('-');
                        currentNumber = currentNumber.Substring(indexOfDash+1,currentNumber.Length-1);
                        double damage = double.Parse(currentNumber);
                        damagePoints -= damage;

                    }
                    else
                    {
                        double damage = double.Parse(currentNumber);
                        damagePoints += damage;
                    }
                    
                }
                
                  foreach (Match matchOperator in operatorMatches)
                    {
                        string currentOperator = matchOperator.Value;

                        if (currentOperator == "*")
                        {
                            damagePoints = damagePoints * 2;
                        }
                        else if (currentOperator == "/")
                        {
                             damagePoints = damagePoints / 2;
                        }
                    }

               
                Demon newDemon = new Demon(currentDeamon, health, damagePoints);
                demons.Add(newDemon);


            }

            List<Demon> sortedDemons =  demons.OrderBy(x => x.Name).ToList();
            foreach (var demon in sortedDemons)
            {
                Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.DamagePoints:F2} damage ");
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
