using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.CitiesByContinentAndCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> map = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string continent = input[0];
                string country = input[1];
                string town = input[2];

                if (!map.ContainsKey(continent))
                {
                    map[continent] = new Dictionary<string, List<string>>();
                }
                if (!map[continent].ContainsKey(country))
                {
                    map[continent].Add(country, new List<string>());
                }
                map[continent][country].Add(town);
            }

            foreach (var continent in map)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.Write($"  {country.Key} -> ");

                    Console.Write(string.Join(", ", country.Value));
                    Console.WriteLine();
                }
            }
        }
    }
}
