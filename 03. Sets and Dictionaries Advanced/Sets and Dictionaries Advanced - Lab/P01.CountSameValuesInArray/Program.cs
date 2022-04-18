using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.CountSameValuesInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            double[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            Dictionary<double, int> data = new Dictionary<double, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!data.ContainsKey(input[i]))
                {
                    data[input[i]] = 0;
                }
                data[input[i]]++;
            }

            foreach (var item in data)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }

        }
    }
}
