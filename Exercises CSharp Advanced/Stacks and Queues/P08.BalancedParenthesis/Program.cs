using System;
using System.Collections.Generic;

namespace P08.BalancedParenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(' || input[i] == '{' || input[i] == '[')
                {
                    stack.Push(input[i]);
                }
                else if (stack.Count > 0)
                {
                    if (stack.Peek() == '(' && input[i] == ')' || stack.Peek() == '{' && input[i] == '}' || stack.Peek() == '[' && input[i] == ']')
                    {
                        stack.Pop();
                    }
                }
                else
                {
                    Console.WriteLine("NO");
                    return;
                }
            }
            if (stack.Count == 0)
            {
                Console.WriteLine("YES");

            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
