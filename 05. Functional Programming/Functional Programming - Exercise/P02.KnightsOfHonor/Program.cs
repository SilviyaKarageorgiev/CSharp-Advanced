using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.KnightsOfHonor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            //Action<string> printSir = name => Console.WriteLine("Sir " + name);
            //input.ForEach(printSir);

            Func<string, string> returnPlusSir = name => "Sir " + name;

            foreach (var item in input)
            {
                Console.WriteLine(returnPlusSir(item));
            }
        }
    }
}
