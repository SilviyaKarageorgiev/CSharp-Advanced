using System;
using System.Collections.Generic;
using System.Linq;

namespace P08.ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            List<int> list = Enumerable.Range(1, n).ToList();

            foreach (var divider in dividers)
            {
                Func<int, bool> isDivisible = number => number % divider == 0;
                list = list.Where(isDivisible).ToList();
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
