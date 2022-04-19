using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string color = input[0];
                string[] clothes = input[1].Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                foreach (var item in clothes)
                {
                    if (!wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color].Add(item, 0);
                    }
                    wardrobe[color][item]++;
                }
            }

            string[] wantedClothe = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            string colorOfWantedClothe = wantedClothe[0];
            string typeOfWantedClothe = wantedClothe[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var (clothe, count) in color.Value)
                {
                    if (color.Key == colorOfWantedClothe && clothe
                        == typeOfWantedClothe)
                    {
                        Console.WriteLine($"* {clothe} - {count} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothe} - {count}");
                    }
                }
            }
        }
    }
}
