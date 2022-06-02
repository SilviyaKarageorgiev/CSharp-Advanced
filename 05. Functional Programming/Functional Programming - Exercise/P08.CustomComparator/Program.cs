using System;
using System.Collections.Generic;
using System.Linq;

namespace P08.CustomComparator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> evenList = new List<int>();
            List<int> oddList = new List<int>();

            Func<List<int>, List<int>> getEvenNumbers = list => list.Where(numbers => numbers % 2 == 0).ToList();
            Func<List<int>, List<int>> getOddNumbers = list => list.Where(numbers => numbers % 2 != 0).ToList();

            evenList = getEvenNumbers(numbers);
            oddList = getOddNumbers(numbers);

            List<int> list = new List<int>();

            foreach (var item in evenList)
            {
                list.Add(item);
            }

            foreach (var item in oddList)
            {
                list.Add(item);
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
