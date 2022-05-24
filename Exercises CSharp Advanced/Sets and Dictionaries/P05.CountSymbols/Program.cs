using System;
using System.Collections.Generic;

namespace P05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> data = new SortedDictionary<char, int>();
            string text = Console.ReadLine();

            foreach (char symbol in text)
            {
                if (!data.ContainsKey(symbol))
                {
                    data[symbol] = 0;
                }
                data[symbol]++;
            }

            foreach (var item in data)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
