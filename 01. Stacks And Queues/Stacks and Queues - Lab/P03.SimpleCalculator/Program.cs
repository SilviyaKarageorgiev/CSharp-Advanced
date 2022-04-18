
using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] reversed = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();
            Stack<string> stack = new Stack<string>(reversed);

            while (stack.Count > 1)
            {
                int first = int.Parse(stack.Pop());
                string operat = stack.Pop();
                int second = int.Parse(stack.Pop());

                if (operat == "+")
                {
                    stack.Push((first + second).ToString());                    
                }
                else if (operat == "-")
                {
                    stack.Push((first - second).ToString());
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
