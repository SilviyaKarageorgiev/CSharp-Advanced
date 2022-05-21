using System;
using System.Collections.Generic;
using System.Text;

namespace P09.SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder text = new StringBuilder();
            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                string command = Console.ReadLine();

                if (command.StartsWith("1"))
                {
                    stack.Push(text.ToString());
                    string texToAdd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1];
                    text.Append(texToAdd);
                }
                else if (command.StartsWith("2"))
                {
                    stack.Push(text.ToString());
                    int count = int.Parse(command.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);
                    text.Remove(text.Length - count, count);
                }
                else if (command.StartsWith("3"))
                {
                    int index = int.Parse(command.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);
                    Console.WriteLine(text[index - 1]);
                }
                else if (command.StartsWith("4"))
                {
                    text = new StringBuilder(stack.Pop());
                }
            }
        }
    }
}
