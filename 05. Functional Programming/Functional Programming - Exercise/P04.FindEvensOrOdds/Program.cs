using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.FindEvensOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int start = int.Parse(input.Split()[0]);
            int end = int.Parse(input.Split()[1]);
            List<int> list = new List<int>();

            for (int i = start; i <= end; i++)
            {
                list.Add(i);
            }

            Predicate<int> predicate = null;
            string type = Console.ReadLine();

            if (type == "even")
            {
                predicate = number => number % 2 == 0;
            }
            else if (type == "odd")
            {
                predicate = number => number % 2 != 0;
            }

            Console.WriteLine(string.Join(" ", list.FindAll(predicate)));
        }
    }
}
