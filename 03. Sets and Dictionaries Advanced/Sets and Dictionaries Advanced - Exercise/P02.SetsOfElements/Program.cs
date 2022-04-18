using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int[] lengthsOfSets = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int n = lengthsOfSets[0];
            int m = lengthsOfSets[1];

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < m; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            List<int> list = firstSet.Intersect(secondSet).ToList();

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
