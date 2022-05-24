using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int[] lengthOfSets = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = lengthOfSets[0];
            int m = lengthOfSets[1];

            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();
            HashSet<int> unique = new HashSet<int>();

            
            for (int i = 0; i < n; i++)
            {
                int element = int.Parse(Console.ReadLine());
                first.Add(element);                
            }

            for (int j = 0; j < m; j++)
            {
                int element = int.Parse(Console.ReadLine());
                second.Add(element);                
            }

            foreach (var item in first)
            {
                if (second.Contains(item))
                {
                    unique.Add(item);
                }
            }

            Console.WriteLine(string.Join(" ", unique));
        }
    }
}
