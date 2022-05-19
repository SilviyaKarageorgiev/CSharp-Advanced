using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.MaximumAndMinimumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Stack<int> stack = new Stack<int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = input[0];

                if (command == "1")
                {
                    stack.Push(int.Parse(input[1]));
                }
                else if (command == "2" && stack.Any())
                {
                    stack.Pop();
                }
                else if (command == "3" && stack.Any())
                {
                    Console.WriteLine(stack.Max());
                }
                else if (command == "4" && stack.Any())
                {
                    Console.WriteLine(stack.Min());
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
