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

            for (int i = 0; i < text.Length; i++)
            {
                if (!data.ContainsKey(text[i]))
                {
                    data[text[i]] = 0;
                }
                data[text[i]]++;
            }

            foreach (var item in data)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
