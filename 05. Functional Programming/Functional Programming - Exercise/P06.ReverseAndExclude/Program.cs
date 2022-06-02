using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<int> inputList = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int n = int.Parse(Console.ReadLine());

            Predicate<int> predicate = number => number % n == 0;
            List<int> list = new List<int>();

            Stack<int> stack = new Stack<int>();
            List<int> reversedList = new List<int>();

            foreach (var item in inputList)
            {
                if (!predicate(item))
                {
                    stack.Push(item);
                }
            }

            while (stack.Any())
            {
                reversedList.Add(stack.Pop());
            }            
            Console.WriteLine(string.Join(" ", reversedList));
        }
    }
}
