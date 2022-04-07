using System;
using System.Collections.Generic;
using System.Data;

namespace P01.ReverseStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string text = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < text.Length; i++)
            {
                stack.Push(text[i]);
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }
    }
}
