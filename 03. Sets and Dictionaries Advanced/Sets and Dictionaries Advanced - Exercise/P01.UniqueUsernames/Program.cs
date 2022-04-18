using System;
using System.Collections.Generic;

namespace P01.UniqueUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int n = int.Parse(Console.ReadLine());
            HashSet<string> set = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                set.Add(Console.ReadLine());
            }

            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
        }
    }
}
