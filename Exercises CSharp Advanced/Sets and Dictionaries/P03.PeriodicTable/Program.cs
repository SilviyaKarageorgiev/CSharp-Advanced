using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> elements = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (string s in input)
                {
                    elements.Add(s);
                }
            }

            elements = elements.OrderBy(e => e).ToHashSet();

            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
