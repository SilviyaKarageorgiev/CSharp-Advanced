using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.SortEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            List<int> numbers = new List<int>();
            numbers = input.Where(x => x % 2 == 0).OrderBy(x => x).ToList();

            Console.WriteLine(string.Join(", ", numbers));

        }
    }
}
