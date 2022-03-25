using System;

namespace P03._SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<name>\%[A-Z]{1}[a-z]+)\%(([^\|\$\%\.]+)*?)<(?<product>[A-Za-z]+)>([^\|\$\%\.]+)*?\|(?<quantity>\d+)\|([^\|\$\%\.]+)*?(?<price>\d+(\.\d)*?)\$";
        }
    }
}
