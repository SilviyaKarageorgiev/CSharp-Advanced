using System;
using System.Collections.Generic;

namespace P04.MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string expression = Console.ReadLine();

            Stack<int> indeces = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    indeces.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int index = indeces.Pop();
                    string subStr = expression.Substring(index, i - index + 1);
                    Console.WriteLine(subStr);
                }
            }

        }
    }
}
