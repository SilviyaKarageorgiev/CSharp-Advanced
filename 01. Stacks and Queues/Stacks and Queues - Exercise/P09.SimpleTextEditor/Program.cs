using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P09.SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Stack<string> stack = new Stack<string>();
            StringBuilder sb = new StringBuilder();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = input[0];

                if (command == "1")
                {
                    string strToAdd = input[1];
                    stack.Push(sb.ToString());
                    
                    sb.Append(strToAdd);
                }

                else if (command == "2")
                {
                    int count = int.Parse(input[1]);
                    stack.Push(sb.ToString());

                    sb.Remove(sb.Length - count, count);                    
                }

                else if (command == "3")
                {
                    int numberOfElement = int.Parse(input[1]);

                    Console.WriteLine(sb[numberOfElement - 1]);
                }

                else if (command == "4")
                {
                    sb.Clear();
                    sb.Append(stack.Pop());
                }

            }

        }
    }
}
