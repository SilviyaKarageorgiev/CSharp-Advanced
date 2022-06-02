using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<int> numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Func<List<int>, int> getMinNumber = numbers => numbers.Min();
            Console.WriteLine(getMinNumber(numbers));

        }
    }
}
