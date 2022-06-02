using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();         

            Predicate<string> predicate = name => name.Length <= n;

            foreach (var name in names)
            {
                if (predicate(name))
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
