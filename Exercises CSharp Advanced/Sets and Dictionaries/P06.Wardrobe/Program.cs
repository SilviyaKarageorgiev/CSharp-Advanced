using System;
using System.Collections.Generic;

namespace P06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> data = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string color = input[0];
                string[] clothes = input[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (!data.ContainsKey(color))
                {
                    data[color] = new Dictionary<string, int>();
                }
                foreach (var item in clothes)
                {
                    if (!data[color].ContainsKey(item))
                    {
                        data[color][item] = 0;
                    }
                    data[color][item]++;
                }
            }

            string[] wanted = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string colorOfWantedClothe = wanted[0];
            string clotheWanted = wanted[1];

            foreach (var color in data)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var value in color.Value)
                {
                    if (color.Key == colorOfWantedClothe && value.Key == clotheWanted)
                    {
                        Console.WriteLine($"* {value.Key} - {value.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {value.Key} - {value.Value}");
                    }
                }
            }
        }
    }
}
