using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<int> numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            Func<List<int>, List<int>> add = list => list.Select(numbers => numbers += 1).ToList();
            Func<List<int>, List<int>> multiply = list => list.Select(numbers => numbers *= 2).ToList();
            Func<List<int>, List<int>> subtract = list => list.Select(numbers => numbers -= 1).ToList();
            Action<List<int>> print = list => Console.WriteLine(string.Join(" ", list));

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = add(numbers);
                        break;
                    case "multiply":
                        numbers = multiply(numbers);
                        break;
                    case "subtract":
                        numbers = subtract(numbers);
                        break;
                    case "print":
                        print(numbers);
                        break;                                           
                }
            }

        }
    }
}
