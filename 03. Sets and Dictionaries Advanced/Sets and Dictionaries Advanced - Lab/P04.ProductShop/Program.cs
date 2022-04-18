using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            SortedDictionary<string, Dictionary<string, double>> dataShops = new SortedDictionary<string, Dictionary<string, double>>();

            string input;
            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] inputArgs = input.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string nameShop = inputArgs[0];
                string product = inputArgs[1];
                double price = double.Parse(inputArgs[2]);

                if (!dataShops.ContainsKey(nameShop))
                {
                    dataShops.Add(nameShop, new Dictionary<string, double>());
                }
                dataShops[nameShop].Add(product, price);
            }

            foreach (var shop in dataShops)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var item in shop.Value)
                {
                    Console.WriteLine($"Product: {item.Key}, Price: {item.Value}");
                }
            }

        }
    }
}
